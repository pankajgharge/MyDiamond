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
using System.Windows.Shapes;

namespace DesktopDemoProject.View
{
    /// <summary>
    /// Interaction logic for Dashbord.xaml
    /// </summary>
    public partial class Dashbord : Window
    {
        public Dashbord()
        {
            InitializeComponent();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new HomePage());
        }

        private void ManageStaff_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ManageStaff());
        }

        private void Customers_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CustomersPage());
        }

        private void TermsConditions_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new TermsConditionsPage());
        }


        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Logging out...");
            //Application.Current.Shutdown();
            MessageBox.Show("Logging out...");
            LoginView loginPage = new LoginView();
            loginPage.Show();
            Window.GetWindow(this)?.Close();
        }

        private void Maximize_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
                WindowState = WindowState.Normal;
            else
                WindowState = WindowState.Maximized;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
