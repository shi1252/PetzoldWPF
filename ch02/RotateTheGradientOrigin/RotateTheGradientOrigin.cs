using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace RotateTheGradientOrigin
{
    public class RotateTheGradientOrigin : Window
    {
        RadialGradientBrush brush;
        double angle;

        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new RotateTheGradientOrigin());
        }

        public RotateTheGradientOrigin()
        {
            Title = "Rotate the Gradient Origin";
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Width = 384;
            Height = 384;

            BorderBrush = Brushes.SaddleBrown;
            BorderThickness = new Thickness(25, 50, 75, 100);

            brush = new RadialGradientBrush(Colors.White, Colors.Blue);
            brush.Center = brush.GradientOrigin = new Point(0.5, 0.5);
            brush.RadiusX = brush.RadiusY = 0.1;
            brush.SpreadMethod = GradientSpreadMethod.Repeat;
            Background = brush;

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Tick += TimerOnTick;
            timer.Start();
        }

        private void TimerOnTick(object sender, EventArgs e)
        {
            Point pt = new Point(0.5 + 0.05 * Math.Cos(angle), 0.5 + 0.05 * Math.Sin(angle));
            brush.GradientOrigin = pt;
            angle += Math.PI / 6;
        }
    }
}
