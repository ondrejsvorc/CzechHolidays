namespace CzechHolidays;

/// <summary>
/// Provides localized display names for Czech public holidays.
/// </summary>
/// <remarks>
/// Pure lookup utility class with no mutable state.
/// Holiday names are resolved by <see cref="CzechHoliday"/> identity and
/// an explicit <see cref="CzechHolidayLanguage"/>.
/// Localization data is initialized lazily per language on first use.
/// </remarks>
public static class CzechHolidayNames
{
    /// <summary>
    /// Returns localized name of a Czech public holiday
    /// in the specified supported language.
    /// </summary>
    /// <returns>
    /// Localized name(s) of the holiday split by ';' delimiter. In current version, only <see cref="CzechHoliday.NewYear"/> contains 2 names.
    /// </returns>
    public static string GetName(CzechHoliday holiday, CzechHolidayLanguage language)
    {
        return Names[language].Value[holiday];
    }

    private static readonly Dictionary<CzechHolidayLanguage, Lazy<Dictionary<CzechHoliday, string>>> Names = new()
    {
        [CzechHolidayLanguage.Czech] = new Lazy<Dictionary<CzechHoliday, string>>(CreateCzech, isThreadSafe: true),
        [CzechHolidayLanguage.English] = new Lazy<Dictionary<CzechHoliday, string>>(CreateEnglish, isThreadSafe: true),
        [CzechHolidayLanguage.German] = new Lazy<Dictionary<CzechHoliday, string>>(CreateGerman, isThreadSafe: true),
    };

    private static Dictionary<CzechHoliday, string> CreateCzech() => new()
    {
        [CzechHoliday.NewYear] = "Den obnovy samostatného českého státu;Nový rok",
        [CzechHoliday.GoodFriday] = "Velký pátek",
        [CzechHoliday.EasterMonday] = "Velikonoční pondělí",
        [CzechHoliday.LabourDay] = "Svátek práce",
        [CzechHoliday.VictoryDay] = "Den vítězství",
        [CzechHoliday.CyrilAndMethodius] = "Den slovanských věrozvěstů Cyrila a Metoděje",
        [CzechHoliday.JanHus] = "Den upálení mistra Jana Husa",
        [CzechHoliday.StWenceslas] = "Den české státnosti",
        [CzechHoliday.IndependentStateDay] = "Den vzniku samostatného československého státu",
        [CzechHoliday.StruggleForFreedomAndDemocracy] = "Den boje za svobodu a demokracii a Mezinárodní den studentstva",
        [CzechHoliday.ChristmasEve] = "Štědrý den",
        [CzechHoliday.ChristmasDay] = "1. svátek vánoční",
        [CzechHoliday.StStephensDay] = "2. svátek vánoční",
    };

    private static Dictionary<CzechHoliday, string> CreateEnglish() => new()
    {
        [CzechHoliday.NewYear] = "Restoration Day of the Independent Czech State;New Year's Day",
        [CzechHoliday.GoodFriday] = "Good Friday",
        [CzechHoliday.EasterMonday] = "Easter Monday",
        [CzechHoliday.LabourDay] = "Labour Day",
        [CzechHoliday.VictoryDay] = "Victory Day",
        [CzechHoliday.CyrilAndMethodius] = "Saints Cyril and Methodius Day",
        [CzechHoliday.JanHus] = "Jan Hus Day",
        [CzechHoliday.StWenceslas] = "Statehood Day",
        [CzechHoliday.IndependentStateDay] = "Independent Czechoslovak State Day",
        [CzechHoliday.StruggleForFreedomAndDemocracy] = "Struggle for Freedom and Democracy Day",
        [CzechHoliday.ChristmasEve] = "Christmas Eve",
        [CzechHoliday.ChristmasDay] = "Christmas Day",
        [CzechHoliday.StStephensDay] = "Second Day of Christmas",
    };

    private static Dictionary<CzechHoliday, string> CreateGerman() => new()
    {
        [CzechHoliday.NewYear] = "Tag der Erneuerung des selbständigen tschechischen Staates;Neujahr",
        [CzechHoliday.GoodFriday] = "Karfreitag",
        [CzechHoliday.EasterMonday] = "Ostermontag",
        [CzechHoliday.LabourDay] = "Tag der Arbeit",
        [CzechHoliday.VictoryDay] = "Tag des Sieges",
        [CzechHoliday.CyrilAndMethodius] = "Tag der Slawenapostel Kyrill und Method",
        [CzechHoliday.JanHus] = "Tag der Verbrennung von Jan Hus",
        [CzechHoliday.StWenceslas] = "Tag der Tschechischen Staatlichkeit",
        [CzechHoliday.IndependentStateDay] = "Tag der Entstehung eines selbstständigen tschechoslowakischen Staates",
        [CzechHoliday.StruggleForFreedomAndDemocracy] = "Tag des Kampfes für Freiheit und Demokratie und Internationaler Studententag",
        [CzechHoliday.ChristmasEve] = "Heiliger Abend",
        [CzechHoliday.ChristmasDay] = "1. Weihnachtsfeiertag",
        [CzechHoliday.StStephensDay] = "2. Weihnachtsfeiertag",
    };
}
