using System;
using System.Windows;
using System.Windows.Input;

namespace InheritAppAndWindow
{
    public class MyWindow : Window
    {
        public MyWindow()
        {
            Title = "Inherit App & Window";
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);

            string message = $"Window clicked with {e.ChangedButton} button at point {e.GetPosition(this)}";
            MessageBox.Show(message, Title);
        }
    }
}
