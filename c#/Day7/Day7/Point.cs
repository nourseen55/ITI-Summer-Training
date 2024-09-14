﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7
{
    internal class Point
    {
        public int x;
        public int y;
        public Point()
        {
            x = y = 10;
        }
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public int X { get { return x; } set { x = value; } }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
    }
}
