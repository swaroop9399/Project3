using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Diagnostics;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public string conString = "Data Source=RD_131;Initial Catalog=test;User ID=sa;Password=pass@123;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
       

        public IActionResult DataTable()
        {
            string query = "select * from tbl_student";
            SqlConnection con = new SqlConnection(conString);

            List<Student> user = con.Query<Student>(query).ToList();
            return View(user);
          

        }
        public IActionResult Login()
        {
            return View();

        }

        [HttpPost]
        public IActionResult Insert(Student s)
        {
            Console.WriteLine(s.Gender);
            string query = $"insert into tbl_student(Name, Email, Gender, Location,Password) values (@Name, @Email, @Gender, @Location, @Password)";
            SqlConnection con = new SqlConnection(conString);
            con.Execute(query, s);
            return Redirect("/Home/DataTable");

        }   
        public IActionResult Update()
        {

            return View();
        }
    }
}