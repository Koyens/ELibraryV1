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
    public partial class adminPublisherManagement : System.Web.UI.Page
    {
        PUBLISHER publisher = new PUBLISHER();
        publisherModels model = new publisherModels();
        string jsonstring;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"] != "admin")
            {
                Response.Redirect("adminLogin.aspx");
            }
            else
            {
                model.publisherID = TextBoxPublisherID.Text;
                model.publisherName = TextBoxPublisherName.Text;

                jsonstring = JsonConvert.SerializeObject(model);
            }
        }


        protected void ButtonPublisherAdd_Click1(object sender, EventArgs e)
        {
            int result = publisher.addPublisher(jsonstring);

            if (result == 1)
            {
                GridViewPublisher.DataBind();
            }
            else if (result == 2)
            {
                Response.Write("<script>alert('Add Failed! Publisher ID already exist!')</script>");
            }
            else if (result == 3)
            {
                Response.Write("<script>alert('Missing Field!')</script>");
            }
            else
            {
                Response.Write("<script>alert('ADD QUERY FAILED!')</script>");
            }
        }

        protected void ButtonPublisherUpdate_Click(object sender, EventArgs e)
        {
            int result = publisher.updatePublisher(jsonstring);

            if(result == 1)
            {
                GridViewPublisher.DataBind();
            }
            else if(result == 2)
            {
                Response.Write("<script>alert('Update Failed! Publisher ID does not exist!')</script>");
            }
            else if(result == 3)
            {
                Response.Write("<script>alert('Missing Field!')</script>");
            }
            else
            {
                Response.Write("<script>alert('UPDATE QUERY FAILED!')</script>");
            }
        }

        protected void ButtonPublisherDelete_Click(object sender, EventArgs e)
        {
            int result = publisher.deletePublisher(jsonstring);

            if(result == 1)
            {
                GridViewPublisher.DataBind();
            }
            else if(result == 2)
            {
                Response.Write("<script>alert('Delete Failed! Publisher ID does not exist!')</script>");
            }
            else if(result == 3)
            {
                Response.Write("<script>alert('Missing Field!')</script>");
            }
            else
            {
                Response.Write("<script>alert('Delete Failed! Invalid Publisher Name!')</script>");
            }
        }

        protected void ButtonGo_Click(object sender, EventArgs e)
        {
            DataTable table = publisher.getPublisherByID(TextBoxPublisherID.Text);

            if(table.Rows.Count > 0)
            {
                TextBoxPublisherName.Text = table.Rows[0]["publisher_name"].ToString();
            }
            else
            {
                Response.Write("<script>alert('No Data!')</script>");
            }
        }
    }
}