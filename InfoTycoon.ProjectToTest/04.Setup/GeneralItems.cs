﻿using InfoTycoon.Fwk.TestAutomation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.Threading;

namespace InfoTycoon.ProjectToTest
{
    public class GeneralItems : PageBase
    {
        static string propID = ConfigurationManager.AppSettings["AutomationPropertyID"];
        public GeneralItems() : base("GENERAL ITEMS", "https://dev-my.infotycoon.com/#/property/" + propID + "/generalitems/")
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
            private IWebElement breGeneralItems;

            [FindsBy(How = How.CssSelector, Using = "h3.content-header")]
            private IWebElement headGeneralItems;

            [FindsBy(How = How.CssSelector, Using = "ul#collapseSidemenu a.active")]
            private IWebElement btnSideMenuActive;

            [FindsBy(How = How.CssSelector, Using = ".page.container input[type='text']")]
            private IWebElement txtSearchGeneralItem;

            [FindsBy(How = How.CssSelector, Using = ".page.container .input-group-btn")]
            private IWebElement btnSearchGeneralItem;

            [FindsBy(How = How.TagName, Using = "tbody")]
            private IWebElement gridGeneralItems;

            [FindsBy(How = How.CssSelector, Using = "tbody > tr")]
            private IList<IWebElement> gridGeneralItemsRows;

            [FindsBy(How = How.LinkText, Using = "Create New")]
            private IWebElement btnCreateNew;

            [FindsBy(How = How.LinkText, Using = "Clone")]
            private IWebElement btnClone;

            [FindsBy(How = How.LinkText, Using = "Apply to Categories")]
            private IWebElement btnApplyToCategories;

            [FindsBy(How = How.ClassName, Using = "toast-title")]
            private IWebElement toastTitle;

            [FindsBy(How = How.ClassName, Using = "toast-message")]
            private IWebElement toastMessage;

            [FindsBy(How = How.XPath, Using = "//td[contains(text(),'New AV')]")]
            private IWebElement rowCreatedAVGeneralItem;

            [FindsBy(How = How.CssSelector, Using = "td:nth-of-type(1)")]
            private IWebElement rowSearchResult;

            [FindsBy(How = How.CssSelector, Using = "tr:first-of-type > td:first-of-type")]
            private IWebElement rowFirstRowFirstCell;        
        #endregion

        #endregion

        #region Methods

        public void SearchGeneralItem(string generalItem)
        {
            WaitForOverlay();
            WaitForElement(txtSearchGeneralItem);
            txtSearchGeneralItem.SendKeys(generalItem);
            WaitForOverlay();
            WaitForAngular();
            WaitForOverlay();
            btnSearchGeneralItem.Click();
            WaitForOverlay();
            WaitForAngular();
        }

        public void ClickCreateNew()
        {
            WaitForOverlay();
            WaitForElement(btnCreateNew);
            btnCreateNew.Click();
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
                WaitForElement(headGeneralItems);
                return headGeneralItems.Text;
            }
        }

        public string PageBreadCrumb
        {
            get
            {
                WaitForOverlay();
                WaitForElement(breGeneralItems);
                return breGeneralItems.Text;
            }
        }

        public bool SideMenuActiveButton
        {
            get
            {
                WaitForElement(headGeneralItems);
                if (btnSideMenuActive.Text.Trim() == "GENERAL ITEMS")
                {
                    return true;
                }
                return false;
            }
        }

        public IWebElement CreateNewButton
        {
            get
            {
                WaitForElement(btnCreateNew);
                return btnCreateNew;
            }
        }

        public IWebElement CloneButton
        {
            get
            {
                WaitForElement(btnClone);
                return btnClone;
            }
        }

        public IWebElement ApplyToCategoriesButton
        {
            get
            {
                WaitForElement(btnApplyToCategories);
                return btnApplyToCategories;
            }
        }

        public int GridRowsCount
        { 
            get
            {
                WaitForOverlay();
                WaitForAngular();
                return gridGeneralItemsRows.Count;
            }
        }

        public string SearchResult
        {
            get
            {
                WaitForOverlay();
                WaitForAngular();
                WaitForDocument();
                WaitFor1RowOnly(gridGeneralItemsRows);

                #region Evaluate text is present on first row
                int count = 0;
                string elementText = null;
                while (count < 5)
                {
                    try
                    {
                        elementText = gridGeneralItemsRows[0].Text;
                        break;
                    }
                    catch (StaleElementReferenceException)
                    {
                        count = count + 1;
                    }
                }
                #endregion

                //returns the name of the item
                string returnedText = elementText.Substring(0, elementText.IndexOf(" "));
                return returnedText;
            }
        }

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
