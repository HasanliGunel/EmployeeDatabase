using EmployeeDatabase.Database;
using EmployeeDatabase.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDatabase.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : Controller
    {
        public readonly EmployeeDb _context;
        public EmployeeController(EmployeeDb context)
        {
            _context = context;
        }
        [Route("GetAll")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _context.Employees.ToList();
            return Ok(data);
        }
        [HttpPost]
        public IActionResult Create(EmployeeVm viewModel)
        {
            var data = new Employee();
            data.Name = viewModel.Name;
            data.Surname = viewModel.Surname;
            data.Department = viewModel.Department;
            _context.Employees.Add(data);
            _context.SaveChanges();
            return Ok("Created");
        }
        [HttpPut]
        public IActionResult Update(Employee model)
        {
            var data = _context.Employees.AsNoTracking().FirstOrDefault(x => x.Id == model.Id);
            if(data==null)
            {
                return BadRequest("Bu ID-li ishchi yoxdur");
            }
            _context.Entry(model).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok("Update");
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var data = _context.Employees.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (data == null)
            {
                return BadRequest("Bu ID-li ishchi yoxdur");
            }
            _context.Entry(data).State = EntityState.Deleted;
            _context.SaveChanges();
            return Ok("deleted");
        }
        [HttpGet]
        public IActionResult GetById(int id)
        {
            var data = _context.Employees.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if(data==null)
            {
                return BadRequest("Bu ID-li ishchi yoxdur");
            }
            return Ok(data);
        }
    }
}

