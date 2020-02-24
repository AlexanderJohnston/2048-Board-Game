using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGame
{
    public class Cube
    {
        public List<Board> Faces = new List<Board>();

        public Cube()
        {
            // Construct the six faces of the cube.
            for (int i = 0; i < 6; i++) 
            {
                Faces[i] = new Board(4);
            }
        }

    }
}
