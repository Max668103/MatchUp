using MatchUp.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Top.Utilities;

namespace MatchUp.ViewModel
{
    class PauseModeVM : ViewModelBase
    {
        // Команди для збереження та скасування дій
        public ICommand CancelCommand { get; set; }
        public ICommand LeaveCommand { get; set; }

        public PauseModeVM()
        {
            CancelCommand = new RelayCommand(Cancel, CanCancel);
            LeaveCommand = new RelayCommand(Leave, CanCancel);
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

        private void Leave(object obj)
        {
            if (obj is Window window)
            {
                window.Close();
            }

            NavigationService.Navigation.ShowHome();
        }

    }
}
