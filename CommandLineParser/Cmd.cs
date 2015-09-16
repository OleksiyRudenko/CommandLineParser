using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLineParser
{
    abstract class Cmd
    {
        protected Queue<String> arguments = new Queue<String>();
        public Cmd()
        {
        }
        public Cmd(Queue<String> arguments)
        {
            this.arguments = arguments;
        }
        public Cmd(String[] arguments)
        {
            this.arguments = new Queue<String>(arguments);
        }
        public virtual String Usage()
        {
            return "";
        }
    }
}
