using DesktopDemoProject.Base;
using System.Windows;
using System.Windows.Input;


namespace DesktopDemoProject.View
{
    public partial class LaunchWindow : Window
    { 

        public LaunchWindow()
        {
            InitializeComponent();           
        }
           

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal; 
            }
            else
            {
                WindowState = WindowState.Maximized; 
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnEmployee_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAdmin_Click(object sender, RoutedEventArgs e)
        {
            Login loginPage = new Login();
            loginPage.DataContext = new LoginViewModel();
            loginPage.Show();
            Window.GetWindow(this)?.Close();
        }

        private void btnDelivery_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Maximized;
        }


    }
}
