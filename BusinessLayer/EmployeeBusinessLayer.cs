using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class EmployeeBusinessLayer
    {
        public IEnumerable<Employee> Employees
        {
            get
            {
                var connectionString = ConfigurationManager.ConnectionStrings["DBES"].ConnectionString;
               
                var employees = new List<Employee>();

                using (var con = new SqlConnection(connectionString))
                {
                    var cmd = new SqlCommand("getAllEmployees", con) { CommandType = CommandType.StoredProcedure };
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var employee = new Employee
                        {
                            EmployeeId = Convert.ToInt32(reader["EmployeeId"]),
                            Name = reader["Name"].ToString(),
                            Gender = reader["Gender"].ToString(),
                            City = reader["City"].ToString(),
                            DateOfBirth = Convert.ToDateTime(reader["Birthdate"])
                        };

                        employees.Add(employee);
                    }

                }
                return employees;
            }
        }

     }
}
