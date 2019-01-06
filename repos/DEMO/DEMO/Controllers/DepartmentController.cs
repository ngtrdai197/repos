using DEMO.DTO;
using DEMO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DEMO.Controllers
{
    public class DepartmentController : ApiController
    {
        [HttpGet]
        [ActionName("GetDepartments")]
        public IHttpActionResult GetDepartments()
        {
            IList<DepartmentDTO> departmentDTOs = null;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                try
                {
                    departmentDTOs = db.Departments.Select(
                        d => new DepartmentDTO()
                        {
                            DepartmentId = d.DepartmentId,
                            DepartmentName = d.DepartmentName
                        }).ToList<DepartmentDTO>();

                    if (departmentDTOs.Count != 0)
                    {
                        return Ok(departmentDTOs);
                    }
                    return NotFound();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
        [HttpPost]
        [ActionName("CreateDepartment")]
        public IHttpActionResult CreateDepartment(DepartmentDTO departmentDTO)
        {

            if (!ModelState.IsValid)
                return BadRequest("Not a valid data");
            using (ApplicationDbContext entities = new ApplicationDbContext())
            {
                entities.Departments.Add(new Department()
                {
                    DepartmentName = departmentDTO.DepartmentName,
                });
                entities.SaveChanges();
            }
            return Ok("Created Successfully");
        }

    }
}
