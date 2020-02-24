using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BoardGame
{
    public class Board
    {
        public Random _rnd;
        public Cell[,] Spaces;

        /// <param name="dimensionalSize">Sets the number of spaces in the X and Y dimensions.</param>
        public Board(int dimensionalSize)
        {
            _rnd = new Random();
            Spaces = new Cell[dimensionalSize, dimensionalSize];
            for (int x = 0; x < dimensionalSize; x++)
            {
                for (int y = 0; y < dimensionalSize; y++)
                {
                    Spaces[x, y] = new Cell(x, y);
                }
            }
        }
        
        public Cell GetSpace(int x, int y)
        {
            return Spaces[x, y];
        }

        public Cell[,] GetAllSpaces() => Spaces;

        public void SetSpace(int x, int y, int value)
        {
            Spaces[x, y].Value = value;
        }

        /// <summary>
        /// Returns a list of empty spaces and also pops out an integer representing the number of spaces found.
        /// </summary>
        public List<Cell> EmptySpaces(out int length)
        {
            var spaces = (from Cell space in Spaces
                          where space.IsEmpty()
                          select space).ToList();
            length = spaces.Count();
            return spaces;
        }

        public void InsertRandomValue()
        {
            var spaces = EmptySpaces(out var length);
            if (spaces.Count > 0) 
                spaces[_rnd.Next(length)].Value = 2;
        }
    }
}
