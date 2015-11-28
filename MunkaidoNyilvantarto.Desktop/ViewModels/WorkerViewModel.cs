using MunkaidoNyilvantarto.Desktop.Services;
using MunkaidoNyilvantarto.Desktop.Views;
using MunkaidoNyilvantarto.ViewModels.Issue;
using MunkaidoNyilvantarto.ViewModels.SpentTime;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MunkaidoNyilvantarto.Desktop.ViewModels
{
    public class WorkerViewModel : INotifyPropertyChanged
    {
        private DataService service = new DataService();

        private bool _isProgressing = false;

        public bool IsProgressing { get { return _isProgressing; } set { _isProgressing = value; OnPropertyChanged(); OnPropertyChanged("IsNotProgressing"); OnPropertyChanged("IsProgressingVisibility"); } }

        public bool IsNotProgressing { get { return !IsProgressing; } }

        public string IsProgressingVisibility { get { return IsProgressing ? "Visible" : "Hidden"; } }

        private string _errorMassage;

        public string ErrorMessage { get { return _errorMassage; } set { _errorMassage = value; OnPropertyChanged(); } }

        private ObservableCollection<SpentTimeDesktopListViewModel> _spentTimes;

        public ObservableCollection<SpentTimeDesktopListViewModel> SpentTimes
        {
            get
            {
                if (_spentTimes == null)
                {
                    _spentTimes = new ObservableCollection<SpentTimeDesktopListViewModel>();
                }

                return _spentTimes;
            }
            set
            {
                _spentTimes = value;
                OnPropertyChanged();
            }
        }


        public WorkerViewModel()
        {
            RefresTable(new object());
        }

        private ICommand _addTimeCommand;

        public ICommand AddTimeCommand
        {
            get
            {
                if(_addTimeCommand == null)
                {
                    _addTimeCommand = new RelayCommand(AddTime);
                }

                return _addTimeCommand;
            }
        }

        private void AddTime(object o)
        {
            var window = new AddSpentTimeWindow();
            window.Show();
        }

        private ICommand _refereshTableCommand;

        public ICommand RefreshTableCommand
        {
            get
            {
                if(_refereshTableCommand == null)
                {
                    _refereshTableCommand = new RelayCommand(RefresTable);
                }

                return _refereshTableCommand;
            }
        }

        private async void RefresTable(object o)
        {
            try
            {
                var result = await service.GetSpentTimesForUser();
                if(result.Succeeded)
                {
                    SpentTimes = new ObservableCollection<SpentTimeDesktopListViewModel>(result.Data);
                }
                else
                {
                    ErrorMessage = string.Join(", ", result.Errors.Select(k => k.Value));
                }
            }
            catch (Exception)
            {
                ErrorMessage = "Hiba történt az adatok lekérése közben";
            }
        }

        private void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
