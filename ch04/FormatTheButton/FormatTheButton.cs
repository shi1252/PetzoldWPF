using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace FormatTheButton
{
    class FormatTheButton : Window
    {
        Run runButton;

        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new FormatTheButton());
        }

        public FormatTheButton()
        {
            Title = "Format the Button";

            Button btn = new Button();
            btn.HorizontalAlignment = HorizontalAlignment.Center;
            btn.VerticalAlignment = VerticalAlignment.Center;
            btn.MouseEnter += ButtonOnMouseEnter;
            btn.MouseLeave += ButtonOnMouseLeave;
            Content = btn;

            TextBlock textBlock = new TextBlock();
            textBlock.FontSize = 24;
            textBlock.TextAlignment = TextAlignment.Center;
            btn.Content = textBlock;

            textBlock.Inlines.Add(new Italic(new Run("Click")));
            textBlock.Inlines.Add(" the ");
            textBlock.Inlines.Add(runButton = new Run("button"));
            textBlock.Inlines.Add(new LineBreak());
            textBlock.Inlines.Add("to launch the ");
            textBlock.Inlines.Add(new Bold(new Run("rocket")));
        }

        private void ButtonOnMouseEnter(object sender, MouseEventArgs e)
        {
            runButton.Foreground = Brushes.Red;
        }

        private void ButtonOnMouseLeave(object sender, MouseEventArgs e)
        {
            runButton.Foreground = SystemColors.ControlTextBrush;
        }
    }
}
