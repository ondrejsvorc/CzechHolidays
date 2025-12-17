namespace CzechHolidays.Tests;

public sealed class CzechHolidaysTests
{
    private readonly CzechHolidaysFactory factory = new();

    [Theory]
    [MemberData(nameof(TestData))]
    public void IsHoliday_ReturnsTrue_ForAllExpectedHolidays(int year, DateTime[] expectedHolidays)
    {
        CzechHolidays holidays = factory.Create(year);

        foreach (DateTime holiday in expectedHolidays)
        {
            Assert.True(holidays.IsHoliday(holiday), $"Expected {holiday:yyyy-MM-dd} to be a holiday in {year}");
        }
    }

    public static readonly TheoryData<int, DateTime[]> TestData = CreateTestData();
    private static TheoryData<int, DateTime[]> CreateTestData()
    {
        return new TheoryData<int, DateTime[]>
        {
            {
                2029,
                [
                    new(2029, 1, 1),
                    new(2029, 3, 30), // Velký pátek
                    new(2029, 4, 2),  // Velikonoční pondělí
                    new(2029, 5, 1),
                    new(2029, 5, 8),
                    new(2029, 7, 5),
                    new(2029, 7, 6),
                    new(2029, 9, 28),
                    new(2029, 10, 28),
                    new(2029, 11, 17),
                    new(2029, 12, 24),
                    new(2029, 12, 25),
                    new(2029, 12, 26)
                ]
            },
            {
                2030,
                [
                    new(2030, 1, 1),
                    new(2030, 4, 19), // Velký pátek
                    new(2030, 4, 22), // Velikonoční pondělí
                    new(2030, 5, 1),
                    new(2030, 5, 8),
                    new(2030, 7, 5),
                    new(2030, 7, 6),
                    new(2030, 9, 28),
                    new(2030, 10, 28),
                    new(2030, 11, 17),
                    new(2030, 12, 24),
                    new(2030, 12, 25),
                    new(2030, 12, 26)
                ]
            }
        };
    }
}
