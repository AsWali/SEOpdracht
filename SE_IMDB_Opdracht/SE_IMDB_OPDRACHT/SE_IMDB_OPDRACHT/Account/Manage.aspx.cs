using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using SE_IMDB_OPDRACHT.Models;

namespace SE_IMDB_OPDRACHT.Account
{
    public partial class Manage : Page
    {
        DatabaseConnection dbconn = new DatabaseConnection();
        private string username;
        private int lastrated;
        private int pagenmr;
        private List<string> viewinghistory;
        private List<string> ratingimages;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["__EVENTARGUMENT"] != null && Request["__EVENTARGUMENT"] == "move")
            {
                pagenmr = dbconn.GetPageNmr(ListBox1.SelectedItem.ToString());
                Session["pagenmr"] = pagenmr;
                Response.Redirect("~/IMDBPage.aspx");
            }
            ListBox1.Attributes.Add("ondblclick", ClientScript.GetPostBackEventReference(ListBox1, "move"));


            username = (string)Session["LoggedInUserName"];           
            ratingimages = dbconn.ProfileRating(username);
            lastrated = ratingimages.Count();
            if (lastrated > 0)
            {
                try
                {
                    Image1.ImageUrl = "/Content/Images/" + ratingimages[lastrated - 1];
                    Image2.ImageUrl = "/Content/Images/" + ratingimages[lastrated - 2];
                    Image3.ImageUrl = "/Content/Images/" + ratingimages[lastrated - 3];
                    Image4.ImageUrl = "/Content/Images/" + ratingimages[lastrated - 4];
                    Image5.ImageUrl = "/Content/Images/" + ratingimages[lastrated - 5];
                }
                catch
                {

                }
            }
            ListBox1.Items.Clear();
            viewinghistory = dbconn.ViewingHistory(username);
            foreach(string pag in viewinghistory)
            {
                ListBox1.Items.Add(pag);
            }
            lbusername.Text = username;
            lbjoindate.Text = "IMDb member since " + dbconn.GetJoinDate(username);
        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session["aboutlabel"] = "Pages Rated !";
            Session["searchresult"] = dbconn.ProfileRatingName(username);
            Response.Redirect("~/ListPage.aspx");
        }

        protected void Image1_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Session["pagenmr"] = dbconn.GetPageNmrFromImage(ratingimages[lastrated - 1]);
                Response.Redirect("~/IMDBPage.aspx");
            }
            catch
            {

            }
        }

        protected void Image2_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Session["pagenmr"] = dbconn.GetPageNmrFromImage(ratingimages[lastrated - 2]);
                Response.Redirect("~/IMDBPage.aspx");
            }
            catch
            {

            }
        }

        protected void Image3_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Session["pagenmr"] = dbconn.GetPageNmrFromImage(ratingimages[lastrated - 3]);
                Response.Redirect("~/IMDBPage.aspx");
            }
            catch
            {

            }
        }

        protected void Image4_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Session["pagenmr"] = dbconn.GetPageNmrFromImage(ratingimages[lastrated - 4]);
                Response.Redirect("~/IMDBPage.aspx");
            }
            catch
            {

            }
        }

        protected void Image5_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Session["pagenmr"] = dbconn.GetPageNmrFromImage(ratingimages[lastrated - 5]);
                Response.Redirect("~/IMDBPage.aspx");
            }
            catch
            {

            }
        }

    }
}