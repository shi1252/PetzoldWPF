using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace EditSomeRichText
{
    class EditSomeRichText : Window
    {
        RichTextBox textBox;
        string filter = "Document Files(*.xaml)|*.xaml|All Files (*.*)|*.*";

        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new EditSomeRichText());
        }

        public EditSomeRichText()
        {
            Title = "Edit Some Rich Text";

            textBox = new RichTextBox();
            textBox.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
            Content = textBox;

            textBox.Focus();
        }

        protected override void OnPreviewTextInput(TextCompositionEventArgs e)
        {
            if (e.ControlText.Length > 0 && e.ControlText[0] == '\x0F')
            {
                var dlg = new OpenFileDialog();
                dlg.CheckFileExists = true;
                dlg.Filter = filter;

                if ((bool)dlg.ShowDialog(this))
                {
                    FlowDocument flow = textBox.Document;
                    var range = new TextRange(flow.ContentStart, flow.ContentEnd);
                    Stream stream = null;

                    try
                    {
                        stream = new FileStream(dlg.FileName, FileMode.Open);
                        range.Load(stream, DataFormats.Xaml);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, Title);
                    }
                    finally
                    {
                        if (stream != null)
                        {
                            stream.Close();
                        }
                    }
                }

                e.Handled = true;
            }

            if (e.ControlText.Length > 0 && e.ControlText[0] == '\x13')
            {
                var dlg = new SaveFileDialog();
                dlg.Filter = filter;

                if ((bool)dlg.ShowDialog(this))
                {
                    FlowDocument flow = textBox.Document;
                    var range = new TextRange(flow.ContentStart, flow.ContentEnd);
                    Stream stream = null;

                    try
                    {
                        stream = new FileStream(dlg.FileName, FileMode.Create);
                        range.Save(stream, DataFormats.Xaml);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, Title);
                    }
                    finally
                    {
                        if (stream != null)
                        {
                            stream.Close();
                        }
                    }
                }

                e.Handled = true;
            }
            base.OnPreviewTextInput(e);
        }
    }
}
