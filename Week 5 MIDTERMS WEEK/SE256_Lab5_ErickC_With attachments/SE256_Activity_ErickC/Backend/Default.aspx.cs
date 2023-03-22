using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SE256_Activity_ErickC.Backend
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUName.Text == "Scott" && txtPW.Text == "NEIT")
            {
                //If we have a match for BOTH UName and PW, set session so other pages know they are logged in and give msg.
                Session["UName"] = txtUName.Text;
                Session["LoggedIn"] = "True";
                lblFeedback.Text = "Successful Login ... Now what do ya want to do?";
                Response.Redirect("~/Backend/ControlPanel.aspx");
            }

            else
            {
                //Else we do not have both matches so we set clear potential session vars and give msg.
                Session["UName"] = "";
                Session["LoggedIn"] = "FALSE";
                lblFeedback.Text = "Login Failed... Please try again or go away";
            }
        }
    }
}