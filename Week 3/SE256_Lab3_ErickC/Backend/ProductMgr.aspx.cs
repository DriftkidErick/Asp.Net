using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SE256_Activity_ErickC.App_Code;

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
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            EProducts temp = new EProducts();

            temp.Brand = txtBrand.Text;
            temp.Model = txtModel.Text;
            temp.Category = txtCategory.Text;
            temp.Description = txtDescription.Text;
            temp.ReleaseDate = calReleaseDate.SelectedDate;


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
    }
}