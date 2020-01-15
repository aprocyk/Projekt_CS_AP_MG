namespace Minesweeper
{
    partial class MinesweeperForm
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.tileGrid = new Minesweeper.MinesweeperForm.TileGrid();
            this.gameButton = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.gameButton)).BeginInit();
            this.SuspendLayout();
            // 
            // tileGrid
            // 
            this.tileGrid.Location = new System.Drawing.Point(10, 50);
            this.tileGrid.Name = "tileGrid";
            this.tileGrid.Size = new System.Drawing.Size(445, 416);
            this.tileGrid.TabIndex = 0;
            // 
            // gameButton
            // 
            this.gameButton.BackgroundImage = global::Minesweeper.Properties.Resources.gbut;
            this.gameButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.gameButton.Location = new System.Drawing.Point(211, 12);
            this.gameButton.Name = "gameButton";
            this.gameButton.Size = new System.Drawing.Size(35, 35);
            this.gameButton.TabIndex = 0;
            this.gameButton.TabStop = false;
            this.gameButton.Click += new System.EventHandler(this.LoadGame);
            // 
            // MinesweeperForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(467, 478);
            this.Controls.Add(this.tileGrid);
            this.Controls.Add(this.gameButton);
            this.MaximizeBox = false;
            this.Name = "MinesweeperForm";
            this.Text = "MineSweeper";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.gameButton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private TileGrid tileGrid;
        private System.Windows.Forms.PictureBox gameButton;
    }
}

