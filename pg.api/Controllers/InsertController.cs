using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace pg.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsertController : ControllerBase
    {
        [HttpGet]
        [Route("insert")]
        public IActionResult insertion() {

            Emp_insertion();
            return Ok();
        }

        private void Emp_insertion()
        {
            SqlConnection connection = null;
            try
            {
                string connectionString = "Data Source=DESKTOP-4INSG0P;Initial Catalog=pg_database;Integrated Security=True;";
                using (connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("Emp_details_insertion", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@EmployeeId", "10001"));
                        cmd.Parameters.Add(new SqlParameter("@DepartmentId", "1"));
                        cmd.Parameters.Add(new SqlParameter("@FullName", "1"));
                        cmd.Parameters.Add(new SqlParameter("@MobileNumber", "1"));
                        cmd.Parameters.Add(new SqlParameter("@Salary", "1"));
                        cmd.Parameters.Add(new SqlParameter("@JoinedDate", DateTime.Now));
                        cmd.Parameters.Add(new SqlParameter("@ResignedDate", DateTime.Now));
                        cmd.Parameters.Add(new SqlParameter("@CreatedOn", DateTime.Now));
                        
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
