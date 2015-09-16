using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLineParser
{
    class CmdPing : Cmd
    {
        public static String Usage()
        {
            return "-ping";
        }
        public String ToString()
        {
            Console.Beep();
            return "Pinging...";
        }
    }
}
