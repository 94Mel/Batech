using Batech.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Batech.Controllers
{
    public class ReportController : Controller
    {
        private readonly FormContext _context;
        public ReportController(FormContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {


            DataTable dataTable = new DataTable();
            string connectionString = "Server=45.84.189.34\\MSSQLSERVER2022;Database=batechco_DB;User Id=batechco_DB;Password=FrSsKBKw0Nk3sf34;TrustServerCertificate=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string sql = "select *from batechco_DB.Form";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {


                        dataTable.Load(reader);


                    }
                }
            }
            return View(dataTable);



        }
    }
}
