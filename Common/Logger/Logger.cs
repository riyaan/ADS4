using System;
using System.IO;

namespace Diagnostics
{
    public class Logger
    {
        private static Logger instance;

        public static Logger Instance
        {
            get
            {
                if (instance == null)
                    instance = new Logger();

                return instance;
            }
        }

        StreamWriter logFile;

        internal StreamWriter LogFile
        {
            get { return logFile; }
            set { logFile = value; }
        }

        private Logger()
        {
            this.logFile = new StreamWriter(@"maze.log", true);
        }

        public void Log(string output)
        {
            this.logFile.WriteLine(String.Format("[{0}] - {1}", DateTime.Now.ToString(), output));
            this.logFile.Flush();
        }
    }
}
