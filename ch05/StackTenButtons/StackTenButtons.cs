using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace StackTenButtons
{
    class StackTenButtons : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new StackTenButtons());
        }

        StackTenButtons()
        {
            Title = "Stack Ten Buttons";

            StackPanel stack = new StackPanel();
            Content = stack;

            Random random = new Random();

            for (int i=0;i<10;++i)
            {
                Button btn = new Button();
                btn.Name = ((char)('A' + i)).ToString();
                btn.FontSize += random.Next(10);
                btn.Content = "Button " + btn.Name + " says 'Click me'";
                //btn.Click += ButtonOnClick;
                btn.HorizontalAlignment = HorizontalAlignment.Center;
                btn.Margin = new Thickness(5);

                stack.Children.Add(btn);
            }

            //stack.Background = Brushes.Aquamarine;
            stack.Orientation = Orientation.Horizontal;
            stack.HorizontalAlignment = HorizontalAlignment.Center;
            stack.Margin = new Thickness(5);
            stack.AddHandler(Button.ClickEvent, new RoutedEventHandler(ButtonOnClick));

            SizeToContent = SizeToContent.WidthAndHeight;
            ResizeMode = ResizeMode.CanResize;
        }

        private void ButtonOnClick(object sender, RoutedEventArgs e)
        {
            Button btn = e.Source as Button;

            MessageBox.Show("Button " + btn.Name + " has been clicked", "Button Click");
        }
    }
}
