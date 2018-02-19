using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using UITestingFramework.PageObjects;

namespace UITestingFramework.Base
{
    public class BaseDriver : RemoteWebElement
    {
        public BaseDriver(RemoteWebDriver driver, string elementId) : base (driver, elementId)
        {
            Instance = driver;
            pageId = elementId;

            ////Initialise Elements
            PageFactory.InitElements(Instance, this);
        }

        #region Properties
        [FindsBy(How = How.XPath, Using = "//a[@id='site']")]
        protected IWebElement uiTesting_btn { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[id='home']")]
        protected IWebElement home_btn { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[id='error']")]
        protected IWebElement error_btn { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[id='form']")]
        protected IWebElement form_btn { get; set; }
        #endregion

        #region Public Methods
        /// <summary>
        /// Force the driver to wait for an element to be visible.
        /// </summary>
        /// <param name="miliseconds">Timeout to wait until the element is visible</param>
        /// <param name="by">Provide a mechanism to find elements within a document.</param>
        /// <returns></returns>
        protected IWebElement WaitUntilIsVisible(long miliseconds, By by)
        {
            WebDriverWait wait = new WebDriverWait(Instance, TimeSpan.FromMilliseconds(miliseconds));
            return wait.Until(ExpectedConditions.ElementIsVisible(by));
        }
        /// <summary>
        /// Force the driver to wait for an element to be clickable
        /// </summary>
        /// <param name="miliseconds">Timeout to wait until the element is clickable</param>
        /// <param name="by">Provide a mechanism to find elements within a document</param>
        /// <returns></returns>
        protected IWebElement WaitElementToBeClickable(long miliseconds, By by)
        {
            WebDriverWait wait = new WebDriverWait(Instance, TimeSpan.FromMilliseconds(miliseconds));
            return wait.Until(ExpectedConditions.ElementToBeClickable(by));
        }

        /// <summary>
        /// This method validates the title of the web page
        /// </summary>
        /// <returns>Returns true in case that the title is ok.</returns>
        public bool checkPageName()
        {
            try
            {
                return checkIfElementExists(By.XPath("//title[text()='UI Testing Site']"));
            }
            catch(NoSuchElementException)
            {
                throw new NoSuchElementException("The <Title Page> value does not meet the requirements!");
            }
        }
        /// <summary>
        /// This method checks if the company logo is diplayed on active web page
        /// </summary>
        /// <returns>Return true if is displayed, false if is not.</returns>
        public bool checkIfCompanyLogoIsDisplayed()
        {
            try
            {
                return Instance.FindElementByCssSelector("#dh_logo").Displayed;
            }
            catch (NoSuchElementException)
            {
                throw new NoSuchElementException("The <Company Logo> does not exists on the current WebPage!");
            }
        }

        #region Nav buttons
        /// <summary>
        /// This method clicks on 'Form' navigation button
        /// </summary>
        /// <returns>Returns the 'FormPage' object type created</returns>
        public FormPage ClickOnFormBtn()
        {
            WaitElementToBeClickable(1100, By.CssSelector("a[id='form']"));
            form_btn.Click();
            return FormPage;
        }
        /// <summary>
        /// This method clicks on 'Error' navigation button
        /// </summary>
        /// <returns>Returns the 'ErrorPage' object type created</returns>
        public ErrorPage ClickOnErrorBtn()
        {
            WaitElementToBeClickable(1100, By.CssSelector("a[id='error']"));  
            error_btn.Click();
            return ErrorPage;
        }
        /// <summary>
        /// This method clicks on 'Home' navigation button
        /// </summary>
        /// <returns>Returns the 'HomePage' object type created</returns>
        public HomePage ClickOnHomeBtn()
        {
            WaitElementToBeClickable(1100, By.CssSelector("a[id='home']"));
            home_btn.Click();
            return HomePage;
        }
        /// <summary>
        /// This method clicks on 'UI Testing' navigation button
        /// </summary>
        /// <returns>Returns the 'HomePage' object type created</returns>
        public HomePage ClickOnUITestingBtn()
        {
            WaitElementToBeClickable(1100, By.CssSelector("//a[@id='site']"));
            uiTesting_btn.Click();
            return HomePage;
        }
        #endregion

        #endregion

        #region Public Properties
        /// <summary>
        /// This method is searching for the desired element on the page
        /// </summary>
        /// <param name="by">Enter the mechanism by which to find element in current DOM</param>
        /// <returns>Returns true if the web element is found.</returns>
        public bool checkIfElementExists(By by)
        {
            try
            {
                Instance.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        #endregion

        #region Private Methods
        private FormPage FormPage
        {
            get
            {
                if (formPage == null)
                    formPage = new FormPage(Instance, "form");
                return formPage;
            }
        }

        private ErrorPage ErrorPage
        {
            get
            {
                if (errorPage == null)
                    errorPage = new ErrorPage(Instance);
                return errorPage;
            }
        }

        private HomePage HomePage
        {
            get { return new HomePage(Instance, "home"); }
        }
        #endregion

        #region Private Fields
        string pageId;
        RemoteWebDriver Instance;
        ErrorPage errorPage;
        FormPage formPage;
        #endregion
    }
}
