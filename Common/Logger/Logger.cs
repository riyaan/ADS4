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
            this.logFile = new StreamWriter(@"C:\temp\logs\maze.txt", true);
        }

        public void Log(string output)
        {            
            this.logFile.WriteLine(output);
            this.logFile.Flush();
        }
    }
}
