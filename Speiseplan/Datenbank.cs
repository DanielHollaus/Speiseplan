using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Data.OleDb;
using System.Data;


namespace Speiseplan
{
    public class Datenbank
    {
        internal OleDbConnection verbindung;
        internal OleDbCommand cmd;
        internal string cn;

        public Datenbank()
        {

            cn = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=Speiseplan.accdb";
            verbindung = new OleDbConnection(cn);
            verbindung.Open();
        }

        public OleDbDataReader Einlesen(string sql)
        {
            try
            {
                cmd = new OleDbCommand(sql, verbindung);
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                throw new Exception("Fehler beim Einlesen: " + ex.Message);
            }
        }

        public void Ausfuehren(string sql)
        {

            try
            {
                cmd = new OleDbCommand(sql, verbindung);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Fehler beim Ausführen: " + ex.Message);
            }
        }
    }
}
