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
        internal string ab;
        private void button1_Click(object sender, EventArgs e)
        {
            return;
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


                        Speiseliste.f3.sql = "UPDATE " + ab + " SET Bildpfad = '" + bild + "', Bezeichnung = '" + bezeeichnung + "', Preis = '" + preis + "; ";
                        db.Ausfuehren(Speiseliste.f3.sql);
                    }
                    else
                    {
                        string bezeeichnung = textBox1.Text;
                        double preis = Convert.ToDouble(textBox2.Text);
                        string bild = textBox3.Text;


                        Speiseliste.f3.sql = "INSERT into " + ab + "Bildpfad, Bezeichnung, Preis) values('" + bild + "','" + bezeeichnung + "', '" + preis + "; ";
                        db.Ausfuehren(Speiseliste.f3.sql);

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
            db = new Datenbank();
            ab = Speiseliste.f3.o;
        }
    }
}
