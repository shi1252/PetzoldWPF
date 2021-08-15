using System;
using System.Windows;
using System.Windows.Input;

namespace InheritAppAndWindow
{
    class MyApplication : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MyWindow win = new MyWindow();
            win.Show();
        }
    }
}
