using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Configuration;

namespace SE_IMDB_OPDRACHT
{
    public class DatabaseConnection
    {
        private OracleConnection conn;

        public DatabaseConnection()
        {
            this.conn = new OracleConnection();
            this.conn.ConnectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            this.conn.Open();
            this.conn.Close();
        }

        public void CreateAccount()
        {
            try
            {
                OracleCommand cmd = this.conn.CreateCommand();
                cmd.CommandText = "INSERT INTO PTS_USER VALUES(:USERID, :RESERVATIONID, :USERNAME, :BANDURATION, :UNIQUECODE)";

                cmd.Parameters.Add("USERID", id);
                cmd.Parameters.Add("RESERVATIONID", reservid);
                cmd.Parameters.Add("USERNAME", username);
                cmd.Parameters.Add("BANDURATION", null);
                cmd.Parameters.Add("UNIQUECODE", uniquecode);

                this.conn.Open();
                cmd.ExecuteReader();
            }
            catch
            {
            }
            finally
            {
                this.conn.Close();
            }
        }
    }
}