using System.ComponentModel;
using System.Windows.Input;

namespace STPRGR
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _inputText;
        private string _memoryLabelText;
        private string _history;
        private string _info;

        public string InputText
        {
            get { return _inputText; }
            set
            {
                _inputText = value;
                OnPropertyChanged(nameof(InputText));
            }
        }

        public string MemoryLabelText
        {
            get { return _memoryLabelText; }
            set
            {
                _memoryLabelText = value;
                OnPropertyChanged(nameof(MemoryLabelText));
            }
        }

        public string History
        {
            get { return _history; }
            set
            {
                _history = value;
                OnPropertyChanged(nameof(History));
            }
        }

        public string Info
        {
            get { return _info; }
            set
            {
                _info = value;
                OnPropertyChanged(nameof(Info));
            }
        }

        public ICommand ExitCommand { get; }
        public ICommand HistoryCommand { get; }
        public ICommand InfoCommand { get; }
        public ICommand CalculateCommand { get; }

        public MainViewModel()
        {
            ExitCommand = new RelayCommand(Exit);
            HistoryCommand = new RelayCommand(ShowHistory);
            InfoCommand = new RelayCommand(ShowInfo);
            CalculateCommand = new RelayCommand(Calculate);

            Info = "Работа выполнена\nстудентом ИП-112 \nШебановым Андреем\nГеоргиевичем";
        }

        private void Exit(object parameter)
        {
//            STPRGR.Current.Shutdown();
        }

        private void ShowHistory(object parameter)
        {
            // Логика для отображения истории
            var historyWindow = new UniversalWindow(History);
            historyWindow.ShowDialog();
        }

        private void ShowInfo(object parameter)
        {
            // Логика для отображения справки
            var infoWindow = new UniversalWindow(Info);
            infoWindow.ShowDialog();
        }

        private void Calculate(object parameter)
        {
            // Логика вычислений
            History = InputText; // Пример: сохраняем в историю
            InputText = ""; // Очищаем поле ввода
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}