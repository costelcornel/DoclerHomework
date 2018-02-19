using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;
using UITestingFramework.Base;
using UITestingFramework.Utilities;

namespace UITestingFramework.PageObjects
{
    public class FormPage : BaseDriver
    {
        public FormPage(RemoteWebDriver driver, string pageName) : base (driver, pageName)
        {
            _webDriver = driver;
            formPage_identifier = string.Format("li[class='active'] > a[id='{0}']", pageName);

            #region Search Criteria
            _webDriver.FindElementByCssSelector(formPage_identifier);
            ////Initialise Elements
            PageFactory.InitElements(_webDriver, this);
            CustomLogs.info("Form page was loaded. Page status = active");
            #endregion
        }

        #region Properties
        [FindsBy(How = How.CssSelector, Using = "#hello-input")]
        protected IWebElement helloInput { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#hello-submit")]
        protected IWebElement submitBtn { get; set; }

        [FindsBy(How = How.CssSelector, Using = "form[id='hello-form']")]
        protected IWebElement helloForm { get; set; }

        #endregion

        #region Public Methods
        /// <summary>
        /// This method check if 'Form' page is displayed and if the text 'Simple Form Submission' is visible
        /// </summary>
        /// <returns>Returns true if is displayed, false if not</returns>
        public bool CheckIfPageIsDisplayed()
        {
            if (_webDriver.FindElementByCssSelector("h1").Text.Equals(_formPage_Identifier))
                return true;
            else
                return false;
        }
        /// <summary>
        /// This method checks if the 'Form' is displayed or not
        /// </summary>
        /// <returns>Returns true if is displayed, false if not</returns>
        public bool CheckIfFormIsDisplayed()
        {
            try { return helloForm.Displayed; }
            catch(NoSuchElementException) { throw new NoSuchElementException("The <form> element was not found on the current page!"); }
        }

        /// <summary>
        /// This method checks if the 'Name' input field is displayed or not
        /// </summary>
        /// <returns>Returns true if is displayed, false if not</returns>
        public bool CheckIfFormInputIsDisplayed()
        {
            try { return helloInput.Displayed; }
            catch (NoSuchElementException) { throw new NoSuchElementException("Hello <input> element was not found on the current page!"); }

        }

        /// <summary>
        /// This method checks if the 'Go' button is displayed or not
        /// </summary>
        /// <returns>Returns true if is displayed, false if not</returns>
        public bool CheckIfSubmitBtnIsDisplayed()
        {
            try { return submitBtn.Displayed; }
            catch (NoSuchElementException) { throw new NoSuchElementException("Submit <button> element was not found on the current page!"); }

        }
        /// <summary>
        /// This method set up the 'Name' input field and clicks on 'Go' button
        /// </summary>
        /// <param name="inputValue">Enter the input value (prefered: name)</param>
        /// <returns>Returns the 'HelloPage' object type created</returns>
        public HelloPage SetUpInputValueAndClickGo(string inputValue)
        {
            helloInput.Clear();
            helloInput.SendKeys(inputValue);
            CustomLogs.info(string.Format("The name '{0}' was typed in the input field", inputValue));
            submitBtn.Click();
            CustomLogs.info("'Go' button was pressed");
            return HelloPage(inputValue);
        }
        #endregion

        #region Private Methods
        private HelloPage HelloPage(string name)
        {
            if (helloPage == null)
                helloPage = new HelloPage(_webDriver, name);
            return helloPage;
        }
       
        #endregion

        #region Private fields
        RemoteWebDriver _webDriver;
        string formPage_identifier;
        HelloPage helloPage;
        #endregion

        #region Private Search Criteria
        private readonly string _formPage_Identifier = "Simple Form Submission";
        #endregion
    }
}
