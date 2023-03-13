namespace DutyHoursCalculatorApp;

public static class Processor
{
    private readonly static List<DailyHour> _overallDutyHours = new();
    private static int dayCounter = 1;
    public static void Run()
    {
        // var timeIn = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0);
        // var timeOut = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 17, 0, 0);
        // TimeSpan timeSpan = timeOut - timeIn;
        // Console.WriteLine(timeSpan.TotalHours);
        // Console.WriteLine(timeOut.ToString("hh:mm tt"));

        Console.WriteLine("Time format ex. 5:20 PM");
        while(true)
        {
            try
            {
                Console.WriteLine($"DAY {dayCounter}");
                Console.Write("Time in: ");
                string timeInString = Console.ReadLine()!;
                if(timeInString == "d") break;
                var timeInResult = InputHelper.ConvertToDateTime(timeInString);

                Console.Write("Time out: ");
                string timeOutString = Console.ReadLine()!;
                var timeOutResult = InputHelper.ConvertToDateTime(timeOutString);

                var dailyHours = ConvertToDailyHour(timeInResult, timeOutResult);
                Console.WriteLine("Total: " + dailyHours.Total());

                _overallDutyHours.Add(dailyHours);
                dayCounter += 1;
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
        
    }

    private static DailyHour ConvertToDailyHour(DateTime timeIn, DateTime timeOut)
    {
        return new DailyHour
            {
                TimeIn = new TimeModel { Hour = timeIn.Hour, Minute = timeIn.Minute, Second = timeIn.Second },
                TimeOut = new TimeModel { Hour = timeOut.Hour, Minute = timeOut.Minute, Second = timeOut.Second }
            };
    }

    public static List<DailyHour> GetAllDailyHours => _overallDutyHours;

}