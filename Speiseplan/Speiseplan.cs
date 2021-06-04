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
    public partial class Speiseplan : Form
    {

        internal static Speiseplan f2;
        Speiseliste f3 = new Speiseliste();
        
        public Speiseplan()
        {
            f2 = this;
            InitializeComponent();
        }
        internal string sql;

        private void button3_Click(object sender, EventArgs e)
        {
            f2.Close();
        }

        private void Speiseplan_Load(object sender, EventArgs e)
        {
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        
    }
}
