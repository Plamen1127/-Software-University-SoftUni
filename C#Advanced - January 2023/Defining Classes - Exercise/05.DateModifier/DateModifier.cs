using System;


namespace Date_Modifier;

public class DateModifier
{
    public static int GetDiferenseDay(string start, string end)
    {
        DateTime startTime = DateTime.Parse(start);
        DateTime endTime = DateTime.Parse(end);

        TimeSpan diferenceInDays = startTime - endTime;

        return Math.Abs(diferenceInDays.Days);
    }
       
}



