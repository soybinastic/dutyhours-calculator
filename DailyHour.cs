namespace DutyHoursCalculatorApp;


public class DailyHour
{
    public TimeModel TimeIn { get; set; } = null!;
    public TimeModel TimeOut { get; set; } = null!;
    
    public double Total()
    {
        var timeIn = new DateTime(
            DateTime.Now.Year, 
            DateTime.Now.Month, 
            DateTime.Now.Day,
            TimeIn.Hour, TimeIn.Minute, TimeIn.Second);

        var timeOut = new DateTime(
            DateTime.Now.Year, 
            DateTime.Now.Month, 
            DateTime.Now.Day,
            TimeOut.Hour, TimeOut.Minute, TimeOut.Second);
        TimeSpan timeSpan = timeOut - timeIn;

        return timeIn.Hour >= 12 ? timeSpan.TotalHours : timeSpan.TotalHours - 1;
    }
}