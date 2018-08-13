using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi2.Models;
using WebApi2.Repository;

namespace WebApi2.Controllers
{
    public class DolarController : ApiController
    {
        public List<Employee> Get()
        {
            List<Employee> list = new List<Employee>();
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["customerDB"].ConnectionString))
            {
                list = db.Query<Employee>("SELECT *  FROM [Employee]").ToList();
            }
            return list;
        }

        public Employee Get(int id)
        {
            Employee employee = new Employee();

            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["customerDB"].ConnectionString))
            {
                employee = db.Query<Employee>("Select*from [Employee] where EmployeeID=" + id, new { id }).SingleOrDefault();
            }
            return employee;

        }


        [Route("api/create")]
        [HttpPost]
        public IHttpActionResult Create(Employee employee)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["customerDB"].ConnectionString))
            {
                string query = string.Format("INSERT INTO [dbo].[Employee]" +
                    " ([Name],[Position],[Age] ,[Salary])" +
                    " VALUES('{0}','{1}',{2},{3})", employee.Name, employee.Position, employee.Age, employee.Salary);
                db.Execute(query);
            }
            return Ok();
        }

        [Route("api/edit")]
        [HttpPost]
        public IHttpActionResult Edit(Employee employee)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["customerDB"].ConnectionString))
            {
                string sqlQuery = string.Format("UPDATE [dbo].[Employee] " +
                    "  SET[Name] ='{0}',[Position] ='{1}',[Age] = {2} ,[Salary] ={3} WHERE EmployeeID={4}", employee.Name, employee.Position, employee.Age, employee.Salary, employee.EmployeeID);
                db.Execute(sqlQuery);

            }

            return Ok();
        }

        [Route("api/delete")]
        [HttpPost]

        public IHttpActionResult Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["customerDB"].ConnectionString))
            {
                string sqlQuery = string.Format("DELETE FROM [dbo].[Employee]" +
                    " WHERE EmployeeID={0}", id);

                db.Execute(sqlQuery);

            }


            return Ok();
        }


    }
}
