using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Graphics
{
    public partial class Window : Form
    {
        public GameGrid Game;

        public Window()
        {
            var dimensions = 4;

            // Don't paint the game just because it is resized.
            ResizeRedraw = false;

            InitializeComponent();
            Game = new GameGrid(dimensions);
            GamePanel.Controls.Add(Game);
        }

        // Capture user input

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            var validKeys = new Input (new Keys[] { Keys.Up, Keys.Left, Keys.Down, Keys.Right });
            if (validKeys.Contains(keyData))
            {
                Game.ReadyForNewValue = true;
                Game.Invalidate(); // Re-paint the board.
                return true;
            }
            else 
            {
                return false;
            }
        }

        public class Input
        {
            public List<Keys> AllowableKeys;

            public Input(Keys[] keys)
            {
                AllowableKeys = keys.ToList();
            }

            public bool Contains(Keys key) => AllowableKeys.Any(allowed => key == allowed);
        }
    }
}
