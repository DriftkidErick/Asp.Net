using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SE256_Activity_ErickC.App_Code;

namespace SE256_Activity_ErickC.Backend
{
    public partial class EProductSearch : System.Web.UI.Page
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //Filling a Dataset and Binding it to a GridView Object

            EProducts temp = new EProducts();

            //USe the object's function to fill a Dataset Object
            DataSet ds = temp.SearchEProducts_DS(txtBrand.Text, txtModel.Text);

            dgResults.DataSource = ds;
            dgResults.DataMember = ds.Tables[0].TableName; //
            dgResults.DataBind(); //Bind the data

        }
    }
}