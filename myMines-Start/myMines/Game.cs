using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls.Primitives;

namespace myMines
{
    class Game
    {
        private int _height;
        private int _width;
        private int _mines;
        private int _safetyareas;
        private Window1 _window;
        private Square[,] _squares;
        private bool _IsStarted = false;

        public Game(Window1 window, int width, int height, int mines)
        {
            _window = window;
            _width = width;
            _height = height;
            _mines = mines;
            _safetyareas = _width * _height - _mines;
            _window.ugdBoard.Children.Clear();
            _window.ugdBoard.Columns = _width;
            _window.ugdBoard.Rows = _height;
        }

        public Game(Window1 window)
            : this(window, 15, 15, 30)
        {
        }

        public bool IsStarted
        {
            get { return _IsStarted; }
            set { _IsStarted = value; }
        }

        public bool IsFinished
        {
            get { return _safetyareas <= 0; }
        }

        public void Start()
        {
            _squares = new Square[_height,_width];
            for (int row = 0; row < _height; row++)
                for (int col = 0; col< _width; col++)
                {
                    Square s = new Square();
                    s.ROW = row;
                    s.COL = col;
                    _squares[row, col] = s;
                    _window.ugdBoard.Children.Add(s);
                }

            int b = 0;
            Random r = new Random();
            while (b < _mines)
            {
                int row = r.Next(_height);
                int col = r.Next(_width);

                Square s = _squares[row, col];
                if (!s.Minded)
                {
                    s.Minded = true;
                    b++;
                }
            }
            _IsStarted = true;
        }

        public void Click(Square s)
        {
            if (!s.Dismantled)
                if (s.Minded)//爆炸
                {
                    _window.timer.Stop();
                    foreach (Square b in _squares)
                        if (b.Minded)
                        {
                            b.Foreground = System.Windows.Media.Brushes.Red;
                            b.Content = "●";
                        }
                    _IsStarted = false;
                }
                else
                    Open(s);
        }

        public void Open(Square s)
        {
            if (!s.Opened && !s.Dismantled)
            {
                s.Opened = true;
                s.LeftClick();
                _safetyareas--;
                if (_safetyareas <= 0)
                {
                    _IsStarted = false;
                    _window.timer.Stop();
                }
                int bombs = 0;
                if (IsBomb(s.ROW - 1, s.COL - 1)) bombs++;
                if (IsBomb(s.ROW, s.COL - 1)) bombs++;
                if (IsBomb(s.ROW + 1, s.COL - 1)) bombs++;
                if (IsBomb(s.ROW - 1, s.COL)) bombs++;
                if (IsBomb(s.ROW + 1, s.COL)) bombs++;
                if (IsBomb(s.ROW - 1, s.COL + 1)) bombs++;
                if (IsBomb(s.ROW, s.COL + 1)) bombs++;
                if (IsBomb(s.ROW + 1, s.COL + 1)) bombs++;

                if (bombs > 0)
                {
                    s.Content = bombs.ToString();
                    switch (bombs)
                    {
                        case 1:
                            s.Foreground = System.Windows.Media.Brushes.Blue;
                            break;
                        case 2:
                            s.Foreground = System.Windows.Media.Brushes.Green;
                            break;
                        case 3:
                            s.Foreground = System.Windows.Media.Brushes.Red;
                            break;
                        case 4:
                            s.Foreground = System.Windows.Media.Brushes.DarkBlue;
                            break;
                        case 5:
                            s.Foreground = System.Windows.Media.Brushes.DarkRed;
                            break;
                        case 6:
                            s.Foreground = System.Windows.Media.Brushes.LightBlue;
                            break;
                        case 7:
                            s.Foreground = System.Windows.Media.Brushes.Orange;
                            break;
                        case 8:
                            s.Foreground = System.Windows.Media.Brushes.Ivory;
                            break;
                    }
                }
                else
                {
                    //打開
                    OpenSpot(s.ROW - 1, s.COL - 1);
                    OpenSpot(s.ROW, s.COL - 1);
                    OpenSpot(s.ROW + 1, s.COL - 1);
                    OpenSpot(s.ROW - 1, s.COL);
                    OpenSpot(s.ROW + 1, s.COL);
                    OpenSpot(s.ROW - 1, s.COL + 1);
                    OpenSpot(s.ROW, s.COL + 1);
                    OpenSpot(s.ROW + 1, s.COL + 1);
                }
            }
        }

        private bool IsBomb(int row, int col)
        {
            bool result = false;
            if (row >= 0 && row < _height && col >= 0 && col < _width)
                result = _squares[row, col].Minded;
            return result;
        }

        private void OpenSpot(int row, int col)
        {
            if (row >= 0 && row < _height && col >= 0 && col < _width)
            {
                Square s = _squares[row, col];
                Open(s);
            }
        }
    }
}
