using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


//Added for Email
using System.Net.Mail;
using System.Net;
using System.IO;//Used for File input and output

namespace SE256_Activity_ErickC
{
    public partial class Emailer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Set email in "to" Textbox
            string emailAddr = "ckswheelsanddeals@gmail.com";
            txtTo.Text = emailAddr;
            //Disable so users cannot change this
            txtTo.ReadOnly= true;

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //Set Email server address and login Criteria //Dont worry this is a fake Gmail account I made
            String strSmtpAddress = "smtp.gmail.com";
            String strSmtpUsername = "ckswheelsanddeals@gmail.com";
            String strSmtpPassword = "shpsmphromejwjpu";
          

            //Fill in the mail msg object with typical email stuff
            MailMessage myMsg = new MailMessage
                (txtTo.Text, txtFrom.Text, txtSubject.Text, txtMessage.Text);

            try
            {
                //Create the SMTP Email server connector and give the address
                SmtpClient myClient = new SmtpClient(strSmtpAddress);

                myClient.UseDefaultCredentials = false; 
               
               
                myClient.Port = 587;

                //Tell the SMTP connector tyour login credentials
                myClient.Credentials = new NetworkCredential(strSmtpUsername, strSmtpPassword);
                myClient.EnableSsl = true;

                //Carbon copy FROM email
                myMsg.CC.Add(txtFrom.Text);
                myMsg.Bcc.Add("ckswheelsanddeals@gmail.com"); //Bind CC me

                myMsg.IsBodyHtml = true; //This email uses HTML tags
                lblSent.Text = ""; //Clear any past feedback

                if (fuImgFile.HasFile) //Had issues with the original attachments video added this and works 
                {
                    myMsg.Attachments.Add(new Attachment (fuImgFile.PostedFile.InputStream, fuImgFile.FileName));
                    

                    
                }

                myClient.Send(myMsg); //Send the message

                //Give feedback and lock the button so users cannot keep clicking send
                lblSent.Text = "Your Email has been sent. Thank you! <br/> Please allow 2-5 business days for a proper response from our support team.";
                btnSubmit.Enabled = false;
            }

            catch (Exception ex)
            {
                //bad feedback
                lblSent.Text = "Sorry...Seems that there was an error: " + ex.Message;
            }

            finally
            {
                //make feedback visible
                lblSent.Visible = true;

                
            }
        }


    }
}