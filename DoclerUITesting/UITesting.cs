using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UITestingFramework.Base;
using UITestingFramework.PageObjects;
using UITestingFramework.Utilities;

namespace DoclerUITesting
{ 
    [TestClass]
    public class UITesting
    {
        #region Private Fields
        private string uitestDoclerSite = "http://uitest.duodecadits.com";
        ChromeDriver chrome;
        HomePage _homepage;
        List<string> nameList = new List<string>() { "John", "Sophia", "Charlie", "Emily" };
        #endregion

        [TestInitialize]
        public void Init()
        {
            CustomLogs.SetupLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName);
            chrome = (ChromeDriver)BrowserFactory.getChromeBrowser();
            chrome.Navigate().GoToUrl(uitestDoclerSite);
        }

        [TestMethod, TestProperty("UITesting", "REQ-UI-01")]
        public void CheckTitleOfallPages()
        {
            CustomLogs.startTestCase(System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {
                HomePage homePage = new HomePage(chrome, "home");
                Assert.IsTrue(homePage.checkPageName());

                homePage.ClickOnUITestingBtn();
                Assert.IsTrue(homePage.checkPageName());

                FormPage formPage = homePage.ClickOnFormBtn();
                Assert.IsTrue(formPage.checkPageName());

                homePage = formPage.ClickOnHomeBtn();
                Assert.IsTrue(homePage.checkPageName());
            }
            catch (AssertFailedException afe)
            {
                CustomLogs.warn(afe.Message);
                throw new AssertFailedException(afe.Message);
            }
            catch (NoSuchElementException nsee)
            {
                CustomLogs.error(nsee.Message);
                throw new NoSuchElementException(nsee.Message);
            }
            catch (Exception exc)
            {
                CustomLogs.error(exc.Message + exc.StackTrace);
                throw new Exception(exc.Message);
            }
            finally
            {
                CustomLogs.endTestCase(System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        [TestMethod, TestProperty("UITesting", "REQ-UI-02")]
        public void CheckCompanyLogo()
        {
            CustomLogs.startTestCase(System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {
                HomePage homePage = HomePage;
                Assert.IsTrue(homePage.checkIfCompanyLogoIsDisplayed());

                homePage.ClickOnUITestingBtn();
                Assert.IsTrue(homePage.checkIfCompanyLogoIsDisplayed());

                homePage.ClickOnFormBtn();
                Assert.IsTrue(homePage.checkIfCompanyLogoIsDisplayed());

                homePage.ClickOnHomeBtn();
                Assert.IsTrue(homePage.checkPageName());
            }
            catch (AssertFailedException afe)
            {
                CustomLogs.warn(afe.Message);
                throw new AssertFailedException(afe.Message);
            }
            catch (NoSuchElementException nsee)
            {
                CustomLogs.error(nsee.Message);
                throw new NoSuchElementException(nsee.Message);
            }
            catch (Exception exc)
            {
                CustomLogs.error(exc.Message + exc.StackTrace);
                throw new Exception(exc.Message);
            }
            finally
            {
                CustomLogs.endTestCase(System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        [TestMethod, TestProperty("UITesting", "REQ-UI-03 & REQ-UI- 09")]
        public void ValidateHomePage()
        {
            CustomLogs.startTestCase(System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {
                HomePage homePage = new HomePage(chrome, "home");
                Assert.IsTrue(homePage.checkWelcomeMessage());
            }
            catch (AssertFailedException afe)
            {
                CustomLogs.warn(afe.Message);
                throw new AssertFailedException(afe.Message);
            }
            catch (NoSuchElementException nsee)
            {
                CustomLogs.error(nsee.Message);
                throw new NoSuchElementException(nsee.Message);
            }
            catch (Exception exc)
            {
                CustomLogs.error(exc.Message + exc.StackTrace);
                throw new Exception(exc.Message);
            }
            finally
            {
                CustomLogs.endTestCase(System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        [TestMethod, TestProperty("UITesting", "REQ-UI-04")]
        public void CheckHomePageStatus()
        {
            CustomLogs.startTestCase(System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {
                HomePage homePage = HomePage;
                homePage.ClickOnHomeBtn();
            }
            catch (AssertFailedException afe)
            {
                CustomLogs.warn(afe.Message);
                throw new AssertFailedException(afe.Message);
            }
            catch (NoSuchElementException nsee)
            {
                CustomLogs.error(nsee.Message);
                throw new NoSuchElementException(nsee.Message);
            }
            catch (Exception exc)
            {
                CustomLogs.error(exc.Message + exc.StackTrace);
                throw new Exception(exc.Message);
            }
            finally
            {
                CustomLogs.endTestCase(System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        [TestMethod, TestProperty("UITesting", "REQ-UI-05")]
        public void ValidateFormPage()
        {
            CustomLogs.startTestCase(System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {
                HomePage homePage = HomePage;
                FormPage formPage = homePage.ClickOnFormBtn();
                Assert.IsTrue(formPage.CheckIfPageIsDisplayed());
            }
            catch (AssertFailedException afe)
            {
                CustomLogs.warn(afe.Message);
                throw new AssertFailedException(afe.Message);
            }
            catch (NoSuchElementException nsee)
            {
                CustomLogs.error(nsee.Message);
                throw new NoSuchElementException(nsee.Message);
            }
            catch (Exception exc)
            {
                CustomLogs.error(exc.Message + exc.StackTrace);
                throw new Exception(exc.Message);
            }
            finally
            {
                CustomLogs.endTestCase(System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        [TestMethod, TestProperty("UITesting", "REQ-UI-06")]
        public void CheckStatusOfFormPage()
        {
            CustomLogs.startTestCase(System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {
                HomePage homePage = HomePage;
                homePage.ClickOnFormBtn();
            }
            catch (AssertFailedException afe)
            {
                CustomLogs.warn(afe.Message);
                throw new AssertFailedException(afe.Message);
            }
            catch (NoSuchElementException nsee)
            {
                CustomLogs.error(nsee.Message);
                throw new NoSuchElementException(nsee.Message);
            }
            catch (Exception exc)
            {
                CustomLogs.error(exc.Message + exc.StackTrace);
                throw new Exception(exc.Message);
            }
            finally
            {
                CustomLogs.endTestCase(System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        [TestMethod, TestProperty("UITesting", "REQ-UI-07")]
        public void CheckErrorResponseCode()
        {
            CustomLogs.startTestCase(System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {
                HomePage homePage = HomePage;
                ErrorPage errorPage = homePage.ClickOnErrorBtn();      
            }
            catch (AssertFailedException afe)
            {
                CustomLogs.warn(afe.Message);
                throw new AssertFailedException(afe.Message);
            }
            catch (NoSuchElementException nsee)
            {
                CustomLogs.error(nsee.Message);
                throw new NoSuchElementException(nsee.Message);
            }
            catch (Exception exc)
            {
                CustomLogs.error(exc.Message + exc.StackTrace);
                throw new Exception(exc.Message);
            }
            finally
            {
                CustomLogs.endTestCase(System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        [TestMethod, TestProperty("UITesting", "REQ-UI-08")]
        public void CheckUITestingMenuButton()
        {
            CustomLogs.startTestCase(System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {
                HomePage homePage = HomePage;
                homePage.ClickOnUITestingBtn();
            }
            catch (AssertFailedException afe)
            {
                CustomLogs.warn(afe.Message);
                throw new AssertFailedException(afe.Message);
            }
            catch (NoSuchElementException nsee)
            {
                CustomLogs.error(nsee.Message);
                throw new NoSuchElementException(nsee.Message);
            }
            catch (Exception exc)
            {
                CustomLogs.error(exc.Message + exc.StackTrace);
                throw new Exception(exc.Message);
            }
            finally
            {
                CustomLogs.endTestCase(System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        [TestMethod, TestProperty("UITesting", "REQ-UI-10")]
        public void CheckParagraphMessageFromHomePage()
        {

            CustomLogs.startTestCase(System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {
                HomePage homePage = HomePage;
                homePage.ClickOnHomeBtn();
                Assert.IsTrue(homePage.checkHomeParagraphMessage());
            }
            catch (AssertFailedException afe)
            {
                CustomLogs.warn(afe.Message);
                throw new AssertFailedException(afe.Message);
            }
            catch (NoSuchElementException nsee)
            {
                CustomLogs.error(nsee.Message);
                throw new NoSuchElementException(nsee.Message);
            }
            catch (Exception exc)
            {
                CustomLogs.error(exc.Message + exc.StackTrace);
                throw new Exception(exc.Message);
            }
            finally
            {
                CustomLogs.endTestCase(System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        [TestMethod, TestProperty("UITesting", "REQ-UI-11")]
        public void CheckFormInputAndSubmitElements()
        {
            CustomLogs.startTestCase(System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {
                HomePage homePage = HomePage;
                FormPage formPage = homePage.ClickOnFormBtn();
                Assert.IsTrue(formPage.CheckIfFormInputIsDisplayed());
                Assert.IsTrue(formPage.CheckIfSubmitBtnIsDisplayed());
            }
            catch (AssertFailedException afe)
            {
                CustomLogs.warn(afe.Message);
                throw new AssertFailedException(afe.Message);
            }
            catch (NoSuchElementException nsee)
            {
                CustomLogs.error(nsee.Message);
                throw new NoSuchElementException(nsee.Message);
            }
            catch (Exception exc)
            {
                CustomLogs.error(exc.Message + exc.StackTrace);
                throw new Exception(exc.Message);
            }
            finally
            {
                CustomLogs.endTestCase(System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        [TestMethod, TestProperty("UITesting", "REQ-UI-12 & REQ-UI- 01")]
        public void CheckHelloPage()
        {
            CustomLogs.startTestCase(System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {
                HomePage homePage = HomePage;
                FormPage formPage = homePage.ClickOnFormBtn();

                foreach (string name in nameList)
                {
                    HelloPage hello = formPage.SetUpInputValueAndClickGo(name);
                    hello.checkIfCompanyLogoIsDisplayed();
                    hello.ReturnToFormPage();     
                }
            }
            catch (AssertFailedException afe)
            {
                CustomLogs.warn(afe.Message);
                throw new AssertFailedException(afe.Message);
            }
            catch (NoSuchElementException nsee)
            {
                CustomLogs.error(nsee.Message);
                throw new NoSuchElementException(nsee.Message);
            }
            catch (Exception exc)
            {
                CustomLogs.error(exc.Message + exc.StackTrace);
                throw new Exception(exc.Message);
            }
            finally
            {
                CustomLogs.endTestCase(System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        [TestCleanup]
        public void CleanUp()
        {
            BrowserFactory.CleanCloseAndKillDriver();
        }

        #region Private Methods
        private HomePage HomePage
        {
            get
            {
                if (_homepage == null)
                    _homepage = new HomePage(chrome, "home");
                return _homepage;
            }
        }
        #endregion
    }
}
