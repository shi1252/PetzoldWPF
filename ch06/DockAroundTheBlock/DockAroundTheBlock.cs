using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace DockAroundTheBlock
{
    class DockAroundTheBlock : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new DockAroundTheBlock());
        }

        DockAroundTheBlock()
        {
            Title = "Dock Around the Block";

            DockPanel dock = new DockPanel();
            Content = dock;

            for (int i = 0; i < 17; ++i)
            {
                Button btn = new Button();
                btn.Content = "Button No. " + (i + 1);
                dock.Children.Add(btn);
                btn.SetValue(DockPanel.DockProperty, (Dock)(i % 4));
                btn.HorizontalAlignment = HorizontalAlignment.Center;
            }
            dock.LastChildFill = false;
        }
    }
}
