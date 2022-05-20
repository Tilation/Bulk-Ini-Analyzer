# Ini data validation

As a console application this software can be used to verify that a bunch of ini formatted files follow a specific pattern.

The Command line interface is as follows:

```
bia.exe 
    [--template-files:"c:/users/damian/etcr/.ini-template"] 
    [--template-files:"**/.ini-template"] 
    [--template-files:"c:/src/data/**/.ini-template"] 
```
## Parameters:
- `template-files`: A path to the template files to be analyzed.
    - Can be a direct path, for example: `"C:/repos/data/.ini-template"`
    - Can be recursive on all folders insidea a directory, for example: `"**/.ini-template"`
    - If full path is not specified, including a drive letter, it will try to appen that directory to the current directory of the executable, or alternatively, the current directory of the `ini-template` file.

## .ini-template:
This file contains the structure that must be followed for the ini files in the specified folders, and the data validators for the values of the ini headers and fields. 

### The first half looks something like this:

``` ini
#This header is mandatory, it contains the affected paths, containing ini data; or files. The name of the properties are just informative, but the order specified will be maintained during evaluation phase.
[paths]

# Don't add double quotes UNLESS you want whitespace to the right or to the left, else it will get trimmed; for example:

# [paths]
# somePath =       src/manchester/*.ini

# Is the same as:
# [paths]
# somePath=src/manchester/*.ini

# But not the same as: (because of the quotations)
# [paths]
# somePath = "  src/manchester/*.ini  "

# Note that there is no need to add the starting.
path1 = "src/*.ini"
path2 = src/metadata/**/*.ini
```
### The other half is like so:
For this example we will be using this ini file:

```ini
# Located at: "items/item1.ini"
                                # Rules:
[item1]                         # item keyword + Numeric item ID
Name = "Epic Item"              # Name of item, as string (with quotations)
Value = 1950                    # Value of the item as numeric
PurchasedFromNpcs = 5,3,67,9    # List of vendors that sell this item
```
Lets say that we want to make sure that the main header of the items is always conformed by the `item` keyword, plus a number, a few examples of the headers we want to check would be:
- ``[item5]`` is valid.
- ``[item 5]`` is **NOT** valid, has an extra space.
- ``[item105]`` is valid.
- ``[broadsword5]`` is **NOT** valid, missing the `item` keyword.

To check for this, the `.ini-template` would look like this:
```ini
[path]
items = "items/item1.ini" # Or "items/*.ini" to check for all items.

# Everything that is not inside the [path] header, are regex rules for headers, properties and values.

[item\d+] # This regex inside the header, is a rule that specifies that there must be a header that matches this pattern. Which is the previous example.

# If you wanted to you could make it non case sensitive, like so:
# [[iI][tT][eE][mM]\d+]
# This new rule would match all of this:
# [item3]
# [Item6]
# [ITEM7]
```
Properties and values defined inside a header, will only check inside their corresponding headers.
To check the previous rules of the `item.ini` template, this would be the full `.ini-template`:
```ini
[path]
items = "items/item*.ini"

# Rule Specification begins here

[item\d+]
Name=".*"
Value=\d+
PurchasedFromNpcs=(\d+,|\d+)+
```

## Step by step execution
Using the previous example, the execution would go as follows:
1. Run `bia.exe` with a `--template-files` parameter (running without will try to locate all `.ini-template` in the current directory)
2. Locate all `.ini-template` files.
3. For each `.ini-template`:
    1. Read all paths affected by the validation, and list files.
    2. Read all rule specification headers with its properties and values, *note that in the rule specification, whitespace matters, as it is a valid regex character.*
    3. For each `file` in the collection:
        1. Check all headers, header properties, and property's values match their rule specification.
        2. Save the non matching in a collection for output.
