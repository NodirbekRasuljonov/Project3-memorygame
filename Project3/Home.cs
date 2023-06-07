using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        public Home()
        {
            InitializeComponent();
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
            buttonsTable.Controls.Clear();
            for (int row = 0; row < 5; row++)
            {
                for (int column = 0; column < 5; column++)
                {
                    Button button = new Button();

                    button.Name = $"btn_{row}_{column}";
                    button.Width = 85;
                    button.Height = 85;
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
            indexx= 1;
            lives= 3;
            showLives();
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
            int index = 0;
            for (int row = 0; row < 5; row++)
            {
                for (int column = 0; column < 5; column++)
                {
                    Button button = new Button();

                    button.Name = $"btn_{row}_{column}";
                    button.Width = 85;
                    button.Height = 85;
                    button.BackColor = Color.CornflowerBlue;
                    
                    button.Click += Button_Click;

                    if (randomIndices.Contains(row * 5 + column))
                    {
                        button.Text = numbers[index].ToString(); // Assign the random number to the button
                        button.Font = new Font("French Script MT", 18);

                        index++;
                    }
                    else
                    {

                    }

                    buttonsTable.Controls.Add(button);
                }
            }
        }












        //BUttons when clicked functions

        private void showLives()
        {
            if (lives < 0)
            {
                lives = 0;
                MessageBox.Show("You have no Lives", "Puzzle Solved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else 
            {
               livesS.Text=lives.ToString();

            }
        }



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
                    MessageBox.Show("You have solved this problem","Puzzle Solved",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else if (int.Parse(button.Text) == indexx && indexx < 6)
                {
                    button.BackColor = Color.Green;
                    button.Enabled = false;
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
