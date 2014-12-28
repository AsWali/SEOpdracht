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
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                int pagenmr = (int)(Session["pagenmr"]);

                // Run the query and bind the resulting DataSet
                // to the GridView control.
                DataSet ds = dbconn.GetDataMovie(pagenmr);
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

        }

       

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}