namespace CzechHolidays.Tests;

public sealed class CzechHolidaysTests
{
    private readonly CzechHolidaysFactory holidaysFactory = new();

    [Theory]
    [MemberData(nameof(TestData))]
    public void IsHoliday_ReturnsTrue_ForAllExpectedHolidays(int year, DateOnly[] expectedHolidays)
    {
        CzechHolidaysYear holidays = holidaysFactory.Create(year);

        foreach (DateOnly holiday in expectedHolidays)
        {
            Assert.True(holidays.Contains(holiday), $"Expected {holiday:yyyy-MM-dd} to be a holiday in {year}");
        }
    }

    public static readonly TheoryData<int, DateOnly[]> TestData = CreateTestData();
    private static TheoryData<int, DateOnly[]> CreateTestData()
    {
        const int year2029 = 2029;
        const int year2030 = 2030;

        return new TheoryData<int, DateOnly[]>
        {
            {
                year2029,
                [
                    new(year2029, 1, 1),
                    new(year2029, 3, 30), // Good Friday
                    new(year2029, 4, 2),  // Easter Monday
                    new(year2029, 5, 1),
                    new(year2029, 5, 8),
                    new(year2029, 7, 5),
                    new(year2029, 7, 6),
                    new(year2029, 9, 28),
                    new(year2029, 10, 28),
                    new(year2029, 11, 17),
                    new(year2029, 12, 24),
                    new(year2029, 12, 25),
                    new(year2029, 12, 26)
                ]
            },
            {
                year2030,
                [
                    new(year2030, 1, 1),
                    new(year2030, 4, 19), // Good Friday
                    new(year2030, 4, 22), // Easter Monday
                    new(year2030, 5, 1),
                    new(year2030, 5, 8),
                    new(year2030, 7, 5),
                    new(year2030, 7, 6),
                    new(year2030, 9, 28),
                    new(year2030, 10, 28),
                    new(year2030, 11, 17),
                    new(year2030, 12, 24),
                    new(year2030, 12, 25),
                    new(year2030, 12, 26)
                ]
            }
        };
    }
}