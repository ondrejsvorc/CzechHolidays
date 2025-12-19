namespace CzechHolidays;

public interface ICzechHolidaysFactory
{
    /// <summary>
    /// Creates an immutable, ordered list of Czech public holidays for the specified calendar year.
    /// </summary>
    IReadOnlyList<CzechHolidayDate> Create(int year);
}