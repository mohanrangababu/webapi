using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace pg.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteController : ControllerBase
    {
        [HttpGet]
        [Route("delete")]
        public IActionResult deletion()
        {

            emp_deletion();
            return Ok();
        }

        private void emp_deletion()
        {
            SqlConnection connection = null;
            try
            {
                string connectionString = "Data Source=DESKTOP-4INSG0P;Initial Catalog=pg_database;Integrated Security=True;";
                using (connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("Emp_deletion", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;


                        cmd.Parameters.Add(new SqlParameter("@EmployeeId", "2"));
                        


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





    

