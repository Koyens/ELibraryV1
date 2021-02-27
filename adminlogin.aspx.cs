using ELibrary2.Classes;
using ELibrary2.models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ELibrary2
{
    public partial class adminlogin : System.Web.UI.Page
    {
        ADMIN admin = new ADMIN();
        adminModels model = new adminModels();
        string jsonstring;

        protected void Page_Load(object sender, EventArgs e)
        {
            TextBoxAdminID.Focus();
        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            if(verify())
            {
                int result = admin.adminLogin(jsonstring);

                if(result == 1)
                {
                    Response.Redirect("homepage.aspx");
                }
                else if(result == 2)
                {
                    Response.Write("<script>alert('Admin ID does not exist!');</script>");
                }
                else
                {
                    Response.Write("<script>alert('Wrong Password!');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Missing Field!');</script>");
            }
        }

        bool verify()
        {
            if(TextBoxAdminID.Text.Trim() == "" || TextBoxPassword.Text.Trim() == "")
            {
                return false;
            }
            else
            {
                model.adminID = TextBoxAdminID.Text;
                model.password = TextBoxPassword.Text;

                jsonstring = JsonConvert.SerializeObject(model);
                return true;
            }
        }
    }
}