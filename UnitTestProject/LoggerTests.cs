using NUnit.Framework;
using SuperMarketAssessment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using Moq;
using System.IO;

namespace UnitTestProject
{
    [TestFixture]
    public class LoggerTests
    {
       
      

      

        [Test]

        public void WhenCalledWrite_DisplaysMsgOnConsole()
        {
            string anyMsg = "astha";
            var output = new StringWriter();
            Console.SetOut(output);
            var logger = new Logger();
            logger.write(anyMsg);
            Assert.That(output.ToString(), Is.EqualTo(anyMsg+string.Format(Environment.NewLine)));
           
        } 
    }
}


