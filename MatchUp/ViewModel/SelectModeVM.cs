using MatchUp.Utilities;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Top.Utilities;
using MatchUp.Model;
using System.Windows.Controls;

namespace MatchUp.ViewModel
{
    class SelectModeVM : ViewModelBase
    {
        private int _selectedCardCount;
        public int SelectedCardCount
        {
            get { return _selectedCardCount; }
            set
            {
                _selectedCardCount = value;
                OnPropertyChanged(nameof(SelectedCardCount)); // Сповіщаємо UI про зміну
            }
        }

        private bool _isTimeLimitEnabled;
        public bool IsTimeLimitEnabled
        {
            get { return _isTimeLimitEnabled; }
            set
            {
                if (_isTimeLimitEnabled != value)
                {
                    _isTimeLimitEnabled = value;
                    OnPropertyChanged(nameof(IsTimeLimitEnabled));  // Оновлюємо UI
                }
            }
        }


        // Команди для збереження та скасування дій
        public ICommand CancelCommand { get; set; }
        public ICommand ContinueCommand { get; set; }

        // Доступні опції для активності кнопки
        public List<int> Options { get; set; }
        private string Name;


        public SelectModeVM(string name)
        {
            CancelCommand = new RelayCommand(Cancel, CanCancel);
            ContinueCommand = new RelayCommand(Continue, CanCancel);

            Options = new List<int> { 10, 20, 30 };
            IsTimeLimitEnabled = false;
            Name = name;
        }

        // Метод перевірки можливості скасування дії (завжди true)
        private bool CanCancel(object arg) => true;

        // Метод для скасування дії та закриття вікна
        private void Cancel(object obj)
        {
            if (obj is Window window)
            {
                window.Close();
            }
        }

        private void Continue(object obj)
        {
            if (obj is Window window)
            {
                window.Close();
            }

            if (SelectedCardCount > 0)
            {
                NavigationService.Name = Name;
                Game game = new Game(SelectedCardCount, IsTimeLimitEnabled, Name);
                NavigationService.Navigation.ShowMain(game);
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть кількість карток.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

    }
}
