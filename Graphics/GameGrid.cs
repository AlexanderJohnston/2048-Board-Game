using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BoardGame;

namespace Graphics
{
    public partial class GameGrid : UserControl
    {

        public Board Logic;

        public int Dimensions;

        public bool ReadyForNewValue;

        public GameGrid(int dimensions)
        {
            this.Width = 800;
            this.Height = 800;

            Dimensions = dimensions;
            Logic = new Board(dimensions);
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            
            // Add a 2 somewhere on the board in an empty space then draw it for interaction.
            if (ReadyForNewValue)
            {
                Logic.InsertRandomValue();
                ReadyForNewValue = false;
            }
            DrawBoard(e);
        }

        private void DrawBoard(PaintEventArgs e)
        {
            int columns = Dimensions;
            int rows = Dimensions;
            int row;
            int column;

            using var pen = new Pen(Color.Black, 6);
            using var brush = new SolidBrush(Color.White);

            for (column = 0; column < columns; column++)
            {
                for (row = 0; row < rows; row++)
                {
                    var x = 100 * column;
                    var y = 100 * row;
                    e.Graphics.FillRectangle(brush, new Rectangle(new Point(x, y), new Size(100, 100)));
                    e.Graphics.DrawRectangle(pen, new Rectangle(new Point(x, y), new Size(100, 100)));
                    DrawSquare(e, row, column);
                }
            }
        }

        private void DrawSquare(PaintEventArgs e, int row, int column)
        {
            // Reach into the game logic for a value
            var spaces = Logic.GetAllSpaces();
            var selected = spaces[row, column];

            if (selected.IsEmpty())
                return;

            var valueToDraw = selected.Value.ToString();

            // How to draw numbers in WinForms...
            var font = new Font("Arial", 48);
            var brush = new SolidBrush(Color.Red);
            var format = new StringFormat();
            var x = column * 100;
            var y = row * 100;
            e.Graphics.DrawString(valueToDraw, font, brush, x, y, format);
        }

    }
}
