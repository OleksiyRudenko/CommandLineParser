using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLineParser
{
    abstract class Cmd
    {
        private Queue<String> argumentsQueue = new Queue<String>();
        public Queue<String> arguments
        {
            get { return argumentsQueue; }
            set { argumentsQueue = value; }
        }
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
        /* public virtual String Usage()
        {
            return "";
        } */
    }
}
