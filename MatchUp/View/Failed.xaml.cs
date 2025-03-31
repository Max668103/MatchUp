using MatchUp.Model;
using MatchUp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MatchUp.View
{
    /// <summary>
    /// Interaction logic for Failed.xaml
    /// </summary>
    public partial class Failed : Window
    {
        public Failed(Game game)
        {
            InitializeComponent();
            FailedVM failed = new FailedVM(game);
            this.DataContext = failed;
        }
    }
}
