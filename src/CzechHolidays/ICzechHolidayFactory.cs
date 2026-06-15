namespace CzechHolidays;

public interface ICzechHolidaysFactory
{
    /// <summary>
    /// Creates an immutable, ordered list of Czech public holidays for 2016 or later.
    /// </summary>
    IReadOnlyList<CzechHolidayDate> Create(int year);
}
