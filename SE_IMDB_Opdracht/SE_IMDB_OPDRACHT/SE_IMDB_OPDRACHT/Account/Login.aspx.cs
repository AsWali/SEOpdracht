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
            HttpCookie aCookie = new HttpCookie("userName");
            aCookie.Value = UserName.Text;
            aCookie.Expires = DateTime.Now.AddDays(14);
            Response.Cookies.Add(aCookie);
            }


            if (dbconn.TryLogin(UserName.Text, Password.Text))
            {

            }
            else
            {
                FailureText.Text = "Incorrecte login gegevens!";
                ErrorMessage.Visible = true;
            }
        }
    }
}