using System;
using System.Windows;
using System.Windows.Input;

namespace ch01.HandleAnEvent
{
    class HandleAnEvent
    {
        [STAThread]
        public static void Main()
        {
            Application application = new Application();

            Window window = new Window();
            window.Title = "Handle An Event";
            window.MouseDown += WindowOnMouseDown;

            application.Run(window);
        }

        private static void WindowOnMouseDown(object sender, MouseButtonEventArgs args)
        {
            Window window = sender as Window;
            string message = $"Window clicked with {args.ChangedButton} button at point {args.GetPosition(window)}";

            MessageBox.Show(message, window.Title);
        }
    }
}
