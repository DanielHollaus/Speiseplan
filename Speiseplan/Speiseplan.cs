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

        internal ListViewItem lvItem1, lvItem2;
        internal string sql;
        Datenbank db;
        OleDbDataReader dr;
        internal int selected, idV, idN, idH;
        internal string o, idr;

        private void button3_Click(object sender, EventArgs e)
        {
            f2.Close();
        }

        private void Speiseplan_Load(object sender, EventArgs e)
        {
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            db = new Datenbank();
            wochentage();
            vorspeisen();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void wochentage()
        {
            string sql = "Select * from Wochentag";
            dr = db.Einlesen(sql);
            while (dr.Read())
            {
                lvItem1 = new ListViewItem(dr[0].ToString());
                lvItem1.SubItems.Add(dr[1].ToString());
                listView1.Items.Add(lvItem1);
            }

            
        }

        private void vorspeisen()
        {
            string sql = "Select * from Vorspeise";
            dr = db.Einlesen(sql);
            while (dr.Read())
            {
                lvItem2 = new ListViewItem(dr[0].ToString());
                lvItem2.SubItems.Add(dr[1].ToString());
                lvItem2.SubItems.Add(dr[2].ToString());
                lvItem2.SubItems.Add(dr[3].ToString());
                listView1.Items.Add(lvItem2);
            }
        }

        internal void idlesen()
        {
            string sql = "Select ID_V from Vorspeise";
            dr = db.Einlesen(sql);
            while (dr.Read())
            {
                idV = Convert.ToInt32(dr[0]);
            }

        }


        internal void randomzahl()
        {



        }

        
    }
}
