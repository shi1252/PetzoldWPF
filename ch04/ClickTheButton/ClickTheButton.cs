using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ClickTheButton
{
    class ClickTheButton : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new ClickTheButton());
        }

        public ClickTheButton()
        {
            Title = "Click the Button";

            Button btn = new Button();
            btn.Content = "_Click me, please!";
            btn.Click += ButtonOnClick;
            btn.Focus();
            btn.IsDefault = true;
            btn.IsCancel = true;
            btn.Margin = new Thickness(96);
            btn.HorizontalContentAlignment = HorizontalAlignment.Left;
            btn.VerticalContentAlignment = VerticalAlignment.Bottom;
            btn.HorizontalAlignment = HorizontalAlignment.Center;
            btn.VerticalAlignment = VerticalAlignment.Center;
            btn.Padding = new Thickness(96);
            btn.FontSize= 48;
            btn.FontFamily = new FontFamily("Times New Roman");
            btn.Background = Brushes.AliceBlue;
            btn.Foreground = Brushes.DarkSalmon;
            btn.BorderBrush = Brushes.Magenta;

            SizeToContent = SizeToContent.WidthAndHeight;

            Content = btn;
        }

        private void ButtonOnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("The button has been clicked and all is well.", Title);
        }
    }
}
