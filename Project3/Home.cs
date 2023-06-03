using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project3
{
    public partial class Home : Form
    {
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
            buttonsTable.Controls.Clear();

            for (int row = 0; row < 5; row++)
            {
                for (int column = 0; column <5 ; column++)
                {
                    Button button = new Button();
                    button.Text = $"Button {row}";
                    button.Name = $"btn_{row}_{column}";
                    button.Width = 80;
                    button.Height = 80;
                    button.BackColor = Color.Blue;
                    button.Click += Button_Click;
                    buttonsTable.Controls.Add(button);
                }
            }
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
