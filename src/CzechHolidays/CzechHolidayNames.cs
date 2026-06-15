namespace CzechHolidays;

/// <summary>
/// Provides localized display names for Czech public holidays.
/// </summary>
public static class CzechHolidayNames
{
    public static string GetName(CzechHoliday holiday, CzechHolidayLanguage language) => Names[(int)language][(int)holiday];

    private static readonly string[][] Names =
    [
        [
            "Den obnovy samostatného českého státu;Nový rok",
            "Velký pátek",
            "Velikonoční pondělí",
            "Svátek práce",
            "Den vítězství",
            "Den slovanských věrozvěstů Cyrila a Metoděje",
            "Den upálení mistra Jana Husa",
            "Den české státnosti",
            "Den vzniku samostatného československého státu",
            "Den boje za svobodu a demokracii a Mezinárodní den studentstva",
            "Štědrý den",
            "1. svátek vánoční",
            "2. svátek vánoční",
        ],
        [
            "Restoration Day of the Independent Czech State;New Year's Day",
            "Good Friday",
            "Easter Monday",
            "Labour Day",
            "Victory Day",
            "Saints Cyril and Methodius Day",
            "Jan Hus Day",
            "Statehood Day",
            "Independent Czechoslovak State Day",
            "Struggle for Freedom and Democracy Day",
            "Christmas Eve",
            "Christmas Day",
            "Second Day of Christmas",
        ],
        [
            "Tag der Erneuerung des selbständigen tschechischen Staates;Neujahr",
            "Karfreitag",
            "Ostermontag",
            "Tag der Arbeit",
            "Tag des Sieges",
            "Tag der Slawenapostel Kyrill und Method",
            "Tag der Verbrennung von Jan Hus",
            "Tag der Tschechischen Staatlichkeit",
            "Tag der Entstehung eines selbstständigen tschechoslowakischen Staates",
            "Tag des Kampfes für Freiheit und Demokratie und Internationaler Studententag",
            "Heiliger Abend",
            "1. Weihnachtsfeiertag",
            "2. Weihnachtsfeiertag",
        ],
    ];
}
