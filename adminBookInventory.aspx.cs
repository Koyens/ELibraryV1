using ELibrary2.Classes;
using ELibrary2.models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ELibrary2
{
    public partial class adminBookInventory : System.Web.UI.Page
    {
        AUTHOR author = new AUTHOR();
        PUBLISHER publisher = new PUBLISHER();
        BOOK_INVENTORY bookInv = new BOOK_INVENTORY();
        bookInventoryModels model = new bookInventoryModels();
        static string global_filepath, global_book_id;
        static int global_actual_stock, global_current_stock, global_issued_books;
        string jsonstring;
        string status = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"] != "admin")
            {
                Response.Redirect("adminLogin.aspx");
            }
            else if(!IsPostBack)
            {
                DropDownListAuthorName.DataSource = author.getAuthorNames();
                DropDownListAuthorName.DataValueField = "author_name";
                DropDownListAuthorName.DataBind();
                DropDownListAuthorName.Items.Insert(0, "Select");

                DropDownListPublisherName.DataSource = publisher.getPublisherNames();
                DropDownListPublisherName.DataValueField = "publisher_name";
                DropDownListPublisherName.DataBind();
                DropDownListPublisherName.Items.Insert(0, "Select");
            }
        }

        public void serialize(string genre, string filepath)
        {
            model.bookID = TextBoxBookID.Text;
            model.bookName = TextBoxBookName.Text;
            model.language = DropDownListLanguage.SelectedItem.Value;
            model.publisherName = DropDownListPublisherName.SelectedItem.Value;
            model.authorName = DropDownListAuthorName.SelectedItem.Value;
            model.publisDate = TextBoxPublishDate.Text;
            model.genre = genre;
            model.edition = TextBoxEdition.Text;
            model.bookCost = TextBoxBookCost.Text;
            model.pagesNo = TextBoxPages.Text;
            model.actualStock = TextBoxActualStock.Text;
            model.bookDescription = TextBoxBookDescription.Text;
            model.bookLink = filepath;

            if(status == "Add")
            {
                model.currentStock = TextBoxActualStock.Text;
            }
            else
            {
                model.currentStock = TextBoxCurrentStock.Text;
            }

            jsonstring = JsonConvert.SerializeObject(model);
        }

        protected void ButtonAddBook_Click(object sender, EventArgs e)
        {
            status = "Add";
            try
            {
                string genre = "";

                foreach (int i in ListBoxGenre.GetSelectedIndices())
                {
                    genre = genre + ListBoxGenre.Items[i] + ",";
                }
                genre = genre.Remove(genre.Length - 1);

                string filepath = "~/book_inventory/books1.png";
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.SaveAs(Server.MapPath("book_inventory/" + filename));
                filepath = "~/book_inventory/" + filename;

                serialize(genre, filepath);

                int result = bookInv.addBook(jsonstring);

                if (result == 1)
                {
                    GridViewBookInventory.DataBind();
                    clearForm();
                }
                else if (result == 2)
                {
                    Response.Write("<script>alert('Missing Field!');</script>");
                }
                else if (result == 3)
                {
                    Response.Write("<script>alert('Book Already Exist!');</script>");
                }
                else
                {
                    Response.Write("<script>alert('ADD QUERY ERROR!');</script>");
                }
            }
            catch (System.IO.DirectoryNotFoundException)
            {
                Response.Write("<script>alert('Please select an image for your book!');</script>");
            }
            catch (System.ArgumentOutOfRangeException)
            {
                Response.Write("<script>alert('Please select genre!');</script>");
            }
        }

        protected void ButtonUpdateBook_Click(object sender, EventArgs e)
        {
            status = "Update";
            try
            {
                if(TextBoxBookID.Text == global_book_id)
                {
                    int actual_stock = Convert.ToInt32(TextBoxActualStock.Text.Trim());
                    int current_stock = Convert.ToInt32(TextBoxCurrentStock.Text.Trim());

                    if(actual_stock != global_actual_stock)
                    {
                        if (actual_stock < global_issued_books)
                        {
                            Response.Write("<script>alert('Issued books cannot be greater than issued books!');</script>");
                            return;
                        }
                        else
                        {
                            current_stock = actual_stock - global_issued_books;
                            TextBoxCurrentStock.Text = "" + current_stock;
                            global_actual_stock = actual_stock;
                            global_current_stock = current_stock;
                        }
                    }

                    string genre = "";
                    foreach (int item in ListBoxGenre.GetSelectedIndices())
                    {
                        genre = genre + ListBoxGenre.Items[item] + ',';
                    }
                    genre = genre.Remove(genre.Length - 1);

                    string filepath = "~/book_inventory/books1.png";
                    string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);

                    if (filename == "" || filename == null)
                    {
                        filepath = global_filepath;
                    }
                    else
                    {
                        FileUpload1.SaveAs(Server.MapPath("book_inventory/" + filename));
                        filepath = "~/book_inventory/" + filename;
                    }
                    serialize(genre, filepath);

                    int result = bookInv.updateBookByID(jsonstring);

                    if (result == 1)
                    {
                        Response.Write("<script>alert('Updated Successfully!');</script>");
                        GridViewBookInventory.DataBind();
                    }
                    else if(result == 2)
                    {
                        Response.Write("<script>alert('Missing Field!');</script>");
                    }
                    else if(result == 3)
                    {
                        Response.Write("<script>alert('Book Name Already Exist!');</script>");
                    }
                    else if(result == 4)
                    {
                        Response.Write("<script>alert('Book ID Does not Exist!');</script>");
                    }
                    else if(result == 500)
                    {
                        Response.Write("<script>alert('BookInventory Class trycatch Error!');</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Update QUERY Error!');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Please press Go first!');</script>");
                }
            }
            catch (System.ArgumentOutOfRangeException)
            {
                Response.Write("<script>alert('Please select genre!');</script>");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void clearForm()
        {
            TextBoxBookID.Text = "";
            TextBoxBookName.Text = "";
            DropDownListLanguage.SelectedValue = "Select";
            DropDownListAuthorName.SelectedValue = "Select";
            DropDownListPublisherName.SelectedValue = "Select";
            TextBoxPublishDate.Text = "";
            ListBoxGenre.SelectedValue = null;
            TextBoxEdition.Text = "";
            TextBoxBookCost.Text = "";
            TextBoxPages.Text = "";
            TextBoxActualStock.Text = "";
            TextBoxCurrentStock.Text = "";
            TextBoxIssuedBooks.Text = "";
            TextBoxBookDescription.Text = "";
        }

        protected void ButtonDeleteBook_Click(object sender, EventArgs e)
        {
            ListBoxGenre.SelectedValue = null;
        }

        protected void ButtonGo_Click(object sender, EventArgs e)
        {
            DataTable table = bookInv.getBookDetails(TextBoxBookID.Text);

            if(table.Rows.Count > 0)
            {
                TextBoxBookName.Text = table.Rows[0]["book_name"].ToString();
                DropDownListLanguage.SelectedValue = table.Rows[0]["language"].ToString();
                DropDownListAuthorName.SelectedValue = table.Rows[0]["author_name"].ToString();
                DropDownListPublisherName.SelectedValue = table.Rows[0]["publisher_name"].ToString();
                TextBoxPublishDate.Text = table.Rows[0]["publish_date"].ToString();
                TextBoxEdition.Text = table.Rows[0]["edition"].ToString();
                TextBoxBookCost.Text = table.Rows[0]["book_cost"].ToString().Trim();
                TextBoxPages.Text = table.Rows[0]["no_of_pages"].ToString().Trim();
                TextBoxActualStock.Text = table.Rows[0]["actual_stock"].ToString().Trim();
                TextBoxCurrentStock.Text = table.Rows[0]["current_stock"].ToString().Trim();
                TextBoxIssuedBooks.Text = "" + (Convert.ToInt32(table.Rows[0]["actual_stock"].ToString()) - Convert.ToInt32(table.Rows[0]["current_stock"].ToString()));
                TextBoxBookDescription.Text = table.Rows[0]["book_description"].ToString();

                string[] genreList = table.Rows[0]["genre"].ToString().Trim().Split(',');

                for(int i = 0; i < genreList.Length; i++)
                {
                    for(int j = 0; j < ListBoxGenre.Items.Count; j++)
                    {
                        if(ListBoxGenre.Items[j].ToString() == genreList[i].ToString())
                        {
                            ListBoxGenre.Items[j].Selected = true;
                        }
                        else
                        {
                            ListBoxGenre.Items[j].Selected = false;
                        }
                    }
                }

                global_filepath = table.Rows[0]["book_img_link"].ToString().Trim();
                global_actual_stock = Convert.ToInt32(table.Rows[0]["actual_stock"].ToString().Trim());
                global_current_stock = Convert.ToInt32(table.Rows[0]["current_stock"].ToString().Trim());
                global_issued_books = global_actual_stock - global_current_stock;
                global_book_id = table.Rows[0]["book_id"].ToString().Trim();
            }
            else
            {
                Response.Write("<script>alert('Please input valid ID!');</script>");
            }
        }
    }
}