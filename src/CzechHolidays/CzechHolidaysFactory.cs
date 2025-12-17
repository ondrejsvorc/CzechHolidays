namespace CzechHolidays;

public class CzechHolidaysFactory : ICzechHolidaysFactory
{
    public CzechHolidays Create(int year)
    {
        if (year < DateTime.MinValue.Year || year > DateTime.MaxValue.Year)
        {
            throw new ArgumentOutOfRangeException(nameof(year));
        }

        List<DateTime> holidays = new(capacity: 13)
        {
            new(year, 1, 1),
            new(year, 5, 1),
            new(year, 5, 8),
            new(year, 7, 5),
            new(year, 7, 6),
            new(year, 9, 28),
            new(year, 10, 28),
            new(year, 11, 17),
            new(year, 12, 24),
            new(year, 12, 25),
            new(year, 12, 26)
        };

        DateTime easterSunday = GetEasterSunday(year);

        if (year >= 2016)
        {
            // Velký pátek
            holidays.Add(easterSunday.AddDays(-2));
        }

        // Velikonoční pondělí
        holidays.Add(easterSunday.AddDays(1));

        return new CzechHolidays(year, holidays);
    }

    /// <summary>
    /// Meeus/Jones/Butcher Gregorian algorithm
    /// </summary>
    private static DateTime GetEasterSunday(int year)
    {
        int a = year % 19;
        int b = year / 100;
        int c = year % 100;
        int d = b / 4;
        int e = b % 4;
        int f = (b + 8) / 25;
        int g = (b - f + 1) / 3;
        int h = ((19 * a) + b - d - g + 15) % 30;
        int i = c / 4;
        int k = c % 4;
        int l = (32 + (2 * e) + (2 * i) - h - k) % 7;
        int m = (a + (11 * h) + (22 * l)) / 451;
        int month = (h + l - (7 * m) + 114) / 31;
        int day = ((h + l - (7 * m) + 114) % 31) + 1;

        return new DateTime(year, month, day);
    }
}

