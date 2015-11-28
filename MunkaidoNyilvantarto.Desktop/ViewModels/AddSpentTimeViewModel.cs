using MunkaidoNyilvantarto.Desktop.Services;
using MunkaidoNyilvantarto.Desktop.Views;
using MunkaidoNyilvantarto.ViewModels.Issue;
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
    public class AddSpentTimeViewModel : INotifyPropertyChanged
    {
        private AddSpentTimeWindow currentWindow;

        private DataService service = new DataService();

        private DateTime _selectedDate;

        public DateTime SelectedDate { get { return _selectedDate; } set { _selectedDate = value; OnPropertyChanged(); } }

        private ObservableCollection<IssueListViewModel> _issues;

        public ObservableCollection<IssueListViewModel> Issues
        {
            get
            {
                if (_issues == null)
                {
                    _issues = new ObservableCollection<IssueListViewModel>();
                }

                return _issues;
            }
            set
            {
                _issues = value;
                OnPropertyChanged();
            }
        }

        private int _selectedIssue;

        public int SelectedIssue { get { return _selectedIssue; } set { _selectedIssue = value; OnPropertyChanged(); } }

        public double Hour { get; set; }

        public string Description { get; set; }

        private bool _isProgressing = false;

        public bool IsProgressing { get { return _isProgressing; } set { _isProgressing = value; OnPropertyChanged(); OnPropertyChanged("IsNotProgressing"); OnPropertyChanged("IsProgressingVisibility"); } }

        public bool IsNotProgressing { get { return !IsProgressing; } }

        public string IsProgressingVisibility { get { return IsProgressing ? "Visible" : "Hidden"; } }

        private string _errorMassage;

        public string ErrorMessage { get { return _errorMassage; } set { _errorMassage = value; OnPropertyChanged(); } }

        public AddSpentTimeViewModel(AddSpentTimeWindow currentWindow)
        {
            this.currentWindow = currentWindow;
            Init();
        }

        private async void Init()
        {
            SelectedDate = DateTime.Today;
            Issues = await service.GetIssuesForUser();
            SelectedIssue = Issues.Any() ? Issues.First().Id : 0;
        }

        private ICommand _addTimeCommand;

        public ICommand AddTimeCommand
        {
            get
            {
                if (_addTimeCommand == null)
                {
                    _addTimeCommand = new RelayCommand(AddTime);
                }

                return _addTimeCommand;
            }
        }

        private void AddTime(object o)
        {

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
