using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                case "-k":
                    CommandKeyValue(arguments);
                    break;
                case "-d":
                    CommandDate(arguments);
                    break;
                case "-ping":
                    CommandPing(); // arguments ignored
                    break;
                case "-print":
                    CommandPrint(arguments);
                    break;
                case "":
                    Console.WriteLine("No command for given arguments, use {0} /? to see set of allowed commands",
                        System.IO.Path.GetFileName(System.Reflection.Assembly.GetEntryAssembly().Location)
                        );
                    break;
                default:
                    Console.WriteLine("Command {0} is not supported, use {1} /? to see set of allowed commands", 
                        command, 
                        System.IO.Path.GetFileName(System.Reflection.Assembly.GetEntryAssembly().Location)
                        );
                    break;
            }
        }
        static void CommandKeyValue(Queue<String> arguments)
        {
            while (arguments.Count > 0)
            {
                String key = arguments.Dequeue();
                String value = (arguments.Count > 0) ? arguments.Dequeue() : "<null>";
                Console.WriteLine("{0} - {1}", key, value);
            }
        }
        static void CommandPing()
        {
            Console.WriteLine("Pinging...");
            Console.Beep();
        }
        static void CommandPrint(Queue<String> arguments)
        {
            if (arguments.Count > 0)
                Console.WriteLine(String.Join(" ",arguments));
        }
        static void CommandDate(Queue<String> arguments)
        {
            String format = (arguments.Count > 0) ? arguments.Dequeue() : "yyyy-MM-dd";
            Console.WriteLine(DateTime.Today.ToString(format));
        }
    
    }
}
