using Api.CustomConfigSection.Config;
using Nano.App.Api;
using Nano.Common.Config.Extensions;

NanoApiApplication
    .ConfigureApp()
    .ConfigureServices(x =>
    {
        x.AddNanoConfigSection<CustomOptions>(CustomOptions.SectionName, out _);
    })
    .Build()
    .Run();
