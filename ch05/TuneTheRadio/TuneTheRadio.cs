﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace TuneTheRadio
{
    class TuneTheRadio : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new TuneTheRadio());
        }

        TuneTheRadio()
        {
            Title = "Tune the Radio";
            SizeToContent = SizeToContent.WidthAndHeight;

            GroupBox group = new GroupBox();
            group.Header = "Window Style";
            group.Margin = new Thickness(96);
            group.Padding = new Thickness(5);
            Content = group;

            StackPanel stack = new StackPanel();
            group.Content = stack;

            stack.Children.Add(CreateRadioButton("No border or caption", WindowStyle.None));
            stack.Children.Add(CreateRadioButton("Single-border window", WindowStyle.SingleBorderWindow));
            stack.Children.Add(CreateRadioButton("3D-border window", WindowStyle.ThreeDBorderWindow));
            stack.Children.Add(CreateRadioButton("Tool window", WindowStyle.ToolWindow));

            AddHandler(RadioButton.CheckedEvent, new RoutedEventHandler(RadioOnChecked));
        }

        private void RadioOnChecked(object sender, RoutedEventArgs e)
        {
            RadioButton radio = e.Source as RadioButton;
            WindowStyle = (WindowStyle)radio.Tag;
        }

        private RadioButton CreateRadioButton(string str, WindowStyle style)
        {
            RadioButton radio = new RadioButton();
            radio.Content = str;
            radio.Tag = style;
            radio.Margin = new Thickness(5);
            radio.IsChecked = (style == WindowStyle);

            return radio;
        }
    }
}
