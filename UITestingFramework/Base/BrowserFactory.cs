using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;

namespace UITestingFramework.Base
{
    public class BrowserFactory
    {
        private static RemoteWebDriver driver = null;

        public static RemoteWebDriver getChromeBrowser()
        {
            try
            {
                driver = ChromeBrowser.SetUp;
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
            return driver;
        }

        protected static void KillProcess(string processName)
        {
            foreach (Process proc in Process.GetProcessesByName(processName))
            {
                proc.Kill();
            }
        }
        protected static void cleanUpAllDrivers()
        {
            try
            {
                if (driver != null)
                    driver.Manage().Cookies.DeleteAllCookies();
            }
            catch (Exception exc)
            {
                throw new Exception("Exception caught: " + exc.Message);
            }
        }
        private static void KillChromeDriverProcess()
        {
            try
            {
                KillProcess("chromedriver");
            }
            catch (Win32Exception e)
            {
                throw new Win32Exception("The process is terminating or could not be terminated");
            }

            catch (InvalidOperationException)
            {
                throw new InvalidOperationException("The process has already exited.");
            }

            catch (Exception e)  // some other exception
            {
                throw new Exception("{0} Exception caught while trying to kill the chrome driver process. Message: ", e);
            }
        }

        protected static void closeAllDrivers()
        {
            try
            {
                if (driver != null)
                {
                    List<string> tabs = new List<string>(driver.WindowHandles);
                    for (int i = 0; i < tabs.Count; i++)
                    {
                        driver.SwitchTo().Window(tabs[i]);
                        driver.Close();
                    }
                }
            }
            catch (Exception exc)
            {
                throw new Exception("Exception caught trying to close the driver: " + exc.Message);
            }
        }

        public static void CleanCloseAndKillDriver()
        {
            cleanUpAllDrivers();
            closeAllDrivers();
            KillChromeDriverProcess();
        }
    }
}
