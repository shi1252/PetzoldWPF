using System;
using System.Windows;
using System.Windows.Media;

namespace CircleTheRainbow
{
    public class CircleTheRainbow : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new CircleTheRainbow());
        }

        public CircleTheRainbow()
        {
            Title = "Circle the Rainbow";

            var brush = new RadialGradientBrush();
            Background = brush;

            brush.GradientStops.Add(new GradientStop(Colors.Red, 0));
            brush.GradientStops.Add(new GradientStop(Colors.Orange, 0.17));
            brush.GradientStops.Add(new GradientStop(Colors.Yellow, 0.33));
            brush.GradientStops.Add(new GradientStop(Colors.Green, 0.5));
            brush.GradientStops.Add(new GradientStop(Colors.Blue, 0.67));
            brush.GradientStops.Add(new GradientStop(Colors.Indigo, 0.84));
            brush.GradientStops.Add(new GradientStop(Colors.Violet, 1));

            brush.GradientOrigin = new Point(0.75, 0.75);
        }
    }
}
