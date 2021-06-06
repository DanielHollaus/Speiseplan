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
        Hinzufügen f4 = new Hinzufügen();
        public Speiseliste()
        {
            InitializeComponent();
            f3 = this;
        }

        internal ListViewItem lvItem;

        Datenbank db;
        OleDbDataReader dr;
        internal string sql;
        internal int selected;
        internal string o, idr;

        private void Speiseliste_Load(object sender, EventArgs e)
        {
            f3 = this;
            db = new Datenbank();
            selectVS();
            o = "Vorspeise";
            idr = "ID_V";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            f3.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            selectVS();
            o = "Vorspeise";
            idr = "ID_V";
        }


        #region methoden
        internal void selectVS()
        {
            listView1.Items.Clear();

            sql = "Select * from Vorspeise;";
            dr = db.Einlesen(sql);
            while (dr.Read())
            {
                lvItem = new ListViewItem(dr[0].ToString());
                lvItem.SubItems.Add(dr[1].ToString());
                lvItem.SubItems.Add(dr[2].ToString());
                lvItem.SubItems.Add(dr[3].ToString());
                listView1.Items.Add(lvItem);
            }
        }

        internal void selectHS()
        {
            listView1.Items.Clear();

            sql = "Select * from Hauptspeise;";
            dr = db.Einlesen(sql);
            while (dr.Read())
            {
                lvItem = new ListViewItem(dr[0].ToString());
                lvItem.SubItems.Add(dr[1].ToString());
                lvItem.SubItems.Add(dr[2].ToString());
                lvItem.SubItems.Add(dr[3].ToString());
                listView1.Items.Add(lvItem);
            }
        }

        internal void selectNS()
        {
            listView1.Items.Clear();

            sql = "Select * from Nachspeise;";
            dr = db.Einlesen(sql);
            while (dr.Read())
            {
                lvItem = new ListViewItem(dr[0].ToString());
                lvItem.SubItems.Add(dr[1].ToString());
                lvItem.SubItems.Add(dr[2].ToString());
                lvItem.SubItems.Add(dr[3].ToString());
                listView1.Items.Add(lvItem);
            }
        }

       


        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            selectHS();
            o = "Hauptspeise";
            idr = "ID_H";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            selectNS();
            o = "Nachspeise";
            idr = "ID_N";
        }

        private void hinzufügenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hinzufügen.f4.Text = "Hinzufügen";
            Hinzufügen.f4.ShowDialog();
           
        }

        private void bearbeitenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                lvItem = listView1.SelectedItems[0];

                if (listView1.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Bitte wählen Sie eine Speise zum Bearbeiten aus!", "Achtung:", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                selected = listView1.SelectedItems[0].Index;

                Hinzufügen.f4.Text = "Bearbeiten";
                f4.textBox1.Text = lvItem.SubItems[2].Text;
                f4.textBox2.Text = lvItem.SubItems[0].Text;
                f4.textBox3.Text = lvItem.SubItems[1].Text;

                Hinzufügen.f4.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show("bitte auswählen");
                return;
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(Speiseplan.f2.kl == 2)
            {
                lvItem = listView1.SelectedItems[0];

                if (listView1.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Bitte wählen Sie eine Speise zum ändern aus!", "Achtung:", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                selected = listView1.SelectedItems[0].Index;




            }
        }

        private void löschenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lvItem = listView1.SelectedItems[0];

            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Bitte wählen Sie einen Speisee zum löschen aus", "Achtung:", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            selected = listView1.SelectedItems[0].Index;
            sql = "DELETE * from "+ o + " WHERE "+ idr +" = " + lvItem.SubItems[0].Text + ";";

            db.Ausfuehren(sql);
            db.Einlesen(sql);
        }
    }
}
