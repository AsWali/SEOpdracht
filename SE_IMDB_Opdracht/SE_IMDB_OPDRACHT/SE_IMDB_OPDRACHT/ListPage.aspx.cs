using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SE_IMDB_OPDRACHT
{
    public partial class About : Page
    {
        DatabaseConnection dbconn = new DatabaseConnection();
        private int pagenmr;

        /// <summary>
        /// Shows the search results
        /// Shows the users ratings list.
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = (string)(Session["aboutlabel"]);
            if (Request["__EVENTARGUMENT"] != null && Request["__EVENTARGUMENT"] == "move")
            {   
                pagenmr =  dbconn.GetPageNmr(ListBox1.SelectedItem.ToString());
                Session["pagenmr"] = pagenmr;
                Response.Redirect("~/IMDBPage.aspx");
            }
            ListBox1.Attributes.Add("ondblclick", ClientScript.GetPostBackEventReference(ListBox1, "move"));

            List<string> searchresults = (List<string>)(Session["searchresult"]);
            foreach (string search in searchresults)
            {
                ListBox1.Items.Add(search);
            }
        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}