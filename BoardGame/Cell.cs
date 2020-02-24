using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGame
{
    public class Cell
    {
        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int Value { get; set; }

        public bool IsEmpty() => Value == 0;
    }
}
