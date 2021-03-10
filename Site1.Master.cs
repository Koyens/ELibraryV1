using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ELibrary2
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"] == null)
            {
                LinkButtonUserLogin.Visible = true;
                LinkButtonViewBooks.Visible = false;
                LinkButtonSignUp.Visible = true;
                navbarDropdown.Visible = false;
                LinkButtonAdminLogin.Visible = true;
                LinkButtonAuthorManagement.Visible = false;
                LinkButtonPublisherManagement.Visible = false;
                LinkButtonBookInventory.Visible = false;
                LinkButtonBookIssuing.Visible = false;
                LinkButtonMemberManagement.Visible = false;
            }
            else if (Session["role"].Equals("user"))
            {
                LinkButtonUserLogin.Visible = false;
                LinkButtonViewBooks.Visible = true;
                LinkButtonSignUp.Visible = false;
                navbarDropdown.Visible = true;
                LinkButtonAdminLogin.Visible = true;
                LinkButtonAuthorManagement.Visible = false;
                LinkButtonPublisherManagement.Visible = false;
                LinkButtonBookInventory.Visible = false;
                LinkButtonBookIssuing.Visible = false;
                LinkButtonMemberManagement.Visible = false;

                navbarDropdown.Text = "Hello, " + Session["fullname"].ToString();
            }
            else
            {
                LinkButtonUserLogin.Visible = false;
                LinkButtonViewBooks.Visible = true;
                LinkButtonSignUp.Visible = false;
                navbarDropdown.Visible = true;
                LinkButtonAdminLogin.Visible = false;
                LinkButtonAuthorManagement.Visible = true;
                LinkButtonPublisherManagement.Visible = true;
                LinkButtonBookInventory.Visible = true;
                LinkButtonBookIssuing.Visible = true;
                LinkButtonMemberManagement.Visible = true;
                LinkButtonProfile.Visible = false;

                navbarDropdown.Text = "Hello, " + Session["fullname"].ToString();
            }
        }

        protected void LinkButtonUserLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("userlogin.aspx");
        }

        protected void LinkButtonSignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("usersignup.aspx");
        }

        protected void LinkButtonViewBooks_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminBookInventory.aspx");
        }

        protected void LinkButtonAdminLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminlogin.aspx");
        }

        protected void LinkButtonAuthorManagement_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminAuthorManagement.aspx");
        }

        protected void LinkButtonPublisherManagement_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminPublisherManagement.aspx");
        }

        protected void LinkButtonBookInventory_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminBookInventory.aspx");
        }

        protected void LinkButtonBookIssuing_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminBookIssuing.aspx");
        }

        protected void LinkButtonMemberManagement_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminUserManagement.aspx");
        }

        protected void LinkButtonProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("userprofile.aspx");
        }

        protected void LinkButtonLogout_Click(object sender, EventArgs e)
        {
            Session["role"] = null;
            Session["fullname"] = "";
            Session["username"] = "";
            Session["accountstatus"] = "";
            Response.Redirect("homepage.aspx");
        }
    }
}