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
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {               
                pagenmr = (int)(Session["pagenmr"]);
                if (dbconn.GetPageKind(pagenmr) == "MOVIE")
                {
                    ds = dbconn.GetDataMovie(pagenmr);
                }
                else if (dbconn.GetPageKind(pagenmr) == "SHOW")
                {
                    ds = dbconn.GetDataShow(pagenmr);
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
                
            }
            Image1.ImageUrl = "/Content/Images/" + dbconn.GetImage(pagenmr);
            DescriptionMessage.Text = dbconn.GetDescription(pagenmr);
        }

       

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}