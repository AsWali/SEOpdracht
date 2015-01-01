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
    }

}