namespace CzechHolidays;

/// <summary>
/// Defines the set of explicitly supported languages for localized Czech public holiday names.
/// </summary>
/// <remarks>
/// This enum represents a closed and intentional list of languages.
/// Only languages declared here are supported by the library.
/// The enum is used instead of <see cref="System.Globalization.CultureInfo"/>
/// to avoid implicit fallbacks, regional ambiguities, and false claims
/// of broader localization support.
/// Adding a new value is a conscious API change and requires
/// providing complete holiday name mappings for the new language.
/// </remarks>
public enum CzechHolidayLanguage
{
    Czech = 0,
    English = 1,
    German = 2
}