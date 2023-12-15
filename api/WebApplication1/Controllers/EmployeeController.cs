// EmployeeController.cs
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly YourDbContext _dbContext;

        public EmployeeController(YourDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var employees = _dbContext.Employee.ToList();
            return Ok(employees);
        }

        [HttpPost]
        public IActionResult Post(Employee emp)
        {
            _dbContext.Employee.Add(emp);
            _dbContext.SaveChanges();

            return Ok("Added Successfully");
        }

        [HttpPut]
        public IActionResult Put(Employee emp)
        {
            _dbContext.Employee.Update(emp);
            _dbContext.SaveChanges();

            return Ok("Updated Successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var emp = _dbContext.Employee.Find(id);
            if (emp == null)
            {
                return NotFound();
            }

            _dbContext.Employee.Remove(emp);
            _dbContext.SaveChanges();

            return Ok("Deleted Successfully");
        }

        [Route("SaveFile")]
        [HttpPost]
        public IActionResult SaveFile()
        {
            try
            {
                // Your file saving logic using Entity Framework goes here

                return Ok("File saved successfully");
            }
            catch (Exception)
            {
                return Ok("Error saving file");
            }
        }
    }
}
