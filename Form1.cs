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
    public partial class Form1 : Form
    {
        public system sys = new system();

        public Form1()
        {
            InitializeComponent();
            // load cards
            sys.loadcards();
        }
    }
}
