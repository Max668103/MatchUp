using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MatchUp.Utilities
{
    class ErrorHandling
    {
        private static readonly string LogFilePath = Path.Combine(Directory.GetCurrentDirectory(), "error_log.txt");

        public static void LogError(Exception ex)
        {
            string errorMessage = $"{DateTime.Now}: {ex.Message}\n{ex.StackTrace}\n";
            File.AppendAllText(LogFilePath, errorMessage);
        }

        public static void ShowErrorMessage(Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void HandleError(Exception ex)
        {
            LogError(ex);          
            ShowErrorMessage(ex);
        }
    }
}
