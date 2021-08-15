using System;
using System.Windows;

namespace ch01.SayHello
{
    class SayHello
    {
        [STAThread]
        public static void Main()
        {
            Window window = new Window();
            window.Title = "Say Hello";
            window.ShowDialog();

            //Application application = new Application();
            //application.Run();
        }
    }
}
