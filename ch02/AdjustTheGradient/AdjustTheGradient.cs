using System;
using System.Windows;
using System.Windows.Media;

namespace AdjustTheGradient
{
    public class AdjustTheGradient : Window
    {
        LinearGradientBrush brush;

        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new AdjustTheGradient());
        }

        public AdjustTheGradient()
        {
            Title = "Adjust the Gradient";
            SizeChanged += WindowOnSizeChanged;

            brush = new LinearGradientBrush(Colors.Red, Colors.Blue, 0);
            brush.MappingMode = BrushMappingMode.Absolute;
            Background = brush;
        }

        private void WindowOnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            double width = ActualWidth - 2 * SystemParameters.ResizeFrameVerticalBorderWidth;
            double height = ActualHeight - 2 * SystemParameters.ResizeFrameHorizontalBorderHeight - SystemParameters.CaptionHeight;

            Point ptCenter = new Point(width / 2, height / 2);
            Vector vectDiag = new Vector(width, -height);
            Vector vectPerp = new Vector(vectDiag.Y, -vectDiag.X);

            vectPerp.Normalize();
            vectPerp *= width * height / vectDiag.Length;

            brush.StartPoint = ptCenter + vectPerp;
            brush.EndPoint = ptCenter - vectPerp;
        }
    }
}
