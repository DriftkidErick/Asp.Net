using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

using Week6_labs_ErickC.Models;

using Microsoft.Extensions.Configuration;

namespace Week6_labs_ErickC.Models
{
    public class AskAdminDataAccessLayer
    {
        string connectionString; //String that will receuve the connection string

        private readonly IConfiguration _configuration;

        public AskAdminDataAccessLayer(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        //To view ask details
        public IEnumerable<AskAdmin> GetAdminLogin(AskAdmin tAdmin)
        {
            List<AskAdmin> lstAskAdmin = new List<AskAdmin>();

            try 
            {
                using(SqlConnection con = new SqlConnection(connectionString))
                {
                    string strSQL = "SELECT TOP 1 * FROM AskAdmin_Registry WHERE AskAdmin_Email = @AskAdmin_Email AND AskAdmin_PW = @AskAdmin_PW;";

                    SqlCommand cmd = new SqlCommand(strSQL, con);
                    cmd.CommandType = CommandType.Text;

                    //Fill in the search params
                    cmd.Parameters.AddWithValue("@AskAdmin_Email", tAdmin.AskAdmin_Email);
                    cmd.Parameters.AddWithValue("@AskAdmin_PW", tAdmin.AskAdmin_PW);

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        AskAdmin aMatch = new AskAdmin();

                        //Fill in temp obj from the DB results
                        aMatch.AskAdmin_ID = Convert.ToInt32(rdr["AskAdmin_ID"]);
                        aMatch.AskAdmin_Email = rdr["AskAdmin_Email"].ToString();
                        aMatch.AskAdmin_PW = rdr["AskAdmin_PW"].ToString();

                        lstAskAdmin.Add(aMatch);
                    }

                    con.Close();
                }
            }
            catch (Exception err)
            {
                //Nothing at this moment
            }
            return lstAskAdmin;
        }
    }
}
