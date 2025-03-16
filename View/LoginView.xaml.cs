using DesktopDemoProject.Model;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace DesktopDemoProject.View
{

    public partial class LoginView : Window
    {
        private List<string> imagePaths = new List<string>
    {
        "/Images/dimond.jpg",
        "/Images/jwellary.png",
        "/Images/Fluid_Pink_Blue_Wallpaper_8k_10 (1).png"
    };

        private DispatcherTimer slideTimer;
        private int currentIndex = 0;

        public LoginView()
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

        //private void ChangeImage(int step)
        //{
        //    double slideDistance = SlideshowImage1.ActualWidth; // Get image width
        //    TranslateTransform translateTransform = new TranslateTransform();
        //    SlideshowImage1.RenderTransform = translateTransform;

        //    // Determine slide direction
        //    double slideOutTo = step == 1 ? -slideDistance : slideDistance;
        //    double slideInFrom = step == 1 ? slideDistance : -slideDistance;

        //    // Slide out current image
        //    DoubleAnimation slideOut = new DoubleAnimation(0, slideOutTo, TimeSpan.FromMilliseconds(300));
        //    slideOut.Completed += (s, _) =>
        //    {
        //        currentIndex = (currentIndex + step + imagePaths.Count) % imagePaths.Count;
        //        LoadImage();

        //        // Position new image outside screen based on direction
        //        translateTransform.X = slideInFrom;

        //        // Slide in new image
        //        DoubleAnimation slideIn = new DoubleAnimation(slideInFrom, 0, TimeSpan.FromMilliseconds(300));
        //        translateTransform.BeginAnimation(TranslateTransform.XProperty, slideIn);
        //    };

        //    translateTransform.BeginAnimation(TranslateTransform.XProperty, slideOut);

        //    // Restart the timer
        //    slideTimer.Stop();
        //    slideTimer.Start();
        //}


        private void ChangeImage(int step)
        {
            if (imagePaths.Count == 0) return;

            double slideDistance = SlideshowImage1.ActualWidth; // Get image width
            TranslateTransform oldTransform = new TranslateTransform();
            TranslateTransform newTransform = new TranslateTransform();

            // Ensure there is a second Image for transition
            SlideshowImage2.Visibility = Visibility.Visible;

            // Set the next image source
            SlideshowImage2.Source = new BitmapImage(new Uri(imagePaths[(currentIndex + step + imagePaths.Count) % imagePaths.Count], UriKind.Relative));

            // Position new image outside the screen (for sliding in)
            newTransform.X = step == 1 ? slideDistance : -slideDistance;
            SlideshowImage2.RenderTransform = newTransform;

            // Slide out current image
            DoubleAnimation slideOut = new DoubleAnimation(0, step == 1 ? -slideDistance : slideDistance, TimeSpan.FromMilliseconds(500));

            // Slide in new image
            DoubleAnimation slideIn = new DoubleAnimation(step == 1 ? slideDistance : -slideDistance, 0, TimeSpan.FromMilliseconds(500));
            slideIn.Completed += (s, _) =>
            {
                // Swap images after animation is done
                SlideshowImage1.Source = SlideshowImage2.Source;
                SlideshowImage2.Visibility = Visibility.Hidden;
                SlideshowImage2.Source = null;

                // Update index
                currentIndex = (currentIndex + step + imagePaths.Count) % imagePaths.Count;
            };

            // Apply animations
            (SlideshowImage1.RenderTransform as TranslateTransform)?.BeginAnimation(TranslateTransform.XProperty, slideOut);
            (SlideshowImage2.RenderTransform as TranslateTransform)?.BeginAnimation(TranslateTransform.XProperty, slideIn);

            // Restart slideshow timer
            slideTimer.Stop();
            slideTimer.Start();
        }


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

        private void btnEmployee_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAdmin_Click(object sender, RoutedEventArgs e)
        {

            Login loginPage = new Login();
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
