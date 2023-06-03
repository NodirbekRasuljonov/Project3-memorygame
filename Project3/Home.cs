using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Project3
{
    public partial class Home : Form
    {
        
        Random r = new Random();
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
            List<int> randomRowIndexes = generateRandomIndexes();
            List<int> randomColumnIndexes = generateRandomIndexes();
            List<int> randomNumbers=generateRandomIndexes();

            buttonsTable.Controls.Clear();
            for (int row = 0; row < 5; row++)
            {
                for (int column = 0; column < 5; column++)
                {
                    Button button = new Button();

                    button.Name = $"btn_{row}_{column}";
                    button.Width = 80;
                    button.Height = 80;
                    button.BackColor = Color.Blue;
                    Console.WriteLine($"RandomNumbers: {randomNumbers[column].ToString()}");
                    Console.WriteLine($"RandomINdex{randomRowIndexes[column].ToString()}");
                    Console.WriteLine($"RandomCOlumn{randomColumnIndexes[column].ToString()}");
                    if (randomNumbers[row] == row || randomNumbers[column]==column) 
                    {
                        button.Text = randomNumbers[column].ToString();
                    }
                    else
                    {

                      // button.Text = "0";
                    }
                    
                    //button.Text = $"{row}_{column}";
                    buttonsTable.Controls.Add(button);
                   
                }
            }


        }
       private List<int> generateRandomIndexes()
       {
            List<int> rands = new List<int>();
            while (rands.Count<5)
            {
                int randomNumber = r.Next(1, 6);
                if (!rands.Contains(randomNumber))
                {
                    rands.Add(randomNumber);
                }
            }
            return new List<int>(rands);
       }

     


        private void Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.Text = button.Name;

            // Perform actions based on the design name of the button
            // ...
        }

        private void buttonsTable_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
