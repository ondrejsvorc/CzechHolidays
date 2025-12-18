using System.Collections.Frozen;

namespace CzechHolidays;

/// <summary>
/// Represents an immutable set of Czech public holidays for a specific calendar year.
/// </summary>
/// <remarks>
/// All holidays are guaranteed to belong to the year specified by <see cref="Year"/>.
/// </remarks>
public sealed class CzechHolidaysYear
{
    public int Year { get; }

    private readonly FrozenSet<DateOnly> _holidays;

    internal CzechHolidaysYear(int year, IEnumerable<DateOnly> holidays)
    {
        Year = year;
        _holidays = holidays.ToFrozenSet();
    }

    public bool Contains(DateOnly date) => _holidays.Contains(date);
    public bool Contains(DateTime dateTime) => _holidays.Contains(DateOnly.FromDateTime(dateTime));
}