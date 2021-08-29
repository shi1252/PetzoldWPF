using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace ScrollCustomColors
{
    class ScrollCustomColors : Window
    {
        ScrollBar[] scrolls = new ScrollBar[3];
        TextBlock[] textValue = new TextBlock[3];
        Panel pnlColor;

        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new ScrollCustomColors());
        }

        ScrollCustomColors()
        {
            Title = "Scroll Custom Colors";
            Width = 500;
            Height = 300;

            Grid gridMain = new Grid();
            Content = gridMain;

            ColumnDefinition coldef = new ColumnDefinition();
            coldef.Width = new GridLength(200, GridUnitType.Pixel);
            gridMain.ColumnDefinitions.Add(coldef);

            coldef = new ColumnDefinition();
            coldef.Width = GridLength.Auto;
            gridMain.ColumnDefinitions.Add(coldef);

            coldef = new ColumnDefinition();
            coldef.Width = new GridLength(100, GridUnitType.Star);
            gridMain.ColumnDefinitions.Add(coldef);

            GridSplitter split = new GridSplitter();
            split.HorizontalAlignment = HorizontalAlignment.Center;
            split.VerticalAlignment = VerticalAlignment.Stretch;
            split.Width = 6;
            gridMain.Children.Add(split);
            Grid.SetRow(split, 0);
            Grid.SetColumn(split, 1);

            pnlColor = new StackPanel();
            pnlColor.Background = new SolidColorBrush(SystemColors.WindowColor);
            gridMain.Children.Add(pnlColor);
            Grid.SetRow(pnlColor, 0);
            Grid.SetColumn(pnlColor, 2);

            Grid grid = new Grid();
            gridMain.Children.Add(grid);
            Grid.SetRow(grid, 0);
            Grid.SetColumn(grid, 0);

            RowDefinition rowdef = new RowDefinition();
            rowdef.Height = GridLength.Auto;
            grid.RowDefinitions.Add(rowdef);

            rowdef = new RowDefinition();
            rowdef.Height = new GridLength(100, GridUnitType.Star);
            grid.RowDefinitions.Add(rowdef);

            rowdef = new RowDefinition();
            rowdef.Height = GridLength.Auto;
            grid.RowDefinitions.Add(rowdef);

            for (int i=0;i<3;++i)
            {
                coldef = new ColumnDefinition();
                coldef.Width = new GridLength(33, GridUnitType.Star);
                grid.ColumnDefinitions.Add(coldef);
            }

            for (int i=0;i<3;++i)
            {
                Label label = new Label();
                label.Content = new string[] { "Red", "Green", "Blue" }[i];
                label.HorizontalAlignment = HorizontalAlignment.Center;
                grid.Children.Add(label);
                Grid.SetRow(label, 0);
                Grid.SetColumn(label, i);

                scrolls[i] = new ScrollBar();
                scrolls[i].Focusable = true;
                scrolls[i].Orientation = Orientation.Vertical;
                scrolls[i].Minimum = 0;
                scrolls[i].Maximum = 255;
                scrolls[i].SmallChange = 1;
                scrolls[i].LargeChange = 16;
                scrolls[i].ValueChanged += ScrollOnValueChanged;
                grid.Children.Add(scrolls[i]);
                Grid.SetRow(scrolls[i], 1);
                Grid.SetColumn(scrolls[i], i);

                textValue[i] = new TextBlock();
                textValue[i].TextAlignment = TextAlignment.Center;
                textValue[i].HorizontalAlignment = HorizontalAlignment.Center;
                textValue[i].Margin = new Thickness(5);
                grid.Children.Add(textValue[i]);
                Grid.SetRow(textValue[i], 2);
                Grid.SetColumn(textValue[i], i);
            }

            Color color = (pnlColor.Background as SolidColorBrush).Color;
            scrolls[0].Value = color.R;
            scrolls[1].Value = color.G;
            scrolls[2].Value = color.B;

            scrolls[0].Focus();
        }

        private void ScrollOnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ScrollBar scroll = sender as ScrollBar;
            Panel pnl = scroll.Parent as Panel;
            TextBlock text = pnl.Children[1 + pnl.Children.IndexOf(scroll)] as TextBlock;

            text.Text = $"{(int)scroll.Value}\n0x{0:X2}";
            pnlColor.Background = new SolidColorBrush(Color.FromRgb((byte)scrolls[0].Value, (byte)scrolls[1].Value, (byte)scrolls[2].Value));
        }
    }
}
