using InfoTycoon.Fwk.TestAutomation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Configuration;
using System;


namespace InfoTycoon.ProjectToTest
{
    public class PropertyActivity : PageBase
    {
        static string propID = ConfigurationManager.AppSettings["AutomationPropertyID"];
        public PropertyActivity() : base("ACTIVITY", "https://dev-my.infotycoon.com/#/property/" + propID + "/activity/")
        {
        }

        #region Page Elements

            #region Header
            [FindsBy(How = How.PartialLinkText, Using = "Properties")]
            private IWebElement btnProperties;

            [FindsBy(How = How.PartialLinkText, Using = "Activity")]
            private IWebElement btnActivity;

            [FindsBy(How = How.PartialLinkText, Using = "Inspections")]
            private IWebElement btnInspections;

            [FindsBy(How = How.PartialLinkText, Using = "Lease File Audits")]
            private IWebElement btnLFA;

            [FindsBy(How = How.PartialLinkText, Using = "Setup")]
            private IWebElement btnSetup;

            [FindsBy(How = How.PartialLinkText, Using = "Reports")]
            private IWebElement btnReports;
            #endregion

            #region Body
            [FindsBy(How = How.CssSelector, Using = "#page-top li")]
            private IWebElement breActivity;

            [FindsBy(How = How.Id, Using = "notificationButton")]
            private IWebElement btnNotification;

            [FindsBy(How = How.Id, Using = "c")]
            private IWebElement headActivity; 
            #endregion

        #endregion

        #region Methods
        public void ClickSetupButton()
        {
            WaitForOverlay();
            WaitForElement(btnNotification);
            WaitForElement(btnSetup);
            btnSetup.Click();
        }
        #endregion

        #region Properties

            #region Header
            public IWebElement PropertiesButton
            {
                get
                {
                    WaitForElement(btnNotification);
                    WaitForElement(btnProperties);
                    return btnProperties;
                }
            }

            public IWebElement ActivityButton
            {
                get
                {
                    WaitForElement(btnNotification);
                    WaitForElement(btnActivity);
                    return btnActivity;
                }
            }

            public IWebElement InspectionsButton
            {
                get
                {
                    WaitForElement(btnNotification);
                    WaitForElement(btnInspections);
                    return btnInspections;
                }
            }

            public IWebElement LFAButton
            {
                get
                {
                    WaitForElement(btnNotification);
                    WaitForElement(btnLFA);
                    return btnLFA;
                }
            }

            public IWebElement SetupButton
            {
                get
                {
                    WaitForElement(btnNotification);
                    WaitForElement(btnSetup);
                    return btnSetup;
                }
            }

            public IWebElement ReportsButton
            {
                get
                {
                    WaitForElement(btnNotification);
                    WaitForElement(btnReports);
                    return btnReports;
                }
            }
            #endregion

        public string PageBreadCrumb
        {
            get
            {
                WaitForElement(btnNotification);
                WaitForElement(breActivity);
                return breActivity.Text;
            }
        }

        public string PageHeader
        {
            get
            {
                WaitForElement(btnNotification);
                WaitForElement(headActivity);
                return headActivity.Text;
            }
        }

        public IWebElement NotificationButton
        {
            get
            {
                WaitForElement(btnNotification);
                return btnNotification;
            }
        }

        #endregion
    }
}
