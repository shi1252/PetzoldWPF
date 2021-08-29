using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace SplitNine
{
    class SplitNine : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new SplitNine());
        }

        SplitNine()
        {
            Title = "Split Nine";

            Grid grid = new Grid();
            Content = grid;

            for (int i=0;i<3;++i)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
                grid.RowDefinitions.Add(new RowDefinition());
            }

            for (int x=0;x<3;++x)
            {
                for (int y=0;y<3;++y)
                {
                    Button btn = new Button();
                    btn.Content = "Row " + y + " and Column " + x;
                    btn.Margin = new Thickness(10);
                    grid.Children.Add(btn);
                    Grid.SetRow(btn, y);
                    Grid.SetColumn(btn, x);
                }
            }

            GridSplitter split = new GridSplitter();
            split.Width = 6;
            split.Height = 6;
            split.HorizontalAlignment = HorizontalAlignment.Left;
            split.VerticalAlignment = VerticalAlignment.Top;
            grid.Children.Add(split);
            Grid.SetRow(split, 1);
            Grid.SetColumn(split, 1);
        }
    }
}
