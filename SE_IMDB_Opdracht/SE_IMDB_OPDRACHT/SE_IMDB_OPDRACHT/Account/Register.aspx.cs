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
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            if (dbconn.EmailAvailable(UserName.Text) == true)
            {
                dbconn.CreateAccount(Password.Text, UserName.Text, DateTime.Today, "N");
            }
            else
            {
                ErrorMessage.Text = "Email is al in gebruik!";
            }

        }
    }
}