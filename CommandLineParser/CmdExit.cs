using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLineParser
{
    class CmdExit : Cmd
    {
        override public String Usage()
        {
            return "-exit";
        }
        override public String ToString()
        {
            System.Environment.Exit(1);
            return "";
        }
    }
}
