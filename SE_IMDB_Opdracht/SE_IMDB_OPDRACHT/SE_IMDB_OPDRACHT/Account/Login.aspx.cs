using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using SE_IMDB_OPDRACHT.Models;

namespace SE_IMDB_OPDRACHT.Account
{
    public partial class Login : Page
    {
        DatabaseConnection dbconn = new DatabaseConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["userName"] != null)
            {
               HttpCookie aCookie = Request.Cookies["userName"];
               UserName.Text = Server.HtmlEncode(aCookie.Value);
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if(RememberMe.Checked == true)
            {

            }


            if (dbconn.TryLogin(UserName.Text, Password.Text))
            {
                Session["LoggedInUserName"] = UserName.Text;
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                FailureText.Text = "Incorrecte login gegevens!";
                ErrorMessage.Visible = true;
            }
        }
    }
}