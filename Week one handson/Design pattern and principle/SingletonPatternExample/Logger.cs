using System;

namespace SingletonPatternExample
{
    public sealed class Logger
    {
        private static Logger? instance;
        private static readonly object lockObject = new object();

        private Logger()
        {
            Console.WriteLine("Logger Instance Created");
        }

        public static Logger GetInstance()
        {
            lock (lockObject)
            {
                if (instance == null)
                {
                    instance = new Logger();
                }
            }

            return instance;
        }

        public void Log(string message)
        {
            Console.WriteLine("Log: " + message);
        }
    }
}