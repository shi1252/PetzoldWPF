using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ExamineKeystrokes
{
    class ExamineKeystrokes : Window
    {
        StackPanel stack;
        ScrollViewer scroll;
        string strHeader = "Event     Key                 Sys-Key   Text      " +
                           "Ctrl-Text Sys-Text  Ime       KeyStates      " +
                           "IsDown  IsUp   IsToggled IsRepeat ";
        string strFormatKey = "{0,-10}{1,-20}{2,-10}                          " +
                              "    {3,-10}{4,-15}{5,-8}{6,-7}{7,-10}{8,-10}";
        string strFormatText = "{0,-10}                              " +
                               "{1,-10}{2,-10}{3,-10}";

        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new ExamineKeystrokes());
        }

        ExamineKeystrokes()
        {
            Title = "Examine Keystrokes";
            FontFamily = new System.Windows.Media.FontFamily("Courier New");

            Grid grid = new Grid();
            Content = grid;

            RowDefinition row = new RowDefinition();
            row.Height = GridLength.Auto;
            grid.RowDefinitions.Add(row);
            grid.RowDefinitions.Add(new RowDefinition());

            TextBlock textHeader = new TextBlock();
            textHeader.FontWeight = FontWeights.Bold;
            textHeader.Text = strHeader;
            grid.Children.Add(textHeader);

            scroll = new ScrollViewer();
            grid.Children.Add(scroll);
            Grid.SetRow(scroll, 1);

            stack = new StackPanel();
            scroll.Content = stack;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            DisplayKeyInfo(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            DisplayKeyInfo(e);
        }

        protected override void OnTextInput(TextCompositionEventArgs e)
        {
            base.OnTextInput(e);
            string str = string.Format(strFormatText, e.RoutedEvent.Name, e.Text, e.ControlText, e.SystemText);
            DisplayInfo(str);
        }

        private void DisplayKeyInfo(KeyEventArgs e)
        {
            string str = string.Format(strFormatKey, e.RoutedEvent.Name, e.Key, e.SystemKey, e.ImeProcessedKey, e.KeyStates, e.IsDown, e.IsUp, e.IsToggled, e.IsRepeat);
            DisplayInfo(str);
        }

        private void DisplayInfo(string str)
        {
            TextBlock text = new TextBlock();
            text.Text = str;
            stack.Children.Add(text);
            scroll.ScrollToBottom();
        }
    }
}
