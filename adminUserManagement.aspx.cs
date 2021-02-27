using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ELibrary2.models;
using ELibrary2.Classes;
using Newtonsoft.Json;

namespace ELibrary2
{
    public partial class adminUserManagement : System.Web.UI.Page
    {
        membersModel model = new membersModel();
        MEMBERS member = new MEMBERS();
        string jsonstring;
        string buttonStatus;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["role"] != "admin")
            {
                Response.Redirect("adminLogin.aspx");
            }
            else
            {
                GridView1.DataBind();
            }
        }

        public void statusUpdater()
        {
            int result = member.updateMemberStatus(jsonstring);

            if (result == 1)
            {
                GridView1.DataBind();
                fillData();
            }
            else if (result == 2)
            {
                Response.Write("<script>alert('Member ID does not exist!')</script>");
            }
            else
            {
                Response.Write("<script>alert('UPDATE QUERY ERROR!')</script>");
            }
        }

        public void serialize()
        {
            model.memberID = TextBoxMemberID.Text;
            model.accountStatus = buttonStatus;
            model.fullName = TextBoxFullname.Text;

            jsonstring = JsonConvert.SerializeObject(model);
        }

        public void fillData()
        {
            DataTable table = member.getMemberByID(jsonstring);

            if (table.Rows.Count > 0)
            {
                TextBoxFullname.Text = table.Rows[0]["full_name"].ToString();
                TextBoxAccountStatus.Text = table.Rows[0]["account_status"].ToString();
                TextBoxBirthdate.Text = table.Rows[0]["birthdate"].ToString();
                TextBoxContactNumber.Text = table.Rows[0]["contact_no"].ToString();
                TextBoxEmail.Text = table.Rows[0]["email"].ToString();
                TextBoxState.Text = table.Rows[0]["state"].ToString();
                TextBoxCity.Text = table.Rows[0]["city"].ToString();
                TextBoxCode.Text = table.Rows[0]["zip_code"].ToString();
                TextBoxAddress.Text = table.Rows[0]["full_address"].ToString();
            }
            else
            {
                Response.Write("<script>alert('No Data!')</script>");
            }
        }

        public void ButtonGo_Click(object sender, EventArgs e)
        {
            serialize();
            fillData();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex);
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBoxMemberID.Text = GridView1.SelectedRow.Cells[0].Text;
        }

        protected void LinkButtonActive_Click(object sender, EventArgs e)
        {
            buttonStatus = "Active";
            serialize();
            statusUpdater();
        }

        protected void LinkButtonPending_Click(object sender, EventArgs e)
        {
            buttonStatus = "Pending";
            serialize();
            statusUpdater();
        }

        protected void LinkButtonInactive_Click(object sender, EventArgs e)
        {
            buttonStatus = "Inactive";
            serialize();
            statusUpdater();
        }

        protected void ButtonDeleteMember_Click(object sender, EventArgs e)
        {
            serialize();
            int result = member.deleteMemberByFullName(jsonstring);

            if(result == 1)
            {
                GridView1.DataBind();
                clearForm();
            }
            else if(result == 2)
            {
                Response.Write("<script>alert('Delete Failed! ID and Name does not match! ');</script>");
            }
            else
            {
                Response.Write("<script>alert('QUERY DELETE ERROR!');</script>");
            }
        }

        public void clearForm()
        {
            TextBoxMemberID.Text = "";
            TextBoxFullname.Text = "";
            TextBoxAccountStatus.Text = "";
            TextBoxBirthdate.Text = "";
            TextBoxContactNumber.Text = "";
            TextBoxEmail.Text = "";
            TextBoxState.Text = "";
            TextBoxCity.Text = "";
            TextBoxCode.Text = "";
            TextBoxAddress.Text = "";
        }
    }
}