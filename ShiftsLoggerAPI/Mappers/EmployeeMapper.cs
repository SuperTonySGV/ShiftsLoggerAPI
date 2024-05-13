using ShiftsLoggerAPI.Dtos.Employee;
using ShiftsLoggerAPI.Models;

namespace ShiftsLoggerAPI.Mappers;

public static class EmployeeMapper
{
    public static EmployeeDto ToEmployeeDto(this Employee employeeModel)
    {
        return new EmployeeDto
        {
            Id = employeeModel.Id,
            Name = employeeModel.Name,
        };
    }

    public static Employee ToEmployeeFromCreateDto(this CreateEmployeeRequestDto employeeDto)
    {
        return new Employee
        {
            Name = employeeDto.Name
        };
    }
}
