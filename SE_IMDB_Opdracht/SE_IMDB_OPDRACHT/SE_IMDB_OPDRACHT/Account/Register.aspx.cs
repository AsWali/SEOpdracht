using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using SE_IMDB_OPDRACHT.Models;

namespace SE_IMDB_OPDRACHT.Account
{
    public partial class Register : Page
    {
        DatabaseConnection dbconn = new DatabaseConnection();

        /// <summary>
        /// Checks if the email adress if available if the outcome is true then it creates a account.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            if (dbconn.EmailAvailable(UserName.Text) == true)
            {
                dbconn.CreateAccount(Password.Text, UserName.Text, DateTime.Today, "N");
                if (dbconn.TryLogin(UserName.Text, Password.Text))
                {
                    Session["LoggedInUserName"] = UserName.Text;
                    Response.Redirect("~/Account/Manage.aspx");
                }
            }
            else
            {
                ErrorMessage.Text = "Email is al in gebruik!";
            }

        }
    }
}