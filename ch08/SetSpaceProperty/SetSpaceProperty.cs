using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace SetSpaceProperty
{
    class SetSpaceProperty : SpaceWindow
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new SetSpaceProperty());
        }

        SetSpaceProperty()
        {
            Title = "Set SpaceProperty";
            SizeToContent = SizeToContent.WidthAndHeight;
            ResizeMode = ResizeMode.CanMinimize;
            int[] iSpaces = { 0, 1, 2 };

            Grid grid = new Grid();
            Content = grid;

            for (int i=0;i<2;i++)
            {
                RowDefinition row = new RowDefinition();
                row.Height = GridLength.Auto;
                grid.RowDefinitions.Add(row);
            }
            for (int i = 0; i < iSpaces.Length; ++i)
            {
                ColumnDefinition col = new ColumnDefinition();
                col.Width = GridLength.Auto;
                grid.ColumnDefinitions.Add(col);
            }

            for (int i = 0; i < iSpaces.Length; ++i)
            {
                SpaceButton btn = new SpaceButton();
                btn.Text = "Set window Space to " + iSpaces[i];
                btn.Tag = iSpaces[i];
                btn.HorizontalAlignment = HorizontalAlignment.Center;
                btn.VerticalAlignment = VerticalAlignment.Center;
                btn.Click += WindowPropertyOnClick;
                grid.Children.Add(btn);
                Grid.SetRow(btn, 0);
                Grid.SetColumn(btn, i);

                btn = new SpaceButton();
                btn.Text = "Set button Space to " + iSpaces[i];
                btn.Tag = iSpaces[i];
                btn.HorizontalAlignment = HorizontalAlignment.Center;
                btn.VerticalAlignment = VerticalAlignment.Center;
                btn.Click += ButtonPropertyOnClick;
                grid.Children.Add(btn);
                Grid.SetRow(btn, 1);
                Grid.SetColumn(btn, i);
            }
        }

        private void WindowPropertyOnClick(object sender, RoutedEventArgs e)
        {
            SpaceButton btn = e.Source as SpaceButton;
            Space = (int)btn.Tag;
        }

        private void ButtonPropertyOnClick(object sender, RoutedEventArgs e)
        {
            SpaceButton btn = e.Source as SpaceButton;
            btn.Space = (int)btn.Tag;
        }
    }
}
