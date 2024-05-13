using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShiftsLoggerAPI.Data;
using ShiftsLoggerAPI.Dtos.Employee;
using ShiftsLoggerAPI.Dtos.Shift;
using ShiftsLoggerAPI.Mappers;

namespace ShiftsLoggerAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ShiftController : ControllerBase
{
    private readonly ApplicationDBContext _context;

    public ShiftController(ApplicationDBContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var shifts = _context.Shifts
            .Select(x => x.ToShiftDto())
            .ToList();

        return Ok(shifts);
    }

    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var shift = _context.Shifts.Find(id);

        if (shift == null)
        {
            return NotFound();
        }

        return Ok(shift.ToShiftDto());
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateShiftRequestDto shiftDto)
    {
        var shiftModel = shiftDto.ToShiftFromCreateDto();
        _context.Shifts.Add(shiftModel);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetById), new { id = shiftModel.Id }, shiftModel.ToShiftDto());
    }

    [HttpPut]
    [Route("{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] UpdateShiftRequestDto shiftDto)
    {
        var shiftModel = _context.Shifts.FirstOrDefault(x => x.Id == id);

        if (shiftModel == null)
        {
            return NotFound();
        }

        shiftModel.StartTime = shiftDto.StartTime;
        shiftModel.EndTime = shiftDto.EndTime;

        _context.SaveChanges();

        return Ok(shiftModel.ToShiftDto());
    }

    [HttpDelete]
    [Route("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        var shiftModel = _context.Shifts.FirstOrDefault(x => x.Id == id);

        if (shiftModel == null)
        {
            return NotFound();
        }

        _context.Shifts.Remove(shiftModel);

        _context.SaveChanges();

        return NoContent();
    }
}
