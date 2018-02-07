using InfoTycoon.Fwk.TestAutomation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.Threading;

namespace InfoTycoon.ProjectToTest
{
    public class GeneralCategoryInfo : PageBase
    {
        static string propID = ConfigurationManager.AppSettings["AutomationPropertyID"];
        public GeneralCategoryInfo() : base("GENERAL CATEGORY INFO", "https://dev-my.infotycoon.com/#/property/" + propID + "/generalcategories/24772/")
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
            [FindsBy(How = How.PartialLinkText, Using = "Automation Property")]
            private IWebElement breGeneralCategoryInfo;

            [FindsBy(How = How.CssSelector, Using = "h3.content-header")]
            private IWebElement headGeneralCategoryInfo;

            [FindsBy(How = How.CssSelector, Using = "ul#collapseSidemenu a.active")]
            private IWebElement btnSideMenuActive;

            [FindsBy(How = How.CssSelector, Using = "form > div:nth-of-type(2) > p")]
            private IWebElement lblName;

            [FindsBy(How = How.LinkText, Using = "Back")]
            private IWebElement btnBack;

            [FindsBy(How = How.CssSelector, Using = "div[class='alert alert-info'] > button")]
            private IWebElement btnAddGeneralItems;

            //[FindsBy(How = How.XPath, Using = "//td[contains(text(),'New AV')]")]
            //private IWebElement rowCreatedAVExteriorItem;

            //[FindsBy(How = How.TagName, Using = "tbody")]
            //private IWebElement gridGeneralItems;

            //[FindsBy(How = How.CssSelector, Using = "tbody > tr")]
            //private IList<IWebElement> gridGeneralCategoriesRows;

            //[FindsBy(How = How.CssSelector, Using = "td:nth-of-type(1)")]
            //private IWebElement rowSearchResult;

            [FindsBy(How = How.CssSelector, Using = "tbody > tr:first-of-type > td:first-of-type")]
            private IWebElement rowFirstRowFirstCell;

            [FindsBy(How = How.CssSelector, Using = "#items_table > table > thead")]
            private IWebElement tblItems;

            [FindsBy(How = How.ClassName, Using = "toast-title")]
            private IWebElement toastTitle;

            [FindsBy(How = How.ClassName, Using = "toast-message")]
            private IWebElement toastMessage;     
        #endregion

        #endregion

        #region Methods
        public void ClickBack()
        {
            WaitForOverlay();
            WaitForAngular();
            WaitForElement(rowFirstRowFirstCell);
            WaitForElement(btnBack);
            btnBack.Click();
        }

        public void ClickAddGeneralItems()
        {
            WaitForOverlay();
            WaitForElement(btnAddGeneralItems);
            btnAddGeneralItems.Click();
        }

        #endregion

        #region Properties

        #region Header
        public IWebElement PropertiesButton
                {
                    get
                    {
                        WaitForElement(btnProperties);
                        return btnProperties;
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

                public IWebElement InspectionsButton
                {
                    get
                    {
                        WaitForElement(btnInspections);
                        return btnInspections;
                    }
                }

                public IWebElement LFAButton
                {
                    get
                    {
                        WaitForElement(btnLFA);
                        return btnLFA;
                    }
                }

                public IWebElement SetupButton
                {
                    get
                    {
                        WaitForElement(btnSetup);
                        return btnSetup;
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

        public string PageHeader
        {
            get
            {
                WaitForElement(headGeneralCategoryInfo);
                return headGeneralCategoryInfo.Text;
            }
        }

        public string PageBreadCrumb
        {
            get
            {
                WaitForOverlay();
                WaitForElement(breGeneralCategoryInfo);
                return breGeneralCategoryInfo.Text;
            }
        }

        public bool SideMenuActiveButton
        {
            get
            {
                WaitForElement(headGeneralCategoryInfo);
                if (btnSideMenuActive.Text.Trim() == "GENERAL CATEGORIES")
                {
                    return true;
                }
                return false;
            }
        }

        public string CategoryName
        {
            get
            {
                WaitForOverlay();
                WaitForElementNotDisplayed(tblItems);
                WaitForElement(lblName);
                return lblName.Text;
            }
        }

        public IWebElement BackButton
        {
            get
            {
                WaitForElement(btnBack);
                return btnBack;
            }
        }

        public IWebElement AddGeneralItemsButton
        {
            get
            {
                WaitForElement(btnAddGeneralItems);
                return btnAddGeneralItems;
            }
        }

        //public int GridRowsCount
        //{ 
        //    get
        //    {
        //        WaitForOverlay();
        //        WaitForAngular();
        //        return gridGeneralCategoriesRows.Count;
        //    }
        //}

        public string ToastTitle
        {
            get
            {
                WaitForElement(toastTitle);
                return toastTitle.Text;
            }
        }

        public string ToastMsg
        {
            get
            {
                WaitForElement(toastMessage);
                return toastMessage.Text;
            }
        }
        #endregion
    }
}
