using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace RenderTheBetterEllipse
{
    public class BetterEllipse :FrameworkElement
    {
        public static readonly DependencyProperty FillProperty;
        public static readonly DependencyProperty StrokeProperty;

        public Brush Fill
        {
            get { return (Brush)GetValue(FillProperty); }
            set { SetValue(FillProperty, value); }
        }

        public Pen Stroke
        {
            get { return (Pen)GetValue(StrokeProperty); }
            set { SetValue(StrokeProperty, value); }
        }

        static BetterEllipse()
        {
            FillProperty = DependencyProperty.Register("Fill", typeof(Brush), typeof(BetterEllipse), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender));
            StrokeProperty = DependencyProperty.Register("Stroke", typeof(Pen), typeof(BetterEllipse), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure));
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            Size sizeDesired = base.MeasureOverride(availableSize);

            if (Stroke != null)
            {
                sizeDesired = new Size(Stroke.Thickness, Stroke.Thickness);
            }

            return sizeDesired;
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            drawingContext.PushClip(new RectangleGeometry(new Rect(new Point(0, 0), RenderSize)));

            Size size = RenderSize;

            if (Stroke != null)
            {
                size.Width = Math.Max(0, size.Width - Stroke.Thickness);
                size.Height = Math.Max(0, size.Height - Stroke.Thickness);
            }
            
            drawingContext.DrawEllipse(Fill, Stroke, new Point(RenderSize.Width / 2, RenderSize.Height / 2), size.Width / 2, size.Height / 2);

            FormattedText formattedText = new FormattedText("Hello, ellipse!", CultureInfo.CurrentCulture, FlowDirection, new Typeface("Times New Roman Italic"), 24, Brushes.DarkBlue);
            Point ptText = new Point((RenderSize.Width - formattedText.Width) / 2, (RenderSize.Height - formattedText.Height) / 2);
            drawingContext.DrawText(formattedText, ptText);
        }
    }
}
