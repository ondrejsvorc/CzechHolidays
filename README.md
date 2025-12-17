## Czech Holidays
.NET library for generating Czech public holidays for any year without external APIs.

The library distinguishes between:
- **fixed holidays** – same date every year
- **movable holidays** – derived from Easter (Good Friday, Easter Monday)

Movable holidays are calculated algorithmically from Easter Sunday using the Meeus/Jones/Butcher algorithm.
No holiday tables are stored for specific years.

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

### Scope
- Czech Republic only
- public holidays only
- no religious or informal calendar days

### Usage
The library returns **dates only** (`DateTime`).
Holiday names are intentionally excluded from the API.
