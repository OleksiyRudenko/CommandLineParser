using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLineParser
{
    class CmdK : Cmd
    {
        static public String Usage()
        {
            return "-k key value";
        }
        override public String ToString()
        {
            StringBuilder result = new StringBuilder("");
            while (arguments.Count > 0)
            {
                String key = arguments.Dequeue();
                String value = (arguments.Count > 0) ? arguments.Dequeue() : "<null>";
                result.AppendFormat("{0} - {1}{2}", key, value, Environment.NewLine);
            }
            return result.ToString();
        }
    }
}
