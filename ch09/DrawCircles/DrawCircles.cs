using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace DrawCircles
{
    class DrawCircles : Window
    {
        Canvas canvas;

        bool isDrawing;
        Ellipse ellipse;
        Point ptCenter;

        bool isDragging;
        FrameworkElement elDragging;
        Point ptMouseStart, ptElementStart;

        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new DrawCircles());
        }

        DrawCircles()
        {
            Title = "Draw Circles";
            Content = canvas = new Canvas();
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            if (isDragging)
            {
                return;
            }

            ptCenter = e.GetPosition(canvas);
            ellipse = new Ellipse();
            ellipse.Stroke = SystemColors.WindowTextBrush;
            ellipse.StrokeThickness = 1;
            ellipse.Width = 0;
            ellipse.Height = 0;
            canvas.Children.Add(ellipse);
            Canvas.SetLeft(ellipse, ptCenter.X);
            Canvas.SetTop(ellipse, ptCenter.Y);

            CaptureMouse();
            isDrawing = true;
        }

        protected override void OnMouseRightButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseRightButtonDown(e);

            if (isDrawing)
            {
                return;
            }

            ptMouseStart = e.GetPosition(canvas);
            elDragging = canvas.InputHitTest(ptMouseStart) as FrameworkElement;

            if (elDragging != null)
            {
                ptElementStart = new Point(Canvas.GetLeft(elDragging), Canvas.GetTop(elDragging));
                isDragging = true;
            }
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.ChangedButton == MouseButton.Middle)
            {
                Shape shape = canvas.InputHitTest(e.GetPosition(canvas)) as Shape;

                if (shape != null)
                {
                    shape.Fill = (shape.Fill == Brushes.Red ? Brushes.Transparent : Brushes.Red);
                }
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            Point ptMouse = e.GetPosition(canvas);

            if (isDrawing)
            {
                double dRadius = Math.Sqrt(Math.Pow(ptCenter.X = ptMouse.X, 2) + Math.Pow(ptCenter.Y - ptMouse.Y, 2));

                Canvas.SetLeft(ellipse, ptCenter.X - dRadius);
                Canvas.SetTop(ellipse, ptCenter.Y - dRadius);
                ellipse.Width = 2 * dRadius;
                ellipse.Height = 2 * dRadius;
            }
            else if (isDragging)
            {
                Canvas.SetLeft(elDragging, ptElementStart.X + ptMouse.X - ptMouseStart.X);
                Canvas.SetTop(elDragging, ptElementStart.Y + ptMouse.Y - ptMouseStart.Y);
            }
        }

        protected override void OnMouseUp(MouseButtonEventArgs e)
        {
            base.OnMouseUp(e);

            if (isDrawing && e.ChangedButton == MouseButton.Left)
            {
                ellipse.Stroke = Brushes.Blue;
                ellipse.StrokeThickness = Math.Min(24, ellipse.Width / 2);
                ellipse.Fill = Brushes.Red;
                isDrawing = false;
                ReleaseMouseCapture();
            }
            else if (isDragging && e.ChangedButton == MouseButton.Right)
            {
                isDragging = false;
            }
        }

        protected override void OnTextInput(TextCompositionEventArgs e)
        {
            base.OnTextInput(e);

            if (e.Text.IndexOf('\x1B') != -1)
            {
                if (isDrawing)
                {
                    ReleaseMouseCapture();
                }
                else if (isDragging)
                {
                    Canvas.SetLeft(elDragging, ptElementStart.X);
                    Canvas.SetTop(elDragging, ptElementStart.Y);
                    isDragging = false;
                }
            }
        }

        protected override void OnLostMouseCapture(MouseEventArgs e)
        {
            base.OnLostMouseCapture(e);

            if (isDrawing)
            {
                canvas.Children.Remove(ellipse);
                isDrawing = false;
            }
        }
    }
}
