using System.ComponentModel;
using System.Windows;
using System.Linq;

namespace DesktopDemoProject.Base
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        private object _windowTag;
        public event PropertyChangedEventHandler PropertyChanged;
        private Command _dragMoveWindowCommand;

        protected void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public object WindowTag
        {
            get
            {
                return _windowTag;
            }
            set
            {
                _windowTag = value;
                RaisePropertyChanged("WindowTag");
            }
        }
               
        public Command DragMoveWindowCommand => _dragMoveWindowCommand ??
                       (_dragMoveWindowCommand = new Command(obj =>
                       {
                           try
                           {
                               var window = GetCurrentWindowByTag(WindowTag = 1);
                               window.DragMove();
                           }
                           catch (System.Exception ex)
                           {

                           }
                       }));

        public static Window GetCurrentWindowByTag(object tag) => (from Window w in Application.Current.Windows
                                                                   where w.Tag == tag
                                                                   select w)?.FirstOrDefault();

    }
    
}
