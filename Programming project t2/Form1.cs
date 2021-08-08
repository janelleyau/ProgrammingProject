using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Programming_project_t2
{
    public partial class Form1 : Form
    {
        PictureBox[,] gameBoard = new PictureBox[7, 7];
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            string[] puzzleconfigarray = File.ReadAllLines(@"puzzleconfig.csv");

            int index = 1; 
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    gameBoard[i, j] = (PictureBox)Controls.Find("pictureBox" +
                    (index).ToString(), true)[0];
                    index++;
                }
            }

            
            int startingconfigindex = 0;
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    gameBoard[i, j].BackColor =
                    Color.FromName(puzzleconfigarray[startingconfigindex]);
                    startingconfigindex++;
                }
            }
            

        }

        private void buttonup_Click(object sender, EventArgs e)
        {
            if (comboBox.Text == "Green")
            {
                moveup(this, e, "Green");
            }
            else if (comboBox.Text == "Yellow")
            {
                moveup(this, e, "Yellow");
            }
            else if (comboBox.Text == "Orange")
            {
                moveup(this, e, "Orange");
            }
            else if (comboBox.Text == "Purple")
            {
                moveup(this, e, "Purple");
            }
            else if (comboBox.Text == "Gray")
            {
                moveup(this, e, "Gray");
            }
            else
            {
                MessageBox.Show("Invalid move. Please try again.");
            }
        }

        private void moveup(object sender, EventArgs e, string color)
        {
            bool movelock = true;
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (gameBoard[i, j].BackColor == Color.FromName(comboBox.Text))
                    {
                        if (i > 0)
                        {
                            if (gameBoard[i - 1, j].BackColor == Color.White)
                            {
                                gameBoard[i - 1, j].BackColor = Color.FromName(color);
                                gameBoard[i, j].BackColor = Color.White;
                                movelock = false;
                            }
                        }
                    }
                }
            }

            if (movelock == true)
            {
                MessageBox.Show("invalid move. Please try again.");
            }
        }

        private void buttondown_Click(object sender, EventArgs e)
        {
            if (comboBox.Text == "Green")
            {
                movedown(this, e, "Green");
            }
            else if (comboBox.Text == "Yellow")
            {
                movedown(this, e, "Yellow");
            }
            else if (comboBox.Text == "Orange")
            {
                movedown(this, e, "Orange");
            }
            else if (comboBox.Text == "Purple")
            {
                movedown(this, e, "Purple");
            }
            else if (comboBox.Text == "Gray")
            {
                movedown(this, e, "Gray");
            }
            else
            {
                MessageBox.Show("Invalid move. Please try again.");
            }
        }


        private void movedown(object sender, EventArgs e, string color)
        {
            bool movelock = true;
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (gameBoard[i, j].BackColor == Color.FromName(comboBox.Text))
                    {
                        if (i < 6)
                        {
                            if (gameBoard[i + 2, j].BackColor == Color.White)
                            {
                                gameBoard[i + 2, j].BackColor = Color.FromName(color);
                                gameBoard[i , j].BackColor = Color.White;
                                movelock = false;
                            }
                        }
                    }
                }
            }

            if (movelock == true)
            {
                MessageBox.Show("Invalid move. Please try again.");
            }
        }

        
        private void buttonleft_Click(object sender, EventArgs e)
        {
            
            if (comboBox.Text == "Green")
            {
                moveleft(this, e, "Green");
            }
            else if (comboBox.Text == "Red")
            {
                moveleft(this, e, "Red");
            }
            else if (comboBox.Text == "Brown")
            {
                moveleft(this, e, "Brown");
            }
            else if (comboBox.Text == "Pink")
            {
                moveleft(this, e, "Pink");
            }
            else if (comboBox.Text == "Black")
            {
                moveleft(this, e, "Black");
            }
            else
            {
                MessageBox.Show("Invalid move. Please try again.");
            }

        }

        private void moveleft(object sender, EventArgs e, string color)
        {
            bool movelock = true;
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (gameBoard[i, j].BackColor == Color.FromName(comboBox.Text))
                    {

                        if (j > 0)
                        {
                            if (gameBoard[i, j - 1].BackColor == Color.White)
                            {
                                gameBoard[i, j - 1].BackColor = Color.FromName(color);
                                gameBoard[i, j].BackColor = Color.White;
                                movelock = false;
                            }

                        }
                    }
                }
            }
            if (movelock == true)
            {
                MessageBox.Show("Invalid move. Please try again.");
            }
        }
    }
}
