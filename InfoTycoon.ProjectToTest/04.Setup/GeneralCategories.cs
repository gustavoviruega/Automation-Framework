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
    public class GeneralCategories : PageBase
    {
        static string propID = ConfigurationManager.AppSettings["AutomationPropertyID"];
        public GeneralCategories() : base("GENERAL CATEGORIES", "https://dev-my.infotycoon.com/#/property/" + propID + "/generalcategories/")
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
            private IWebElement breGeneralCategories;

            [FindsBy(How = How.CssSelector, Using = "h3.content-header")]
            private IWebElement headGeneralCategories;

            [FindsBy(How = How.CssSelector, Using = "ul#collapseSidemenu a.active")]
            private IWebElement btnSideMenuActive;

            [FindsBy(How = How.CssSelector, Using = ".page.container input[type='text']")]
            private IWebElement txtSearchGeneralCategory;

            [FindsBy(How = How.CssSelector, Using = ".page.container .input-group-btn")]
            private IWebElement btnSearchGeneralCategory;

            [FindsBy(How = How.TagName, Using = "tbody")]
            private IWebElement gridGeneralCategories;

            [FindsBy(How = How.CssSelector, Using = "tbody > tr")]
            private IList<IWebElement> gridGeneralCategoriesRows;

            [FindsBy(How = How.LinkText, Using = "Create New")]
            private IWebElement btnCreateNew;

            [FindsBy(How = How.LinkText, Using = "Clone")]
            private IWebElement btnClone;

            [FindsBy(How = How.ClassName, Using = "toast-title")]
            private IWebElement toastTitle;

            [FindsBy(How = How.ClassName, Using = "toast-message")]
            private IWebElement toastMessage;

            [FindsBy(How = How.XPath, Using = "//td[contains(text(),'Gustavo')]")]
            private IWebElement rowCreatedGeneralCategory;

            [FindsBy(How = How.XPath, Using = "//td[contains(text(),'Automation')]")]
            private IWebElement rowTestingGeneralCategory;

            [FindsBy(How = How.CssSelector, Using = "td:nth-of-type(1)")]
            private IWebElement rowSearchResult;

            [FindsBy(How = How.CssSelector, Using = "tr:first-of-type > td:first-of-type")]
            private IWebElement rowFirstRowFirstCell;        
        #endregion

        #endregion

        #region Methods

        public void SearchGeneralCategory(string generalCategory)
        {
            WaitForOverlay();
            WaitForElement(txtSearchGeneralCategory);
            txtSearchGeneralCategory.SendKeys(generalCategory);
            WaitForOverlay();
            WaitForAngular();
            WaitForOverlay();
            btnSearchGeneralCategory.Click();
            WaitForOverlay();
            WaitForAngular();
        }

        public void SelectGeneralCategory(string generalCategory)
        {
            WaitForElement(btnProperties);
            WaitForOverlay();
            WaitForAngular();
            if (generalCategory.Contains("Automation"))
            {
                WaitForElement(rowTestingGeneralCategory);
                WaitForOverlay();
                rowTestingGeneralCategory.Click();
            }
            else
            {
                WaitForElement(rowCreatedGeneralCategory);
                WaitForOverlay();
                rowCreatedGeneralCategory.Click();
            }
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
                WaitForElement(btnCreateNew);
                WaitForElement(headGeneralCategories);
                return headGeneralCategories.Text;
            }
        }

        public string PageBreadCrumb
        {
            get
            {
                WaitForOverlay();
                WaitForElement(breGeneralCategories);
                return breGeneralCategories.Text;
            }
        }

        public bool SideMenuActiveButton
        {
            get
            {
                WaitForElement(headGeneralCategories);
                if (btnSideMenuActive.Text.Trim() == "GENERAL CATEGORIES")
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

        public int GridRowsCount
        { 
            get
            {
                WaitForOverlay();
                WaitForAngular();
                return gridGeneralCategoriesRows.Count;
            }
        }

        public string SearchResult
        {
            get
            {
                WaitForOverlay();
                WaitForAngular();
                WaitForDocument();
                WaitFor1RowOnly(gridGeneralCategoriesRows);

                #region Evaluate text is present on first row
                int count = 0;
                string elementText = null;
                while (count < 5)
                {
                    try
                    {
                        elementText = gridGeneralCategoriesRows[0].Text;
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
