using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace SetSpaceProperty
{
    public class SpaceButton : Button
    {
        string text;
        public string Text
        {
            get { return text; }
            set 
            { 
                text = value;
                Content = SpaceOutText(text);
            }
        }

        public static readonly DependencyProperty SpaceProperty;

        public int Space
        {
            get { return (int)GetValue(SpaceProperty); }
            set { SetValue(SpaceProperty, value); }
        }

        static SpaceButton()
        {
            FrameworkPropertyMetadata meta = new FrameworkPropertyMetadata();
            meta.DefaultValue = 1;
            meta.AffectsMeasure = true;
            meta.Inherits = true;
            meta.PropertyChangedCallback += OnSpacePropertyChanged;

            SpaceProperty = DependencyProperty.Register("Space", typeof(int), typeof(SpaceButton), meta, ValidateSpaceValue);
        }

        private static bool ValidateSpaceValue(object value)
        {
            int i = (int)value;
            return i >= 0;
        }

        private static void OnSpacePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SpaceButton btn = d as SpaceButton;
            btn.Content = btn.SpaceOutText(btn.text);
        }

        private string SpaceOutText(string text)
        {
            if (text == null)
            {
                return null;
            }

            StringBuilder build = new StringBuilder();

            foreach (char c in text)
            {
                build.Append(c + new string(' ', Space));
            }
            return build.ToString();
        }
    }
}
