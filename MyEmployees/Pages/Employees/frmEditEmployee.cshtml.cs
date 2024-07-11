using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace MyEmployees.Pages.Employees
{
    public class frmEditEmployeeModel : PageModel
    {
        public EmployeeInfo EmployeeInfo = new EmployeeInfo();
        public String errorMessage = "";
        public String successMessage = "";
        public void OnGet()
        {
            String id = Request.Query["id"];
            try
            {
                string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=MyEmployees;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM Employee WHERE id=@id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("id", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                EmployeeInfo.id = "" + reader.GetInt32(0);
                                EmployeeInfo.name = reader.GetString(1);
                                EmployeeInfo.email = reader.GetString(2);
                                EmployeeInfo.phone = reader.GetString(3);
                                EmployeeInfo.address = reader.GetString(4);
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
        }
        public void OnPost()
        {
            EmployeeInfo.id = Request.Form["id"];
            EmployeeInfo.name = Request.Form["name"];
            EmployeeInfo.email = Request.Form["email"];
            EmployeeInfo.phone = Request.Form["phone"];
            EmployeeInfo.address = Request.Form["address"];

            if (EmployeeInfo.id.Length == 0 || EmployeeInfo.name.Length == 0 || EmployeeInfo.email.Length == 0 || EmployeeInfo.phone.Length == 0 || EmployeeInfo.address.Length == 0)
            {
                errorMessage = "All the fields are required";
                return;
            }
            try
            {
                string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=MyEmployees;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "UPDATE Employee" +
                                 "SET name=@name,email=@email,phone=@phone,address=@address" +
                                 "WHERE id=@id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@name", EmployeeInfo.name);
                        command.Parameters.AddWithValue("@email", EmployeeInfo.email);
                        command.Parameters.AddWithValue("@phone", EmployeeInfo.phone);
                        command.Parameters.AddWithValue("@address", EmployeeInfo.address);
                        command.Parameters.AddWithValue("@id", EmployeeInfo.id);

                        command.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }
            Response.Redirect("/Employees/Index");
        }



    }
}
