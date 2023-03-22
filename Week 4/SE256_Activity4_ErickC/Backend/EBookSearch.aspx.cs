using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Use these namespaces to include DB capablities for generic componets and SQL Server
using System.Data;
using System.Data.SqlClient;
using SE256_Activity_ErickC.App_Code; //Added this reference to get easy access to classes in the App_Code folder;

namespace SE256_Activity_ErickC.Backend
{
    public partial class EBookSearch : System.Web.UI.Page
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

        protected void btnSearch_Click(object sender, EventArgs e)
        { 
            //Filling a dataset and binding it to a GridView Object
            EBook temp = new EBook(); //Create an object

            //Use the object's function to fill a DataSet object
            DataSet ds = temp.SearchEBooks_DS(txtTitle.Text, txtAuthorLast.Text);

            dgResults.DataSource = ds; //Point GV to the dataset
            dgResults.DataMember = ds.Tables[0].TableName; //Point GV to the one table
            dgResults.DataBind(); //Bind Data (open faucet)


            //Outputting results using a Datareader bound to a repeater object
            SqlDataReader dr = null;

            //Filll the reader with zero or more results
            dr = temp.SearchEBooks_DR(txtTitle.Text, txtAuthorLast.Text);

            //(Like connecting a hose to a faucet, then turning the faucet on)
            rptSearch.DataSource = dr; //point or connect the repeater to the reader
            rptSearch.DataBind(); //Bind the data

            //Output results using a DataReader to fill in a literal object
            dr = temp.SearchEBooks_DR(txtTitle.Text, txtAuthorLast.Text);

            //Start the table
            litResults.Text = "<table>";

            //Create a header row
            litResults.Text += "<th>Title</th><th>First Name</th><th>Last Name</th><th>Date Published</th><th>Edit Link</th>";


            //Loop through the results and add each as their own table row
            while (dr.Read())
            {
                litResults.Text +=
                    "<tr>" +
                    "<td>" + dr["Title"].ToString() + "</td>" +
                    "<td>" + dr["AuthorFirst"].ToString() + "</td>" +
                    "<td>" + dr["AuthorLast"].ToString() + "</td>" +
                    "<td>" + dr["DatePublished"].ToString() + "</td>" +
                    "<td>" + "<a href='EBookMgr.aspx?EBookID=" + dr["EBookID"].ToString() + "'>Edit</a></td>" +
                    "<tr>";
            }

            //close the table, once the loop adding results is complete
            litResults.Text += "</table>";
        }
    }
}