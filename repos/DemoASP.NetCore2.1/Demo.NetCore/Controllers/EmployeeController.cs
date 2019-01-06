using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.NetCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo.NetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetEmployees()
        {
            using (ManagementContext db = new ManagementContext())
            {
                var employees = db.Employees.ToList();
                return Ok(employees);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployee(int id)
        {
            using (ManagementContext db = new ManagementContext())
            {
                try
                {
                    var employee = db.Employees.Find(id);
                    if (employee != null)
                    {
                        return Ok(employee);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
        }

        [HttpPost]
        public IActionResult CreateEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            using (ManagementContext db = new ManagementContext())
            {
                try
                {
                    db.Employees.Add(employee);
                    db.SaveChanges();
                    return Ok(employee);

                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
        }

        [HttpPut("{id}")]
        public IActionResult updateEmployee(Employee employee, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            using (ManagementContext db = new ManagementContext())
            {
                try
                {
                    var emp = db.Employees.Find(id);
                    if (emp != null)
                    {
                        emp.Address = employee.Address;
                        emp.Birthday = employee.Birthday;
                        emp.Email = employee.Email;
                        emp.FullName = employee.FullName;
                        emp.PhoneNumber = employee.PhoneNumber;

                        db.SaveChanges();
                        return Ok(employee);
                    }
                    else
                    {
                        return NotFound();
                    }

                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
        }
    }
}