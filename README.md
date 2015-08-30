# C# Command Line Parser
Command Line Parser is a test application submitted to [Kottans](http://kottans.org/) to apply for a C# course.
The application parses console command line arguments producing predictable results according to an assignment.

## Requirements
To build the application Visual Studio 2010+ is required.

## Features
Command line arguments:
* `-k key value key value...` - prints pairs of key and value; `<null>` replaces absent value
* `-print message to print` - prints given message
* `-ping` - beeps and prints "Pinging..." NB! No actual pinging is effected whatever it might mean except the behaviour described
* `-d [dateFormat]` - prints current date using given format; default format is yyyy-MM-dd.

Use `/?`, `-help` or `/help` command-line argument to get help from the application in console.
Commands are executed in order of their appearance except for `/?`, `/help` and `-help`, which are ignored once help output occured.

## Compilation
Open solution with Visual Studio and press F7 to build the application.

## Tests
1. Open solution root folder in Explorer.
2. Launch `CommandLineParserTest.bat`

You will see app behaviour run with various command-line arguments as well as error handling.

## Usage
Well, I doubt one can make any real use from this application. But, please, feel free playing around.
`CommandLineParserTest.bat` is a good source of ideas for that. Amend it to see how various command-line arguments affect application output.

## Author
Oleksiy Rudenko oleksiy.rudenko@gmail.com

Aug 29, 2015