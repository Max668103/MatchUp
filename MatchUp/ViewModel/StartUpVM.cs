using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using MatchUp.Utilities;
using MatchUp.View;
using Top.Utilities;

namespace MatchUp.ViewModel
{
    class StartUpVM : ViewModelBase
    {

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public ICommand StartGameCommand { get; private set; }
        public ICommand ExitCommand { get; private set; }
        public ICommand ScoresCommand { get; private set; }

        public StartUpVM()
        {
            // Ініціалізація команд
            StartGameCommand = new RelayCommand(StartGame, CanShowWindow);
            ExitCommand = new RelayCommand(Exit, CanShowWindow);
            ScoresCommand = new RelayCommand(Scores, CanShowWindow);

            if (NavigationService.Name != "")
            {
                Name = NavigationService.Name;
            }
        }

        private bool CanShowWindow(object arg)
        {
            return true;
        }

        // Відкриває вікно фільтрації кнопок.
        private void StartGame(object obj)
        {
            try
            {
                // Check if name is null or empty
                if (string.IsNullOrEmpty(Name))
                {
                    throw new Exception("Name cannot be empty");
                }

                // Check if name is too long
                if (Name.Length > 12)
                {
                    Name = "";
                    throw new Exception("Name is too long");
                }

                // Check if name contains only letters
                if (!Name.All(char.IsLetter))
                {
                    Name = "";
                    throw new Exception("Name should contain only letters");
                }
            }
            catch(Exception ex)
            {
                ErrorHandling.ShowErrorMessage(ex);
                return;
            }

            Name = char.ToUpper(Name[0]) + Name.Substring(1);
            SelectMode selectMode = new SelectMode(Name);
            selectMode.ShowDialog();
        }

        private void Exit(object obj)
        {
            Application.Current.Shutdown();
        }

        private void Scores(object obj)
        {
            Savings saving = new Savings();
            saving.ShowDialog();
        }
    }
}
