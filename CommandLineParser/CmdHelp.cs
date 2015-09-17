using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLineParser
{
    class CmdHelp : Cmd
    {
        override public String Usage()
        {
            return "/?] [/help] [-help";
        }
        override public String ToString()
        {
            List<String> result = new List<String>();

            return System.IO.Path.GetFileName(System.Reflection.Assembly.GetEntryAssembly().Location) + " "
                + String.Join("] [",result)
                + ']';
        }
    }
}
