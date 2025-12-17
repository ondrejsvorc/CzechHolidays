namespace CzechHolidays;

public interface ICzechHolidaysFactory
{
    CzechHolidays Create(int year);
}
