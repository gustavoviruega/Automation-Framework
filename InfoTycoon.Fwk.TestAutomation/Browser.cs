using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Diagnostics;
using System.Linq;
using InfoTycoon.Fwk.TestAutomation.Helpers;
using System.Drawing.Imaging;
using System.Configuration;
using System.IO;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace InfoTycoon.Fwk.TestAutomation
{
    public static class Browser
    {
        #region Driver Settings
        private const string INTERNET_EXPLORER_DRIVER = "internetexplorerdriver";
        private const string CHROME_DRIVER = "chromedriver";
        private const string INTERNET_EXPLORER_DRIVER_SERVER = "iedriverserver";

        private static IWebDriver webDriver { get; set; }

        public static void Initializes(bool maximized = true)
        {
            webDriver = DriverHelper.FactoryDriver();

            if (maximized)
            {
                webDriver.Manage().Window.Maximize();
            }
        }

        public static IWebDriver Driver
        {
            get
            {
                return webDriver;
            }
        }
        #endregion

        #region Browser Actions
        //The browser redirects to an url.
        public static void GoTo(string url)
        {
            webDriver.Url = url;
        }

        //The browser redirects to an url.
        public static void GoToUrl(string url)
        {
            webDriver.Navigate().GoToUrl(url);
        }

        //The browser redirects to a page's url.
        public static void GoToPage(PageBase page)
        {
            webDriver.Navigate().GoToUrl(page.PageUrl);
        }

        public static void PrintScreen(string fileName, ImageFormat imageFormat, string path = null)
        {
            if (String.IsNullOrEmpty(path))
                path = ConfigurationManager.AppSettings["DefaultImagePath"];
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            var file = path + fileName + "." + imageFormat.ToString();
            Screenshot ss = ((ITakesScreenshot)webDriver).GetScreenshot();
            ss.SaveAsFile(file, imageFormat);
        }

        public static void Quit()
        {
            webDriver.Quit();
            KillDriverProcesses();
        }

        private static void KillDriverProcesses()
        {
            var driverName = webDriver.GetType().Name.ToLower();
            string processName = String.Empty;
            switch (driverName)
            {
                case INTERNET_EXPLORER_DRIVER:
                    processName = INTERNET_EXPLORER_DRIVER_SERVER;
                    break;
                case CHROME_DRIVER:
                    processName = CHROME_DRIVER;
                    break;
            }
            if (!String.IsNullOrEmpty(processName))
            {
                var processes = Process.GetProcesses().Where(p => p.ProcessName.ToLower() == processName);
                foreach (var process in processes)
                {
                    process.Kill();
                }
            }
        }
        #endregion

        #region Waits
        public static void ImplicitlyWait(int seconds)
        {
            webDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(seconds));
        }

        public static void ExplicitWait(int seconds, IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds));
            wait.Until((webDriver => element.Displayed && element.Enabled));
        }

        public static void ExplicitWait1RowOnly(int seconds, IList<IWebElement> elements)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds));
            wait.Until((webDriver => elements.Count == 1));
        }

        public static void ExplicitWaitDisplayed(int seconds, IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds));
            wait.Until((webDriver => element.Displayed));
        }

        public static void OverlayWait(int seconds)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds));
            //Originally made with "ExpectedConditions.ElementExists"
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.CssSelector("#overlay[style='display: none;']")));
        }

        public static void AngularWait(int seconds)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds));

            string hasAngularFinishedScript =
                @"var callback = arguments[arguments.length - 1];
                if (document.readyState == 'complete') {
                    var el = document.querySelector('html');
                    if (!window.angular) {
                        callback('False')
                    }
                    if (angular.getTestability) {
                        angular.getTestability(el).whenStable(function() { callback('True'); });
                    } else {
                        if (!angular.element(el).injector()) {
                            callback('False')
                        }
                        var browser = angular.element(el).injector().get('$browser');
                        browser.notifyWhenNoOutstandingRequests(function() { callback('True'); });
                    } 
                } else {
                    callback('False');
                }";

            Driver.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(10));
            wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteAsyncScript(hasAngularFinishedScript).Equals("True"));
        }

        public static void DocumentWait(int seconds)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds));
            Driver.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(10));
            wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
        }

        #endregion
    }
}
