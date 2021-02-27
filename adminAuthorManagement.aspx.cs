using ELibrary2.Classes;
using ELibrary2.models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ELibrary2
{
    public partial class adminAuthorManagement : System.Web.UI.Page
    {
        AUTHOR author = new AUTHOR();
        authorModels model = new authorModels();
        string jsonstring;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["role"] != "admin")
            {
                Response.Redirect("adminLogin.aspx");
            }
        }

        bool verify()
        {
            if(TextBoxAuthorID.Text.Trim() == "" || TextBoxAuthorName.Text.Trim() == "")
            {
                return false;
            }
            else
            {
                model.authorID = TextBoxAuthorID.Text;
                model.authorFullName = TextBoxAuthorName.Text;

                jsonstring = JsonConvert.SerializeObject(model);
                return true;
            }
        }

        protected void ButtonAddAuthorYes_Click(object sender, EventArgs e)
        {
            if(verify())
            {
                int result = author.addAuthor(jsonstring);

                if(result == 1)
                {
                    GridView1.DataBind();
                }
                else if(result == 2)
                {
                    Response.Write("<script>alert('Add Failed! Author ID already exist');</script>");
                }
                else
                {
                    Response.Write("<script>alert('QUERY ADD FAILED!');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Missing Field!');</script>");
            }
        }

        protected void ButtonUpdateAuthorYes_Click(object sender, EventArgs e)
        {
            if(verify())
            {
                int result = author.updateAuthor(jsonstring);

                if(result == 1)
                {
                    GridView1.DataBind();
                }
                else if(result == 2)
                {
                    Response.Write("<script>alert('Update Failed! Author ID does not exist!');</script>");
                }
                else
                {
                    Response.Write("<script>alert('QUERY UPDATE FAILED!');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Missing Field!');</script>");
            }
        }

        protected void ButtonDeleteAuthorYes_Click(object sender, EventArgs e)
        {
            if(verify())
            {
                int result = author.deleteAuthor(jsonstring);

                if(result == 1)
                {
                    GridView1.DataBind();
                }
                else if(result == 2)
                {
                    Response.Write("<script>alert('Delete Failed! Author ID does not exist!');</script>");
                }
                else
                {
                    Response.Write("<script>alert('QUERY DELETE FAILED!');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Missing Field!');</script>");
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ButtonGo_Click(object sender, EventArgs e)
        {
            DataTable table = author.getAuthorByID(TextBoxAuthorID.Text);

            if(table.Rows.Count > 0)
            {
                TextBoxAuthorName.Text = table.Rows[0]["author_name"].ToString();
            }
            else
            {
                Response.Write("<script>alert('No Data!');</script>");
            }
        }
    }
}