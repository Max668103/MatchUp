using System;
using System.Windows.Input;

namespace Top.Utilities
{
    // Клас RelayCommand реалізує інтерфейс 
    public class RelayCommand : ICommand
    {
        // Делегати для виконання команди і перевірки можливості її виконання
        private readonly Action<object> _execute; // Делегат для виконання команди
        private readonly Func<object, bool> _canExecute; // Делегат для перевірки можливості виконання команди

        // Подія, що сповіщає про зміни у можливості виконання команди.
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        // Конструктор RelayCommand приймає делегати для виконання команди і перевірки.
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            // Якщо делегат виконання є null, кидаємо виняток
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute; // Зберігаємо делегат для перевірки
        }

        // Метод, що перевіряє, чи може команда бути виконана.
        public bool CanExecute(object parameter) => _canExecute == null || _canExecute(parameter);

        // Метод, що виконує команду.
        public void Execute(object parameter) => _execute(parameter);
    }

   
}

