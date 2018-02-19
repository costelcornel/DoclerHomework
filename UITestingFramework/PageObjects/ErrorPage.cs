using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;
using UITestingFramework.Utilities;

namespace UITestingFramework.PageObjects
{
    public class ErrorPage
    {
        public ErrorPage(RemoteWebDriver driver)
        {
            _webDriver = driver;
            errorPage_identifier = string.Format("//h1[contains(text(),'404 Error')]"); ////title[contains(text(),'404 Error')]   ??pageName???

            #region Search Criteria
            _webDriver.FindElementByXPath(errorPage_identifier);
            ////Initialise Elements
            PageFactory.InitElements(_webDriver, this);
            CustomLogs.info("Error page was loaded.");
            #endregion
        }

        //get title page?

        #region Private fields
        RemoteWebDriver _webDriver;
        string errorPage_identifier;
        #endregion
    }
}
