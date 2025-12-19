namespace CzechHolidays;

internal sealed class CzechHolidayDateComparer : IComparer<CzechHolidayDate>
{
    internal CzechHolidayDateComparer() { }

    public int Compare(CzechHolidayDate x, CzechHolidayDate y) => x.Date.CompareTo(y.Date);
}

