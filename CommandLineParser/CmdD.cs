using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLineParser
{
    class CmdD : Cmd
    {
        public static String Usage()
        {
            return "-k key value";
        }
        public String ToString()
        {
            String format = (arguments.Count > 0) ? arguments.Dequeue() : "yyyy-MM-dd";
            return DateTime.Today.ToString(format);
        }
    }
}
