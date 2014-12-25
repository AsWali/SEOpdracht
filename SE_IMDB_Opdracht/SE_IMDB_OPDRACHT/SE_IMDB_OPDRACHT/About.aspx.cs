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
        protected void Page_Load(object sender, EventArgs e)
        {
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