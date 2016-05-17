using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace poker
{
    public partial class frmPokerLJ : Form
    {
        public frmPokerLJ()
        {
            InitializeComponent();
        }

        private void tsmiExitLJ_Click(object sender, EventArgs e)
        {
            //close application
            Application.Exit();
        }

        private void tsmiRestartLJ_Click(object sender, EventArgs e)
        {
            //restart application
            Application.Restart();
        }

        private void tsmiRefreshLJ_Click(object sender, EventArgs e)
        {
            //refresh application
            this.Refresh();
        }

        private void tsmiHelpLJ_Click(object sender, EventArgs e)
        {
            //show help
            MessageBox.Show("rip");
        }

        private void tsmiAboutGameLJ_Click(object sender, EventArgs e)
        {
            //show info about game
            MessageBox.Show("This game is an student application for gaining experiance./n/nThe rights belong to ROC-terAa Helmond ICT-college");
        }

        private void tsmiDevLucLJ_Click(object sender, EventArgs e)
        {
            //show info about Luc Sieben
            MessageBox.Show("Luc Sieben is one of the two student developers who made this application.\n\n2nd grade college at ROC-TerAa in Helmond in 2015-2016");
        }

        private void tsmiDevJenneLJ_Click(object sender, EventArgs e)
        {
            //show info about Jenne van den Boom
            MessageBox.Show("Jenne van den Boom is one of the two student developers who made this application.\n\n2nd grade college at ROC-TerAa in Helmond in 2015-2016");
        }
    }
}
