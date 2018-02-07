using InfoTycoon.Fwk.TestAutomation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Configuration;
using System;

namespace InfoTycoon.ProjectToTest
{
    public class CreateGeneralCategory : PageBase
    {
        static string propID = ConfigurationManager.AppSettings["AutomationPropertyID"];
        public CreateGeneralCategory() : base("CREATE GENERAL CATEGORY", "https://dev-my.infotycoon.com/#/property/" + propID + "/generalcategories/create/")
        {
        }

        #region Page Elements

            #region Body
            [FindsBy(How = How.PartialLinkText, Using = "Automation Property")]
            private IWebElement breCreateGeneralCategory;

            [FindsBy(How = How.CssSelector, Using = "h3.content-header")]
            private IWebElement headCreateGeneralCategory;

            [FindsBy(How = How.CssSelector, Using = "ul#collapseSidemenu a.active")]
            private IWebElement btnSideMenuActive;

            [FindsBy(How = How.Id, Using = "SubmitButton")]
            public IWebElement btnSaveGeneralCategory;

            [FindsBy(How = How.LinkText, Using = "Back")]
            public IWebElement btnBack;

            [FindsBy(How = How.Id, Using = "name")]
            public IWebElement txtName;

            [FindsBy(How = How.Id, Using = "categoryType")]
            public IWebElement cmbCategoryType;

            [FindsBy(How = How.CssSelector, Using = "option[label='Administrative']")]
            private IWebElement cmboptAdministrative;

            [FindsBy(How = How.CssSelector, Using = "option[label='Leasing']")]
            private IWebElement cmboptLeasing;

            [FindsBy(How = How.CssSelector, Using = "option[label='Operations']")]
            private IWebElement cmboptOperations;

            [FindsBy(How = How.CssSelector, Using = "label[ng-show='form.name.$error.required']")]
            private IWebElement msgCategoryName;

            [FindsBy(How = How.CssSelector, Using = "label[ng-show='form.categoryType.$error.required']")]
            private IWebElement msgCategoryType;
        #endregion

        #endregion

        #region Methods
        public void CompleteGeneralCategory(string name, string type)
        {
            WaitForOverlay();
            WaitForElement(cmbCategoryType);
            WaitForElement(txtName);
            txtName.SendKeys(name);
            if (type == "Leasing")
            {
                WaitForElement(cmboptLeasing);
                cmboptLeasing.Click();
            }
            else if (type == "Operations")
            {
                WaitForElement(cmboptOperations);
                cmboptOperations.Click();
            }
            else if (string.IsNullOrWhiteSpace(type))
            {
                WaitForElement(cmboptOperations);
            }
            else
            {
                WaitForElement(cmboptAdministrative);
                cmboptAdministrative.Click();
            }
        }

        public void ClickSave()
        {
            WaitForOverlay();
            WaitForElement(btnSaveGeneralCategory);
            btnSaveGeneralCategory.Click();
        }

        public void ClickBack()
        {
            WaitForOverlay();
            WaitForElement(btnBack);
            btnBack.Click();
        }
        #endregion

        #region Properties

        public string PageBreadCrumb
        {
            get
            {
                WaitForOverlay();
                WaitForElement(cmbCategoryType);
                WaitForElement(breCreateGeneralCategory);
                return breCreateGeneralCategory.Text;
            }
        }

        public string PageHeader
        {
            get
            {
                WaitForElement(cmbCategoryType);
                WaitForElement(headCreateGeneralCategory);
                return headCreateGeneralCategory.Text;
            }
        }
        
        public bool SideMenuActiveButton
        {
            get
            {
                WaitForElement(cmbCategoryType);
                if (btnSideMenuActive.Text.Trim() == "GENERAL CATEGORIES")
                {
                    return true;
                }
                return false;
            }
        }

        public IWebElement SaveButton
        {
            get
            {
                WaitForElement(cmbCategoryType);
                return btnSaveGeneralCategory;
            }
        }

        public IWebElement BackButton
        {
            get
            {
                WaitForElement(cmbCategoryType);
                WaitForElement(btnBack);
                return btnBack;
            }
        }

        public bool SaveButtonEnabled
        {
            get
            {
                WaitForElement(cmbCategoryType);
                if (btnSaveGeneralCategory != null)
                {
                    return btnSaveGeneralCategory.Enabled;
                }
                return false;
            }
        }

        public IWebElement NameField
        {
            get
            {
                WaitForElement(txtName);
                return txtName;
            }
        }

        public IWebElement CategoryTypeField
        {
            get
            {
                WaitForElement(cmbCategoryType);
                return cmbCategoryType;
            }
        }

        public string CategoryNameMsg
        {
            get
            {
                WaitForElement(msgCategoryName);
                return msgCategoryName.Text;
            }
        }

        public string CategoryTypeMsg
        {
            get
            {
                WaitForElement(msgCategoryType);
                return msgCategoryType.Text;
            }
        }
        #endregion
    }
}
