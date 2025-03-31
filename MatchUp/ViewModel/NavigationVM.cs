using MatchUp.Model;
using MatchUp.Utilities;
using MatchUp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Top.Utilities;

namespace MatchUp.ViewModel
{
    public class NavigationVM : ViewModelBase
    {
        private object _currentView;
        public object CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public NavigationVM()
        {
            ShowHome();
        }

        public void ShowHome()
        {
            CurrentView = new StartUp();
        }

        public void ShowMain(Game game)
        {
            CurrentView = new Main(game);
        }
    }

}
