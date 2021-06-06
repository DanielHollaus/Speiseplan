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

        internal ListViewItem lvItem2;
        internal string sql;
        Datenbank db;
        OleDbDataReader dr;
        internal int idV, idN, idH, kl;
        internal int selected;
        internal string name, vor, haupt, nach;
        Random rnd = new Random();

        private void button3_Click(object sender, EventArgs e)
        {
            f2.Close();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            lvItem2 = listView1.SelectedItems[0];

            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Bitte wählen Sie eine Speise zum Bearbeiten aus!", "Achtung:", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            selected = listView1.SelectedItems[0].Index;

            kl = 2;

            Speiseliste.f3.ShowDialog();
        }

        private void Speiseplan_Load(object sender, EventArgs e)
        {
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            db = new Datenbank();
            kl = 0;
            vorspeisen();
            hauptspeisen();
            nachspeisen();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Word.Application wordapp = new Microsoft.Office.Interop.Word.Application();
            if (wordapp == null)
            {
                MessageBox.Show("No connection");
                return;
            }

            name = Microsoft.VisualBasic.Interaction.InputBox("Welcher Tag:");

            wordapp.Visible = true;
            wordapp.Documents.Open(Application.StartupPath + "\\../../../../Speiseplan.docx");
            wordapp.ActiveDocument.FormFields["Wochentag"].Result = name;
            wordapp.ActiveDocument.FormFields["BildV"].Result = name;
            wordapp.ActiveDocument.FormFields["Vorspeise"].Result = vor;
            wordapp.ActiveDocument.FormFields["BildN"].Result = name;
            wordapp.ActiveDocument.FormFields["Nachspeise"].Result = haupt;
            wordapp.ActiveDocument.FormFields["BildH"].Result = name;
            wordapp.ActiveDocument.FormFields["Hauptspeise"].Result = nach;



            wordapp.ActiveDocument.SaveAs2(Application.StartupPath + "\\../../../../" + name + ".docx");

            wordapp.ActiveDocument.ExportAsFixedFormat(Application.StartupPath + "\\../../../../" + name + ".pdf", Microsoft.Office.Interop.Word.WdExportFormat.wdExportFormatPDF, true);
        }

        #region methoden
        //
        private void vorspeisen()
        {
            string sql = "Select count(*) from Vorspeise";
            dr = db.Einlesen(sql);
            
            while (dr.Read())
            {
                idV = Convert.ToInt32(dr[0]);
                
            }
            int arnd = rnd.Next(idV);
            sql = "Select * from Vorspeise Where ID_V = " + arnd;
            dr = db.Einlesen(sql);
            while (dr.Read())
            {
                lvItem2 = new ListViewItem(dr[0].ToString());
                lvItem2.SubItems.Add(dr[1].ToString());
                lvItem2.SubItems.Add(dr[2].ToString());
                vor = dr[2].ToString();
                listView1.Items.Add(lvItem2);
            }
        }
        private void hauptspeisen()
        {
            string sql = "Select count(*) from Hauptspeise";
            dr = db.Einlesen(sql);

            while (dr.Read())
            {
                idH = Convert.ToInt32(dr[0]);
                
            }
            int arnd = rnd.Next(idH);
            sql = "Select * from Hauptspeise Where ID_H = " + arnd;
            dr = db.Einlesen(sql);
            while (dr.Read())
            {
                lvItem2 = new ListViewItem(dr[0].ToString());
                lvItem2.SubItems.Add(dr[1].ToString());
                lvItem2.SubItems.Add(dr[2].ToString());
                haupt = dr[2].ToString();
                listView1.Items.Add(lvItem2);
            }
        }


        private void nachspeisen()
        {
            string sql = "Select count(*) from Nachspeise";
            dr = db.Einlesen(sql);

            while (dr.Read())
            {
                idN = Convert.ToInt32(dr[0]);
                
            }
            int arnd = rnd.Next(idN);
            sql = "Select * from Nachspeise Where ID_N = " + arnd;
            dr = db.Einlesen(sql);
            while (dr.Read())
            {
                lvItem2 = new ListViewItem(dr[0].ToString());
                lvItem2.SubItems.Add(dr[1].ToString());
                lvItem2.SubItems.Add(dr[2].ToString());
                nach = dr[2].ToString();
                listView1.Items.Add(lvItem2);
            }
        }
        


        
        #endregion

    }
}
