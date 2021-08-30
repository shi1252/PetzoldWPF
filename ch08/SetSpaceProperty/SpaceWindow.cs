using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace SetSpaceProperty
{
    public class SpaceWindow : Window
    {
        public static readonly DependencyProperty SpaceProperty;

        public int Space
        {
            get { return (int)GetValue(SpaceProperty); }
            set { SetValue(SpaceProperty, value); }
        }

        static SpaceWindow()
        {
            FrameworkPropertyMetadata meta = new FrameworkPropertyMetadata();
            meta.Inherits = true;

            SpaceProperty = SpaceButton.SpaceProperty.AddOwner(typeof(SpaceWindow));
            SpaceProperty.OverrideMetadata(typeof(SpaceWindow), meta);
        }
    }
}
