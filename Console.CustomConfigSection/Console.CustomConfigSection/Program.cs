using Console.CustomConfigSection.Config;
using Nano.App.Console;
using Nano.Common.Config.Extensions;

NanoConsoleApplication
    .ConfigureApp(args)
    .ConfigureServices(x =>
    {
        x.AddNanoConfigSection<CustomOptions>(CustomOptions.SectionName, out _);
    })
    .Build()
    .Run();