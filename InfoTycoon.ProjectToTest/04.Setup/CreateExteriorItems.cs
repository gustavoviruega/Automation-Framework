using InfoTycoon.Fwk.TestAutomation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Configuration;
using System.Threading;
using System;

namespace InfoTycoon.ProjectToTest
{
    public class CreateExteriorItems : PageBase
    {
        static string propID = ConfigurationManager.AppSettings["AutomationPropertyID"];
        public CreateExteriorItems() : base("CREATE EXTERIOR ITEM", "https://dev-my.infotycoon.com/#/property/" + propID + "/exterioritems/create/")
        {
        }

        #region Page Elements

            #region Body
            [FindsBy(How = How.PartialLinkText, Using = "Automation Property")]
            private IWebElement breCreateExteriorItems;

            [FindsBy(How = How.CssSelector, Using = "h3.content-header")]
            private IWebElement headCreateExteriorItems;

            [FindsBy(How = How.CssSelector, Using = "ul#collapseSidemenu a.active")]
            private IWebElement btnSideMenuActive;

            [FindsBy(How = How.Id, Using = "SubmitButton")]
            public IWebElement btnSaveExteriorItem;

            [FindsBy(How = How.LinkText, Using = "Back")]
            public IWebElement btnBack;

            [FindsBy(How = How.Id, Using = "actionTypeId")]
            public IWebElement cmbActionType;

            [FindsBy(How = How.CssSelector, Using = "option[label='Action Value']")]
            private IWebElement cmboptActionValue;

            [FindsBy(How = How.CssSelector, Using = "option[label='Counter']")]
            private IWebElement cmboptCounter;

            [FindsBy(How = How.CssSelector, Using = "option[label='Date']")]
            private IWebElement cmboptDate;

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
            if (option == "Counter")
            {
                WaitForElement(cmboptCounter);
                cmboptCounter.Click();
            }
            else if (option == "Date")
            {
                WaitForElement(cmboptDate);
                cmboptDate.Click();
            }
            else
            {
                WaitForElement(cmboptActionValue);
                cmboptActionValue.Click();
            }
        }

        public void CompleteAVExteriorItem(string name, string value1)
        {
            WaitForOverlay();
            WaitForElement(cmbActionType);
            WaitForElement(txtName);
            //txtName.SendKeys(name) -This is not working, is too fast, doesn't send the complete string;
            foreach (char c in name)
            {
                txtName.SendKeys(c.ToString());
            }
            txtValue1.SendKeys(value1);
        }

        public void CompleteExteriorItem(string name)
        {
            WaitForOverlay();
            WaitForElement(cmbActionType);
            WaitForElement(txtName);
            txtName.SendKeys(name);
        }

        public void ClickSave()
        {
            WaitForOverlay();
            WaitForElement(btnSaveExteriorItem);
            btnSaveExteriorItem.Click();
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
                WaitForElement(cmbActionType);
                WaitForElement(breCreateExteriorItems);
                return breCreateExteriorItems.Text;
            }
        }

        public string PageHeader
        {
            get
            {
                WaitForElement(cmbActionType);
                WaitForElement(headCreateExteriorItems);
                return headCreateExteriorItems.Text;
            }
        }
        
        public bool SideMenuActiveButton
        {
            get
            {
                WaitForElement(cmbActionType);
                if (btnSideMenuActive.Text.Trim() == "EXTERIOR ITEMS")
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
                return btnSaveExteriorItem;
            }
        }

        public IWebElement BackButton
        {
            get
            {
                WaitForElement(cmbActionType);
                WaitForElement(btnBack);
                return btnBack;
            }
        }

        public bool SaveButtonEnabled
        {
            get
            {
                WaitForElement(cmbActionType);
                if (btnSaveExteriorItem != null)
                {
                    return btnSaveExteriorItem.Enabled;
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
