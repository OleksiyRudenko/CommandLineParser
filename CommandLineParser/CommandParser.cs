using System;
using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;

namespace CommandLineParser
{
    class Program
    {
        static bool HelpPrinted = false;
        static void Main(string[] args)
        {
            string[] defaultArguments = { "/?" };
            if (args.Length == 0)
                ParseArguments(defaultArguments);
            else
                ParseArguments(args);
        }

        static void ParseArguments(String[] args)
        {
            String command="";
            Queue<String> arguments = new Queue<String>();

            foreach (String str in args)
            {
                if (str[0] == '-' || str[0] == '/')
                { // assume command
                    // execute previous command
                    ExecuteCommand(command, arguments);
                    // initialize new command
                    command = str;
                    arguments.Clear();
                }
                else
                { // assume argument for command
                    arguments.Enqueue(str);
                }
            }
            ExecuteCommand(command, arguments);
        }
        static void ExecuteCommand(String command, Queue<String> arguments)
        {
            if (command == "" && arguments.Count == 0L)
                return;
            switch (command.ToLower())
            {
                case "/?":
                case "/help":
                case "-help":
                    if (!HelpPrinted)
                    {
                        Console.WriteLine("{0} [/?] [/help] [-help] [-k key value] [-ping] [-print <print a value>] [-d [date-format]]", System.IO.Path.GetFileName(System.Reflection.Assembly.GetEntryAssembly().Location));
                        HelpPrinted = true;
                    }
                    break;
                case "":
                    Console.WriteLine("No command for given arguments, use {0} /? to see set of allowed commands",
                        System.IO.Path.GetFileName(System.Reflection.Assembly.GetEntryAssembly().Location)
                        );
                    break;
                default:
                    // try executing any command
                    Cmd commandObject = (Cmd) CreateCmdInstanceFromTextName(command,arguments);
                    try
                    {
                        Console.WriteLine(commandObject);
                    }
                    catch (ArgumentNullException)
                    {
                        Console.WriteLine("Empty command {0} passed, use {1} /? to see set of allowed commands",
                        command,
                        System.IO.Path.GetFileName(System.Reflection.Assembly.GetEntryAssembly().Location)
                        );
                    }
                    catch (TypeLoadException)
                    {
                        Console.WriteLine("Command {0} is not supported, use {1} /? to see set of allowed commands",
                        command,
                        System.IO.Path.GetFileName(System.Reflection.Assembly.GetEntryAssembly().Location)
                        );
                    }
                    break;
            }
        }
        private static object CreateCmdInstanceFromTextName(string className, Queue<String> arguments)
        {
            if (String.IsNullOrEmpty(className))
                throw new ArgumentNullException();
            // skip leading slash or dash
            char leadingChar = className.ToCharArray()[0];
            if (leadingChar == '-' || leadingChar == '/')
                className = className.Substring(1);
            if (String.IsNullOrEmpty(className))
                throw new ArgumentNullException();
            // capitalize first letter
            className = Char.ToUpper(className[0]) + className.Substring(1).ToLower();
            return Activator.CreateInstance(null,"Cmd"+className,arguments.ToArray());
        } 
    }
}
