namespace ShiftsLoggerAPI.Dtos.Shift;

public class CreateShiftRequestDto
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public int EmployeeId { get; set; }
}
