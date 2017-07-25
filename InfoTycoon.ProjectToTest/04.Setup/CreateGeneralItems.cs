using InfoTycoon.Fwk.TestAutomation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Configuration;
using System;

namespace InfoTycoon.ProjectToTest
{
    public class CreateGeneralItems : PageBase
    {
        static string propID = ConfigurationManager.AppSettings["AutomationPropertyID"];
        public CreateGeneralItems() : base("CREATE GENERAL ITEM", "https://dev-my.infotycoon.com/#/property/" + propID + "/generalitems/create/")
        {
        }

        #region Page Elements

            #region Body
            [FindsBy(How = How.PartialLinkText, Using = "Automation Property")]
            private IWebElement breCreateGeneralItems;

            [FindsBy(How = How.CssSelector, Using = "h3.content-header")]
            private IWebElement headCreateGeneralItems;

            [FindsBy(How = How.CssSelector, Using = "ul#collapseSidemenu a.active")]
            private IWebElement btnSideMenuActive;

            [FindsBy(How = How.Id, Using = "SubmitButton")]
            public IWebElement btnSaveGeneralItem;

            [FindsBy(How = How.LinkText, Using = "Cancel")]
            public IWebElement btnCancel;

            [FindsBy(How = How.Id, Using = "actionTypeId")]
            public IWebElement cmbActionType;

            [FindsBy(How = How.CssSelector, Using = "option[label='Action Value']")]
            private IWebElement cmboptActionValue;

            [FindsBy(How = How.CssSelector, Using = "option[label='Survey']")]
            private IWebElement cmboptSurvey;

            [FindsBy(How = How.CssSelector, Using = "option[label='Counter']")]
            private IWebElement cmboptCounter;

            [FindsBy(How = How.CssSelector, Using = "option[label='Date']")]
            private IWebElement cmboptDate;

            [FindsBy(How = How.CssSelector, Using = "option[label='Petty Cash']")]
            private IWebElement cmboptPettyCash;

            [FindsBy(How = How.Id, Using = "name")]
            public IWebElement txtName;

            [FindsBy(How = How.CssSelector, Using = "input[id='action1caption'][placeholder='Value']")]
            public IWebElement txtValue1;

            [FindsBy(How = How.CssSelector, Using = "label[ng-show='form.name.$error.required']")]
            private IWebElement msgItemName;

            [FindsBy(How = How.CssSelector, Using = "label[class='control-label'][ng-show*='form.action1caption.$error.dependentRequired']")]
            private IWebElement msgItemValue;

            [FindsBy(How = How.ClassName, Using = "toast-title")]
            private IWebElement toastTitle;

            [FindsBy(How = How.ClassName, Using = "toast-message")]
            private IWebElement toastMessage;
        #endregion

        #endregion

        #region Methods
        public void ClickActionTypeOption(string option)
        {
            WaitForOverlay();
            WaitForElement(cmbActionType);
            if (option == "Survey")
            {
                WaitForElement(cmboptSurvey);
                cmboptSurvey.Click();
            }
            else if (option == "Counter")
            {
                WaitForElement(cmboptCounter);
                cmboptCounter.Click();
            }
            else if (option == "Date")
            {
                WaitForElement(cmboptDate);
                cmboptDate.Click();
            }
            else if (option == "Petty Cash")
            {
                WaitForElement(cmboptPettyCash);
                cmboptPettyCash.Click();
            }
            else
            {
                WaitForElement(cmboptActionValue);
                cmboptActionValue.Click();
            }
        }

        public void CompleteAVGeneralItem(string name, string value1)
        {
            WaitForOverlay();
            WaitForElement(cmbActionType);
            WaitForElement(txtName);
            txtName.SendKeys(name);
            txtValue1.SendKeys(value1);
        }

        public void CompleteGeneralItem(string name)
        {
            WaitForOverlay();
            WaitForElement(cmbActionType);
            WaitForElement(txtName);
            txtName.SendKeys(name);
        }

        public void ClickSave()
        {
            WaitForOverlay();
            WaitForElement(btnSaveGeneralItem);
            btnSaveGeneralItem.Click();
        }

        public void ClickCancel()
        {
            WaitForOverlay();
            WaitForElement(btnCancel);
            btnCancel.Click();
        }
        #endregion

        #region Properties

        public string PageBreadCrumb
        {
            get
            {
                WaitForOverlay();
                WaitForElement(cmbActionType);
                WaitForElement(breCreateGeneralItems);
                return breCreateGeneralItems.Text;
            }
        }

        public string PageHeader
        {
            get
            {
                WaitForElement(cmbActionType);
                WaitForElement(headCreateGeneralItems);
                return headCreateGeneralItems.Text;
            }
        }
        
        public bool SideMenuActiveButton
        {
            get
            {
                WaitForElement(cmbActionType);
                if (btnSideMenuActive.Text.Trim() == "GENERAL ITEMS")
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
                WaitForElement(cmbActionType);
                return btnSaveGeneralItem;
            }
        }

        public IWebElement CancelButton
        {
            get
            {
                WaitForElement(cmbActionType);
                WaitForElement(btnCancel);
                return btnCancel;
            }
        }

        public bool SaveButtonEnabled
        {
            get
            {
                WaitForElement(cmbActionType);
                if (btnSaveGeneralItem != null)
                {
                    return btnSaveGeneralItem.Enabled;
                }
                return false;
            }
        }

        public IWebElement ActionTypeField
        {
            get
            {
                WaitForElement(cmbActionType);
                return cmbActionType;
            }
        }

        public string ItemNameMsg
        {
            get
            {
                WaitForElement(msgItemName);
                return msgItemName.Text;
            }
        }

        public string ItemValueMsg
        {
            get
            {
                WaitForElement(msgItemValue);
                return msgItemValue.Text;
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
