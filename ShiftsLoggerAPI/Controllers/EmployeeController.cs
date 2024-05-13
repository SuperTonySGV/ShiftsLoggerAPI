using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShiftsLoggerAPI.Data;
using ShiftsLoggerAPI.Dtos.Employee;
using ShiftsLoggerAPI.Mappers;

namespace ShiftsLoggerAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly ApplicationDBContext _context;

    public EmployeeController(ApplicationDBContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var employees = _context.Employees
            .Select(s => s.ToEmployeeDto())
            .ToList();
        
        return Ok(employees);
    }

    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var employee = _context.Employees.Find(id);

        if (employee == null)
        {
            return NotFound();
        }

        return Ok(employee.ToEmployeeDto());
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateEmployeeRequestDto employeeDto)
    {
        var employeeModel = employeeDto.ToEmployeeFromCreateDto();
        _context.Employees.Add(employeeModel);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetById), new { id = employeeModel.Id }, employeeModel.ToEmployeeDto());
    }

    [HttpPut]
    [Route("{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] UpdateEmployeeRequestDto employeeDto)
    {
        var employeeModel = _context.Employees.FirstOrDefault(x => x.Id == id);

        if (employeeModel == null)
        {
            return NotFound();
        }

        employeeModel.Name = employeeDto.Name;

        _context.SaveChanges();

        return Ok(employeeModel.ToEmployeeDto());
    }

    [HttpDelete]
    [Route("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        var employeeModel = _context.Employees.FirstOrDefault(x => x.Id == id);

        if (employeeModel == null)
        {
            return NotFound();
        }

        _context.Employees.Remove(employeeModel);

        _context.SaveChanges();

        return NoContent();
    }

}
