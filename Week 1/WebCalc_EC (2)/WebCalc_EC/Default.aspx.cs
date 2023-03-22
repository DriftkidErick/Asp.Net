using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Ajax.Utilities;

namespace WebCalc_EC
{
    public partial class Default : System.Web.UI.Page
         
    {
        string N1;
        string Operand;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn1_Click(object sender, EventArgs e)
        {
            txtLCD.Text += "1";
            
        }

        protected void btn2_Click(object sender, EventArgs e)
        {
            txtLCD.Text += "2";
            
        }

        protected void btn3_Click(object sender, EventArgs e)
        {
            txtLCD.Text += "3";
            
        }

        protected void btnNumber_Click(object sender, EventArgs e) //Basically this reads the text that is assinged to the button 
        {
            Button tButton = (Button)sender; //Stores the sender to tButton  
            txtLCD.Text += tButton.Text; //grabs number from the button clicked
            
        }

        protected void btnOperand_Click(object sender, EventArgs e) //Stores everything into one function 
            //BONUS (5 points) Employ one function to handle all the number buttons AND one for the four math operand buttons(+, -, *, /)
        {
            Button tButton = (Button)sender; //Stores the sender to tButton  

            if (btnPlus == tButton) //If btnPlus is the same as tButton
            {
                N1 = txtLCD.Text; //Save the Number in LCD
                Session["N1"] = txtLCD.Text;

                Operand = "+";  // Save Math Operand
                Session["Operand"] = "+";
            }

            else if (btnSub == tButton)//If btnSub is the same as tButton
            {
                N1 = txtLCD.Text; //Save the Number in LCD
                Session["N1"] = txtLCD.Text;

                Operand = "-";  // Save Math Operand
                Session["Operand"] = "-";
            }

            else if (btnMulti == tButton)//If btnMulti is the same as tButton
            {
                N1 = txtLCD.Text; //Save the Number in LCD
                Session["N1"] = txtLCD.Text;

                Operand = "*";  // Save Math Operand
                Session["Operand"] = "*";
            }

            else if (btnDivis == tButton) ////If btnDivis is the same as tButton
            {
                N1 = txtLCD.Text; //Save the Number in LCD
                Session["N1"] = txtLCD.Text;

                Operand = "/";  // Save Math Operand
                Session["Operand"] = "/";
            }

            //Else was not used because then if an error occurs it would automatically throw it to what was not used
            
            txtLCD.Text = ""; //Clear the textBox after an operand is found

            lblsymbol.Text = tButton.Text; //this store the operand to the lable to the right of the display

            lblmem.Text = "M"; // This activates once N1 is stored and places a M next to the LCD display
        }


        //protected void btnPlus_Click(object sender, EventArgs e)
        //{


        //    // N1 = txtLCD.Text; //Save the Number in LCD
        //    Session["N1"] = txtLCD.Text;

        //    //Operand = "+";  // Save Math Operand
        //    Session["Operand"] = "+";

        //    txtLCD.Text = ""; //Clear the textBox

        //    lblsymbol.Text = "+";

        //}

        //protected void btnSub_Click(object sender, EventArgs e) //This connects to the subtraction button
        //{
        //    // N1 = txtLCD.Text; //Save the Number in LCD
        //    Session["N1"] = txtLCD.Text;

        //    //Operand = "-";  // Save Math Operand
        //    Session["Operand"] = "-";

        //    txtLCD.Text = ""; //Clear the textBox
        //    lblsymbol.Text = "-";
        //}

        //protected void btnMulti_Click(object sender, EventArgs e) //This connects to the multipliaction button
        //{
        //    // N1 = txtLCD.Text; //Save the Number in LCD
        //    Session["N1"] = txtLCD.Text;

        //    //Operand = "*";  // Save Math Operand
        //    Session["Operand"] = "*";

        //    txtLCD.Text = ""; //Clear the textBox

        //    lblsymbol.Text = "*";
        //}

        //protected void btnDivis_Click(object sender, EventArgs e) //This connects to the division button
        //{
        //    // N1 = txtLCD.Text; //Save the Number in LCD
        //    Session["N1"] = txtLCD.Text;

        //    memory.Text += $"{N1}";

        //    //Operand = "/";  // Save Math Operand
        //    Session["Operand"] = "/";

        //    txtLCD.Text = ""; //Clear the textBox

        //    lblsymbol.Text = "/";

        //}

        protected void btnEquals_Click(object sender, EventArgs e) //If you click the equals button
        {
            string N2;
            double Result = 0, dblN1, dblN2; //Result is 0 to have some initial value

            N2 = txtLCD.Text;

            

            dblN1 = Double.Parse(Session["N1"].ToString()); //Convert String values to numerics
            dblN2 = Double.Parse(N2);

            string Operand_used = (Session["Operand"].ToString());

            //Or can do 
            //Operand = Session["Operand"].ToString();

            //Performs the math
            if (Session["Operand"].ToString() == "+")
            {
                Result = dblN1 + dblN2;
            }

            else if (Session["Operand"].ToString() == "-")
            {
                Result = dblN1 - dblN2;
            }

            else if (Session["Operand"].ToString() == "*")
            {
                Result = dblN1 * dblN2;
            }

            else if (Session["Operand"].ToString() == "/")
            {
                Result = dblN1 / dblN2;
            }

            txtLCD.Text = Result.ToString();

            memory.Text += $"{dblN1}{Operand_used}{dblN2}= {Result}"; //This is where you left off working on memeory storage

        }

        protected void btnClr_Click(object sender, EventArgs e)//Clr button
        {

            txtLCD.Text = "";//Clears out the LCD screen
            memory.Text = "";//Clears out the memory section

            lblmem.Text = "|"; //Clears out the M
            lblsymbol.Text = "|";//Clears out the Operand symbol next to the M
        }
    }
}