using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace GetMedieval
{
    class GetMedieval : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new GetMedieval());
        }

        GetMedieval()
        {
            Title = "Get Medieval";

            MedievalButton btn = new MedievalButton();
            btn.Text = "Click this button";
            btn.FontSize = 24;
            btn.HorizontalAlignment = HorizontalAlignment.Center;
            btn.VerticalAlignment = VerticalAlignment.Center;
            btn.Padding = new Thickness(5, 20, 5, 20);
            btn.Knock += ButtonOnKnock;
            btn.Width = 50;

            Content = btn;
        }

        private void ButtonOnKnock(object sender, RoutedEventArgs args)
        {
            MedievalButton btn = args.Source as MedievalButton;
            MessageBox.Show("The button labeled \"" + btn.Text + "\" has been knocked.", Title);
        }
    }
}
