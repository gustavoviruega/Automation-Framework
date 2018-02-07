using InfoTycoon.Fwk.TestAutomation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using System.Threading;
using System;

namespace InfoTycoon.ProjectToTest
{
    public class Properties : PageBase
    {
        public Properties() : base("PROPERTIES", "https://dev-my.infotycoon.com/#/companydashboard/properties/")
        {
        }

        #region Page Elements

            #region Header 
        [FindsBy(How = How.PartialLinkText, Using = "Regions")]
        private IWebElement btnRegions;

        [FindsBy(How = How.PartialLinkText, Using = "Activity")]
        private IWebElement btnActivity;

        [FindsBy(How = How.PartialLinkText, Using = "Properties")]
        private IWebElement btnProperties;

        [FindsBy(How = How.PartialLinkText, Using = "Users")]
        private IWebElement btnUsers;

        [FindsBy(How = How.PartialLinkText, Using = "Company Info")]
        private IWebElement btnCompanyInfo;

        [FindsBy(How = How.PartialLinkText, Using = "Reports")]
        private IWebElement btnReports;
            #endregion

            #region Body
            [FindsBy(How = How.CssSelector, Using = "a[href='#/companydashboard/properties/']")]
            private IWebElement breProperties;

            [FindsBy(How = How.ClassName, Using = "content-header")]
            private IWebElement headProperties;

            [FindsBy(How = How.CssSelector, Using = "input[type='text']")]
            private IWebElement txtSearchProperty;

            [FindsBy(How = How.CssSelector, Using = "button[onclick='toggleFilter()'")]
            private IWebElement btnFilterProperties;

            [FindsBy(How = How.CssSelector, Using = "button[ng-click='search()']")]
            private IWebElement btnSearchProperty;

            [FindsBy(How = How.LinkText, Using = "Create New")]
            private IWebElement btnCreateNew;

            [FindsBy(How = How.CssSelector, Using = "tbody")]
            private IWebElement tblProperties;

            [FindsBy(How = How.XPath, Using = "//td[contains(text(),'Gustavo')]")]
            private IWebElement rowCreatedProperty;

            [FindsBy(How = How.XPath, Using = "//td[contains(text(),'Automation')]")]
            private IWebElement rowTestingProperty;

            [FindsBy(How = How.CssSelector, Using = "tbody > tr")]
            private IList<IWebElement> rowsProperties;

            [FindsBy(How = How.CssSelector, Using = "td:nth-of-type(2)")]
            private IWebElement cellSearchResult;

            [FindsBy(How = How.CssSelector, Using = "#_pendo-close-guide_")]
            private IWebElement btnClosePendo;

            [FindsBy(How = How.CssSelector, Using = "button.dismiss-button._pendo-guide-next_")]
            private IWebElement btnGotIt;
        #endregion

        #endregion

        #region Methods
        public void SearchProperty(string propname)
        {
            WaitForOverlay();
            WaitForElement(btnRegions);
            WaitForElement(txtSearchProperty);
            txtSearchProperty.SendKeys(propname);
            WaitForOverlay();
            WaitForAngular();
            //btnSearchProperty.Click();
            WaitFor1RowOnly(rowsProperties);
            WaitForOverlay();
        }

        public void ClickCreateNewButton()
        {
            WaitForElement(btnRegions);
            WaitForOverlay();
            WaitForAngular();
            WaitForElement(btnCreateNew);
            btnCreateNew.Click();
        }

        public void SelectProperty(string propname)
        {
            ScrollToFooter();
            WaitForElement(btnRegions);
            Thread.Sleep(1000);
            WaitForOverlay();
            WaitForAngular();
            if (propname.Contains("Automation"))
            {
                WaitForElement(rowTestingProperty);
                WaitForOverlay();
                btnFilterProperties.Click();
                rowTestingProperty.Click();
            }
            else
            {
                WaitForElement(rowCreatedProperty);
                WaitForOverlay();
                btnFilterProperties.Click();
                rowCreatedProperty.Click();
            }
        }

        #endregion

        #region Properties

        #region Header
        public IWebElement RegionsButton
            {
                get
                {
                    WaitForElement(btnRegions);
                    return btnRegions;
                }
            }

        public IWebElement ActivityButton
            {
                get
                {
                    WaitForElement(btnActivity);
                    return btnActivity;
                }
            }

        public IWebElement PropertiesButton
            {
                get
                {
                    WaitForElement(btnProperties);
                    return btnProperties;
                }
            }

        public IWebElement UsersButton
            {
                get
                {
                    WaitForElement(btnUsers);
                    return btnUsers;
                }
            }

        public IWebElement CompanyInfoButton
            {
                get
                {
                    WaitForElement(btnCompanyInfo);
                    return btnCompanyInfo;
                }
            }

        public IWebElement ReportsButton
            {
                get
                {
                    WaitForElement(btnReports);
                    return btnReports;
                }
            } 
            #endregion

        public string PageBreadCrumb
        {
            get
            {
                WaitForElement(breProperties);
                return breProperties.Text;
            }
        }

        public string PageHeader
        {
            get
            {
                WaitForElement(btnRegions);
                WaitForElement(headProperties);
                return headProperties.Text;
            }
        }

        public IWebElement CreateButton
        {
            get
            {
                WaitForElement(btnRegions);
                WaitForElement(btnCreateNew);
                return btnCreateNew;
            }
        }

        public string CreateNewButtonName
        {
            get
            {
                WaitForElement(btnRegions);
                WaitForElement(btnCreateNew);
                return btnCreateNew.Text;
            }
        }

        public IWebElement SearchPropertyField
        {
            get
            {
                WaitForElement(btnRegions);
                WaitForElement(txtSearchProperty);
                return txtSearchProperty;
            }
        }

        public string SearchResult
        {
            get
            {
                WaitForElement(cellSearchResult);
                return cellSearchResult.Text;
            }
        }
        #endregion
    }
}
