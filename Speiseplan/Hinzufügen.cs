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
    public partial class Hinzufügen : Form
    {

        internal static Hinzufügen f4;
        //Speiseliste f3 = new Speiseliste();
        public Hinzufügen()
        {
            InitializeComponent();
            f4 = this;
        }
        Datenbank db;
        OleDbDataReader dr;
        internal string ab, bildpfad, sql, abezeichnung;
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {


                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                {
                    MessageBox.Show("Bitte füllen Sie alle Felder aus!");
                }

                else
                {
                    if (this.Text.Equals("Bearbeiten"))
                    {

                        //int id = Convert.ToInt32(textBox1.Text);
                        string bezeeichnung = textBox1.Text;
                        double preis = Convert.ToDouble(textBox2.Text);
                        string bild = textBox3.Text;


                        sql = "UPDATE " + ab + " SET Bildpfad = '" + bild + "', Bezeichnung = '" + bezeeichnung + "', Preis = " + preis + " Where bezeichnung = '" + abezeichnung + "'";
                        db.Ausfuehren(sql);
                    }
                    else
                    {
                        string bezeeichnung = textBox1.Text;
                        double preis = Convert.ToDouble(textBox2.Text);
                        string bild = textBox3.Text;


                        sql = "INSERT into " + ab + " Bildpfad, Bezeichnung, Preis values('" + bild + "', '" + bezeeichnung + "', " + preis + "); ";
                        db.Ausfuehren(sql);

                    }


                    if(ab.Equals("Vorspeise"))
                    {
                        Speiseliste.f3.selectVS();

                    }
                    else if(ab.Equals("Hauptspeise"))
                    {
                        Speiseliste.f3.selectHS();
                    }
                    else
                    {
                        Speiseliste.f3.selectNS();
                    }

                    this.Close();




                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }

        private void Hinzufügen_Load(object sender, EventArgs e)
        {
            f4 = this;

            abezeichnung = textBox1.Text;
            

            db = new Datenbank();
            ab = Speiseliste.f3.o;
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images Files (*.jpg; *.jpeg; *.bmp; *.png; *.gif) | *.jpg; *.jpeg; *.bmp; *.png; *.gif";
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(ofd.FileName);
                bildpfad = ofd.FileName;
            }
        }
    }
}
