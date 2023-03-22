using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SE256_Activity_ErickC.Backend
{
    public partial class ControlPanel : System.Web.UI.Page
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

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.Abandon(); //Destorys any session vars
            Response.Redirect("~/Backend/Default.aspx"); //send back to login
        }
    }
}