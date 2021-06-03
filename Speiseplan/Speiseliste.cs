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
    public partial class Speiseliste : Form
    {

        internal static Speiseliste f3;
        public Speiseliste()
        {
            InitializeComponent();
        }

        private void Speiseliste_Load(object sender, EventArgs e)
        {
            f3 = this;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            f3.Close();
        }
    }
}
