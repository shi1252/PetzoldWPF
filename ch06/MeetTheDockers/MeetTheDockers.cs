using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace MeetTheDockers
{
    class MeetTheDockers : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new MeetTheDockers());
        }

        MeetTheDockers()
        {
            Title = "Meet the Dockers";

            DockPanel dock = new DockPanel();
            Content = dock;

            Menu menu = new Menu();
            MenuItem item = new MenuItem();
            item.Header = "Menu";
            menu.Items.Add(item);

            DockPanel.SetDock(menu, Dock.Top);
            dock.Children.Add(menu);

            ToolBar tool = new ToolBar();
            tool.Header = "Toolbar";

            DockPanel.SetDock(tool, Dock.Top);
            dock.Children.Add(tool);

            StatusBar status = new StatusBar();
            StatusBarItem statItem = new StatusBarItem();
            statItem.Content = "Status";
            status.Items.Add(statItem);

            DockPanel.SetDock(status, Dock.Bottom);
            dock.Children.Add(status);

            ListBox listBox = new ListBox();
            listBox.Items.Add("List Box Items");

            DockPanel.SetDock(listBox, Dock.Left);
            dock.Children.Add(listBox);

            TextBox textBox = new TextBox();
            textBox.AcceptsReturn = true;

            dock.Children.Add(textBox);
            textBox.Focus();
        }
    }
}
