# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

### Changed

- Supported years now start at 2016, the first year in which the current set of Czech public holidays applied.

## [1.0.1] - 2025-01-XX

### ⚠️ Breaking Changes

- **Removed `CzechHolidaysYear` class**: The class has been completely removed from the API.
- **Changed return type of `ICzechHolidaysFactory.Create()`**: The method now returns `IReadOnlyList<CzechHolidayDate>` instead of `CzechHolidaysYear`.
- **Removed `Contains()` method**: The `Contains(DateOnly)` and `Contains(DateTime)` methods are no longer available. To check if a date is a holiday, just use LINQ on the returned list: `holidays.Any(h => h.Date == date)`.

### ✨ Added

- **New `CzechHoliday` enum**: Identification of all 13 Czech public holidays as stable enum values.
- **New `CzechHolidayDate` type**: Record struct combining `DateOnly` date and `CzechHoliday` holiday identifier.
- **Holiday name localization**: New static class `CzechHolidayNames` provides localized holiday names.
- **Multi-language support**: New `CzechHolidayLanguage` enum with support for:
  - Czech (`Czech`)
  - English (`English`)
  - German (`German`)
- **Sorted results**: The `Create()` method now returns holidays sorted chronologically by date.
- **Improved year validation**: Explicit year range validation with clear error message when an invalid year is provided.

### 🔧 Changed

- **Internal implementation**: Changed internal structure for more efficient work with holiday identifiers and their names.

### 📝 Migration Guide

To migrate from version 1.0.0 to 1.0.1:

**Before (1.0.0):**
```csharp
ICzechHolidaysFactory factory = new CzechHolidaysFactory();
CzechHolidaysYear holidays = factory.Create(2025);
bool isHoliday = holidays.Contains(new DateOnly(2025, 1, 1));
````
**After (1.0.1):**
```csharp
ICzechHolidaysFactory factory = new CzechHolidaysFactory();
IReadOnlyList<CzechHolidayDate> holidays = factory.Create(2025);
bool isHoliday = holidays.Any(h => h.Date == new DateOnly(2025, 1, 1));
```
