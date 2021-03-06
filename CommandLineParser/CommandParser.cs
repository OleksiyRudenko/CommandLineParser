﻿using System;
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
            // wait for input -- one line per command
            // -exit -- terminates the app
            Console.WriteLine(Environment.NewLine + "User input console. Single line per command with its arguments.");
            Console.WriteLine("Use /? for help, -exit to terminate the application");
            do
            {
                Console.Write("> ");
                String userInput = Console.ReadLine();
                ParseUserInput(userInput);
            } while (true);

        }
        static void ParseUserInput(String command)
        {
            Queue<String> components = new Queue<String>(command.Split(' '));
            if (components.Count > 0)
            {
                command = components.Dequeue();
            }
            else
                return;
            ExecuteCommand(command,components);
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
                case "help":
                case "?":
                    if (!HelpPrinted)
                    {
                        Cmd commandObject = CommandFactory.CreateCmdInstanceFromTextName("help", arguments);
                        Console.WriteLine(commandObject);
                        // HelpPrinted = true;
                    }
                    break;
                case "":
                    Console.WriteLine("No command for given arguments, use {0} /? to see set of allowed commands",
                        System.IO.Path.GetFileName(System.Reflection.Assembly.GetEntryAssembly().Location)
                        );
                    break;
                default:
                    // try executing arbitrary command
                    try
                    {
                        Cmd commandObject = CommandFactory.CreateCmdInstanceFromTextName(command, arguments);
                        Console.WriteLine(commandObject);
                    }
                    catch (ArgumentNullException)
                    {
                        Console.WriteLine("Empty command {0} passed, use {1} /? to see set of allowed commands",
                        command,
                        System.IO.Path.GetFileName(System.Reflection.Assembly.GetEntryAssembly().Location)
                        );
                    }
                    break;
            }
        }
    }
}
