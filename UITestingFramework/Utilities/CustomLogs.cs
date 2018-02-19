using log4net;
using log4net.Appender;
using log4net.Core;
using log4net.Layout;
using log4net.Repository.Hierarchy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITestingFramework.Utilities
{
    public class CustomLogs
    {
        private static ILog logger;// = LogManager.GetLogger(typeof(CustomLogs));
        private static ILog errorLog;// = LogManager.GetLogger("ErrorsFile");

        #region Public Methods
        /// <summary>
        /// Set the name of the logger(used for a better tracking of the info/error messages).
        /// </summary>
        /// <param name="loggername">The logger name (can be the type/name of the Class/TestMethod. Example of param: System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName).</param>
        public static void SetupLogger(string loggername)
        {
            logger = LogManager.GetLogger(loggername);
            errorLog = LogManager.GetLogger(loggername);
            Setup(loggername);
        }
        public static void pageIsDisplayed(string pageName)
        {
            logger.Info(string.Format("      -> The '{0}' page is displayed.", pageName));
        }

        /// <summary>
        /// This is to print log for the beginning of the test case
        /// </summary>
        /// <param name="sTestCaseName">The name of the test case</param>
        public static void startTestCase(string sTestCaseName)
        {
            //XmlConfigurator.Configure(new FileInfo(ConfigurationManager.AppSettings["log4net-config-file"]));

            logger.Info("****************************************************************************************");

            logger.Info(" ######   START -> " + sTestCaseName + "    ########## ");

            logger.Info("----------------------------------------------------------------------------------------");

        }

        /// <summary>
        /// This is to print log for the ending of the test case
        /// </summary>
        /// <param name="sTestCaseName">The name of the test case</param>
        public static void endTestCase(string sTestCaseName)
        {
            logger.Info(" ######   " + "-END -> " + sTestCaseName + "    ########## ");
        }

        /// <summary>
        /// This is to print log for info messages
        /// </summary>
        /// <param name="message">The info message to be printed</param>
        public static void info(string message)
        {
            logger.Info("      -> " + message);
        }
        /// <summary>
        /// This is to print log for warning messages
        /// </summary>
        /// <param name="message">The warning message to be printed</param>
        public static void warn(string message)
        {
            logger.Warn("      -w " + message);
        }
        /// <summary>
        /// This is to print log for error messages
        /// </summary>
        /// <param name="message">The error message to be printed</param>
        public static void error(string message)
        {
            errorLog.Error("      -x " + message);
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// This method is used to set up the log4net configuration files that will log the application.
        /// </summary>
        /// <param name="fileName">The name of the informatoin file.</param>
        private static void Setup(string fileName)
        {
            string logFilePath = "../../../Logs/";

            Hierarchy hierarchy = (Hierarchy)LogManager.GetRepository();

            PatternLayout patternLayoutTC = new PatternLayout();
            patternLayoutTC.ConversionPattern = "%date [%level] - %message%newline";
            patternLayoutTC.ActivateOptions();

            RollingFileAppender testCaseRoller = new RollingFileAppender();
            testCaseRoller.AppendToFile = false;
            testCaseRoller.File = string.Format("{0}logfile-{1}-{2}.log", logFilePath, fileName, DateTime.Now.ToString("HHmm-MMdd-yyyy"));
            testCaseRoller.Layout = patternLayoutTC;
            testCaseRoller.DatePattern = "HH-MMdd-yyyy";
            testCaseRoller.MaxSizeRollBackups = -1;
            testCaseRoller.MaximumFileSize = "1MB";
            testCaseRoller.RollingStyle = RollingFileAppender.RollingMode.Composite;

            var filterTC = new log4net.Filter.LevelRangeFilter
            {
                LevelMin = Level.Debug,
                LevelMax = Level.Warn
            };
            testCaseRoller.AddFilter(filterTC);
            testCaseRoller.ActivateOptions();
            hierarchy.Root.AddAppender(testCaseRoller);


            PatternLayout ErrorPatternLayout = new PatternLayout();
            ErrorPatternLayout.ConversionPattern = "%date [%level] %logger - message: %message%newline%newline";
            ErrorPatternLayout.ActivateOptions();

            FileAppender ErrorFiles = new FileAppender();
            ErrorFiles.File = string.Format("{0}ErrorLogFile.log", logFilePath);
            ErrorFiles.AppendToFile = true;
            ErrorFiles.LockingModel = new FileAppender.MinimalLock();
            ErrorFiles.Layout = ErrorPatternLayout;

            var filter = new log4net.Filter.LevelRangeFilter
            {
                LevelMin = Level.Error,
                LevelMax = Level.Fatal
            };
            ErrorFiles.AddFilter(filter);
            ErrorFiles.ActivateOptions();
            hierarchy.Root.AddAppender(ErrorFiles);

            MemoryAppender memory = new MemoryAppender();
            memory.ActivateOptions();
            hierarchy.Root.AddAppender(memory);

            hierarchy.Root.Level = Level.All;
            hierarchy.Configured = true;
        }
        #endregion
    }
}
