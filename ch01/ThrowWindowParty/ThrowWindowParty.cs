using System;
using System.Windows;
using System.Windows.Input;

namespace ch01.ThrowWindowParty
{
    class ThrowWindowParty : Application
    {
        [STAThread]
        public static void Main()
        {
            ThrowWindowParty application = new ThrowWindowParty();
            application.Run();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            Window winMain = new Window();
            winMain.Title = "Main Window";
            winMain.MouseDown += WindowOnMouseDown;
            winMain.Show();

            for (int i=0;i<2;++i)
            {
                Window win = new Window();
                win.Title = $"Extra Window No.{i + 1}";
                win.Owner = winMain;
                win.Show();
            }
        }

        private void WindowOnMouseDown(object sender, MouseButtonEventArgs e)
        {
            Window win = new Window();
            win.Title = "Modal Dialog Box";
            win.ShowDialog();
        }
    }
}
