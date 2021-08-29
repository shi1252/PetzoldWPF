using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace CalculateYourLife
{
    class CalculateYourLife : Window
    {
        TextBox textBoxBegin, textBoxEnd;
        Label labelLifeYears;

        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new CalculateYourLife());
        }

        CalculateYourLife()
        {
            Title = "Calculate Your Life";
            SizeToContent = SizeToContent.WidthAndHeight;
            ResizeMode = ResizeMode.CanMinimize;

            Grid grid = new Grid();
            Content = grid;

            for (int i=0;i<3;++i)
            {
                RowDefinition rowdef = new RowDefinition();
                rowdef.Height = GridLength.Auto;
                grid.RowDefinitions.Add(rowdef);
            }

            for (int i=0;i<2;++i)
            {
                ColumnDefinition coldef = new ColumnDefinition();
                coldef.Width = GridLength.Auto;
                grid.ColumnDefinitions.Add(coldef);
            }

            Label label = new Label();
            label.Content = "Begin Data: ";
            grid.Children.Add(label);
            Grid.SetRow(label, 0);
            Grid.SetColumn(label, 0);

            textBoxBegin = new TextBox();
            textBoxBegin.Text = new DateTime(1980, 1, 1).ToShortDateString();
            textBoxBegin.TextChanged += TextBoxOnTextChanged;
            grid.Children.Add(textBoxBegin);
            Grid.SetRow(textBoxBegin, 0);
            Grid.SetColumn(textBoxBegin, 1);

            label = new Label();
            label.Content = "End Date: ";
            grid.Children.Add(label);
            Grid.SetRow(label, 1);
            Grid.SetColumn(label, 0);

            textBoxEnd = new TextBox();
            textBoxEnd.TextChanged += TextBoxOnTextChanged;
            grid.Children.Add(textBoxEnd);
            Grid.SetRow(textBoxEnd, 1);
            Grid.SetColumn(textBoxEnd, 1);

            label = new Label();
            label.Content = "Life Years: ";
            grid.Children.Add(label);
            Grid.SetRow(label, 2);
            Grid.SetColumn(label, 0);

            labelLifeYears = new Label();
            grid.Children.Add(labelLifeYears);
            Grid.SetRow(labelLifeYears, 2);
            Grid.SetColumn(labelLifeYears, 1);

            Thickness thick = new Thickness(5);
            grid.Margin = thick;

            foreach(Control ctrl in grid.Children)
            {
                ctrl.Margin = thick;
            }

            textBoxBegin.Focus();
            textBoxEnd.Text = DateTime.Now.ToShortDateString();
        }

        private void TextBoxOnTextChanged(object sender, TextChangedEventArgs e)
        {
            DateTime dtBeg, dtEnd;

            if (DateTime.TryParse(textBoxBegin.Text, out dtBeg) &&
                DateTime.TryParse(textBoxEnd.Text, out dtEnd))
            {
                int iYears = dtEnd.Year - dtBeg.Year;
                int iMonths = dtEnd.Month - dtBeg.Month;
                int iDays = dtEnd.Day - dtBeg.Day;

                if (iDays < 0)
                {
                    iDays += DateTime.DaysInMonth(dtEnd.Year, iMonths + (dtEnd.Month + 10) % 12);
                    iMonths -= 1;
                }
                if (iMonths < 0)
                {
                    iMonths += 12;
                    iYears -= 1;
                }
                labelLifeYears.Content = $"{iYears} year{(iYears == 1 ? "" : "s")}, {iMonths} month{(iMonths == 1 ? "" : "s")}, {iDays} day{(iDays == 1 ? "" : "s")}";
            }
            else
            {
                labelLifeYears.Content = "";
            }
        }
    }
}
