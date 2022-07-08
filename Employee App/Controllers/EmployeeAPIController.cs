using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Employee_App.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Employee_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeAPIController : ControllerBase
    {
        // GET: api/<EmployeeAPIController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetEmployeeList()
        {
            return Ok(getData());
        }

        private List<EmployeeInfo> getData()
        {
            List<EmployeeInfo> listemployee = new List<EmployeeInfo>();
            try
            {
                String connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\New One\Documents\mystore.mdf';Integrated Security=True;Connect Timeout=30";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM Employee";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                EmployeeInfo employeeInfo = new EmployeeInfo();
                                employeeInfo.employeeid = reader.GetInt32(0);
                                employeeInfo.firstname = reader.GetString(1);
                                employeeInfo.lastname = reader.GetString(2);
                               // employeeInfo.joineddate = reader.GetDateTime(3).ToString();
                                employeeInfo.email = reader.GetString(4);
                                employeeInfo.address = reader.GetString(5);
                                employeeInfo.phonenumber = reader.GetInt32(6).ToString();

                                listemployee.Add(employeeInfo);

                            }
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception : " + ex.ToString());
            }

            return listemployee;
        }



        // GET api/<EmployeeAPIController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EmployeeAPIController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EmployeeAPIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmployeeAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
   
}


