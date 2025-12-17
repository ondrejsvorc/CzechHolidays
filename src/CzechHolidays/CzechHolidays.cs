namespace CzechHolidays;

public class CzechHolidays(int year, IEnumerable<DateTime> holidays)
{
    public int Year { get; } = year;

    private readonly HashSet<DateTime> _holidays = [.. holidays];

    public bool IsHoliday(DateTime date) => date.Year == Year && _holidays.Contains(date.Date);

    public IReadOnlyCollection<DateTime> All => _holidays;
}
