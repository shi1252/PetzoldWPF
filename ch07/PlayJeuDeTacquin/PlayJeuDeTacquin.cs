using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Threading;

namespace PlayJeuDeTacquin
{
    class PlayJeuDeTacquin : Window
    {
        const int NumberRows = 4;
        const int NumberCols = 4;

        UniformGrid uniformGrid;
        int xEmpty, yEmpty, iCounter;
        Key[] keys = { Key.Left, Key.Right, Key.Up, Key.Down };
        Random rand;
        UIElement elEmptySpare = new Empty();

        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new PlayJeuDeTacquin());
        }

        PlayJeuDeTacquin()
        {
            Title = "Jeu De Tacquin";
            SizeToContent = SizeToContent.WidthAndHeight;
            ResizeMode = ResizeMode.CanResize;
            Background = SystemColors.ControlBrush;

            StackPanel stack = new StackPanel();
            Content = stack;

            Button btn = new Button();
            btn.Content = "_Scramble";
            btn.Margin = new Thickness(10);
            btn.HorizontalAlignment = HorizontalAlignment.Center;
            btn.Click += ScrambleOnClick;
            stack.Children.Add(btn);

            Border bord = new Border();
            bord.BorderBrush = SystemColors.ControlDarkBrush;
            bord.BorderThickness = new Thickness(1);
            stack.Children.Add(bord);

            uniformGrid = new UniformGrid();
            uniformGrid.Rows = NumberRows;
            uniformGrid.Columns = NumberCols;
            bord.Child = uniformGrid;

            for (int i=0;i<NumberRows * NumberCols - 1;++i)
            {
                Tile tile = new Tile();
                tile.Text = (i + 1).ToString();
                tile.MouseLeftButtonDown += TileOnMouseLeftButtonDown;
                uniformGrid.Children.Add(tile);
            }

            uniformGrid.Children.Add(new Empty());
            xEmpty = NumberCols - 1;
            yEmpty = NumberRows - 1;
        }

        private void TileOnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tile tile = sender as Tile;

            int iMove = uniformGrid.Children.IndexOf(tile);
            int xMove = iMove % NumberCols;
            int yMove = iMove / NumberCols;

            if (xMove == xEmpty)
            {
                while(yMove != yEmpty)
                {
                    MoveTile(xMove, yEmpty + (yMove - yEmpty) / Math.Abs(yMove - yEmpty));
                }
            }

            if (yMove == yEmpty)
            {
                while(xMove != xEmpty)
                {
                    MoveTile(xEmpty + (xMove - xEmpty) / Math.Abs(xMove - xEmpty), yMove);
                }
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            switch(e.Key)
            {
                case Key.Right:
                    MoveTile(xEmpty - 1, yEmpty);
                    break;
                case Key.Left:
                    MoveTile(xEmpty + 1, yEmpty);
                    break;
                case Key.Down:
                    MoveTile(xEmpty, yEmpty - 1);
                    break;
                case Key.Up:
                    MoveTile(xEmpty, yEmpty + 1);
                    break;
            }
        }

        private void ScrambleOnClick(object sender, RoutedEventArgs e)
        {
            rand = new Random();
            iCounter = 16 * NumberCols * NumberRows;

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(10);
            timer.Tick += TimerOnTick;
            timer.Start();
        }

        private void TimerOnTick(object sender, EventArgs e)
        {
            for (int i=0;i<5;++i)
            {
                MoveTile(xEmpty, yEmpty + rand.Next(3) - 1);
                MoveTile(xEmpty + rand.Next(3) - 1, yEmpty);
            }

            if (0 == iCounter--)
            {
                (sender as DispatcherTimer).Stop();
            }
        }

        private void MoveTile(int xTile, int yTile)
        {
            if ((xTile == xEmpty && yTile == yEmpty) || xTile < 0 || xTile >= NumberCols || yTile < 0 || yTile >= NumberRows)
                return;

            int iTile = NumberCols * yTile + xTile;
            int iEmpty = NumberCols * yEmpty + xEmpty;

            UIElement elTile = uniformGrid.Children[iTile];
            UIElement elEmpty = uniformGrid.Children[iEmpty];

            uniformGrid.Children.RemoveAt(iTile);
            uniformGrid.Children.Insert(iTile, elEmptySpare);
            uniformGrid.Children.RemoveAt(iEmpty);
            uniformGrid.Children.Insert(iEmpty, elTile);

            xEmpty = xTile;
            yEmpty = yTile;
            elEmptySpare = elEmpty;
        }

    }
}
