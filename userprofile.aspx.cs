using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ELibrary2.models;
using ELibrary2.Classes;
using System.Data;
using Newtonsoft.Json;

namespace ELibrary2
{
    public partial class userprofile : System.Web.UI.Page
    {
        MEMBERS member = new MEMBERS();
        membersModel model = new membersModel();
        ISSUE_BOOK issueBook = new ISSUE_BOOK();

        string jsonstring;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["fullname"] == "" || Session["fullname"] == null)
            {
                Response.Write("<script>alert('Session Expired! Login Again!');</script>");
                Response.Redirect("userlogin.aspx");
            }
            else
            {
                model.memberID = Session["username"].ToString().Trim();
                jsonstring = JsonConvert.SerializeObject(model);
                DataTable table = member.getMemberByID(jsonstring);

                TextBoxFullName.Text = table.Rows[0]["full_name"].ToString();
                TextBoxBirthdate.Text = table.Rows[0]["birthdate"].ToString();
                TextBoxContactNumber.Text = table.Rows[0]["contact_no"].ToString();
                TextBoxEmail.Text = table.Rows[0]["email"].ToString();
                DropDownListState.SelectedValue = table.Rows[0]["state"].ToString();
                TextBoxCity.Text = table.Rows[0]["city"].ToString();
                TextBoxCode.Text = table.Rows[0]["zip_code"].ToString();
                TextBoxAddress.Text = table.Rows[0]["full_address"].ToString();
                TextBoxUserID.Text = table.Rows[0]["member_id"].ToString();
                TextBoxOldPassword.Text = table.Rows[0]["password"].ToString();
                LabelStatus.Text = Session["accountstatus"].ToString();

                GridView1.DataSource = issueBook.getIssueDetailsByID(Session["username"].ToString());
                GridView1.DataBind();
            }
        }

        void serialize()
        {
            model.fullName = TextBoxFullName.Text;
            model.birthdate = TextBoxBirthdate.Text;
            model.contactNo = TextBoxContactNumber.Text;
            model.email = TextBoxEmail.Text;
            model.state = DropDownListState.SelectedValue.ToString();
            model.city = TextBoxCity.Text;
            model.zipCode = TextBoxCode.Text;
            model.fullAddress = TextBoxAddress.Text;
            model.memberID = TextBoxUserID.Text;
            model.password = TextBoxNewPassword.Text;

            jsonstring = JsonConvert.SerializeObject(model);
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow)
            {
                DateTime dt = Convert.ToDateTime(e.Row.Cells[5].Text);
                DateTime today = DateTime.Today;

                if(today > dt)
                {
                    e.Row.BackColor = System.Drawing.Color.PaleVioletRed;
                }
            }
        }

        protected void ButtonUpdateProfile_Click(object sender, EventArgs e)
        {
            serialize();

            int result = member.updateMember(jsonstring);

            if(result == 0)
            {
                Response.Write("<script>alert('UPDATE QUERY FAILED!');</script>");
            }
            else if(result == 1)
            {
                if(TextBoxNewPassword.Text != "")
                {
                    TextBoxOldPassword.Text = TextBoxNewPassword.Text.ToString();
                    TextBoxNewPassword.Text = "";
                }
                Response.Write("<script>alert('UPDATED SUCCESSFULLY!');</script>");

            }
            else if(result == 2)
            {
                Response.Write("<script>alert('Missing Field!');</script>");
            }
            else if(result == 3)
            {
                Response.Write("<script>alert('Full Name Already Taken!');</script>");
            }
            else if(result == 4)
            {
                Response.Write("<script>alert('Date must not be greater than today!');</script>");
            }
            else
            {
                Response.Write("<script>alert('Try Catch Error!');</script>");
            }
        }
    }
}