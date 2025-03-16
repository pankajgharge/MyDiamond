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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using DesktopDemoProject.Model;
namespace DesktopDemoProject.View
{
    public partial class Login : Window
    {
        private List<string> imagePaths = new List<string>
{
                    "/Images/dimond.jpg",
                    "/Images/jwellary.png"
};
        private bool isPasswordVisible = false;

        private DispatcherTimer slideTimer;
        private int currentIndex = 0;

        public Login()
        {
            InitializeComponent();
            LoadImage();
            StartSlideshow();
        }

        private void LoadImage()
        {
            if (imagePaths.Count == 0) return;

            string currentImage = imagePaths[currentIndex];
            SlideshowImage1.Source = new BitmapImage(new Uri(currentImage, UriKind.Relative));

        }

        private void StartSlideshow()
        {
            slideTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(3)
            };
            slideTimer.Tick += (s, e) => ChangeImage(1);
            slideTimer.Start();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeImage(1);
        }

        private void PrevButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeImage(-1);
        }

        private void ChangeImage(int step)
        {
            double slideDistance = SlideshowImage1.ActualWidth; // Get image width
            TranslateTransform translateTransform = new TranslateTransform();
            SlideshowImage1.RenderTransform = translateTransform;

            // Determine slide direction
            double slideOutTo = step == 1 ? -slideDistance : slideDistance;
            double slideInFrom = step == 1 ? slideDistance : -slideDistance;

            // Slide out current image
            DoubleAnimation slideOut = new DoubleAnimation(0, slideOutTo, TimeSpan.FromMilliseconds(500));
            slideOut.Completed += (s, _) =>
            {
                currentIndex = (currentIndex + step + imagePaths.Count) % imagePaths.Count;
                LoadImage();

                // Position new image outside screen based on direction
                translateTransform.X = slideInFrom;

                // Slide in new image
                DoubleAnimation slideIn = new DoubleAnimation(slideInFrom, 0, TimeSpan.FromMilliseconds(500));
                translateTransform.BeginAnimation(TranslateTransform.XProperty, slideIn);
            };

            translateTransform.BeginAnimation(TranslateTransform.XProperty, slideOut);

            // Restart the timer
            slideTimer.Stop();
            slideTimer.Start();
        }



        //private void PrevButton_Click(object sender, RoutedEventArgs e)
        //{
        //    PrevImage();
        //}

        //private void NextButton_Click(object sender, RoutedEventArgs e)
        //{
        //    NextImage();
        //}

        //private void PrevImage()
        //{
        //    currentImageIndex = (currentImageIndex - 1 + imagePaths.Count) % imagePaths.Count;
        //    UpdateSlideshowImage(true);
        //}

        //private void NextImage()
        //{
        //    currentImageIndex = (currentImageIndex + 1) % imagePaths.Count;
        //    UpdateSlideshowImage(true);
        //}

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal; 
            }
            else
            {
                this.WindowState = WindowState.Maximized; 
            }
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void EmailTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && textBox.Text == "Email Address")
            {
                textBox.Text = "";
                textBox.Foreground = System.Windows.Media.Brushes.Black;
            }
        }

        private void EmailTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Email Address";
                textBox.Foreground = System.Windows.Media.Brushes.Gray;
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Dashbord dashbord = new Dashbord();
            dashbord.Show();
            Window.GetWindow(this)?.Close();
        }

        private void TogglePasswordVisibility_Click(object sender, RoutedEventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;

            if (isPasswordVisible)
            {
                PasswordTextBox.Text = PasswordBox.Password;
                PasswordTextBox.Visibility = Visibility.Visible;
                PasswordBox.Visibility = Visibility.Collapsed;
            }
            else
            {
               
                PasswordBox.Password = PasswordTextBox.Text;
                PasswordBox.Visibility = Visibility.Visible;
                PasswordTextBox.Visibility = Visibility.Collapsed;
                PasswordBox.Focus();
            }
        }

        private void PasswordTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            PasswordTextBox.Visibility = Visibility.Collapsed;
            PasswordBox.Visibility = Visibility.Visible;
            PasswordBox.Focus();

        }


        private void PasswordTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(PasswordBox.Password))
            {
                PasswordTextBox.Visibility = Visibility.Visible;
                PasswordBox.Visibility = Visibility.Collapsed;
            }

            
        }

        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Maximized;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            //var mainWindow = Application.Current.MainWindow as MainWindow;
            //if (mainWindow != null)
            //{
            //    mainWindow.ContentArea.Content = new PreviousUserControl();
            //}

            ///Back Button is Working ------------> 
            LoginView mainWindow = new LoginView();
            mainWindow.Show();

            // Close the current Login page window
            Window.GetWindow(this)?.Close();
        }

        //private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        //{
        //    if (!isPasswordVisible)
        //    {
        //        PasswordTextBox.Text = PasswordBox.Password;
        //    }
        //}
    }

    }

