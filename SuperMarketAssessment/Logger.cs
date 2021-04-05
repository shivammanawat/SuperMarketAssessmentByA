using System;

namespace SuperMarketAssessment
{
    public class Logger :ILogger
    {
        private ILogger _logger;
        public Logger(ILogger logger=null)
        {
            _logger = logger; 
        }
      
     
        public void write(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}