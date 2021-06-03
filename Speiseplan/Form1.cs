using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Data.OleDb;

namespace Speiseplan
{
    public partial class Form1 : Form
    {
        Speiseplan f2 = new Speiseplan();
        Speiseliste f3 = new Speiseliste();
        public Form1()
        {
            InitializeComponent();
        }

        internal string sql;

        private void button1_Click(object sender, EventArgs e)
        {
            Speiseplan f2 = new Speiseplan();
            f2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {            
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Speiseliste f3 = new Speiseliste();
            f3.ShowDialog();
        }
    }
}
