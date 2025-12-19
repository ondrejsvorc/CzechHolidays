namespace CzechHolidays;

/// <summary>
/// Identifies Czech public holidays as a closed, stable set of holiday types.
/// </summary>
/// <remarks>
/// This enum represents holiday identities independently of their
/// calendar occurrence in a specific year.
/// Most holidays have a fixed calendar date, while some holidays
/// (such as <see cref="GoodFriday"/> and <see cref="EasterMonday"/>)
/// are movable and their exact date depends on the Easter calculation
/// for a given year.
/// The enum intentionally contains no localization, dates, or metadata.
/// Those concerns are handled by separate components responsible for
/// calendar computation and name localization.
/// The set of values is governed by Czech law and is expected to change
/// rarely. Any addition or removal represents a breaking change in
/// the real-world holiday definition and therefore in the API.
/// </remarks>
public enum CzechHoliday
{
    /// <summary>
    /// New Year's Day and Restoration Day of the Independent Czech State
    /// (January 1).
    /// </summary>
    NewYear = 0,

    /// <summary>
    /// Good Friday.
    /// A movable Christian holiday occurring two days before Easter Sunday.
    /// </summary>
    GoodFriday = 1,

    /// <summary>
    /// Easter Monday.
    /// A movable Christian holiday occurring one day after Easter Sunday.
    /// </summary>
    EasterMonday = 2,

    /// <summary>
    /// Labour Day (May 1).
    /// </summary>
    LabourDay = 3,

    /// <summary>
    /// Victory Day (May 8), commemorating the end of World War II in Europe.
    /// </summary>
    VictoryDay = 4,

    /// <summary>
    /// Saints Cyril and Methodius Day (July 5).
    /// </summary>
    CyrilAndMethodius = 5,

    /// <summary>
    /// Jan Hus Day (July 6).
    /// </summary>
    JanHus = 6,

    /// <summary>
    /// Statehood Day (September 28),
    /// commemorating Saint Wenceslas.
    /// </summary>
    StWenceslas = 7,

    /// <summary>
    /// Independent Czechoslovak State Day (October 28).
    /// </summary>
    IndependentStateDay = 8,

    /// <summary>
    /// Struggle for Freedom and Democracy Day (November 17),
    /// also observed as International Students' Day.
    /// </summary>
    StruggleForFreedomAndDemocracy = 9,

    /// <summary>
    /// Christmas Eve (December 24).
    /// </summary>
    ChristmasEve = 10,

    /// <summary>
    /// Christmas Day (December 25).
    /// </summary>
    ChristmasDay = 11,

    /// <summary>
    /// St. Stephen's Day, the Second Day of Christmas (December 26).
    /// </summary>
    StStephensDay = 12
}
