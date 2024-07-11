using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace MyEmployees.Pages.Employees
{
    public class frmCreateEmployeeModel : PageModel
    {
        public EmployeeInfo EmployeeInfo = new EmployeeInfo();
        public String errorMessage = "";
        public String successMessage = "";
        public void OnGet()
        {
        }
        public void OnPost() 
        {
            EmployeeInfo.name = Request.Form["name"];
            EmployeeInfo.email = Request.Form["email"];
            EmployeeInfo.phone = Request.Form["phone"];
            EmployeeInfo.address = Request.Form["address"];

            if (EmployeeInfo.name.Length == 0 || EmployeeInfo.email.Length == 0 || EmployeeInfo.phone.Length == 0 || EmployeeInfo.address.Length == 0)
            {
                errorMessage = "All the fields are required";
                return;
            }

            // Save to database.
            try
            {
                string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=MyEmployees;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                { 
                connection.Open();
                    String sql = "INSERT INTO Employee (name,email,phone,address)" +
                                 " VALUES (@name,@email,@phone,@address);";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    { 
                    command.Parameters.AddWithValue("@name", EmployeeInfo.name);
                    command.Parameters.AddWithValue("@email", EmployeeInfo.email);
                    command.Parameters.AddWithValue("@phone", EmployeeInfo.phone);
                    command.Parameters.AddWithValue("@address", EmployeeInfo.address);

                    command.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            EmployeeInfo.name = "";
            EmployeeInfo.name = "";
            EmployeeInfo.name = "";
            EmployeeInfo.name = "";
            successMessage = "New employee saved successfully";

            Response.Redirect("/Employees/Index");


        }
    }
}
