using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SE256_Activity_ErickC.App_Code;
using System.Data;
using System.Data.SqlClient;



namespace SE256_Activity_ErickC.Backend
{
    public partial class ProductMgr : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //If the user is already logged in, we can keep them here
            if (Session["LoggedIn"] != null && Session["LoggedIn"].ToString() == "True")
            {
                //We can stay here... they are good
            }

            else
            {
                //if they are not logged in, send them to the backend's page to login
                Response.Redirect("~/Backend/Default.aspx");
            }

            //Code to check if thee is an existing EProduct ID that we need to pull up one Product and display it

            string strEProductID = "";
            int intEProductID = 0;

            //does EProduct exist
            if ((!IsPostBack) && Request.QueryString["ProductID"] != null)
            {
                //If there is an ID there is no need to show the add buttton
                btnAdd.Visible= false;
                btnAdd.Enabled= false;
                //If so .. gather Products ID and Fill form

                strEProductID = Request.QueryString["ProductID"].ToString();
                lblProduct_ID.Text = strEProductID;

                intEProductID = Convert.ToInt32(strEProductID);

                //Fill the "temp" Product info based on ID
                EProducts temp = new EProducts();
                SqlDataReader dr = temp.FindOneEProduct(intEProductID);


                while (dr.Read())
                {
                    txtBrand.Text = dr["Brand"].ToString();
                    txtModel.Text = dr["Model"].ToString();
                    txtCategory.Text = dr["Category"].ToString();
                    txtDescription.Text = dr["Description"].ToString();
                    txtPrice.Text = dr["Price"].ToString();
                    txtQuantity.Text = dr["Quantity"].ToString();
                    txtWeight.Text = dr["Weight"].ToString();

                    calReleaseDate.VisibleDate = DateTime.Parse(dr["ReleaseDate"].ToString()).Date;
                    calReleaseDate.SelectedDate = DateTime.Parse(dr["ReleaseDate"].ToString()).Date;

                    btnActive.Text = dr["Active"].ToString();
                
                }
            }

            else 
            {
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnDelete.Enabled = false;
                btnUpdate.Enabled = false;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            EProducts temp = new EProducts();

            temp.Brand = txtBrand.Text;
            temp.Model = txtModel.Text;
            temp.Category = txtCategory.Text;
            temp.Description = txtDescription.Text;
            temp.ReleaseDate = calReleaseDate.SelectedDate;

            if (btnActive.SelectedValue == "1")
            {
                temp.Active = true;
            }
            else
            {
                temp.Active = false;
            }


            Double dblPrice = 0;
            if (Double.TryParse(txtPrice.Text, out dblPrice))
            {
                temp.Price = dblPrice;
            }

            Int32 intQuantity = 0;
            if (Int32.TryParse(txtQuantity.Text, out intQuantity))
            {
                temp.Quantity = intQuantity;
            }

            Double dblweight = 0;
            if (Double.TryParse(txtWeight.Text, out dblweight))
            {
                temp.Weight = dblweight;
            }



            if (temp.Feedback.Contains("Error:"))
            {
                lblFeedback.Text = temp.Feedback;
            }

            else
            {
                lblFeedback.Text = temp.AddARecord();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            EProducts temp = new EProducts();
            temp.ProductID = Int32.Parse(lblProduct_ID.Text);
            temp.Brand = txtBrand.Text;
            temp.Model = txtModel.Text;
            temp.Category = txtCategory.Text;
            temp.Description = txtDescription.Text;
            temp.ReleaseDate = calReleaseDate.SelectedDate;

            if (btnActive.SelectedValue == "1")
            {
                temp.Active = true;
            }
            else 
            {
                temp.Active = false;
            }


            Int32 intQuantity = 0;
            if (Int32.TryParse(txtQuantity.Text, out intQuantity))
            {
                temp.Quantity = intQuantity;
            }

            Double dblWeight = 0;
            if (Double.TryParse(txtWeight.Text, out dblWeight))
            {
                temp.Weight = dblWeight;
            }

            Double dblPrice = 0;
            if (Double.TryParse(txtPrice.Text, out dblPrice))
            {
                temp.Price = dblPrice;
            }
            if (temp.Feedback.Contains("Error:"))
            {
                lblFeedback.Text = temp.Feedback;
            }
            else
            {
                lblFeedback.Text = temp.UpdateARecord();
            }

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Int32 intEProductID = Convert.ToInt32(lblProduct_ID.Text); //Get the ID from Label

            //Create a EProduct so we can use the delete method
            EProducts temp = new EProducts();

            //Use the EProducts and pass it to the delete function
            lblFeedback.Text = temp.DeleteOneProduct(intEProductID);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Backend/ControlPanel"); //Sends user back to control panel
        }


    }

    
}