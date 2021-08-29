using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace ExploreDirectories
{
    class ExploreDirectories : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new ExploreDirectories());
        }

        ExploreDirectories()
        {
            Title = "Explore Directories";
            ScrollViewer scroll = new ScrollViewer();
            Content = scroll;
            WrapPanel wrap = new WrapPanel();
            scroll.Content = wrap;
            wrap.Children.Add(new FileSystemInfoButton());
        }
    }
}
