using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Configuration;
using System.Data;


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
        //Try logging in, kijk of de username en password een row returnt. Zo ja return true.
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
        /// Return een list met de namen van pagina;s die lijken op de searchterm
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

        /// <summary>
        /// Returnt DataSet met de acteurs die in de film spelen en de character die de acteurs spelen.
        /// </summary>
        public DataSet GetDataMovie(int pagenmr)
        {
            string queryString = "select b.name, a.characternaam from op_movie_acteur a, Op_imdbpage b where a.PAGENMRACTEUR = b.PAGENMR  and a.PAGENMRMOVIE = :un";
            OracleCommand cmd = new OracleCommand(queryString, this.conn);
            cmd.Parameters.Add("un", pagenmr);
            OracleDataAdapter adapter = new OracleDataAdapter(cmd);
            

            this.conn.Open();

            DataSet ds = new DataSet();

            try
            {
                // Fill the DataSet.
                adapter.Fill(ds);

            }
            catch (OracleException e)
            {
                // The connection failed. Display an error message            
            }
             finally
            {
                conn.Close();
            }
            return ds;
        }

        /// <summary>
        /// Returnt DataSet met de acteurs die in de show spelen en de character die de acteurs spelen.
        /// </summary>
         public DataSet GetDataShow(int pagenmr)
         {
             string queryString = "select b.name, a.characternaam from op_tvshow_acteur a, Op_imdbpage b where a.PAGENMRACTEUR = b.PAGENMR  and a.PAGENMRSHOW =  :un";
             OracleCommand cmd = new OracleCommand(queryString, this.conn);
             cmd.Parameters.Add("un", pagenmr);
             OracleDataAdapter adapter = new OracleDataAdapter(cmd);


             this.conn.Open();

             DataSet ds = new DataSet();

             try
             {
                 // Fill the DataSet.
                 adapter.Fill(ds);

             }
             catch (OracleException e)
             {
                 // The connection failed. Display an error message            
             }
             finally
             {
                 conn.Close();
             }
             return ds;
         }

         /// <summary>
         /// Returnt DataSet met de series waar de acteurs in spelen en de character die ze spelen.
         /// </summary>
         public DataSet GetDataActeurShow(int pagenmr)
         {
             string queryString = "select c.NAME, a.CHARACTERNAAM from op_tvshow_acteur a,  op_imdbpage c where c.PAGENMR = a.PAGENMRSHOW and a.PAGENMRACTEUR= :un";
             OracleCommand cmd = new OracleCommand(queryString, this.conn);
             cmd.Parameters.Add("un", pagenmr);
             OracleDataAdapter adapter = new OracleDataAdapter(cmd);


             this.conn.Open();

             DataSet ds = new DataSet();

             try
             {
                 // Fill the DataSet.
                 adapter.Fill(ds);

             }
             catch (OracleException e)
             {
                 // The connection failed. Display an error message            
             }
             finally
             {
                 conn.Close();
             }
             return ds;
         }

         /// <summary>
         /// Returnt DataSet met de films waar de acteurs in spelen en de character die ze spelen. 
         /// </summary>
         public DataSet GetDataActeurMovie(int pagenmr)
         {
             string queryString = "select c.NAME, a.CHARACTERNAAM from op_movie_acteur a,  op_imdbpage c where c.PAGENMR = a.PAGENMRMOVIE and a.PAGENMRACTEUR= :un";
             OracleCommand cmd = new OracleCommand(queryString, this.conn);
             cmd.Parameters.Add("un", pagenmr);
             OracleDataAdapter adapter = new OracleDataAdapter(cmd);


             this.conn.Open();

             DataSet ds = new DataSet();

             try
             {
                 // Fill the DataSet.
                 adapter.Fill(ds);

             }
             catch (OracleException e)
             {
                 // The connection failed. Display an error message            
             }
             finally
             {
                 conn.Close();
             }
             return ds;
         }

         /// <summary>
         /// Returnt de pagenmr van de pagina met de parameter
         /// </summary>
        public int GetPageNmr(string name)
         {
            int pagenmr = 0;
            string queryString = "select pagenmr from OP_imdbpage where name= :un";
            OracleCommand cmd = new OracleCommand(queryString, this.conn);
            cmd.Parameters.Add("un", name);

            this.conn.Open();

            using (OracleDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    pagenmr = reader.GetInt32(0);
                }
            }
            this.conn.Close();

            return pagenmr;
         }

        /// <summary>
        /// Returnt de pagenmr van de pagina met de parameter
        /// </summary>
        public int GetPageNmrFromImage(string image)
         {
            int pagenmr = 0;
            string queryString = "select pagenmr from op_imdbpage where image = :un";
            OracleCommand cmd = new OracleCommand(queryString, this.conn);
            cmd.Parameters.Add("un", image);

            this.conn.Open();

            using (OracleDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    pagenmr = reader.GetInt32(0);
                }
            }
            this.conn.Close();

            return pagenmr;
         }

        /// <summary>
        /// Returnt de description van de pagina met de parameter
        /// </summary>
        public string GetDescription(int pagenmr)
        {
            string description = "";
            string queryString = "select description from op_imdbpage where pagenmr=:un";
            OracleCommand cmd = new OracleCommand(queryString, this.conn);
            cmd.Parameters.Add("un", pagenmr);

            this.conn.Open();

            using (OracleDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    description = reader.GetString(0);
                }
            }
            this.conn.Close();

            return description;
         }

        /// <summary>
        /// Returnt de image bestandsnaam van de pagina, waar de pagina nummer hetzelfde is als de parameter
        /// </summary>
        public string GetImage(int pagenmr)
        {
            string image = "";
            string queryString = "select image from op_imdbpage where pagenmr=:un";
            OracleCommand cmd = new OracleCommand(queryString, this.conn);
            cmd.Parameters.Add("un", pagenmr);

            this.conn.Open();

            using (OracleDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    image = reader.GetString(0);
                }
            }
            this.conn.Close();

            return image;
        }

        /// <summary>
        /// Returnt de pagina soort (actor,serie,movie) van de pagina, waar de pagina nummer hetzelfde is als de parameter
        /// </summary>
        public string GetPageKind(int pagenmr)
        {
            string pagekind = "";
            string queryString = "select pagekind from op_imdbpage where pagenmr=:un";
            OracleCommand cmd = new OracleCommand(queryString, this.conn);
            cmd.Parameters.Add("un", pagenmr);

            this.conn.Open();

            using (OracleDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    pagekind = reader.GetString(0);
                }
            }
            this.conn.Close();

            return pagekind;
        }

        /// <summary>
        /// Returnt de rating van de pagina, waar de pagina nummer hetzelfde is als de parameter
        /// </summary>
        public int GetRating(int page)
        {
            int rating = 0;
            string queryString = "select AVG(Rating) from op_rat_imdbpage where pagenmr=:un";
            OracleCommand cmd = new OracleCommand(queryString, this.conn);
            cmd.Parameters.Add("un", page);

            this.conn.Open();
            try
            {
                using (OracleDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            rating = reader.GetInt32(0);
                        }
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

            return rating;
        }

        /// <summary>
        /// Kijkt of de email al de pagina een cijfer heeft gegeven.
        /// </summary>
        public int AlreadyRated(int page, string email)
        {
            int rating = -1;
            string queryString = "select Rating from op_rat_imdbpage where pagenmr=:un and Email=:email";
            OracleCommand cmd = new OracleCommand(queryString, this.conn);
            cmd.Parameters.Add("un", page);
            cmd.Parameters.Add("email", email);

            this.conn.Open();

            using (OracleDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    rating = reader.GetInt32(0);
                }
            }
            this.conn.Close();

            return rating;

        }

        /// <summary>
        /// Voegt een pagina toe aan de recently viewed tabel voor de user.
        /// </summary>
        public void LastViewed(int pagenmr, string email, DateTime viewdate)
        {
            try
            {
                OracleCommand cmd = this.conn.CreateCommand();
                cmd.CommandText = "INSERT INTO OP_Rec_IMDBPAGE VALUES (:email,:pg, :tm)";
                cmd.Parameters.Add("email", email);
                cmd.Parameters.Add("pg", pagenmr);
                cmd.Parameters.Add("tm", viewdate);

                this.conn.Open();
                cmd.ExecuteReader();
            }
            catch (OracleException e)
            {
            }
            finally
            {
                this.conn.Close();
            }

        }

        /// <summary>
        /// Verwijdert een pagina van de recently viewed tabel voor de user.
        /// </summary>
        public void DeleteFromViewed(int pagenmr, string email)
        {
            try
            {
                OracleCommand cmd = this.conn.CreateCommand();
                cmd.CommandText = "delete from op_rec_imdbpage where email=:email and pagenmr=:pg";
                cmd.Parameters.Add("email", email);
                cmd.Parameters.Add("pg", pagenmr);

                this.conn.Open();
                cmd.ExecuteReader();
            }
            catch (OracleException e)
            {
            }
            finally
            {
                this.conn.Close();
            }
        }

        /// <summary>
        /// Returnt de image namen voor de ratings list voor de user.
        /// </summary>
        public List<string> ProfileRating(string email)
        {
            List<string> profilrating = new List<string>();
            try
            {
                OracleCommand cmd = this.conn.CreateCommand();
                cmd.CommandText = "select b.IMAGE from op_rat_imdbpage a , op_imdbpage b where a.PAGENMR = b.PAGENMR and a.EMAIL=:email ORDER BY a.VIEWDATE ASC";
                cmd.Parameters.Add("email", email);

                this.conn.Open();
                cmd.ExecuteReader();
                using (OracleDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        profilrating.Add(reader.GetString(0));
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
            return profilrating;
        }

        /// <summary>
        /// Returnt de pagina namen voor de ratings list voor de user.
        /// </summary>
        public List<string> ProfileRatingName(string email)
        {
            List<string> profilrating = new List<string>();
            try
            {
                OracleCommand cmd = this.conn.CreateCommand();
                cmd.CommandText = "select b.name from op_rat_imdbpage a , op_imdbpage b where a.PAGENMR = b.PAGENMR and a.EMAIL=:email ORDER BY a.VIEWDATE DESC";
                cmd.Parameters.Add("email", email);

                this.conn.Open();
                cmd.ExecuteReader();
                using (OracleDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        profilrating.Add(reader.GetString(0));
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
            return profilrating;
        }

        /// <summary>
        /// Rate een pagina voor een user.
        /// </summary>
        public void RatePage(int pagenmr, int rating, string email, DateTime viewdate)
        {
            try
            {
                OracleCommand cmd = this.conn.CreateCommand();
                cmd.CommandText = "INSERT INTO OP_RAT_IMDBPAGE VALUES (:email,:pg, :rt, :tm)";
                cmd.Parameters.Add("email", email);
                cmd.Parameters.Add("pg", pagenmr);
                cmd.Parameters.Add("rt", rating);
                cmd.Parameters.Add("'tm", viewdate);

                this.conn.Open();
                cmd.ExecuteReader();
            }
            catch (OracleException e)
            {
            }
            finally
            {
                this.conn.Close();
            }

        }

        /// <summary>
        /// Update een rating voor de user.
        /// </summary>
        public void UpdateRatePage(int pagenmr, int rating, string email)
        {
            try
            {
                OracleCommand cmd = this.conn.CreateCommand();
                cmd.CommandText = "UPDATE OP_RAT_IMDBPAGE SET Rating=:rt WHERE Email=:email and pagenmr=:pg";
                cmd.Parameters.Add("rt", rating);               
                cmd.Parameters.Add("email", email);
                cmd.Parameters.Add("pg", pagenmr);

                conn.Open();
                cmd.ExecuteReader();
            }
            catch (OracleException e)
            {

            }
            finally
            {
                this.conn.Close();
            }
        }

        /// <summary>
        /// Returnt de joindate voor een user.
        /// </summary>
        public string GetJoinDate(string email)
        {
            string joindate = "";
            string queryString = "select joindate from op_ibaccount where EmailAdres=:un";
            OracleCommand cmd = new OracleCommand(queryString, this.conn);
            cmd.Parameters.Add("un", email);

            this.conn.Open();

            using (OracleDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    joindate = reader.GetDateTime(0).ToShortDateString();
                }
            }
            this.conn.Close();

            return joindate;

        }

        /// <summary>
        /// Returnt de images/pagina namen voor de paginas die de gebruiks in zijn geschiedenis heeft.
        /// </summary>
        public List<string> ViewingHistory(string email)
        {
            List<string> history = new List<string>();
            try
            {
                string queryString = "select b.name from op_rec_imdbpage a, op_imdbpage b where a.pagenmr = b.pagenmr and email=:un  ORDER BY a.VIEWDATE DESC";

                OracleCommand cmd = new OracleCommand(queryString, this.conn);
                cmd.Parameters.Add(":un", email);
                this.conn.Open();

                using (OracleDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        history.Add(reader.GetString(0));
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
            return history;
        }

        public List<string> ViewingHistoryImages(string email)
        {
            List<string> history = new List<string>();
            try
            {
                string queryString = "select b.image from op_rec_imdbpage a, op_imdbpage b where a.pagenmr = b.pagenmr and email=:un  ORDER BY a.VIEWDATE DESC";

                OracleCommand cmd = new OracleCommand(queryString, this.conn);
                cmd.Parameters.Add(":un", email);
                this.conn.Open();

                using (OracleDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        history.Add(reader.GetString(0));
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
            return history;
        }

    }
}