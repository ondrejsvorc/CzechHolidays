## Czech Holidays
Lightweight .NET library for generating Czech public holidays for any calendar year without external APIs or stored year tables.

![](https://github.com/ondrejsvorc/CzechHolidays/blob/main/icon.png)

The library distinguishes between:
- **Fixed holidays** – same date every year
- **Movable holidays** – derived from Easter (Good Friday, Easter Monday)

Movable holidays are calculated algorithmically from Easter Sunday using the Meeus/Jones/Butcher algorithm.

### Fixed Holidays
| Date | Holiday |
|------:|--------|
| Jan 1 | Restoration Day of the Independent Czech State; New Year’s Day |
| May 1 | Labour Day |
| May 8 | Victory Day |
| Jul 5 | Saints Cyril and Methodius Day |
| Jul 6 | Jan Hus Day |
| Sep 28 | St. Wenceslas Day (Czech Statehood Day) |
| Oct 28 | Independent Czechoslovak State Day |
| Nov 17 | Struggle for Freedom and Democracy Day |
| Dec 24 | Christmas Eve |
| Dec 25 | Christmas Day |
| Dec 26 | St. Stephen’s Day |

### Movable Holidays
| Date | Holiday |
|------:|--------|
| Differs each year | Good Friday |
| Differs each year | Easter Monday |

### Scope
- Czech public holidays only
- Holiday names available in Czech, English, and German

The API intentionally exposes **dates only**.

### Usage

#### Create Czech Holidays for a Year
```csharp
ICzechHolidaysFactory holidaysFactory = new CzechHolidaysFactory();
IReadOnlyList<CzechHolidayDate> holidays2025 = holidaysFactory.Create(year: 2025);
```

#### Determine Whether a Date Is a Czech Public Holiday In a Specific Year
```csharp
ICzechHolidaysFactory factory = new CzechHolidaysFactory();
IReadOnlyList<CzechHolidayDate> holidays2025 = factory.Create(2025);

bool isHoliday = holidays2025.Any(holiday => holiday.Date == new DateOnly(2025, 1, 1)); // true
```

### Get Holiday Names
```csharp
string newYearCzechName = CzechHolidayNames.GetName(CzechHoliday.NewYear, CzechHolidayLanguage.Czech);
string newYearEnglishName = CzechHolidayNames.GetName(CzechHoliday.NewYear, CzechHolidayLanguage.English);
string newYearGermanName = CzechHolidayNames.GetName(CzechHoliday.NewYear, CzechHolidayLanguage.German);
```

```csharp
ICzechHolidaysFactory factory = new CzechHolidaysFactory();
IReadOnlyList<CzechHolidayDate> holidays2025 = factory.Create(2025);

CzechHolidayDate holiday = holidays2025.First();
string czechName = CzechHolidayNames.GetName(holiday.Holiday, CzechHolidayLanguage.Czech);
```