namespace CzechHolidays;

public sealed class CzechHolidaysFactory : ICzechHolidaysFactory
{
    public IReadOnlyList<CzechHolidayDate> Create(int year)
    {
        EnsureSupportedYear(year);

        List<CzechHolidayDate> holidays = [.. GetFixedHolidays(year)];

        foreach (CzechHolidayDate easterHoliday in GetEasterHolidays(year))
        {
            InsertSorted(holidays, easterHoliday);
        }

        return holidays;
    }

    private static void EnsureSupportedYear(int year)
    {
        int minYear = DateOnly.MinValue.Year;
        int maxYear = DateOnly.MaxValue.Year;

        if (year < minYear || year > maxYear)
        {
            throw new ArgumentOutOfRangeException(nameof(year), year, $"Year must be in range {minYear}–{maxYear}.");
        }
    }

    private static void InsertSorted(List<CzechHolidayDate> holidays, CzechHolidayDate holiday)
    {
        int index = holidays.BinarySearch(holiday, new CzechHolidayDateComparer());
        if (index < 0)
        {
            holidays.Insert(~index, holiday);
        }
    }

    /// <summary>
    /// https://www.mpsv.cz/zakon-c.-245-2000-sb.-ze-dne-29.-cervna-2000-
    /// </summary>
    private static IEnumerable<CzechHolidayDate> GetFixedHolidays(int year)
    {
        yield return new(new DateOnly(year, 1, 1), CzechHoliday.NewYear);
        yield return new(new DateOnly(year, 5, 1), CzechHoliday.LabourDay);
        yield return new(new DateOnly(year, 5, 8), CzechHoliday.VictoryDay);
        yield return new(new DateOnly(year, 7, 5), CzechHoliday.CyrilAndMethodius);
        yield return new(new DateOnly(year, 7, 6), CzechHoliday.JanHus);
        yield return new(new DateOnly(year, 9, 28), CzechHoliday.StWenceslas);
        yield return new(new DateOnly(year, 10, 28), CzechHoliday.IndependentStateDay);
        yield return new(new DateOnly(year, 11, 17), CzechHoliday.StruggleForFreedomAndDemocracy);
        yield return new(new DateOnly(year, 12, 24), CzechHoliday.ChristmasEve);
        yield return new(new DateOnly(year, 12, 25), CzechHoliday.ChristmasDay);
        yield return new(new DateOnly(year, 12, 26), CzechHoliday.StStephensDay);
    }

    private static IEnumerable<CzechHolidayDate> GetEasterHolidays(int year)
    {
        DateOnly easterSunday = GetEasterSunday(year);

        const int GoodFridayFirstObservedYear = 2016;
        if (year >= GoodFridayFirstObservedYear)
        {
            yield return new(easterSunday.AddDays(-2), CzechHoliday.GoodFriday);
        }

        yield return new(easterSunday.AddDays(1), CzechHoliday.EasterMonday);
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