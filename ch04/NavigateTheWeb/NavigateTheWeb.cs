using System;
using System.Windows;
using System.Windows.Controls;

namespace NavigateTheWeb
{
    class NavigateTheWeb : Window
    {
        Frame frame;

        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new NavigateTheWeb());
        }

        public NavigateTheWeb()
        {
            Title = "Navigate the Web";

            frame = new Frame();
            Content = frame;

            Loaded += OnWindowLoaded;
        }

        private void OnWindowLoaded(object sender, RoutedEventArgs e)
        {
            UriDialog dlg = new UriDialog();
            dlg.Owner = this;
            dlg.Text = "http://";
            dlg.ShowDialog();

            try
            {
                frame.Source = new Uri(dlg.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Title);
            }
        }
    }
}
