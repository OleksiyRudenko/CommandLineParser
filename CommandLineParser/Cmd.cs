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

        public Cmd(Queue<String> arguments)
        {
            arguments = this.arguments;
        }

        // abstract void Execute();

        public abstract static String Usage();
    }
}
