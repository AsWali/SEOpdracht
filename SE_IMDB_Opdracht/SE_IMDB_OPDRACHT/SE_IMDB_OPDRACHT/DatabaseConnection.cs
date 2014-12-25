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

        /// <summary>
        /// Register form, De eerste methode is om ervoor te zorgen dat niet de zelfde email er 2 x in staat.
        /// En de tweede methode voegt een account toe aan de database.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool EmailAvailable(string email)
        {
            List<string> allemails = new List<string>();
            string queryString = "SELECT EMAILADRES from OP_IBaccount";

            OracleCommand cmd = new OracleCommand(queryString, this.conn);
            this.conn.Open();
            using (OracleDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    allemails.Add(reader.GetString(0));
                }
            }
            this.conn.Close();
            foreach (string ema in allemails)
            {
                if (ema == email)
                {
                    return false;
                }
            }
            return true;
        }
        public void CreateAccount(string password, string email, DateTime joindate, string type)
        {
            try
            {
                OracleCommand cmd = this.conn.CreateCommand();
                cmd.CommandText = "INSERT INTO OP_IBACCOUNT(Password,JoinDate,Firstname,Lastname,Sex,DateOfBirth, EmailAdres, AccountType) VALUES(:PASSWORD, :JOINDATE, :FIRSTNAME, :LASTNAME, :SEX, :DATEOFBIRTH, :EMAILADRES, :ACCOUNTTYPE)";
                cmd.Parameters.Add("PASSWORD", password);
                cmd.Parameters.Add("JOINDATE", joindate);
                cmd.Parameters.Add("FIRSTNAME", null);
                cmd.Parameters.Add("LASTNAME", null);
                cmd.Parameters.Add("SEX", null);
                cmd.Parameters.Add("DATEOFBIRTH", null);
                cmd.Parameters.Add("EMAILADRES", email);
                cmd.Parameters.Add("ACCOUNTTYPE", type);

                this.conn.Open();
                cmd.ExecuteReader();
            }
            catch(OracleException e)
            {
            }
            finally
            {
                this.conn.Close();
            }
        }




        /// <summary>
        //Try logging in
        /// </summary>
        public bool TryLogin(string username, string password)
        {

            string queryString = "SELECT EMAILADRES from OP_IBaccount WHERE emailadres=:un AND password=:pw";
            OracleCommand cmd = new OracleCommand(queryString, this.conn);
            cmd.Parameters.Add("un", username);
            cmd.Parameters.Add("pw", password);

            this.conn.Open();

            using (OracleDataReader reader = cmd.ExecuteReader())
            {
                if(reader.HasRows)
                {
                    return true;
                }
            }
            this.conn.Close();
            return false;
        }


        /// <summary>
        //Try logging in
        /// </summary>
        public List<string> SearchIMDB(string searchterm)
        {
            List<string> searchresults = new List<string>();
            try
            {
            string queryString = "SELECT name from OP_IMDBPAGE WHERE name LIKE :un";
            
            OracleCommand cmd = new OracleCommand(queryString, this.conn);
            cmd.Parameters.Add(":un", OracleDbType.NVarchar2).Value = "%" + searchterm + "%";


            this.conn.Open();

            using (OracleDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    searchresults.Add(reader.GetString(0));
                }
            }
            }
            catch
            {

            }
            finally
            {
            this.conn.Close();
            }
            return searchresults;
        }


    }
}