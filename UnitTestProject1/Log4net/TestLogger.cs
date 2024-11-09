using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Layout;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnitTestProject1.Log4net
{
    [TestClass]
    public class TestLogger
    {
        public static ILog Logger;
        [TestMethod]
        public static ILog TestLog4Net()
        {
            var patternLayout = new PatternLayout();
            patternLayout.ConversionPattern = "%date{dd-MMM-yyyy hh:mm:ss} [%class] [%level] [%method] %message%newline";
            patternLayout.ActivateOptions();

            var consoleAppender = new ConsoleAppender()
            {
                Name = "ConsoleAppender",
                Layout = patternLayout,
                Threshold = Level.All
            };

            var fileAppender = new FileAppender()
            {
                Name = "fileAppender",
                Layout = patternLayout,
                Threshold= Level.All,
                AppendToFile = true,
                File = "FileLogger.log",

            };
                fileAppender.ActivateOptions();
          

            consoleAppender.ActivateOptions();
            BasicConfigurator.Configure(consoleAppender, fileAppender);

            Logger = LogManager.GetLogger(typeof(TestLogger));

            //Logger.Debug("This is debug information");
            //Logger.Info("This is Info information");
            //Logger.Warn("This is warn information");
            //Logger.Error("This is Error information");
            //Logger.Fatal("This is fatal information");

            return Logger;

        }
    }
}
