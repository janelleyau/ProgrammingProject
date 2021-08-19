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
using System.Globalization;

namespace Programming_project_t2
{
    public partial class Form1 : Form
    {
        //This creates a two-dimensional array 
        PictureBox[,] gameBoard = new PictureBox[7, 7];

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //displays messagebox at the start that gives the user simple instructions on how to use the program. 
            MessageBox.Show("Welcome! To start the game, select a colour from the box on the top left side of the screen and press the controls below to move the piece. :D");

            /* This line of code reads all the information from the csv file and stores each value into an array. Each new line represents a 
            new slot in the array and the code stops when there is a blank line. 
            e.g puzzleconfigarray[0] = white
            */
            string[] puzzleconfigarray = File.ReadAllLines(@"puzzleconfig.csv");


            /* The index variable helps in tracking which picturebox is the user up to. The nested loop below loads the current pictureboxes
            from the windows form and puts it into an array. This makes it easier to continuously loop over and change the state of the picturebox.
            e.g if the index equals to 5 then it would load picturebox5 into the two dimensional array.
            */
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

            //This line of code loops through the whole gameboard and assigns each picturebox with the designated colour. 
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

        /* When the user presses the up button after selecting a colour, the selected colour piece will move up.
        An if/else statement is used to check if the selected colour can move up and if it can, it runs a subprogram to move the piece. 
        If the move is not allowed, then a messagebox will pop up stating that it is an invalid move.
        */
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

        /* This is a function specifically made for the green block to move up. It is similar to the normal moveup subprogram except prevents the piece from accidently moving
        in one side and not the other. 
        */
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

                            }
                        }
                    }
                }
            }


            if (movelock == true)
            {
                MessageBox.Show("invalid move. Please try again.");
            }

            if (gameBoard[2, 6].BackColor == Color.Green && gameBoard[3, 6].BackColor == Color.Green)
            {
                MessageBox.Show("Congratulations! You have completed the game :)");
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

            if (gameBoard[2, 6].BackColor == Color.Green && gameBoard[3, 6].BackColor == Color.Green)
            {
                MessageBox.Show("Congratulations! You have completed the game :)");
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

            if (gameBoard[2, 6].BackColor == Color.Green && gameBoard[3, 6].BackColor == Color.Green)
            {
                MessageBox.Show("Congratulations! You have completed the game :)");
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

            if (gameBoard[2, 6].BackColor == Color.Green && gameBoard[3, 6].BackColor == Color.Green)
            {
                MessageBox.Show("Congratulations! You have completed the game :)");
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

    }
}
