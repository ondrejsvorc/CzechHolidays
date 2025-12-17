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
- No holiday names in the API

The API intentionally exposes **dates only**.

### Usage

#### Create Czech Holidays for a Year
```csharp
ICzechHolidaysFactory holidaysFactory = new CzechHolidaysFactory();
CzechHolidaysYear holidays2025 = holidaysFactory.Create(year: 2025);
```

#### Determine Whether a Date Is a Czech Public Holiday (DateOnly)
```csharp
ICzechHolidaysFactory holidaysFactory = new CzechHolidaysFactory();
CzechHolidaysYear holidays2025 = holidaysFactory.Create(year: 2025);

DateOnly newYearDate = new(year: 2025, month: 1, day: 1);
bool isHoliday = holidays2025.Contains(newYearDate); // true
```

#### Determine Whether a Date Is a Czech Public Holiday (DateTime)
```csharp
ICzechHolidaysFactory holidaysFactory = new CzechHolidaysFactory();
CzechHolidaysYear holidays2025 = holidaysFactory.Create(year: 2025);

DateTime newYearDate = new(year: 2025, month: 1, day: 1);
bool isHoliday = holidays2025.Contains(newYearDate); // true
```
