using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace SplitTheClient
{
    class SplitTheClient : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new SplitTheClient());
        }

        SplitTheClient()
        {
            Title = "Split the Client";

            Grid grid1 = new Grid();
            grid1.ColumnDefinitions.Add(new ColumnDefinition());
            grid1.ColumnDefinitions.Add(new ColumnDefinition());
            grid1.ColumnDefinitions.Add(new ColumnDefinition());
            grid1.ColumnDefinitions[1].Width = GridLength.Auto;
            Content = grid1;

            Button btn = new Button();
            btn.Content = "Button No. 1";
            grid1.Children.Add(btn);
            Grid.SetRow(btn, 0);
            Grid.SetColumn(btn, 0);

            GridSplitter splitter = new GridSplitter();
            splitter.ShowsPreview = true;
            splitter.HorizontalAlignment = HorizontalAlignment.Center;
            splitter.VerticalAlignment = VerticalAlignment.Stretch;
            splitter.Width = 6;
            grid1.Children.Add(splitter);
            Grid.SetRow(splitter, 0);
            Grid.SetColumn(splitter, 1);

            Grid grid2 = new Grid();
            grid2.RowDefinitions.Add(new RowDefinition());
            grid2.RowDefinitions.Add(new RowDefinition());
            grid2.RowDefinitions.Add(new RowDefinition());
            grid2.RowDefinitions[1].Height = GridLength.Auto;
            grid1.Children.Add(grid2);
            Grid.SetRow(grid2, 0);
            Grid.SetColumn(grid2, 2);

            btn = new Button();
            btn.Content = "Button No. 2";
            grid2.Children.Add(btn);
            Grid.SetRow(btn, 0);
            Grid.SetColumn(btn, 0);

            splitter = new GridSplitter();
            splitter.ShowsPreview = true;
            splitter.HorizontalAlignment = HorizontalAlignment.Stretch;
            splitter.VerticalAlignment = VerticalAlignment.Center;
            splitter.Height = 6;
            grid2.Children.Add(splitter);
            Grid.SetRow(splitter, 1);
            Grid.SetColumn(splitter, 0);

            btn = new Button();
            btn.Content = "Button No. 3";
            grid2.Children.Add(btn);
            Grid.SetRow(btn, 2);
            Grid.SetColumn(btn, 0);
        }
    }
}
