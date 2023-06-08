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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void startGameButton_Click(object sender, EventArgs e)
        {
            Home h=new Home(this);
            h.Show();
            this.Hide();
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
