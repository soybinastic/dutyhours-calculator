namespace DutyHoursCalculatorApp;

public class HourModel
{
    private static readonly Dictionary<HourModel, int> _hours = new Dictionary<HourModel, int>
    {
        { new HourModel { Hour = 1, TT = "AM" }, 1 },
        { new HourModel { Hour = 2, TT = "AM" }, 2 },
        { new HourModel { Hour = 3, TT = "AM" }, 3 },
        { new HourModel { Hour = 4, TT = "AM" }, 4 },
        { new HourModel { Hour = 5, TT = "AM" }, 5 },
        { new HourModel { Hour = 6, TT = "AM" }, 6 },
        { new HourModel { Hour = 7, TT = "AM" }, 7 },
        { new HourModel { Hour = 8, TT = "AM" }, 8 },
        { new HourModel { Hour = 9, TT = "AM" }, 9 },
        { new HourModel { Hour = 10, TT = "AM" }, 10 },
        { new HourModel { Hour = 11, TT = "AM" }, 11 },
        { new HourModel { Hour = 12, TT = "PM" }, 12 },
        { new HourModel { Hour = 1, TT = "PM" }, 13 },
        { new HourModel { Hour = 2, TT = "PM" }, 14 },
        { new HourModel { Hour = 3, TT = "PM" }, 15 },
        { new HourModel { Hour = 4, TT = "PM" }, 16 },
        { new HourModel { Hour = 5, TT = "PM" }, 17 },
        { new HourModel { Hour = 6, TT = "PM" }, 18 },
        { new HourModel { Hour = 7, TT = "PM" }, 19 },
        { new HourModel { Hour = 8, TT = "PM" }, 20 },
        { new HourModel { Hour = 9, TT = "PM" }, 21 },
        { new HourModel { Hour = 10, TT = "PM" }, 22 },
        { new HourModel { Hour = 11, TT = "PM" }, 23 },
        { new HourModel { Hour = 12, TT = "AM" }, 24 }
    };
    public int Hour { get; set; }
    public string TT { get; set; } = null!;

    public int To24Hour()
    {
        if(Hour > 24) throw new Exception("Invalid hour");

        if(TT != "PM" && TT != "AM") throw new Exception("Invalid TT");

        var pms = _hours.Where(h => h.Key.TT == "PM").ToList();
        var ams = _hours.Where(h => h.Key.TT == "AM").ToList();

        var result = TT == "PM" ? pms.Where(h => h.Key.Hour == Hour)
            .FirstOrDefault() : ams.Where(h => h.Key.Hour == Hour)
                .FirstOrDefault();

        return result.Value;
    }

}