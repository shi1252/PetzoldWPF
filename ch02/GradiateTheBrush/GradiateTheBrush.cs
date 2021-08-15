using System;
using System.Windows;
using System.Windows.Media;

namespace GradiateTheBrush
{
    public class GradiateTheBrush : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new GradiateTheBrush());
        }

        public GradiateTheBrush()
        {
            Title = "Gradiate the Brush";

            var brush = new LinearGradientBrush(Colors.Red, Colors.Blue, new Point(0, 0), new Point(0.25, 0.25));
            brush.SpreadMethod = GradientSpreadMethod.Reflect;
            Background = brush;
        }
    }
}
