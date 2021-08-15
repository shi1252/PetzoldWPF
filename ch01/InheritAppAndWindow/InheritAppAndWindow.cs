using System;
using System.Windows;
using System.Windows.Input;

namespace InheritAppAndWindow
{
    class InheritAppAndWindow
    {
        [STAThread]
        public static void Main()
        {
            MyApplication app = new MyApplication();
            app.Run();
        }
    }
}
