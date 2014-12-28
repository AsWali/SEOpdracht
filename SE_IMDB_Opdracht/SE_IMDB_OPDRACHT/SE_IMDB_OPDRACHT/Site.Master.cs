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
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        protected void Page_Init(object sender, EventArgs e)
        {
           /* if (Session["LoggedInUserName"] == null)
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = (string)(Session["LoggedInUserName"]);
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
            }

            Page.PreLoad += master_Page_PreLoad;*/
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
           /* if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }*/
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Session["searchresult"] = dbconn.SearchIMDB(TextBox1.Text);
            Response.Redirect("~/about.aspx");
        }

        protected string GetUserName()
        {
            return (string)(Session["LoggedInUserName"]);
        }
    }

}