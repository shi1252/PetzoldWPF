using System;
using System.Windows;
using System.Windows.Input;

namespace TypeYourTitle
{
    public class TypeYourTitle : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new TypeYourTitle());
        }

        public TypeYourTitle()
        {
            WindowStyle = WindowStyle.SingleBorderWindow;
            ResizeMode = ResizeMode.CanResizeWithGrip;
        }

        protected override void OnTextInput(TextCompositionEventArgs e)
        {
            base.OnTextInput(e);

            if (e.Text == "\b" && Title.Length > 0)
            {
                Title = Title.Substring(0, Title.Length - 1);
            }
            else if (e.Text.Length > 0 && !char.IsControl(e.Text[0]))
            {
                Title += e.Text;
            }
        }
    }
}
