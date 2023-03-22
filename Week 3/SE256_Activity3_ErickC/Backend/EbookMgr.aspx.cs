using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SE256_Activity_ErickC.App_Code; //Added this reference to get easy access to classes in the APP_Code Folder

namespace SE256_Activity_ErickC.Backend
{
    public partial class EbookMgr : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //If the user is already logged in, We can keep them here
            if (Session["LoggedIn"] != null && Session["LoggedIn"].ToString() == "True")
            {
                //We can stay here.. They are good
            }

            else
            {
                //if they are not logged in, send them to the backend's page to login
                Response.Redirect("~/Backend/Default.aspx");
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            EBook temp = new EBook(); //Create a temporary book item and run constructor

            temp.Title = txtTitle.Text; //Fill in the temp book with info from the form

            temp.AuthorFirst = txtAuthorFirst.Text;
            temp.AuthorLast = txtAuthorLast.Text;
            temp.Email = txtAuthorEmail.Text;
            temp.DatePublished = calDatePublished.SelectedDate; //Notice we used calendar object to get a DateTime
            temp.DateRentalExpires = calRentalExpires.SelectedDate;

            //If # of pages is a legit integer, We copy it over the object
            Int32 intPages = 0;
            if (Int32.TryParse(txtPages.Text, out intPages))
            {
                temp.Pages = intPages;
            }

            //if price is a legit double, we copy it over the object
            Double dblPrice = 0;
            if (Double.TryParse(txtPrice.Text, out dblPrice))
            {
                temp.Price = dblPrice;
            }

            //If Bookmark page is a legit interger, we copy it over the object
            Int32 intBookmarkPage = 0;
            if (Int32.TryParse(txtBookmarkPage.Text, out intBookmarkPage))
            {
                temp.BookmarkPage = intBookmarkPage;
            }

            if (temp.Feedback.Contains("ERROR:")) //If there is an error it will appear
            {
                lblFeeback.Text = temp.Feedback;
            }

            else
            {
                lblFeeback.Text = temp.AddARecord(); //Display some info
            }


        }
    }
}