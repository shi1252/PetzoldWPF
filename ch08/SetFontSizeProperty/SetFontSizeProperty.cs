using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace SetFontSizeProperty
{
    class SetFontSizeProperty : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new SetFontSizeProperty());
        }

        SetFontSizeProperty()
        {
            Title = "Set FontSize Property";
            SizeToContent = SizeToContent.WidthAndHeight;
            ResizeMode = ResizeMode.CanMinimize;
            FontSize = 16;
            double[] fontSizes = { 8, 16, 32 };

            Grid grid = new Grid();
            Content = grid;

            for (int i=0;i<2;++i)
            {
                RowDefinition row = new RowDefinition();
                row.Height = GridLength.Auto;
                grid.RowDefinitions.Add(row);
            }
            for (int i=0;i<fontSizes.Length;++i)
            {
                ColumnDefinition col = new ColumnDefinition();
                col.Width = GridLength.Auto;
                grid.ColumnDefinitions.Add(col);
            }

            for (int i=0;i<fontSizes.Length;++i)
            {
                Button btn = new Button();
                btn.Content = new TextBlock(new Run("Set window FontSize to " + fontSizes[i]));
                btn.Tag = fontSizes[i];
                btn.HorizontalAlignment = HorizontalAlignment.Center;
                btn.VerticalAlignment = VerticalAlignment.Center;
                btn.Click += WindowFontSizeOnClick;
                grid.Children.Add(btn);
                Grid.SetRow(btn, 0);
                Grid.SetColumn(btn, i);

                btn = new Button();
                btn.Content = new TextBlock(new Run("Set button FontSize to " + fontSizes[i]));
                btn.Tag = fontSizes[i];
                btn.HorizontalAlignment = HorizontalAlignment.Center;
                btn.VerticalAlignment = VerticalAlignment.Center;
                btn.Click += ButtonFontSizeOnClick;
                grid.Children.Add(btn);
                Grid.SetRow(btn, 1);
                Grid.SetColumn(btn, i);
            }
        }

        private void ButtonFontSizeOnClick(object sender, RoutedEventArgs e)
        {
            Button btn = e.Source as Button;
            btn.FontSize = (double)btn.Tag;
        }

        private void WindowFontSizeOnClick(object sender, RoutedEventArgs e)
        {
            Button btn = e.Source as Button;
            FontSize = (double)btn.Tag;
        }
    }
}
