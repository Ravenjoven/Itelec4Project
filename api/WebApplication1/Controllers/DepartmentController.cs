
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class DepartmentController : ControllerBase
{
    private readonly YourDbContext _dbContext;

    public DepartmentController(YourDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var departments = _dbContext.Department.ToList();
        return new JsonResult(departments);
    }

    [HttpPost]
    public IActionResult Post(Department dep)
    {
        _dbContext.Department.Add(dep);
        _dbContext.SaveChanges();
        return Ok("Added Successfully");
    }

    [HttpPut]
    public IActionResult Put(Department dep)
    {
        _dbContext.Entry(dep).State = EntityState.Modified;
        _dbContext.SaveChanges();
        return Ok("Updated Successfully");
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var dep = _dbContext.Department.Find(id);
        if (dep == null)
            return NotFound();

        _dbContext.Department.Remove(dep);
        _dbContext.SaveChanges();

        return Ok("Deleted Successfully");
    }
}
