using ShiftsLoggerAPI.Dtos.Shift;
using ShiftsLoggerAPI.Models;

namespace ShiftsLoggerAPI.Mappers;

public static class ShiftMapper
{
    public static ShiftDto ToShiftDto(this Shift shiftModel)
    {
        return new ShiftDto
        {
            Id = shiftModel.Id,
            StartTime = shiftModel.StartTime,
            EndTime = shiftModel.EndTime,
            EmployeeId = shiftModel.EmployeeId
        };
    }
    public static Shift ToShiftFromCreateDto(this CreateShiftRequestDto shiftDto)
    {
        return new Shift
        {
            StartTime = shiftDto.StartTime,
            EndTime = shiftDto.EndTime,
            EmployeeId = shiftDto.EmployeeId,
        };
    }
}
