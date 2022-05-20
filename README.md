# Bulk Ini Analyzer

![Build Status](https://dev.azure.com/Tilation/Ini%20Data%20Viewer/_apis/build/status/Tilation.Bulk-Ini-Analyzer?branchName=main)
[![](https://img.shields.io/badge/.Net%20Framework-4.8-brightgreen)](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net48)

[![](https://img.shields.io/badge/Latest%20Release-Download-brightgreen)](https://github.com/Tilation/Bulk-Ini-Analyzer/releases/latest)

Bulk Ini Analyzer is a tool that shows you every header/property combination of a collection of items inside a folder, and on which files are present.

## Usage:
1. Have a folder with lots of ini formated data.
2. Select the folder in Bulk Ini Analyzer.
3. If the files don't have the "INI" extension, you can change the extension to look after, write in the next textbox the target extension without punctuation.
4. Press the gather button.
5. Clicking on a header/property item will update the right list and the bottom, and show you in which files happens the occurrence. Also will show all the unique values found.
6. Double click the occurrence to open the file explorer with the file selected.

## Features:
- Searchbox for header/property items.
- Browse all found unique values for properties and view on which files the values are.
- Searchbox for occurrence files.
- Searchbox for values.
- Can modify the search pattern to read INI formatted data that doesn't have an .INI extension
- Open location of occurrence files.
- Headers with numbers are scrapped down and numbers are replaced with "#" so if your headers look like [ITEM356] [ITEM357] [ITEM358], don't worry, this will truncate them to [ITEM#] so you know that that header is a numbered header. 

## Todo:
- [Command line verification for CI/CD projects, to verify all data in the inis follow a header/property pattern.](https://github.com/Tilation/Bulk-Ini-Analyzer/blob/main/ini-validation.md)
  - Specify a folder continaing the INIS
  - Specify a filename match (can be * to match everything in the folder)
  - Specify a path to the template
  - When ran, would output if all files match the template.

## Screenshots
### When selecting Header & Properties
It shows on which files the header and property appears.
![preview](https://github.com/Tilation/ImagenesPublicas/blob/main/Bulk%20Ini%20Analyzer/gridview.png?raw=true)

### When selecting Values
It shows on which files the value of that property appears.
![preview](https://github.com/Tilation/ImagenesPublicas/blob/main/Bulk%20Ini%20Analyzer/gridview-values.png?raw=true)
