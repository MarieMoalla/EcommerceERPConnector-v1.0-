using EcommerceERPConnector_V1._0_.Services;
using EcommerceERPConnector_V1._0_.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;

namespace EcommerceERPConnector_V1._0_.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        IAuthenticationService _authServ;

        public LoginView()
        {
            InitializeComponent();
            _authServ = new AuthenticationService();
        }

        private void authenticate_Click(object sender, RoutedEventArgs e)
        {
            ////real data
            //string endpoint1 = ecommerceUrl.Text, userName1 = ecommerceEmail.Text, password1 = ecommercePassword.Text, username1Format = ecommerceEmailFormt.Text, password1Format = ecommercePasswordFormat.Text;
            //string endpoint2 = erpUrl.Text, userName2 = erpEmail.Text, password2 = erpPassword.Text, username2Format = erpEmailFormat.Text, password2Format = erpPasswordFormat.Text;
            
            //test data
            string endpoint1 = "https://api.escuelajs.co/api/v1/auth/login", userName1 = "john@mail.com", password1 = "changeme", username1Format = ecommerceEmailFormt.Text, password1Format = ecommercePasswordFormat.Text;
            string endpoint2 = "https://dummyjson.com/auth/login", userName2 = "kminchelle", password2 = "0lelplR", username2Format = erpEmailFormat.Text, password2Format = erpPasswordFormat.Text;

            string msg1 = this._authServ.AuthenticateUser(false, endpoint1, userName1, password1, username1Format, password1Format);
            string msg2 = this._authServ.AuthenticateUser(true, endpoint2, userName2, password2, username2Format, password2Format);
            if (msg1 == "Connected!" && msg2 == "Connected!") displayDialog(msg1);
            else displayDialog("E-Commerce Site:" + msg1 + " | ERP: " + msg2);
        }

        #region Display Dialog
        public void displayDialog(string msg)
        {
            try
            {
                InfoPopup popup = new InfoPopup();
                if (msg == "Connected!")
                {
                    popup.type.Content = "Results";
                    popup.content.Text = "Connection Result :" + msg;
                    this.Hide();
                    Views.MainView mainView = new Views.MainView();
                    mainView.Show();
                }
                else
                {
                    popup.type.Content = "Error";
                    popup.content.Text = "Connection Result :" + msg;
                }
                popup.Show();
            }
            catch (Exception e) { Debug.WriteLine(e.Message); }
        }
        #endregion

        #region Events
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) DragMove();
        }
        #endregion
    }
}
