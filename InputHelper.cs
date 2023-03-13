namespace DutyHoursCalculatorApp;


public static class InputHelper
{
    public static DateTime ConvertToDateTime(string stringTime)
    {

        if(!stringTime.Contains(":")) throw new Exception("Please put colon (:)");

        if(stringTime.Contains("PM"))
        {
            return GetDateTime(stringTime, "PM");
        }
        else if(stringTime.Contains("AM"))
        {
            return GetDateTime(stringTime, "AM");
        }
        else
        {
            throw new Exception("Invalid time input!");
        }
    }

    private static DateTime GetDateTime(string stringTime, string tt)
    {
        var times = stringTime.Split(':');
        var hourModel = new HourModel();

        int hour = int.Parse(times[0].Trim());

        hourModel.Hour = hour;
        hourModel.TT = (tt == "PM" ? "PM" : "AM");

        string minString = times[1].Replace((tt == "PM" ? "PM" : "AM"), "");
        int min = int.Parse(minString.Trim());
        return new DateTime(
            DateTime.Now.Year,
            DateTime.Now.Month,
            DateTime.Now.Day,
            hourModel.To24Hour(),
            min,
            0
        );
        
    }
}