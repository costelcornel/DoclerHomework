using OpenQA.Selenium.Chrome;

namespace UITestingFramework.Base
{
    public class ChromeBrowser
    {
        public static ChromeDriver SetUp
        {
            get
            {
                return new ChromeDriver(Options);
            }
        }

        private static ChromeOptions Options
        {
            get
            {
                var chromeOptions = new ChromeOptions();
                chromeOptions.AddArgument("test-type");
                chromeOptions.AddArguments("start-maximized");
                chromeOptions.AddUserProfilePreference("intl.accept_languages", "nl");
                chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");
                chromeOptions.AddUserProfilePreference("download.prompt_for_download", "false");
                chromeOptions.AddUserProfilePreference("download.directory_upgrade", "true");

                return chromeOptions;
            }
        }     
    }
}
