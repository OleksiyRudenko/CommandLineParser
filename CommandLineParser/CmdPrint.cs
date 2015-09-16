using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLineParser
{
    class CmdPrint : Cmd
    {
        override public String Usage()
        {
            return "-print <value to print>";
        }
        override public String ToString()
        {
            return (arguments.Count > 0) 
                ?
                String.Join(" ",arguments)
                :
                "";
        }
    }
}
