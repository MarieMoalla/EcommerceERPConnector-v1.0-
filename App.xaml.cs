using EcommerceERPConnector_V1._0_.Services;
using EcommerceERPConnector_V1._0_.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace EcommerceERPConnector_V1._0_
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            IAuthenticationService auth = new AuthenticationService();
            if (!auth.IsAuthenticated())
            {
                LoginView login = new LoginView();
                login.Show();
            }
            else
            {
                MainView main = new MainView();
                main.Show();
            }
        }
    }
}
