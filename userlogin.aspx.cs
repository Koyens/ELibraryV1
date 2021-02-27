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
    public partial class userlogin : System.Web.UI.Page
    {
        MEMBERS member = new MEMBERS();
        membersModel model = new membersModel();
        string jsonstring;

        protected void Page_Load(object sender, EventArgs e)
        {
            TextBoxMemberID.Focus();
        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            if (verify())
            {
                int output = member.userLogin(jsonstring);

                if(output == 1)
                {
                    Response.Redirect("homepage.aspx");
                }
                else if(output == 2)
                {
                    Response.Write("<script>alert('Member ID does not exit');</script");
                }
                else
                {
                    Response.Write("<script>alert('Invalid Password');</script");
                }
            }
            else
            {
                Response.Write("<script>alert('Missing Field!');</script");
            }
        }

        bool verify()
        {
            if(TextBoxMemberID.Text.Trim() == "" || TextBoxMemberPassword.Text.Trim() == "")
            {
                return false;
            }
            else
            {
                model.memberID = TextBoxMemberID.Text;
                model.password = TextBoxMemberPassword.Text;

                jsonstring = JsonConvert.SerializeObject(model);
                return true;
            }
        }
    }
}