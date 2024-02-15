using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;

namespace pg.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SelectController : ControllerBase
    {
        
            [HttpGet]
            [Route("select")]
            public IActionResult selection()
            {

                emp_selection();
                return Ok();
            }

            private void emp_selection()
            {
                SqlConnection connection = null;
                try
                {
                    string connectionString = "Data Source=DESKTOP-4INSG0P;Initial Catalog=pg_database;Integrated Security=True;";
                    using (connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("Emp_selection", connection))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                         
                      
                            cmd.Parameters.Add(new SqlParameter("@FullName", "FullName"));
                            cmd.Parameters.Add(new SqlParameter("@MobileNumber", "MobileNumber"));
                            

                            connection.Open();
                            cmd.ExecuteNonQuery();
                        }
                        connection.Close();
                    }
                }
                catch (Exception ex)
                {
                    if (connection != null && connection.State == ConnectionState.Open) connection.Close();
                    throw;
                }
            }
        }
    }




