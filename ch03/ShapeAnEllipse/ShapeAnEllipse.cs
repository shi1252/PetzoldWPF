﻿using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ShapeAnEllipse
{
    public class ShapeAnEllipse : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new ShapeAnEllipse());
        }

        public ShapeAnEllipse()
        {
            Title = "Shape an Ellipse";

            Ellipse elips = new Ellipse();
            elips.Fill = Brushes.AliceBlue;
            elips.StrokeThickness = 24;
            elips.Stroke = new LinearGradientBrush(Colors.CadetBlue, Colors.Chocolate, new Point(1, 0), new Point(0, 1));

            elips.Width = 300;
            elips.Height = 300;

            Content = elips;
        }
    }
}
