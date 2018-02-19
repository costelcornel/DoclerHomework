using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using UITestingFramework.Base;
using UITestingFramework.Utilities;

namespace UITestingFramework.PageObjects
{
    public class HelloPage : BaseDriver
    {
        public HelloPage(RemoteWebDriver driver, string nameTyped) : base(driver, nameTyped)
        {
            _webDriver = driver;
            helloPage_identifier = string.Format("//h1[@id='hello-text' and text()='Hello {0}!']", nameTyped);

            #region Search Criteria
            try
            {
                WaitUntilIsVisible(1500, By.XPath(helloPage_identifier));
                _webDriver.FindElementByXPath(helloPage_identifier);
                CustomLogs.info("Hello Page was loaded.");
            }
            catch (NoSuchElementException) { throw new NoSuchElementException(string.Format("Hello Page does not contains the expected text message! Expected text: 'Hello {0}!' - Actual text: '{1}'", nameTyped, ReturnHelloText)); }
            #endregion
        }


        public FormPage ReturnToFormPage()
        {
            _webDriver.Navigate().GoToUrl("http://uitest.duodecadits.com/form.html");
            return FormPage;
        }

        #region Private Methods
        /// <summary>
        /// This method returns the hello_text 
        /// </summary>
        private string ReturnHelloText
        {
            get
            {
                try { return _webDriver.FindElementByCssSelector("h1").Text; }
                catch(NoSuchElementException) { throw new NoSuchElementException("Element <h1> was not found on Hello Page!"); }      
            }
        }
        private FormPage FormPage
        {
            get
            {
                if (formPage == null)
                    formPage = new FormPage(_webDriver, "form");
                return formPage;
            }
        }

        #endregion

        #region Private fields
        RemoteWebDriver _webDriver;
        FormPage formPage;
        string helloPage_identifier;
        #endregion
    }
}
