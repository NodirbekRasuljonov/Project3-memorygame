using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Project3
{
    public partial class Home : Form
    {
        
        Random r = new Random();
        int indexx = 1;
        int lives = 3;
        int tiles = 5;
        Main m1;
        Timer increaseTimerr;
        Timer decreaseTimerr;
        double seconds = 1.0;


        public Home(Main m)
        {
            InitializeComponent();
            this.m1= m;
        }

        private void backToMainMenu_Click(object sender, EventArgs e)
        {
            Main m=new Main();
            m.Show();
            this.Hide();
        }
       
        private void Home_Load(object sender, EventArgs e)
        {
            
            showLives();
            showTiles();
            nameLabel.Text = m1.nameTextBox.Text;
            buttonsTable.Controls.Clear();
            for (int row = 0; row < 5; row++)
            {
                for (int column = 0; column < 5; column++)
                {
                    Button button = new Button();

                    button.Name = $"btn_{row}_{column}";
                    button.Width = 82;
                    button.Height = 82;
                    button.BackColor = Color.CornflowerBlue;
                    button.Enabled = false;


                    //button.Text = $"{row}_{column}";
                    buttonsTable.Controls.Add(button);

                }

            }

        }


       

        private void buttonsTable_Paint(object sender, PaintEventArgs e)
        {

        }



        //start game button
        private void startGameButton_Click(object sender, EventArgs e)
        {
            decreaseTimerr?.Stop();
            increaseTimerr?.Stop();
            Timer tm = new Timer();
            tm.Interval = 2000;
            tm.Start();
            indexx = 1;
            lives = 3;
            tiles = 5;
            int index = 0;
            showLives();
            showTiles();



            

            decreaseTimer();


            buttonsTable.Controls.Clear();


            Random random = new Random();
            //generate random numbers
            List<int> numbers = new List<int>();
            for (int i = 1; i <= 6; i++)
            {
                numbers.Add(i);
            }



            //generate 5 random places 
            HashSet<int> randomIndices = new HashSet<int>();

            while (randomIndices.Count < 5)
            {
                randomIndices.Add(random.Next(25));
            }
           
            //generate buttons with random numbers in random places
            for (int row = 0; row < 5; row++)
            {
                for (int column = 0; column < 5; column++)
                {
                    Button button = new Button();

                    button.Name = $"btn_{row}_{column}";
                    button.Width = 82;
                    button.Height = 82;
                    button.BackColor = Color.CornflowerBlue;
                    button.Enabled = false;
                    button.Click += Button_Click;

                    if (randomIndices.Contains(row * 5 + column))
                    {
                        if (tm.Enabled)
                        {
                            button.Text = numbers[index].ToString(); // Assign the random number to the button
                            button.Font = new Font("French Script MT", 18);
                            button.Enabled = false;
                            index++;

                        }

                        tm.Tick += delegate (object s, EventArgs w)
                        {
                            button.Enabled = true;
                            button.ForeColor = button.BackColor;
                            tm.Stop();
                            EnableAllButtons();

                        };
                        

                    }
                    else
                    {
    
                    }
                    buttonsTable.Controls.Add(button);
                }
            }

            

        }


        //enabling all buttons;
        private void EnableAllButtons()
        {
            foreach (Control control in buttonsTable.Controls)
            {
                if (control is Button button)
                {
                    button.Enabled = true;
                }
            }
        }


        //decreasing time;
        private void decreaseTimer()
        {
            int count = 2;
            decreaseTimerr = new Timer();
            timerLabel.Text = count.ToString();
            decreaseTimerr.Interval = 1000;
            decreaseTimerr.Stop();
            decreaseTimerr.Start();
            decreaseTimerr.Tick += (s, ev) =>
            {
                count--;
                if (count >= 0)
                {
                    timerLabel.Text = count.ToString();
                }
                else
                {
                    decreaseTimerr.Stop();
                    increaseTimer();
                }
            };
        }

        //increasing time;
        private void increaseTimer()
        {
            seconds = 1.0;
            increaseTimerr= new Timer();
            timerLabel.Text = seconds.ToString();
            increaseTimerr.Interval = 100;
            increaseTimerr.Stop();
            increaseTimerr.Start();
            increaseTimerr.Tick += (s, ev) =>
            {
                seconds+=0.1;
                if (seconds <= 10)
                {
                    timerLabel.Text = seconds.ToString("0.0");
                }
                else
                {

                    increaseTimerr.Stop();
                    MessageBox.Show("You cannot solve this puzzle","Puzzle Solved", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
            };

        }


     
        

        //BUttons when clicked functions

        //show lives
        private void showLives()
        {
            if (lives < 0)
            {
                lives = 0;
                increaseTimerr.Stop();
                MessageBox.Show("You have no Lives", "Puzzle Solved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else 
            {
               livesLeft.Text=lives.ToString();

            }
        }


        //show tiles
        private void showTiles() {
            if (tiles < 0)
            {
                tiles = 0;
            }
            else
            {
                tilesLeft.Text=tiles.ToString();
            }
        }

        //button clicked;
        private void Button_Click(object sender, EventArgs e)
        {
           
            Button button = (Button)sender;
            button.Text = button.Text;
            Console.WriteLine(button.Text);
            
            if (button.Text == "")
            {
                button.BackColor = Color.Red;
                lives -= 1;
                showLives();
            }
            else
            {
                if(indexx == 5)
                {
                    button.BackColor = Color.Green;
                    button.Enabled= false;
                    tiles-= 1;
                    showTiles();
                    increaseTimerr.Stop();
                    MessageBox.Show($"You have solved this problem in {seconds} seconds", "Puzzle Solved",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else if (int.Parse(button.Text) == indexx && indexx < 6)
                {
                    button.BackColor = Color.Green;
                    button.Enabled = false;
                    tiles -= 1;
                    showTiles();
                    indexx++;
                }
                else
                {

                    button.BackColor = Color.Gray;

                }
            }
           
           
            Console.WriteLine($"INDEXXXXXXXXXXX {indexx}");
        }
    }
}
