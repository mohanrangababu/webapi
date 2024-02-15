using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace pg.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateController : ControllerBase
    {
        [HttpGet]
        [Route("update")]
        public IActionResult updation()
        {

            emp_updation();
            return Ok();
        }

        private void emp_updation()
        {
            SqlConnection connection = null;
            try
            {
                string connectionString = "Data Source=DESKTOP-4INSG0P;Initial Catalog=pg_database;Integrated Security=True;";
                using (connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("Emp_updation", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;


                        cmd.Parameters.Add(new SqlParameter("@EmployeeId", "1"));
                        cmd.Parameters.Add(new SqlParameter("@MobileNumber", "56266287878"));


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






    

