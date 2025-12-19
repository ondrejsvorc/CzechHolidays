namespace CzechHolidays;

/// <summary>
/// Represents a single occurrence of a Czech public holiday on a specific calendar date.
/// Instances are created exclusively by the library to guarantee domain invariants (one holiday per date).
/// </summary>
public readonly record struct CzechHolidayDate
{
    public DateOnly Date { get; }
    public CzechHoliday Holiday { get; }

    internal CzechHolidayDate(DateOnly date, CzechHoliday holiday)
    {
        Date = date;
        Holiday = holiday;
    }
}
