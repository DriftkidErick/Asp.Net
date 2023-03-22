using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Added for use of SQl Database componnets

using System.Data;
using System.Data.SqlClient;

//Using models
using TroubleTickets.Models;

//Added to use IConfig
using Microsoft.Extensions.Configuration;

namespace TroubleTickets.Models
{
    public class TicketAdminDataAccessLayer
    {
        string connectionString;

        private readonly IConfiguration _configuration;

        public TicketAdminDataAccessLayer(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        //To View Trouble Ticket Details
        public IEnumerable<TicketAdmin> GetAdminLogin(TicketAdmin tAdmin)
        {
            List<TicketAdmin> lstTicketAdmin = new List<TicketAdmin>();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string strSQL = "SELECT TOP 1 * FROM TicketAdmin_Registry WHERE TicketAdmin_Email = @TicketAdmin_Email AND TicketAdmin_PW = @TicketAdmin_PW;";
                    SqlCommand cmd = new SqlCommand(strSQL, con);
                    cmd.CommandType = CommandType.Text;

                    //Fill in search params with login
                    cmd.Parameters.AddWithValue("@TicketAdmin_Email", tAdmin.TicketAdmin_Email);
                    cmd.Parameters.AddWithValue("@TicketAdmin_PW", tAdmin.TicketAdmin_PW);

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        TicketAdmin tMatch = new TicketAdmin(); //Creats tem object

                        //Fill in temp obj 
                        tMatch.TicketAdmin_ID = Convert.ToInt32(rdr["TicketAdmin_ID"]);
                        tMatch.TicketAdmin_Email = rdr["TicketAdmin_Email"].ToString();
                        tMatch.TicketAdmin_PW = rdr["TicketAdmin_PW"].ToString();

                        lstTicketAdmin.Add(tMatch); //Add temp obj to list
                    }

                    con.Close();
                }
            }

            catch (Exception err)
            {

                //nothin at the moment
            
            }

            return lstTicketAdmin;//returns the list so the Razor Page can build html
        }
    }
}
