using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;
using UITestingFramework.Base;
using UITestingFramework.Utilities;

namespace UITestingFramework.PageObjects
{
    public class HomePage : BaseDriver
    {
        public HomePage(RemoteWebDriver driver, string pageName) : base(driver, pageName)
        {
            _webDriver = driver;
            homePage_identifier = string.Format("li[class='active'] > a[id='{0}']", pageName);

            #region Search Criteria
            _webDriver.FindElementByCssSelector(homePage_identifier);

            ////Initialise Elements
            PageFactory.InitElements(_webDriver, this);
            CustomLogs.info("Home page was loaded. Page status = active");
            #endregion
        }

        #region Properties
        [FindsBy(How = How.XPath, Using = "//h1")]
        protected IWebElement welcomeMsg { get; set; }

        [FindsBy(How = How.CssSelector, Using = "p")]
        protected IWebElement paragraphMsg { get; set; }
        #endregion

        #region Public Methods
        /// <summary>
        /// This method validates the welcome message from the Home Page!
        /// </summary>
        /// <returns>Returns true in case that the welcome page meet the requirements</returns>
        public bool checkWelcomeMessage()
        {
            try
            {
                if (welcomeMsg.Text.Equals(_welcomeMsg))
                {
                    CustomLogs.info("Welcome message from the Home Page is displayed");
                    return welcomeMsg.Displayed;
                }
                else
                    throw new NoSuchElementException(string.Format("The <h1> element does not contains the expected text message! Actual Message: '{0}'", welcomeMsg.Text));
            }
            catch(NoSuchElementException)
            {
                throw new NoSuchElementException("The <h1> element does not exists on Home Page!");
            }
        }

        /// <summary>
        /// This method validates the message from the Home Page paragraph!
        /// </summary>
        /// <returns>Returns true in case that the welcome page meet the requirements</returns>
        public bool checkHomeParagraphMessage()
        {
            try
            {
                if (paragraphMsg.Text.Equals(_paragraphMsg))
                {
                    CustomLogs.info("The paragraph message from the Home Page is displayed");
                    return paragraphMsg.Displayed;
                }
                else
                    throw new NoSuchElementException(string.Format("The <p> (paragraph) element does not contains the expected text message! Actual Message: '{0}'", paragraphMsg.Text));
            }
            catch (NoSuchElementException)
            {
                throw new NoSuchElementException("The <p> (paragraph) element does not exists on Home Page!");
            }
        }
        #endregion

        #region Private fields
        RemoteWebDriver _webDriver;
        string homePage_identifier;
        #endregion

        #region Private Search Criteria
        private readonly string _welcomeMsg = "Welcome to the Docler Holding QA Department";
        private readonly string _paragraphMsg = "This site is dedicated to perform some exercises and demonstrate automated web testing.";
        #endregion
    }
}
