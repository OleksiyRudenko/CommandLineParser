using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLineParser
{
    class CmdHelp : Cmd
    {
        static public String Usage()
        {
            return "/?] [/help] [-help";
        }
        override public String ToString()
        {
            List<String> result = CommandFactory.CmdUsage();

            return "Usage: " +
                System.IO.Path.GetFileName(System.Reflection.Assembly.GetEntryAssembly().Location) + " ["
                + String.Join("] [",result)
                + ']';
        }
    }
}
