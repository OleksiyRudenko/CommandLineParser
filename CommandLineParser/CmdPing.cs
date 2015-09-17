using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLineParser
{
    class CmdPing : Cmd
    {
        static public String Usage()
        {
            return "-ping";
        }
        override public String ToString()
        {
            Console.Beep();
            return "Pinging...";
        }
    }
}
