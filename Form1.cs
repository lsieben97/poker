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
        public game g = new game();
        public static Random r = new Random();
        public int cardCount = 1;
        public Timer aniTimer = new Timer();
        public Point startPoint;
        public Point currentPoint;
        public Point targetPoint;
        public Control animationTarget;
        public Point[] positionMap = { new Point(), game.fieldPosition1, game.fieldPosition2, game.fieldPosition3, game.fieldPosition4, game.fieldPosition5 };
        public PictureBox[] controlMap;
        public frmPokerLJ()
        {
            InitializeComponent();
            this.controlMap = new PictureBox[] {new PictureBox(),pbCard1LJ,pbCard2LJ,pbCard3LJ,pbCard4LJ,pbCard5LJ};
            g.loadcards();
            pbCard1LJ.Location = game.deckPosition;
            pbCard2LJ.Location = game.deckPosition;
            pbCard3LJ.Location = game.deckPosition;
            pbCard4LJ.Location = game.deckPosition;
            pbCard5LJ.Location = game.deckPosition;
            //pbDeckLJ.Location = game.deckPosition;
            Console.WriteLine(pbDeckLJ.Location.ToString());
            this.aniTimer.Interval = 1;
            this.aniTimer.Tick += aniTimer_Tick;
        }

        private void aniTimer_Tick(object sender, EventArgs e)
        {
            if(targetPoint.X > currentPoint.X)
            {
                currentPoint.X++;
            }
            else if(targetPoint.X < currentPoint.X)
            {
                currentPoint.X--;
            }
            if (targetPoint.Y > currentPoint.Y)
            {
                currentPoint.Y++;
            }
            else if (targetPoint.Y < currentPoint.Y)
            {
                currentPoint.Y--;
            }
            animationTarget.Location = currentPoint;
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

        private void btnDealLJ_Click(object sender, EventArgs e)
        {
            card c = this.getCard();
            this.g.addCard(c.name);
            this.startPoint = this.controlMap[this.cardCount].Location;
            this.currentPoint = this.startPoint;
            this.targetPoint = this.positionMap[this.cardCount];
            this.controlMap[this.cardCount].Image = c.image;
            this.animationTarget = this.controlMap[this.cardCount];
            this.aniTimer.Start();
            this.cardCount++;

        }
        public card getCard()
        {
            return this.g.cards[frmPokerLJ.r.Next(55)];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = string.Format("{0} {1} {2} {3}", pbDeckLJ.Location.X, pbDeckLJ.Location.Y, pbDeckLJ.Size.Width, pbDeckLJ.Size.Height);
        }
    }
}
