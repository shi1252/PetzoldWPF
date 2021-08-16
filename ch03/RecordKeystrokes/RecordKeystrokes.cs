using System;
using System.Windows;
using System.Windows.Input;

namespace RecordKeystrokes
{
    public class RecordKeystrokes : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new RecordKeystrokes());
        }

        public RecordKeystrokes()
        {
            Title = "Record Keystrokes";
            Content = "";
        }

        protected override void OnTextInput(TextCompositionEventArgs e)
        {
            base.OnTextInput(e);

            string str = Content as string;
            if (e.Text == "\b")
            {
                if (str.Length > 0)
                {
                    str = str.Substring(0, str.Length - 1);
                }
            }
            else
            {
                str += e.Text;
            }
            Content = str;
        }
    }
}
