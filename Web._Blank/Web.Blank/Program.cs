using Nano.App.Web;
using Web.Blank;

NanoWebApplication
    .ConfigureApp()
    .ConfigureServices(_ =>
    {
        // Blank
    })
    .Build<App>()
    .Run();