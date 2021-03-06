using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace EnterTheGrid
{
    class EnterTheGrid : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new EnterTheGrid());
        }

        EnterTheGrid()
        {
            Title = "Enter the Grid";
            MinWidth = 300;
            SizeToContent = SizeToContent.WidthAndHeight;

            StackPanel stack = new StackPanel();
            Content = stack;

            Grid grid1 = new Grid();
            grid1.Margin = new Thickness(5);
            stack.Children.Add(grid1);

            for (int i=0;i<5;++i)
            {
                RowDefinition rowdef = new RowDefinition();
                rowdef.Height = GridLength.Auto;
                grid1.RowDefinitions.Add(rowdef);
            }

            ColumnDefinition coldef = new ColumnDefinition();
            coldef.Width = GridLength.Auto;
            grid1.ColumnDefinitions.Add(coldef);

            coldef = new ColumnDefinition();
            coldef.Width = new GridLength(100, GridUnitType.Star);
            grid1.ColumnDefinitions.Add(coldef);

            string[] strLabels = { "_First name:", "_Last name:", "_Social security number:", "_Credit card number:", "_Other personal stuff:" };

            for (int i=0;i<strLabels.Length;++i)
            {
                Label label = new Label();
                label.Content = strLabels[i];
                label.VerticalContentAlignment = VerticalAlignment.Center;
                grid1.Children.Add(label);
                Grid.SetRow(label, i);
                Grid.SetColumn(label, 0);
                TextBox textBox = new TextBox();
                textBox.Margin = new Thickness(5);
                grid1.Children.Add(textBox);
                Grid.SetRow(textBox, i);
                Grid.SetColumn(textBox, 1);
            }

            Grid grid2 = new Grid();
            grid2.Margin = new Thickness(10);
            stack.Children.Add(grid2);

            grid2.ColumnDefinitions.Add(new ColumnDefinition());
            grid2.ColumnDefinitions.Add(new ColumnDefinition());

            Button btn = new Button();
            btn.Content = "Submit";
            btn.HorizontalAlignment = HorizontalAlignment.Center;
            btn.IsDefault = true;
            btn.Click += delegate { Close(); };
            grid2.Children.Add(btn);
            btn = new Button();
            btn.Content = "Cancel";
            btn.HorizontalAlignment = HorizontalAlignment.Center;
            btn.IsCancel = true;
            btn.Click += delegate { Close(); };
            grid2.Children.Add(btn);
            Grid.SetColumn(btn, 1);

            (stack.Children[0] as Panel).Children[1].Focus();
        }
    }
}
