using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ELibrary2.models;
using Newtonsoft.Json;
using ELibrary2.Classes;

namespace ELibrary2
{
    public partial class usersignup : System.Web.UI.Page
    {
        MEMBERS member = new MEMBERS();
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSignupYes_Click(object sender, EventArgs e)
        {
            try
            {
                membersModel model = new membersModel();
                model.fullName = TextBoxFullName.Text;
                model.birthdate = TextBoxBirthdate.Text;
                model.contactNo = TextBoxContact.Text;
                model.email = TextBoxEmail.Text;
                model.state = DropDownListState.SelectedItem.Value;
                model.city = TextBoxCity.Text;
                model.zipCode = TextBoxCode.Text;
                model.fullAddress = TextBoxAddress.Text;
                model.memberID = TextBoxUserID.Text;
                model.password = TextBoxPassword.Text;
                model.accountStatus = "Pending";

                string jsonstring = JsonConvert.SerializeObject(model);

                if (verify())
                {
                    if (passwordMatch())
                    {
                        int output = member.addMember(jsonstring);
                        if (output == 10)
                        {
                            Response.Write("<script>alert('Added Successfully');</script");
                        }
                        else if (output == 5)
                        {
                            Response.Write("<script>alert('Add Failed');</script");
                        }
                        else if (output == 1)
                        {
                            Response.Write("<script>alert('Member ID Already Taken');</script");
                        }
                        else
                        {
                            Response.Write("<script>alert('Full Name Already Exist');</script");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Password not match!');</script");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Missing Field!');</script");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('"+ ex.Message +"');</script");
            }
        }

        bool verify()
        {
            if(TextBoxFullName.Text.Trim() == "" || TextBoxBirthdate.Text.Trim() == "" || TextBoxEmail.Text.Trim() == "" || TextBoxContact.Text.Trim() == "" || DropDownListState.Text.Trim() == "Select" || TextBoxCity.Text.Trim() == "" || TextBoxCode.Text.Trim() == "" || TextBoxAddress.Text.Trim() == "" || TextBoxUserID.Text.Trim() == "" || TextBoxPassword.Text.Trim() == "" || TextBoxConfirmPassword.Text.Trim() == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        bool passwordMatch()
        {
            if(TextBoxPassword.Text.Trim() == TextBoxConfirmPassword.Text.Trim())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}