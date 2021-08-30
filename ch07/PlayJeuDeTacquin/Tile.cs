using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PlayJeuDeTacquin
{
    public class Tile : Canvas
    {
        const int SIZE = 64;
        const int BORD = 6;
        TextBlock textBlock;

        public Tile()
        {
            Width = SIZE;
            Height = SIZE;

            Polygon poly = new Polygon();
            poly.Points = new PointCollection(new Point[]
            {
                new Point(0, 0),
                new Point(SIZE, 0),
                new Point(SIZE - BORD, BORD),
                new Point(BORD, BORD),
                new Point(BORD, SIZE - BORD),
                new Point(0, SIZE),
            });
            poly.Fill = SystemColors.ControlLightLightBrush;
            Children.Add(poly);

            poly = new Polygon();
            poly.Points = new PointCollection(new Point[]
            {
                new Point(SIZE, SIZE),
                new Point(SIZE, 0),
                new Point(SIZE - BORD, BORD),
                new Point(SIZE - BORD, SIZE - BORD),
                new Point(BORD, SIZE - BORD),
                new Point(0, SIZE),
            });
            poly.Fill = SystemColors.ControlDarkBrush;
            Children.Add(poly);

            Border bord = new Border();
            bord.Width = SIZE - 2 * BORD;
            bord.Height = SIZE - 2 * BORD;
            bord.Background = SystemColors.ControlBrush;
            Children.Add(bord);
            SetLeft(bord, BORD);
            SetTop(bord, BORD);

            textBlock = new TextBlock();
            textBlock.FontSize = 32;
            textBlock.Foreground = SystemColors.ControlTextBrush;
            textBlock.HorizontalAlignment = HorizontalAlignment.Center;
            textBlock.VerticalAlignment = VerticalAlignment.Center;
            bord.Child = textBlock;
        }

        public string Text
        {
            set { textBlock.Text = value; }
            get { return textBlock.Text; }
        }
    }
}
