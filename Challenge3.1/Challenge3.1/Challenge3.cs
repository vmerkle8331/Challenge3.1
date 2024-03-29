using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Challenge3._1
{
    public partial class Challenge3 : Form
    {

        Button[,] theGrid = new Button[10, 10];
        Random random = new Random();

        public Challenge3()
        {
            InitializeComponent();
            InstantiateButtons();
            CheckerFill(Color.Red, Color.Black);
        }

        public void InstantiateButtons()
        {
            Size btnSize = new Size(24, 24);


            for (int row = 0; row < theGrid.GetLength(0); row++)
            {
                for (int col = 0; col < theGrid.GetLength(1); col++)
                {
                    theGrid[row, col] = new Button();
                    theGrid[row, col].Size = btnSize;
                    theGrid[row, col].Location = new Point(col * btnSize.Width, row * btnSize.Height);
                    theGrid[row, col].Click += ButtonClickedHandler;
                    this.Controls.Add(theGrid[row, col]);

                }
            }

            this.Refresh();
        }

        public void CheckerFill(Color color1, Color color2)
        {
            for (int row = 0; row < theGrid.GetLength(0); row++)
            {
                for (int col = 0; col < theGrid.GetLength(1); col++)
                {
                    theGrid[row, col].BackColor = ((row + col) % 2 == 0) ? color1 : color2;
                }
            }
        }

        public void ButtonClickedHandler(object sender, EventArgs e)
        {
            Color oldColor = ((Button)sender).BackColor;
            Color newColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));

            foreach(Button button in theGrid)
            {
                if (button.BackColor == oldColor)
                {
                    button.BackColor = newColor;
                }
            }

        }

    }
}
