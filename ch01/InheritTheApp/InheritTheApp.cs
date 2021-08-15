using System;
using System.Windows;
using System.Windows.Input;

namespace ch01.InheritTheApp
{
    class InheritTheApp : Application
    {
        [STAThread]
        public static void Main()
        {
            InheritTheApp application = new InheritTheApp();
            application.Run();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Window window = new Window();
            window.Title = "Inherit the App";
            window.Show();
        }

        protected override void OnSessionEnding(SessionEndingCancelEventArgs e)
        {
            base.OnSessionEnding(e);

            MessageBoxResult result = MessageBox.Show("Do you want to save your data?",
                MainWindow.Title,
                MessageBoxButton.YesNoCancel,
                MessageBoxImage.Question,
                MessageBoxResult.Yes);

            e.Cancel = (result == MessageBoxResult.Cancel);
        }
    }
}
