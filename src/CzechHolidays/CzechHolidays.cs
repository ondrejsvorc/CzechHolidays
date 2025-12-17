using System.Collections.Frozen;

namespace CzechHolidays;

/// <summary>
/// Represents an immutable set of Czech public holidays for a specific calendar year.
/// </summary>
/// <remarks>
/// All holidays are guaranteed to belong to the year specified by <see cref="Year"/>.
/// </remarks>
public sealed class CzechHolidays
{
    public int Year { get; }

    private readonly FrozenSet<DateOnly> _holidays;

    public CzechHolidays(int year, IEnumerable<DateOnly> holidays)
    {
        DateOnly[] holidayArray = [.. holidays];

        if (holidayArray.Any(holiday => holiday.Year != year))
        {
            throw new ArgumentException($"All holidays must belong to year: {year}.", nameof(holidays));
        }

        Year = year;
        _holidays = holidayArray.ToFrozenSet();
    }

    public bool Contains(DateOnly date) => _holidays.Contains(date);
    public bool Contains(DateTime dateTime) => _holidays.Contains(DateOnly.FromDateTime(dateTime));
}