
namespace CzechHolidays.Tests;

public sealed class CzechHolidaysTests
{
    private readonly CzechHolidaysFactory holidaysFactory = new();

    [Theory]
    [MemberData(nameof(TestData))]
    public void IsHoliday_ReturnsTrue_ForAllExpectedHolidays(int year, CzechHolidayDate[] expectedHolidays)
    {
        IReadOnlyList<CzechHolidayDate> holidays = holidaysFactory.Create(year);

        foreach (CzechHolidayDate expectedHoliday in expectedHolidays)
        {
            Assert.True(holidays.Any(holiday => holiday == expectedHoliday), $"Expected {expectedHoliday:yyyy-MM-dd} to be a holiday in {year}");
        }

        CzechHolidayNames.GetName(CzechHoliday.NewYear, CzechHolidayLanguage.Czech);
    }

    [Theory]
    [InlineData(2029)]
    [InlineData(2030)]
    public void Holidays_AreOrderedByDate(int year)
    {
        IReadOnlyList<CzechHolidayDate> holidays = holidaysFactory.Create(year);

        DateOnly[] dates = holidays.Select(holiday => holiday.Date).ToArray();
        DateOnly[] ordered = dates.Order().ToArray();

        Assert.Equal(ordered, dates);
    }

    [Fact]
    public void All_Languages_Have_All_Holiday_Translations()
    {
        CzechHoliday[] holidays = Enum.GetValues<CzechHoliday>();
        CzechHolidayLanguage[] languages = Enum.GetValues<CzechHolidayLanguage>();

        foreach (CzechHolidayLanguage language in languages)
        {
            foreach (CzechHoliday holiday in holidays)
            {
                string name = CzechHolidayNames.GetName(holiday, language);
                Assert.False(string.IsNullOrWhiteSpace(name), $"Missing translation for {holiday} in {language}");
            }
        }
    }

    public static readonly TheoryData<int, CzechHolidayDate[]> TestData = CreateTestData();
    private static TheoryData<int, CzechHolidayDate[]> CreateTestData()
    {
        const int year2029 = 2029;
        const int year2030 = 2030;

        return new TheoryData<int, CzechHolidayDate[]>
        {
            {
                year2029,
                [
                    // Movable
                    new(new DateOnly(year2029, 3, 30), CzechHoliday.GoodFriday),
                    new(new DateOnly(year2029, 4, 2), CzechHoliday.EasterMonday),

                    // Fixed
                    new(new DateOnly(year2029, 1, 1), CzechHoliday.NewYear),
                    new(new DateOnly(year2029, 5, 1), CzechHoliday.LabourDay),
                    new(new DateOnly(year2029, 5, 8), CzechHoliday.VictoryDay),
                    new(new DateOnly(year2029, 7, 5), CzechHoliday.CyrilAndMethodius),
                    new(new DateOnly(year2029, 7, 6), CzechHoliday.JanHus),
                    new(new DateOnly(year2029, 9, 28), CzechHoliday.StWenceslas),
                    new(new DateOnly(year2029, 10, 28), CzechHoliday.IndependentStateDay),
                    new(new DateOnly(year2029, 11, 17), CzechHoliday.StruggleForFreedomAndDemocracy),
                    new(new DateOnly(year2029, 12, 24), CzechHoliday.ChristmasEve),
                    new(new DateOnly(year2029, 12, 25), CzechHoliday.ChristmasDay),
                    new(new DateOnly(year2029, 12, 26), CzechHoliday.StStephensDay),
                ]
            },
            {
            year2030,
                [
                    // Movable
                    new(new DateOnly(year2030, 4, 19), CzechHoliday.GoodFriday),
                    new(new DateOnly(year2030, 4, 22), CzechHoliday.EasterMonday),

                    // Fixed
                    new(new DateOnly(year2030, 1, 1), CzechHoliday.NewYear),
                    new(new DateOnly(year2030, 5, 1), CzechHoliday.LabourDay),
                    new(new DateOnly(year2030, 5, 8), CzechHoliday.VictoryDay),
                    new(new DateOnly(year2030, 7, 5), CzechHoliday.CyrilAndMethodius),
                    new(new DateOnly(year2030, 7, 6), CzechHoliday.JanHus),
                    new(new DateOnly(year2030, 9, 28), CzechHoliday.StWenceslas),
                    new(new DateOnly(year2030, 10, 28), CzechHoliday.IndependentStateDay),
                    new(new DateOnly(year2030, 11, 17), CzechHoliday.StruggleForFreedomAndDemocracy),
                    new(new DateOnly(year2030, 12, 24), CzechHoliday.ChristmasEve),
                    new(new DateOnly(year2030, 12, 25), CzechHoliday.ChristmasDay),
                    new(new DateOnly(year2030, 12, 26), CzechHoliday.StStephensDay),
                ]
            }
        };
    }
}