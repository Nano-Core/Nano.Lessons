# Console.Storage.Azure

> _Nano Console application with azure storage._  
_All lessons are complete, self-contained examples that include build and deployment setup._

> ⚠️ _To run this solution, the [Nano.Library](https://github.com/Nano-Core/Nano.Library) repository must be checked out in the same root directory. 
Nano is referenced directly from source (not via NuGet packages) and is expected to be located in the .nano solution folder._

> ⚠️ Remember to set the docker-compose project as startup project, before running the solution in Visual Studio.

***

## Table of Contents
* [Summary](#summary)
* [Registration](#registration)
* [Configuration](#configuration)
* [Docker-compose](#docker-compose)
* [Kubernetes](#kubernetes)
* [GitHub Actions](#github-actions)

## Summary
This application builds on **[Console.Blank](https://github.com/Nano-Core/Nano.Lessons/tree/master/Console._Blank)**.  

This application demonstrates creating a file and saving it to a mapped file share.  
When running locally, files are **NOT** written to the Azure File Share. Instead, Docker mounts a local directory to simulate the file share.  
Files are saved in `.docker/bin/`.  

> 📖 Learn more about **[Nano.Storage.Azure](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.Storage.Azure/README#nanostorageazure)**.

## Registration
The following storage has been registered using `ConfigureServices(...)` in `program.cs`.  

```csharp
...
.ConfigureServices(x =>
{
    x.AddNanoStorage<AzureFileshareProvider>();
})
...
```

## Configuration
Configured the application with the necessary storage setup.  

```json
"Storage": {
  "ShareName": "nano-storage-azure"
}
```

## Docker Compose
Mapped the fileshare in `docker-compose.yml`.  

```yaml 
services:
  svc.accounts:
    volumes:
      - ./bin/nano-storage-azure:/mnt/nano-storage-azure
```

## Kubernetes
Added three new kubernetes templaets, the `storage-pv.yaml`, `storage-pvc.yaml`, and the `service-account.yaml`.   

```yaml
apiVersion: v1
kind: PersistentVolume
metadata:
  name: %SERVICE_NAME%-azurefile-pv-%VOLUME_NAME_SUFFIX%
spec:
  capacity:
    storage: %STORAGE_SIZE%
  accessModes:
    - ReadWriteMany
  persistentVolumeReclaimPolicy: Retain
  storageClassName: azurefile-static
  mountOptions:
    - dir_mode=0777
    - file_mode=0777
    - uid=0
    - gid=0
  claimRef:
    name: %SERVICE_NAME%-azurefile-pvc-%VOLUME_NAME_SUFFIX%
    namespace: %KUBERNETES_NAMESPACE%
  csi:
    driver: file.csi.azure.com
    volumeHandle: %AZURE_GROUP_STORAGE%#%STORAGE_ACCOUNT_NAME%#%STORAGE_SHARE_NAME%-%VOLUME_NAME_SUFFIX%
    volumeAttributes:
      shareName: %STORAGE_SHARE_NAME%
      storageAccount: %STORAGE_ACCOUNT_NAME%
      resourceGroup: %AZURE_GROUP_STORAGE%
      clientID: %IDENTITY_CLIENT_ID%
      mountWithWorkloadIdentityToken: "true"
```

```yaml
apiVersion: v1
kind: PersistentVolumeClaim
metadata:
  name: %SERVICE_NAME%-azurefile-pvc-%VOLUME_NAME_SUFFIX%
  namespace: %KUBERNETES_NAMESPACE%
spec:
  accessModes:
    - ReadWriteMany
  storageClassName: azurefile-static
  resources:
    requests:
      storage: %STORAGE_SIZE%
  volumeName: %SERVICE_NAME%-azurefile-pv-%VOLUME_NAME_SUFFIX%
```

Also, the `configmap.yaml` should have the share-name included.

```
data:
  Storage__ShareName: %STORAGE_SHARE_NAME%
```

Updated the `cronjob.yaml` mounting the volume.

```yaml
spec:
  jobTemplate:
    metadata:
      labels:
        azure.workload.identity/use: "true"
    spec:
      template:
        spec:
          serviceAccountName: %SERVICE_NAME%-service-account
          containers:
            volumeMounts:
            - name: %SERVICE_NAME%-volume
              mountPath: /mnt/%STORAGE_SHARE_NAME%
            - name: tmp
              mountPath: /tmp
          volumes:
          - name: %SERVICE_NAME%-volume
            persistentVolumeClaim:
              claimName: %SERVICE_NAME%-azurefile-pvc-%VOLUME_NAME_SUFFIX%
          - name: tmp
            emptyDir: {}
```

Notice the name suffix for `claimName`. The PersistentVolume (PV) and PersistentVolumeClaim (PVC) are created with a suffix to allow the managed identity used for authenticating with the 
Azure File Share to be changed without trying to replace existing immutable resources.

## GitHub Actions
Add the following environment variables to the `buid-and-deply.yml`.  

```yaml
env:
  AZURE_GROUP_BACKUP: ${{ vars.AZURE_RESOURCE_GROUP_BACKUP }}
  AZURE_GROUP_STORAGE: ${{ vars.AZURE_RESOURCE_GROUP_STORAGE }}
  STORAGE_SIZE: 1000
  STORAGE_SHARE_NAME: nano-storage-azure
```

Additionally, this step has been added to ensure the file share is created before the application is deployed.  

```yaml
- name: Create Fileshare
  shell: pwsh
  run: |
    $env:STORAGE_ACCOUNT_NAME = az storage account list -g $env:AZURE_GROUP_STORAGE --query [0].name -o tsv;

    $env:FILE_SHARE_EXISTS = az storage share-rm exists `
        -g $env:AZURE_GROUP_STORAGE `
        -n $env:STORAGE_SHARE_NAME `
        --storage-account $env:STORAGE_ACCOUNT_NAME `
        --query exists;

    if ($env:FILE_SHARE_EXISTS -eq "false")
    { 
        az storage share-rm create `
            -g $env:AZURE_GROUP_STORAGE `
            -n $env:STORAGE_SHARE_NAME `
            --storage-account $env:STORAGE_ACCOUNT_NAME `
            --access-tier TransactionOptimized `
            --quota $env:STORAGE_SIZE;
    }
    else
    {
        az storage share-rm update `
            -g $env:AZURE_GROUP_STORAGE `
            -n $env:STORAGE_SHARE_NAME `
            --storage-account $env:STORAGE_ACCOUNT_NAME `
            --access-tier TransactionOptimized `
            --quota $env:STORAGE_SIZE;
    }

    if ($LastExitCode -ne 0) 
    { 
        throw "error";
    };

    $env:BACKUP_VAULT_NAME = az backup vault list -g $env:AZURE_GROUP_BACKUP --query [0].name -o tsv;

    az backup protection enable-for-azurefileshare `
        -g $env:AZURE_GROUP_BACKUP `
        -v $env:BACKUP_VAULT_NAME `
        -p $env:STORAGE_ACCOUNT_NAME-fileshare-backup-policy `
        --storage-account $env:STORAGE_ACCOUNT_NAME `
        --azure-file-share $env:STORAGE_SHARE_NAME;

    if ($LastExitCode -ne 0) 
    { 
        throw "error";
    };
```

...and includes a step to create a managed identity and federated credentials for authenticating with the storage account.  

```
- name: Managed Identity & Federated Credentials
  shell: pwsh
  run: |
    $env:IDENTITY_NAME = $env:SERVICE_NAME + "-identity";
    $env:IDENTITY_PRINCIPAL_ID = az identity show -g $env:AZURE_GROUP_KUBERNETES -n $env:IDENTITY_NAME --query principalId -o tsv;
    $env:KUBERNETES_ISSUER_URL = az aks list -g $env:AZURE_GROUP_KUBERNETES --query [0].['oidcIssuerProfile.issuerUrl'] -o tsv;
    $env:STORAGE_ACCOUNT_ID = az storage account list -g $env:AZURE_GROUP_STORAGE --query [0].id -o tsv;

    if (-not $env:IDENTITY_PRINCIPAL_ID)
    {
        az identity create `
            -g $env:AZURE_GROUP_KUBERNETES `
            -n $env:IDENTITY_NAME;

        if ($LastExitCode -ne 0)
        {
            throw "error";
        };

        $env:IDENTITY_PRINCIPAL_ID = az identity show -g $env:AZURE_GROUP_KUBERNETES -n $env:IDENTITY_NAME --query principalId -o tsv;
    }

    az role assignment create `
        --assignee-object-id $env:IDENTITY_PRINCIPAL_ID `
        --assignee-principal-type ServicePrincipal `
        --role "Storage File Data SMB MI Admin" `
        --scope $env:STORAGE_ACCOUNT_ID

    if ($LastExitCode -ne 0)
    {
        throw "error";
    };

    az identity federated-credential create `
        --name $env:SERVICE_NAME-credentials `
        --resource-group $env:AZURE_GROUP_KUBERNETES `
        --identity-name $env:IDENTITY_NAME `
        --issuer $env:KUBERNETES_ISSUER_URL `
        --subject "system:serviceaccount:${env:KUBERNETES_NAMESPACE}:${env:SERVICE_NAME}-service-account" `
        --audience api://AzureADTokenExchange;

    if ($LastExitCode -ne 0)
    {
        throw "error";
    };

    echo "IDENTITY_NAME=$env:IDENTITY_NAME" >> $env:GITHUB_ENV;
```

Last, during the Kubernetes deployment step, before any resources are applied, environmental variables required for the new `stoerage-pv.yaml` and `stoerage-pvc.yaml` must be set.

```powershell
$env:IDENTITY_CLIENT_ID = az identity show -g $env:AZURE_GROUP_KUBERNETES -n $env:IDENTITY_NAME --query clientId -o tsv;
$env:VOLUME_NAME_SUFFIX = $env:IDENTITY_CLIENT_ID.Substring(0, 5);
```

The deployment commands have been updated to apply the new Kubernetes storage templates.  
