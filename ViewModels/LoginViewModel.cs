using DesktopDemoProject.View;
using System.Windows;
namespace DesktopDemoProject.Base
{
    public class LoginViewModel : ViewModelBase
    {
        private string email = "Email Address";
        private string password = " ";
        private Command loginCommand;
        private Command maxWindowCommand;
        private Command closeCommand;
        private Command backComamnd;
        private Command minimizeWindowCommand;

        public Command BackCommand
        {
            get
            {
                return backComamnd;
            }
        }
        public Command MinimizeWindowCommand
        {
            get
            {
                return minimizeWindowCommand;
            }
        }

        public Command LoginCommand
        {
            get
            {
                return loginCommand;
            }
        }
        public Command MaxWindowCommand
        {
            get
            {
                return maxWindowCommand;
            }
        }
        public Command CloseCommand
        {
            get
            {
                return closeCommand;
            }
        }

        public LoginViewModel()
        {
            loginCommand = new Command(ExecuteLoginCommand, CanExecuteLoginCommand);
            maxWindowCommand = new Command(ExecuteMaxWindowCommand, CanExecuteMaxWindowCommand);
            closeCommand = new Command(ExecuteCloseCommand, CanExecuteCloseCommand);
            minimizeWindowCommand = new Command(ExecuteMinimizeWindowCommand, CanExecuteMinimizeWindowCommand);
            backComamnd = new Command(ExecuteBackCommand, CanExecuteBackCommand);
        }

        public string Email
        {
            get => email;
            set
            {
                email = value;
                RaisePropertyChanged("Email");
            }
        }
        public string Password
        {
            get => password;
            set
            {
                password = value;
                RaisePropertyChanged("Password");
            }
        }

        public bool CanExecuteLoginCommand(object parameter)
        {
            return true;
        }

        public void ExecuteLoginCommand(object parameter)
        {
            Dashbord dashbord = new Dashbord();
            dashbord.Show();
            Window wnd = parameter as Window;
            wnd?.Close();
        }

        public bool CanExecuteCloseCommand(object parameter)
        {
            return true;
        }

        public void ExecuteCloseCommand(object parameter)
        {
            Application.Current.Shutdown();

        }

        public bool CanExecuteMaxWindowCommand(object parameter)
        {
            return true;
        }

        public void ExecuteMaxWindowCommand(object parameter)
        {
            Window wnd = parameter as Window;
            wnd.WindowState = WindowState.Maximized;
        }

        public bool CanExecuteMinimizeWindowCommand(object parameter)
        {
            return true;
        }
        public void ExecuteMinimizeWindowCommand(object parameter)
        {
            Window wnd = parameter as Window;
            if (wnd.WindowState == WindowState.Maximized)
            {
                wnd.WindowState = WindowState.Normal;
            }
            else
            {
                wnd.WindowState = WindowState.Maximized;
            }
        }

        public bool CanExecuteBackCommand(object parameter)
        {
            return true;
        }

        public void ExecuteBackCommand(object parameter)
        {
            Window wnd = parameter as Window;
            ///Back Button is Working ------------> 
            LaunchWindow mainWindow = new LaunchWindow();
            mainWindow.Show();

            // Close the current Login page window
            wnd.Close();
        }

    }
}
