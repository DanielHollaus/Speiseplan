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
        Speiseliste f3 = new Speiseliste();
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
                        string bezeeichnung = textBox2.Text;
                        double preis = Convert.ToDouble(textBox3.Text);
                        string bild = textBox3.Text;


                        f3.sql = "UPDATE " + ab +" SET Bildpfad = '" + bild + "', Bezeichnung = '" + bezeeichnung + "', Preis = '" + preis+"; ";
                        db.Ausfuehren(f3.sql);
                    }

                    //else
                    //{
                    //    string unternehmen = txtUnternehmen.Text;
                    //    string ansprechperson = txtAnzeige.Text;
                    //    string telefon = txtTelefon.Text;
                    //    string email = txtEmail.Text;
                    //    string strasse = txtStraße.Text;
                    //    string zahlungskondition = txtZahlung.Text;
                    //    int postleitzahlID = Convert.ToInt32(txtPLZ.Text);

                    //    f3.sql = "Insert into Kunde (Unternehmen, Ansprechperson, Telefon, Email, Strasse, Zahlungskondition, PostleitzahlID) values ('" + unternehmen + "', '" + ansprechperson + "', '" + telefon + "', '" + email + "', '" + strasse + "', '" + zahlungskondition + "', " + postleitzahlID + " );";
                    //    db.Ausfuehren(f3.sql);

                    //}


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
            ab = f3.o;
        }
    }
}
