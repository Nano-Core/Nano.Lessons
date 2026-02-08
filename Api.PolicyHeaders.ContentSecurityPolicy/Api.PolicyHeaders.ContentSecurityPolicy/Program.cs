using Nano.App.Api;

// BUG: We need logging here because otherwise we don't see the logged csp-report

NanoApiApplication
    .ConfigureApp()
    .ConfigureServices(_ =>
    {
        // Blank
    })
    .Build()
    .Run();
