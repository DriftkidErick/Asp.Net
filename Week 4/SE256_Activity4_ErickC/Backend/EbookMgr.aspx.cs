using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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


            //Code to check if there is an existing EBook ID that we need to pull up one book and display it
            string strEBook_ID = "";
            int intEBook_ID = 0;

            //Does eBook_ID Exist?
            if ((!IsPostBack) && Request.QueryString["EBookID"] != null)
            {
                //If there is an ID, There is not need to show the Add Button
                btnAdd.Visible = false;
                btnAdd.Enabled = false;

                //If so gather ebook id and fill form
                strEBook_ID = Request.QueryString["EBookID"].ToString();
                lblEBook_ID.Text = strEBook_ID;

                intEBook_ID = Convert.ToInt32(strEBook_ID);

                //Fill the 'temp' ebook info based on ID
                EBook temp = new EBook();
                SqlDataReader dr = temp.FindOneEBook(intEBook_ID);

                while (dr.Read())
                {
                    txtTitle.Text = dr["Title"].ToString();
                    txtAuthorFirst.Text = dr["AuthorFirst"].ToString();
                    txtAuthorLast.Text = dr["AuthorLast"].ToString();
                    txtAuthorEmail.Text = dr["Email"].ToString();
                    txtPages.Text = dr["Pages"].ToString();
                    txtPrice.Text = dr["Price"].ToString();
                    txtBookmarkPage.Text = dr["BookmarkPage"].ToString();

                    calDatePublished.VisibleDate = DateTime.Parse(dr["DatePublished"].ToString()).Date;
                    calDatePublished.SelectedDate = DateTime.Parse(dr["DatePublished"].ToString()).Date;

                    calRentalExpires.VisibleDate = DateTime.Parse(dr["DateRentalExpires"].ToString()).Date;
                    calRentalExpires.SelectedDate = DateTime.Parse(dr["DateRentalExpires"].ToString()).Date;

                }
            }

            else
            {
                //No Ebook ID, So it must be an add. Hide the Delete and Update Buttons

                //Not Visible
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                //Not Enabled
                btnDelete.Enabled = false;
                btnUpdate.Enabled = false;


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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            EBook temp = new EBook();
            temp.EBook_ID = Int32.Parse(lblEBook_ID.Text);
            temp.Title = txtTitle.Text; //Fill in temp book with info from form
            temp.AuthorFirst = txtAuthorFirst.Text;
            temp.AuthorLast = txtAuthorLast.Text;
            temp.Email = txtAuthorEmail.Text;

            //Notice how these use Cal
            temp.DatePublished = calDatePublished.SelectedDate;
            temp.DateRentalExpires = calRentalExpires.SelectedDate;

            //If # of pages is a legit integer, we copy it over the object
            Int32 intPages = 0;
            if (Int32.TryParse(txtPages.Text, out intPages))
            {
                temp.Pages = intPages;
            }

            //If price is a legit double, we copy it over the object
            Double dblPrice = 0;
            if (Double.TryParse(txtPrice.Text, out dblPrice))
            {
                temp.Price = dblPrice;
            }

            //If Bookmark Pages is a legit integer, We copy it over the object
            Int32 intBookmarkPage = 0;
            if (Int32.TryParse(txtBookmarkPage.Text, out intBookmarkPage))
            {
                temp.BookmarkPage = intBookmarkPage;
            }

            if (temp.Feedback.Contains("Error::")) //If theres an error display it in the feedback lable
            {
                lblFeeback.Text = temp.Feedback;
            }
            else //Attempt to add the record and display results feedback
            {
                lblFeeback.Text = temp.UpdateARecord();
            }

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Int32 intEBook_ID = Convert.ToInt32(lblEBook_ID.Text); //Get the ID from the lable

            //Create a Ebook so we can use the delete method
            EBook temp = new EBook();

            //Use the Ebook ID and pass it to the delete function
            //And get the number of records deleted
            lblFeeback.Text = temp.DeleteOneEBook(intEBook_ID);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Backend/ControlPanel"); //Sends user abck to control panel
        }
    }
}