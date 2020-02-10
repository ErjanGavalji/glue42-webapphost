using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Tick42;
using Tick42.AppManager;
using Tick42.Windows;

namespace DotNetCaller
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Glue42 glue;

        public MainWindow()
        {
            InitializeComponent();

            this.glue = new Glue42();
            this.glue.Initialize("DotNetWindowLoadCaller", useContexts: true);

            // Initialize Window Stickiness and read from config:
            var swOptions = this.glue.GlueWindows?.GetStartupOptions() ?? new GlueWindowOptions();
            this.glue.GlueWindows?.RegisterWindow(this, swOptions);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //this.ReuseAppWithURL("http://localhost:22080/getting-started/");
            this.StartAppWithURL("http://localhost:22080/getting-started/");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //this.ReuseAppWithURL("http://localhost:22080/client-list-portfolio-contact/dist/#/clientlist");
            this.StartAppWithURL("http://localhost:22080/client-list-portfolio-contact/dist/#/clientlist");
        }

        private IAppManagerApplication GetWebManagerHost()
        {
            return this.glue.AppManager.Applications.First((app) =>
            {
                return app.Name == "WebAppHost";
            });
        }

        private void ReuseAppWithURL(string url)
        {
            var appDef = this.GetWebManagerHost();
            var service = this.glue.Interop.CreateServiceProxy<IContextSetter>();
            var app = appDef.Instances.FirstOrDefault();
            if (app == null)
            {
                this.StartAppWithURL(url);
            }
            else
            {
                service.Execute("updateContext", app.Id, new Dictionary<string, string> { { "url", url } });
            }
        }

        private void StartAppWithURL(string url)
        {
            var webAppHostApp = this.GetWebManagerHost();

            var webAppHostContext = AppManagerContext.CreateNew();
            webAppHostContext.Set("url", url);
            webAppHostApp.Start(webAppHostContext);
        }
    }
}
