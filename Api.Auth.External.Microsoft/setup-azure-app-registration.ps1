# One-time setup - creates the Azure AD (Entra ID) app registration this lesson needs for
# Microsoft external login. Re-running it issues a new client secret and can create a duplicate
# app registration; it's not meant to be run repeatedly.
$env:APP_DISPLAY_NAME = "nano-api-auth-external-microsoft";
$env:REDIRECT_URI = "http://localhost/auth/callback";
$env:SECRET_DISPLAY_NAME = "nano-lesson-secret";

$env:TENANT_ID = az account show --query "tenantId" -o tsv;
$env:APP_ID = az ad app list --display-name $env:APP_DISPLAY_NAME --query "[0].appId" -o tsv;

az ad app create `
    --display-name $env:APP_DISPLAY_NAME `
    --sign-in-audience AzureADMyOrg `
    --web-redirect-uris $env:REDIRECT_URI;

$env:CLIENT_SECRET = az ad app credential reset `
    --id $env:APP_ID `
    --display-name $env:SECRET_DISPLAY_NAME `
    --years 2 `
    --query "password" -o tsv;
