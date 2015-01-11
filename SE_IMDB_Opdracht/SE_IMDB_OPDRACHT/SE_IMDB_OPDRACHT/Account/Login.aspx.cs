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
            if (!IsPostBack)
            {
                if (Request.Cookies["UserName"] != null && Request.Cookies["Password"] != null)
                {
                    UserName.Text = Request.Cookies["UserName"].Value;
                    Password.Attributes["value"] = Request.Cookies["Password"].Value;
                }
            }

        }


        /// <summary>
        /// Creates a cookie if the remember me checkbox is checked.
        /// And logs in if the login information is correct.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        protected void LogIn(object sender, EventArgs e)
        {
            ///Check if remember me is checked, if so create cookies if not delete cookies
            if (RememberMe.Checked == true)
            {
                Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(30);
                Response.Cookies["Password"].Expires = DateTime.Now.AddDays(30);
                Response.Cookies["UserName"].Value = UserName.Text;
                Response.Cookies["Password"].Value = Password.Text;
            }
            else
            {
                if (Request.Cookies["UserName"] != null || Request.Cookies["Password"] != null)
                {
                    Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);
                }
            }

            //Kijkt of de login gegevens juist zijn, als het true returnt dan logt de gebruiker in en wordt hij verwijst naar zijn profiel
            //zo niet dan krijgt hij een error message te zien.
            if (dbconn.TryLogin(UserName.Text, Password.Text))
            {
                Session["LoggedInUserName"] = UserName.Text;
                Response.Redirect("~/Account/Manage.aspx");
            }
            else
            {
                FailureText.Text = "Incorrecte login gegevens!";
                ErrorMessage.Visible = true;
            }
        }
    }
}