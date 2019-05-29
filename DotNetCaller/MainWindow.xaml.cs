using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tick42;
using Tick42.AppManager;

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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.ReuseAppWithUrl("http://localhost:22080/getting-started/");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.ReuseAppWithUrl("http://localhost:22080/client-list-portfolio-contact/dist/#/clientlist");
        }

        private IAppManagerApplication GetWebManagerHost()
        {
            return this.glue.AppManager.Applications.First((app) =>
            {
                return app.Name == "WebAppHost";
            });
        }

        private void ReuseAppWithUrl(string url)
        {
            var appDef = this.GetWebManagerHost();
            var service = this.glue.Interop.CreateServiceProxy<IContextSetter>();
            var app = appDef.Instances.FirstOrDefault();
            if (app == null)
            {
                this.StartAppWithUrl(url);
            }
            else
            {
                service.Execute("updateContext", app.Id, new Dictionary<string, string> { { "url", url } });
            }
        }

        private void StartAppWithUrl(string url)
        {
            var webAppHostApp = this.GetWebManagerHost();

            var webAppHostContext = AppManagerContext.CreateNew();
            webAppHostContext.Set("url", url);
            webAppHostApp.Start(webAppHostContext);
        }
    }
}
