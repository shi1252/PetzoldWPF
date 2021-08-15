using System;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace FlipThroughTheBrushes
{
    public class FlipThroughTheBrushes : Window
    {
        int index = 0;
        PropertyInfo[] props;

        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new FlipThroughTheBrushes());
        }

        public FlipThroughTheBrushes()
        {
            props = typeof(Brushes).GetProperties(BindingFlags.Public | BindingFlags.Static);
            SetTitleAndBackground();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.Key == Key.Down || e.Key == Key.Up)
            {
                index += e.Key == Key.Up ? 1 : props.Length - 1;
                index %= props.Length;
                SetTitleAndBackground();
            }
        }

        private void SetTitleAndBackground()
        {
            Title = $"Flip Through the Brushes - {props[index].Name}";
            Background = (Brush)props[index].GetValue(null, null);
        }
    }
}
