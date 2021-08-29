using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace SpanTheCells
{
    class SpanTheCells : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new SpanTheCells());
        }

        SpanTheCells()
        {
            Title = "Span the Cells";
            SizeToContent = SizeToContent.WidthAndHeight;

            Grid grid = new Grid();
            grid.Margin = new Thickness(5);
            Content = grid;

            for (int i=0;i<6;++i)
            {
                RowDefinition rowdef = new RowDefinition();
                rowdef.Height = GridLength.Auto;
                grid.RowDefinitions.Add(rowdef);
            }

            for (int i=0;i<4;++i)
            {
                ColumnDefinition coldef = new ColumnDefinition();

                if (i == 1)
                {
                    coldef.Width = new GridLength(100, GridUnitType.Star);
                }
                else
                {
                    coldef.Width = GridLength.Auto;
                }

                grid.ColumnDefinitions.Add(coldef);
            }

            string[] astrLabel = { "_First name:", "_Last name:", "_Social security number:", "_Credit card number:", "_Other personal stuff:" };
            
            for (int i=0;i<astrLabel.Length;++i)
            {
                Label label = new Label();
                label.Content = astrLabel[i];
                label.VerticalContentAlignment = VerticalAlignment.Center;

                grid.Children.Add(label);
                Grid.SetRow(label, i);
                Grid.SetColumn(label, 0);

                TextBox textBox = new TextBox();
                textBox.Margin = new Thickness(5);

                grid.Children.Add(textBox);
                Grid.SetRow(textBox, i);
                Grid.SetColumn(textBox, 1);
                Grid.SetColumnSpan(textBox, 3);
            }

            Button btn = new Button();
            btn.Content = "Submit";
            btn.Margin = new Thickness(5);
            btn.IsDefault = true;
            btn.Click += delegate { Close(); };
            grid.Children.Add(btn);
            Grid.SetRow(btn, 5);
            Grid.SetColumn(btn, 2);

            btn = new Button();
            btn.Content = "Cancel";
            btn.Margin = new Thickness(5);
            btn.IsCancel = true;
            btn.Click += delegate { Close(); };
            grid.Children.Add(btn);
            Grid.SetRow(btn, 5);
            Grid.SetColumn(btn, 3);

            grid.Children[1].Focus();
        }
    }
}
