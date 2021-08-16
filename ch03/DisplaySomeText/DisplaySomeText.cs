using System;
using System.Windows;
using System.Windows.Media;

namespace DisplaySomeText
{
    public class DisplaySomeText : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new DisplaySomeText());
        }

        public DisplaySomeText()
        {
            Title = "Display Some Text";
            Content = "Content can be simple text!";
            FontFamily = new FontFamily("Comic Sans MS");
            FontStyle = FontStyles.Italic;
            FontWeight = FontWeights.Bold;
            FontSize = 48;

            var brush = new LinearGradientBrush(Colors.Black, Colors.White, new Point(0, 0), new Point(1, 1));
            Foreground = brush;
            Background = brush;
            SizeToContent = SizeToContent.WidthAndHeight;

            ResizeMode = ResizeMode.NoResize;

            BorderBrush = Brushes.SaddleBrown;
            BorderThickness = new Thickness(25, 50, 75, 100);
        }
    }
}
