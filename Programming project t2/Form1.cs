﻿using System;
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
        //creates a two-dimensional array 
        PictureBox[,] gameBoard = new PictureBox[7, 7];
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //read all the information from the csv file and stores each value into an array (e.g puzzleconfigarray[0] = white)
            string[] puzzleconfigarray = File.ReadAllLines(@"puzzleconfig.csv");

            //
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
                greenmoveup(this, e, "Green");
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

        private void greenmoveup(object sender, EventArgs e, string color)
        {
            bool movelock = true;
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (gameBoard[i, j].BackColor == Color.Green && gameBoard[i, j - 1].BackColor == Color.Green)
                    {
                        if (i > 0)
                        {
                            if (gameBoard[i - 1, j].BackColor == Color.White && gameBoard[i - 1, j - 1].BackColor == Color.White)
                            {
                                gameBoard[i - 1, j].BackColor = Color.Green;
                                gameBoard[i - 1, j - 1].BackColor = Color.Green;
                                gameBoard[i, j].BackColor = Color.White;
                                gameBoard[i, j - 1].BackColor = Color.White;
                                movelock = false;
                                /*
                                if (gameBoard[3 , 7].BackColor == Color.Green && gameBoard[4 , 7].BackColor == Color.Green )
                                {
                                  MessageBox.Show("congrats!");
                                }
                                */
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
                greenmovedown(this, e, "Green");
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

        private void greenmovedown(object sender, EventArgs e, string color)
        {
            bool movelock = true;
            for (int i = 6; i > -1; i--)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (gameBoard[i, j].BackColor == Color.Green && gameBoard[i, j - 1].BackColor == Color.Green)
                    {
                        if (i < 6)
                        {
                            if (gameBoard[i + 1, j].BackColor == Color.White && gameBoard[i + 1, j - 1].BackColor == Color.White)
                            {
                                gameBoard[i + 1, j].BackColor = Color.Green;
                                gameBoard[i + 1, j - 1].BackColor = Color.Green;
                                gameBoard[i, j].BackColor = Color.White;
                                gameBoard[i, j - 1].BackColor = Color.White;
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

        private void movedown(object sender, EventArgs e, string color)
        {
            bool movelock = true;
            for (int i = 6; i > -1; i--)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (gameBoard[i, j].BackColor == Color.FromName(comboBox.Text))
                    {
                        if (i < 6)
                        {
                            if (gameBoard[i + 1, j].BackColor == Color.White)
                            {
                                gameBoard[i + 1, j].BackColor = Color.FromName(color);
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

        private void buttonleft_Click(object sender, EventArgs e)
        {

            if (comboBox.Text == "Green")
            {
                greenmoveleft(this, e, "Green");
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

        private void greenmoveleft(object sender, EventArgs e, string color)
        {
            bool movelock = true;
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (gameBoard[i, j].BackColor == Color.Green && gameBoard[i - 1, j].BackColor == Color.Green)
                    {

                        if (j > 0)
                        {
                            if (gameBoard[i, j - 1].BackColor == Color.White && gameBoard[i - 1, j - 1].BackColor == Color.White)
                            {
                                gameBoard[i, j - 1].BackColor = Color.Green;
                                gameBoard[i - 1, j - 1].BackColor = Color.Green;
                                gameBoard[i, j].BackColor = Color.White;
                                gameBoard[i - 1, j].BackColor = Color.White;
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

        private void buttonright_Click(object sender, EventArgs e)
        {
            if (comboBox.Text == "Green")
            {
                greenmoveright(this, e, "Green");
            }
            else if (comboBox.Text == "Red")
            {
                moveright(this, e, "Red");
            }
            else if (comboBox.Text == "Brown")
            {
                moveright(this, e, "Brown");
            }
            else if (comboBox.Text == "Pink")
            {
                moveright(this, e, "Pink");
            }
            else if (comboBox.Text == "Black")
            {
                moveright(this, e, "Black");
            }
            else
            {
                MessageBox.Show("Invalid move. Please try again.");
            }
        }

        private void greenmoveright(object sender, EventArgs e, string color)
        {
            bool movelock = true;
            for (int i = 0; i < 7; i++)
            {
                for (int j = 6; j > -1; j--)
                {
                    if (gameBoard[i, j].BackColor == Color.Green && gameBoard[i - 1, j].BackColor == Color.Green)
                    {

                        if (j < 6)
                        {
                            if (gameBoard[i, j + 1].BackColor == Color.White && gameBoard[i - 1, j + 1].BackColor == Color.White)
                            {
                                gameBoard[i, j + 1].BackColor = Color.Green;
                                gameBoard[i - 1, j + 1].BackColor = Color.Green;
                                gameBoard[i, j].BackColor = Color.White;
                                gameBoard[i - 1, j].BackColor = Color.White;
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

        private void moveright(object sender, EventArgs e, string color)
        {
            bool movelock = true;
            for (int i = 0; i < 7; i++)
            {
                for (int j = 6; j > -1; j--)
                {
                    if (gameBoard[i, j].BackColor == Color.FromName(comboBox.Text))
                    {

                        if (j < 6)
                        {
                            if (gameBoard[i, j + 1].BackColor == Color.White)
                            {
                                gameBoard[i, j + 1].BackColor = Color.FromName(color);
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

        public void endgame(object sender, EventArgs e)
        {
            MessageBox.Show("Congratulations! you have completed the game :)");
        }
    }
}
