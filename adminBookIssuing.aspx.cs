using ELibrary2.Classes;
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

namespace ELibrary2
{
    public partial class adminBookIssuing : System.Web.UI.Page
    {
        BOOK_INVENTORY bookInv = new BOOK_INVENTORY();
        ISSUE_BOOK issueBook = new ISSUE_BOOK();
        MEMBERS member = new MEMBERS();
        membersModel model = new membersModel();
        issueBookModels issuemodels = new issueBookModels();
        string jsonstring;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["role"] != "admin")
            {
                Response.Redirect("adminLogin.aspx");
            }
        }

        void serialize()
        {
            issuemodels.bookID = TextBoxBookID.Text;
            issuemodels.bookName = TextBoxBookName.Text;
            issuemodels.memberID = TextBoxMemberID.Text;
            issuemodels.memberName = TextBoxMemberName.Text;
            issuemodels.issueDate = TextBoxStartDate.Text;
            issuemodels.dueDate = TextBoxEndDate.Text;

            jsonstring = JsonConvert.SerializeObject(issuemodels);
        }

        void clearForm()
        {
            TextBoxMemberID.Text = "";
            TextBoxMemberName.Text = "";
            TextBoxBookID.Text = "";
            TextBoxBookName.Text = "";
            TextBoxStartDate.Text = "";
            TextBoxEndDate.Text = "";
        }

        protected void ButtonGo_Click(object sender, EventArgs e)
        {
            try
            {
                model.memberID = TextBoxMemberID.Text;
                jsonstring = JsonConvert.SerializeObject(model);

                DataTable tblMembers = member.getMemberByID(jsonstring);
                DataTable tblBooks = bookInv.getBookDetails(TextBoxBookID.Text);

                if(tblMembers.Rows.Count == 0 )
                {
                    Response.Write("<script>alert('Member Does not exist!');</script>");
                }
                else if(tblBooks.Rows.Count == 0)
                {
                    Response.Write("<script>alert('Book Does not exist!');</script>");
                }
                else
                {
                    TextBoxMemberName.Text = tblMembers.Rows[0]["full_name"].ToString();
                    TextBoxBookName.Text = tblBooks.Rows[0]["book_name"].ToString();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void ButtonIssueBook_Click(object sender, EventArgs e)
        {
            serialize();

            int result = issueBook.issueBook(jsonstring);

            if(result == 1)
            {
                GridViewBookIssuing.DataBind();
                clearForm();
            }
            else if(result == 2)
            {
                Response.Write("<script>alert('Issue Failed! This book is out of stock!');</script>");
            }
            else if(result == 3)
            {
                Response.Write("<script>alert('Book Does not exist!');</script>");
            }
            else if(result == 4)
            {
                Response.Write("<script>alert('Select Dates!');</script>");
            }
            else if(result == 5)
            {
                Response.Write("<script>alert('Member Does not exist!');</script>");
            }
            else if(result == 6)
            {
                Response.Write("<script>alert('Issue Date must nt be previous from today!');</script>");
            }
            else if(result == 7)
            {
                Response.Write("<script>alert('Due Date must not be equal or less than the issue date!');</script>");
            }
            else if(result == 8)
            {
                Response.Write("<script>alert('Member already have this book!');</script>");
            }
            else if(result == 9)
            {
                Response.Write("<script>alert('Check member status!');</script>");
            }
            else if(result == 10)
            {
                Response.Write("<script>alert('You cannot issue book because you have an unreturned book!');</script>");
            }
            else if(result == 500)
            {
                Response.Write("<script>alert('Try catch Error!');</script>");
            }
            else
            {
                Response.Write("<script>alert('ISSUE QUERY FAILED!');</script>");
            }
        }

        protected void ButtonReturnBook_Click(object sender, EventArgs e)
        {
            serialize();

            int result = issueBook.returnBook(jsonstring);

            if(result == 0)
            {
                Response.Write("<script>alert('QUERY FAILED!');</script>");
            }
            else if(result == 1)
            {
                GridViewBookIssuing.DataBind();
                clearForm();
            }
            else if(result == 2)
            {
                Response.Write("<script>alert('Member Does not exist!');</script>");
            }
            else if(result == 3)
            {
                Response.Write("<script>alert('Book does not exist!');</script>");
            }
            else if(result == 4)
            {
                Response.Write("<script>alert('You have not borrowed this book!');</script>");
            }
            else if(result == 400)
            {
                Response.Write("<script>alert('Your account status is still pending!');</script>");
            }
            else
            {
                Response.Write("<script>alert('Try Catch Error!');</script>");
            }
        }

        protected void GridViewBookIssuing_RowDataBound(object sender, GridViewRowEventArgs e)
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
    }
}