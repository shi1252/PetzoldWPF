using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace NavigateTheWeb
{
    class UriDialog : Window
    {
        TextBox textBox;

        public UriDialog()
        {
            Title = "Enter a URI";
            ShowInTaskbar = false;
            SizeToContent = SizeToContent.WidthAndHeight;
            WindowStyle = WindowStyle.ToolWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;

            textBox = new TextBox();
            textBox.Margin = new Thickness(48);
            Content = textBox;

            textBox.Focus();
        }

        public string Text
        {
            set
            {
                textBox.Text = value;
                textBox.SelectionStart = textBox.Text.Length;
            }
            get
            {
                return textBox.Text;
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.Key == Key.Enter)
            {
                Close();
            }
        }
    }
}
