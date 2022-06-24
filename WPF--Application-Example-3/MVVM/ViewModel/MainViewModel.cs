using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using WPF___Application_Example_3.Core;
using WPF__Application_Example_3;

namespace WPF___Application_Example_3.MVVM.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {

        public MainViewModel()
        {
            // Set Startup Page
            SelectedView = new StartupViewModel();
        }


        // Current View on Content Control //
        private object _selectedView;
        public object SelectedView
        {
            get => _selectedView;
            set 
            { 
                _selectedView = value;
                OnPropertyChanged("SelectedView");
            }
        }

        // Change Views Command //
        private ICommand _switchViewsCommand;
        public ICommand SwitchViewsCommand
        {
            get
            {
                if (_switchViewsCommand == null)
                {
                    _switchViewsCommand = new RelayCommand(o => SwitchViewsMethod(o));
                }
                return _switchViewsCommand;
            }
        }

        // Change Views Method //
        public void SwitchViewsMethod(object obj)
        {

            switch (obj)
            {
                case "Home":
                    SelectedView = new HomeViewModel();
                    break;
                case "Music":
                    SelectedView = new MusicViewModel();
                    break;
                case "Movies":
                    SelectedView = new MovieViewModel();
                    break;
                case "Search":
                    SelectedView = new SearchViewModel();
                    break;
                case "Folders":
                    SelectedView = new FolderViewModel();
                    break;
                case "History":
                    SelectedView = new HistoryViewModel();
                    break;
                case "Settings":
                    SelectedView = new SettingsViewModel();
                    break;
                case "About":
                    SelectedView = new AboutViewModel();
                    break;
                case "Exit":
                    SelectedView = new ExitViewModel();
                    break;

                default:
                    SelectedView = new StartupViewModel();
                    break;
            }
        }


        // Close App Method //
        public void CloseApp()
        {
            MainWindow win = Window.GetWindow(App.Current.MainWindow) as MainWindow;
            win.Close();
        }

        // Close App Command //
        private ICommand _closeCommand;
        public ICommand CloseAppCommand
        {
            get
            {
                if (_closeCommand == null)
                {
                    _closeCommand = new RelayCommand(o => CloseApp());
                }
                return _closeCommand;
            }
        }

        // Maximize App Method //
        private void MaxBtn_Click()
        {
            MainWindow win = Window.GetWindow(App.Current.MainWindow) as MainWindow;
            if (win.WindowState == WindowState.Normal)
            {
                win.WindowState = WindowState.Maximized;
            }
            else
            {
                if (win.WindowState == WindowState.Maximized)
                {
                    win.WindowState = WindowState.Normal;
                }
            }
        }

        // Maximize App Command //
        private ICommand _maxBtnCommand;
        public ICommand MaxBtnCommand
        {
            get
            {
                if (_maxBtnCommand == null)
                {
                    _maxBtnCommand = new RelayCommand(o => MaxBtn_Click());
                }
                return _maxBtnCommand;
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
