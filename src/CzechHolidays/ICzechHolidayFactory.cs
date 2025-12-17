namespace CzechHolidays;

public interface ICzechHolidaysFactory
{
    /// <summary>
    /// Creates a <see cref="CzechHolidaysYear"/> instance for the specified calendar year.
    /// </summary>
    /// <param name="year">Gregorian calendar year.</param>
    /// <returns>Immutable set of Czech public holidays for the given year.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when <paramref name="year"/> is outside the range supported by <see cref="DateOnly"/>.
    /// </exception>
    /// <remarks>
    /// Returned instance includes all fixed-date holidays and Easter-related holidays as defined by Czech law.
    /// </remarks>
    CzechHolidaysYear Create(int year);
}