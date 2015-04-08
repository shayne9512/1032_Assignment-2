using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace myMines
{
    class Square : Button
    {
        private int _row;
        private int _col;
        private bool _dismantled = false;
        private bool _minded = false;
        private bool _opened = false;

        public int ROW
        {
            get { return _row; }
            set { _row = value; }
        }

        public int COL
        {
            get { return _col; }
            set { _col = value; }
        }

        public bool Dismantled
        {
            get { return _dismantled; }
            set { _dismantled = value; }
        }

        public bool Minded
        {
            get { return _minded; }
            set { _minded = value; }
        }

        public bool Opened
        {
            get { return _opened; }
            set { _opened = value; }
        }

        public Square()
            : base()
        {
            this.Background = System.Windows.Media.Brushes.LightGray;

            //this.Background = new System.Windows.Media.SolidColorBrush(
            //    System.Windows.Media.Colors.Green);

            //this.Background = SystemColors.ControlBrush;

            //byte red = 0; byte green = 255; byte blue = 0;
            //this.Background = new System.Windows.Media.SolidColorBrush(
            //    System.Windows.Media.Color.FromRgb(red, green, blue));
        }

        public void LeftClick()
        {
            this.IsEnabled = false;
            this.BorderBrush = System.Windows.Media.Brushes.Black;
        }

        public void DismantleClick()
        {
            if (!_opened)
            {
                if (_dismantled)
                {
                    _dismantled = false;
                    this.Content = "?";
                }
                else
                {
                    _dismantled = true;
                    this.Foreground = System.Windows.Media.Brushes.Green;
                    this.Content = "★";
                }
            }
        }
    }
}
