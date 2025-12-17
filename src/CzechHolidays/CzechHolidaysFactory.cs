namespace CzechHolidays;

public sealed class CzechHolidaysFactory : ICzechHolidaysFactory
{
    public CzechHolidaysYear Create(int year) => new(year, [.. GetFixedHolidays(year), .. GetEasterHolidays(year)]);

    /// <summary>
    /// https://www.mpsv.cz/zakon-c.-245-2000-sb.-ze-dne-29.-cervna-2000-
    /// </summary>
    private static IEnumerable<DateOnly> GetFixedHolidays(int year)
    {
        yield return new(year, 1, 1);
        yield return new(year, 5, 1);
        yield return new(year, 5, 8);
        yield return new(year, 7, 5);
        yield return new(year, 7, 6);
        yield return new(year, 9, 28);
        yield return new(year, 10, 28);
        yield return new(year, 11, 17);
        yield return new(year, 12, 24);
        yield return new(year, 12, 25);
        yield return new(year, 12, 26);
    }

    private static IEnumerable<DateOnly> GetEasterHolidays(int year)
    {
        DateOnly easterSunday = GetEasterSunday(year);

        static DateOnly GetGoodFriday(DateOnly easterSunday) => easterSunday.AddDays(-2);
        static DateOnly GetEasterMonday(DateOnly easterSunday) => easterSunday.AddDays(1);

        const int GoodFridayFirstObservedYear = 2016;
        if (year >= GoodFridayFirstObservedYear)
        {
            yield return GetGoodFriday(easterSunday);
        }

        yield return GetEasterMonday(easterSunday);
    }

    /// <summary>
    /// Meeus/Jones/Butcher Gregorian algorithm
    /// </summary>
    private static DateOnly GetEasterSunday(int year)
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

        return new(year, month, day);
    }
}