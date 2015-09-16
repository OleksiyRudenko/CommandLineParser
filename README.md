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

## Extending Features
For e.g. you want to implement new command, say, `-foo`.
Add new class to the solution.
Class name should start with `Cmd` followed by command name (excluding leading dash) with first letter capitalized.
This class should extend abstract class Cmd and implement two methods:

1. `Usage()`, which returns String containing command usage description.
2. `ToString()`, which returns String containing arguments processing result.

Example:
```
    class CmdFoo : Cmd
    {
        public static String Usage()
        {
            return "-foo argument anotherArgument yetAnother Argument";
        }
        public String ToString()
        {
            // process arguments, contained in the field arguments of Queue<String> type
            return (arguments.Count > 0) ? arguments.Dequeue() : ""; // or whatever you want
        }
    }
```
Amend `CommandLineParserTest.bat` as appropriate to test your command.

## Usage
Well, I doubt one can make any real use from this application. But, please, feel free playing around.
`CommandLineParserTest.bat` is a good source of ideas for that. Amend it to see how various command-line arguments affect application output.

## Author
Oleksiy Rudenko oleksiy.rudenko@gmail.com

Aug 29, 2015