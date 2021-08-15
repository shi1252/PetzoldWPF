using System;
using System.Windows;
using System.Windows.Media;

namespace FollowTheRainbow
{
    public class FollowTheRainbow : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new FollowTheRainbow());
        }

        public FollowTheRainbow()
        {
            Title = "Follow the Rainbow";

            var brush = new LinearGradientBrush();
            brush.StartPoint = new Point(0, 0);
            brush.EndPoint = new Point(1, 0);
            Background = brush;

            brush.GradientStops.Add(new GradientStop(Colors.Red, 0));
            brush.GradientStops.Add(new GradientStop(Colors.Orange, 0.17));
            brush.GradientStops.Add(new GradientStop(Colors.Yellow, 0.33));
            brush.GradientStops.Add(new GradientStop(Colors.Green, 0.5));
            brush.GradientStops.Add(new GradientStop(Colors.Blue, 0.67));
            brush.GradientStops.Add(new GradientStop(Colors.Indigo, 0.84));
            brush.GradientStops.Add(new GradientStop(Colors.Violet, 1));
        }
    }
}
