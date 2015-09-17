using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLineParser
{
    static class CommandFactory
    {
        public static Cmd CreateCmdInstanceFromTextName(string className, Queue<String> arguments)
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

            // Activator.CreateInstance(Type.GetType("SomeNamespace.SomeClassName"));
            // or
            // Activator.CreateInstance(null, "SomeNamespace.SomeClassName").Unwrap();
            // var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            // return Activator.CreateInstance(null, "Cmd" + className, arguments.ToArray());
            Cmd obj = null;
            try
            {
                obj = (Cmd)Activator.CreateInstance(null, "CommandLineParser.Cmd" + className).Unwrap();
                obj.arguments = arguments;
            }
            catch (TypeLoadException)
            {
                Console.WriteLine("Command {0} is not supported, use {1} /? to see set of allowed commands",
                className.ToLower(),
                System.IO.Path.GetFileName(System.Reflection.Assembly.GetEntryAssembly().Location)
                );
            }
            return obj;
        }
        public static List<String> CmdUsage()
        {
            List<String> usages = new List<string>();
            foreach (Type t in GetDerivedTypesFor(Type.GetType("CommandLineParser.Cmd"))) // CmdTypeList())
            {
                usages.Add((String)t.GetMethod("Usage").Invoke(null,null));
            }
            return usages;
        }
        /* public static List<Type> CmdTypeList()
        {
            return (List<Type>) GetDerivedTypesFor(Type.GetType("CommandLineParser.Cmd"));
        } */
        private static IEnumerable<Type> GetDerivedTypesFor(Type baseType) // Type.GetType("SomeNamespace.SomeClassName")
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            return assembly.GetTypes()
                .Where(baseType.IsAssignableFrom)
                .Where(t => baseType != t);
        }
    }
}
