using System;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace EditSomeText
{
    class EditSomeText : Window
    {
        static string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Petzold\\EditSomeText\\EditSomeText.txt");

        TextBox textBox;

        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new EditSomeText());
        }

        public EditSomeText()
        {
            Title = "Edit Some Text";

            textBox = new TextBox();
            textBox.AcceptsReturn = true;
            textBox.TextWrapping = TextWrapping.Wrap;
            textBox.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
            textBox.KeyDown += TextBoxOnKeyDown;
            Content = textBox;

            try
            {
                textBox.Text = File.ReadAllText(fileName);
            }
            catch
            {
            }

            textBox.CaretIndex = textBox.Text.Length;
            textBox.Focus();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(fileName));
                File.WriteAllText(fileName, textBox.Text);
            }
            catch (Exception ex)
            {
                MessageBoxResult result = MessageBox.Show($"File Could not be saved: {ex.Message}\nClose program anyway?", Title, MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
                e.Cancel = (result == MessageBoxResult.No);
            }
        }

        private void TextBoxOnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F5)
            {
                textBox.SelectedText = DateTime.Now.ToString();
                textBox.CaretIndex = textBox.SelectionStart + textBox.SelectionLength;
            }
        }
    }
}
