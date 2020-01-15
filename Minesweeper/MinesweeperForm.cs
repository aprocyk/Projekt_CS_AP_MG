using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Minesweeper.Properties;

namespace Minesweeper
{
    public partial class MinesweeperForm : Form
    {
        private Difficulty difficulty;

        public MinesweeperForm()
        {
            InitializeComponent();
            this.LoadGame(null, null);
        }

        private enum Difficulty { Expert, Intermediate, Beginner }

        private void LoadGame(object sender, EventArgs e)
        {
            int x, y, mines;
            switch (this.difficulty)
            {
                case Difficulty.Beginner:
                    x = y = 9;
                    mines = 10;
                    break;
                case Difficulty.Intermediate:
                    x = y = 16;
                    mines = 40;
                    break;
                case Difficulty.Expert:
                    x = 30;
                    y = 16;
                    mines = 99;
                    break;
                default:
                    throw new InvalidOperationException("Choose existing difficulty!");
            }
            this.tileGrid.LoadGrid(new Size(x,y), mines);
            this.MaximumSize = this.MaximumSize = new Size(this.tileGrid.Width + 36, this.tileGrid.Height + 98);
        }
        
        private class TileGrid : Panel
        {
            private Size gridSize;
            private int mines;
            private int flags;
            private void Tile_MouseDown(object sender, MouseEventArgs e)
            {

            }
            internal void LoadGrid(Size gridSize, int mines)
            {
                this.Controls.Clear();
                this.gridSize = gridSize;
                this.mines = this.flags = mines;
                this.Size = new Size(gridSize.Width * Tile.LENGTH, gridSize.Height * Tile.LENGTH);
                for (int x = 0; x < gridSize.Width; x++)
                {
                    for(int y = 0; y < gridSize.Height; y++)
                    {
                        Tile tile = new Tile(x,y);
                        tile.MouseDown += Tile_MouseDown;
                        this.Controls.Add(tile);
                    }
                }
            }
            private class Tile : PictureBox
            {
                internal const int LENGTH = 25;

                internal Point GridPosition;
                internal Tile(int x, int y)
                {
                    this.Name = $"Tile_{x}_{y}";
                    this.Location = new Point(x * LENGTH, y * LENGTH);
                    this.GridPosition = new Point(x, y);
                    this.Size = new Size(LENGTH, LENGTH);
                    this.Image = Resources.tile;
                    this.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }
    }
}
