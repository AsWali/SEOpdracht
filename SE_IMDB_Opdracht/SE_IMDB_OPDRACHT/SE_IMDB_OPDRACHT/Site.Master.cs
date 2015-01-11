using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SE_IMDB_OPDRACHT
{
    public partial class SiteMaster : MasterPage
    {
        DatabaseConnection dbconn = new DatabaseConnection();
        private string username;
        private int hist;
        private List<string> history;
        private int pagenmr;

        protected void Page_Init(object sender, EventArgs e)
        {
            username = (string)Session["LoggedInUserName"];

            if (!IsPostBack)
            {
                if (Session["LoggedInUserName"] != null)
                {
                    
                    regman.InnerText = username;
                    regman.HRef = "Account/Manage";
                    loginout.InnerText = "Sign Off";
                }
            }

            ImagesHistory();

        }

        protected void ImagesHistory()
        {
            if (Session["LoggedInUserName"] != null)
            {
                history = dbconn.ViewingHistoryImages(username);
                hist = history.Count;
                if (hist > 0)
                {
                    try
                    {
                        ImageButton1.ImageUrl = "/Content/Images/" + history[hist - 1];
                        ImageButton2.ImageUrl = "/Content/Images/" + history[hist - 2];
                        ImageButton3.ImageUrl = "/Content/Images/" + history[hist - 3];
                        ImageButton4.ImageUrl = "/Content/Images/" + history[hist - 4];
                        ImageButton5.ImageUrl = "/Content/Images/" + history[hist - 5];
                        ImageButton6.ImageUrl = "/Content/Images/" + history[hist - 6];
                        ImageButton7.ImageUrl = "/Content/Images/" + history[hist - 7];
                        ImageButton8.ImageUrl = "/Content/Images/" + history[hist - 8];
                        ImageButton9.ImageUrl = "/Content/Images/" + history[hist - 9];
                        ImageButton10.ImageUrl = "/Content/Images/" + history[hist - 10];
                        ImageButton11.ImageUrl = "/Content/Images/" + history[hist - 11];
                        ImageButton12.ImageUrl = "/Content/Images/" + history[hist - 12];
                    }
                    catch
                    {

                    }
                }
            }
            else
            {
                ImageButton1.Visible = false;
                ImageButton2.Visible = false;
                ImageButton3.Visible = false;
                ImageButton4.Visible = false;
                ImageButton5.Visible = false;
                ImageButton6.Visible = false;
                ImageButton7.Visible = false;
                ImageButton8.Visible = false;
                ImageButton9.Visible = false;
                ImageButton10.Visible = false;
                ImageButton11.Visible = false;
                ImageButton12.Visible = false;
            }

        }


        protected void master_Page_PreLoad(object sender, EventArgs e)
        {

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
        }



        protected void TryLogOut(object sender, EventArgs e)
        {
            if (loginout.InnerText == "Sign Off")
            {
                Session["LoggedInUserName"] = null;
                Response.Redirect("~/Default.aspx");
            }
            else if(loginout.InnerText == "Log in")
            {
                Response.Redirect("~/Account/Login.aspx");
            }
        }

        protected void ProfileView(object sender, EventArgs e)
        {
            if (regman.InnerText == username)
            {
                Response.Redirect("~/Account/Manage.aspx");
            }
            else if (regman.InnerText == "Register")
            {
                Response.Redirect("~/Account/Register.aspx");
            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Session["aboutlabel"] = "Searchresults :";
            Session["searchresult"] = dbconn.SearchIMDB(TextBox1.Text);
            Response.Redirect("~/about.aspx");
        }

        protected string GetUserName()
        {
            return (string)(Session["LoggedInUserName"]);
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Session["pagenmr"] = dbconn.GetPageNmrFromImage(history[hist - 1]);
                Response.Redirect("~/Contact.aspx");
            }
            catch
            {

            }
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Session["pagenmr"] = dbconn.GetPageNmrFromImage(history[hist - 2]);
                Response.Redirect("~/Contact.aspx");
            }
            catch
            {

            }
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Session["pagenmr"] = dbconn.GetPageNmrFromImage(history[hist - 3]);
                Response.Redirect("~/Contact.aspx");
            }
            catch
            {

            }
        }

        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Session["pagenmr"] = dbconn.GetPageNmrFromImage(history[hist - 4]);
                Response.Redirect("~/Contact.aspx");
            }
            catch
            {

            }
        }

        protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Session["pagenmr"] = dbconn.GetPageNmrFromImage(history[hist - 5]);
                Response.Redirect("~/Contact.aspx");
            }
            catch
            {

            }
        }

        protected void ImageButton6_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Session["pagenmr"] = dbconn.GetPageNmrFromImage(history[hist - 6]);
                Response.Redirect("~/Contact.aspx");
            }
            catch
            {

            }
        }

        protected void ImageButton7_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Session["pagenmr"] = dbconn.GetPageNmrFromImage(history[hist - 7]);
                Response.Redirect("~/Contact.aspx");
            }
            catch
            {

            }
        }

        protected void ImageButton8_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Session["pagenmr"] = dbconn.GetPageNmrFromImage(history[hist - 8]);
                Response.Redirect("~/Contact.aspx");
            }
            catch
            {

            }
        }

        protected void ImageButton9_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Session["pagenmr"] = dbconn.GetPageNmrFromImage(history[hist - 9]);
                Response.Redirect("~/Contact.aspx");
            }
            catch
            {

            }
        }

        protected void ImageButton10_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Session["pagenmr"] = dbconn.GetPageNmrFromImage(history[hist - 10]);
                Response.Redirect("~/Contact.aspx");
            }
            catch
            {

            }
        }

        protected void ImageButton11_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Session["pagenmr"] = dbconn.GetPageNmrFromImage(history[hist - 11]);
                Response.Redirect("~/Contact.aspx");
            }
            catch
            {

            }
        }

        protected void ImageButton12_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Session["pagenmr"] = dbconn.GetPageNmrFromImage(history[hist - 12]);
                Response.Redirect("~/Contact.aspx");
            }
            catch
            {

            }
        }
    }

}