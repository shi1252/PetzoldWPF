using System;
using System.Windows;

namespace InheritTheWin
{
    class InheritTheWin : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new InheritTheWin());
        }

        public InheritTheWin()
        {
            Title = "Inherit the Win";
            Width = 100 * Math.PI;
            Height = 100 * Math.E;

            Left = (SystemParameters.WorkArea.Width - Width) / 2 + SystemParameters.WorkArea.Left;
            Top = (SystemParameters.WorkArea.Height - Height) / 2 + SystemParameters.WorkArea.Top;
        }
    }
}
