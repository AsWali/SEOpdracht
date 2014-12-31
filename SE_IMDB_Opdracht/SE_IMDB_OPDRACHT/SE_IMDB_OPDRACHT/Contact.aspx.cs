using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SE_IMDB_OPDRACHT
{
    public partial class Contact : Page
    {
        DatabaseConnection dbconn = new DatabaseConnection();
        private int pagenmr;
        private string username;
        private bool alreadyrated;
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            pagenmr = (int)(Session["pagenmr"]);
            username = (string)Session["LoggedInUserName"];
            if (!IsPostBack)
            {               
                
                if (dbconn.GetPageKind(pagenmr) == "MOVIE")
                {
                    ds = dbconn.GetDataMovie(pagenmr);
                    Lblrating.Text = "Rating = " + dbconn.GetRating(pagenmr).ToString();
                }
                else if (dbconn.GetPageKind(pagenmr) == "SHOW")
                {
                    ds = dbconn.GetDataShow(pagenmr);
                    Lblrating.Text = "Rating = " +  dbconn.GetRating(pagenmr).ToString();
                }
                else if (dbconn.GetPageKind(pagenmr) == "ACTEUR")
                {
                    ds = dbconn.GetDataActeurShow(pagenmr);
                    DataSet data2 = dbconn.GetDataActeurMovie(pagenmr);
                    ds.Merge(data2);                
                }
                
                if (ds.Tables.Count > 0)
                {
                    AuthorsGridView.DataSource = ds;
                    AuthorsGridView.DataBind();
                }
                else
                {
                    Message.Text = "Unable to connect to the database.";
                }

                if (dbconn.AlreadyRated(pagenmr, username) != -1)
                {
                    tbrating.Text = dbconn.AlreadyRated(pagenmr, username).ToString();
                    alreadyrated = true;
                    ErrorMessage.Text = "Already Rated";
                }
                else
                {
                    alreadyrated = false;
                }
                Refresh();
            }

            
            
        }

       protected void Refresh()
       {
           if (dbconn.GetPageKind(pagenmr) == "MOVIE")
           {
               Lblrating.Text = "Rating = " + dbconn.GetRating(pagenmr).ToString();
           }
           else if (dbconn.GetPageKind(pagenmr) == "SHOW")
           {
               Lblrating.Text = "Rating = " + dbconn.GetRating(pagenmr).ToString();
           }
           Image1.ImageUrl = "/Content/Images/" + dbconn.GetImage(pagenmr);
           DescriptionMessage.Text = dbconn.GetDescription(pagenmr);
           ErrorMessage.Text = string.Empty;
       }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnrate_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(tbrating.Text) > 10 || Convert.ToInt32(tbrating.Text) < 1)
            {
                ErrorMessage.Text = "Pick a number between 1 and 10 !";
            }
            else
            {
                if (alreadyrated == true)
                {
                    dbconn.UpdateRatePage(pagenmr, Convert.ToInt32(tbrating.Text), username);
                    tbrating.Text = string.Empty;
                }
                else
                {
                    dbconn.RatePage(pagenmr, Convert.ToInt32(tbrating.Text), username);
                    tbrating.Text = string.Empty;
                }
                Refresh();
            }
        }
    }
}