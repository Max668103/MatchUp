using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MatchUp.Utilities
{
    // Базовий клас для моделей, що реалізує INotifyPropertyChanged
    public class ViewModelBase : INotifyPropertyChanged
    {
        // Подія, яка викликається при зміні властивості
        public event PropertyChangedEventHandler PropertyChanged;

        // Метод для виклику події PropertyChanged
        public void OnPropertyChanged([CallerMemberName] string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
