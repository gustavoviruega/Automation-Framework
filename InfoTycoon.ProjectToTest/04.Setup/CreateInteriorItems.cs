using InfoTycoon.Fwk.TestAutomation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Configuration;
using System.Threading;
using System;

namespace InfoTycoon.ProjectToTest
{
    public class CreateInteriorItems : PageBase
    {
        static string propID = ConfigurationManager.AppSettings["AutomationPropertyID"];
        public CreateInteriorItems() : base("CREATE INTERIOR ITEM", "https://dev-my.infotycoon.com/#/property/" + propID + "/interioritems/create/")
        {
        }

        #region Page Elements

            #region Body
            [FindsBy(How = How.PartialLinkText, Using = "Automation Property")]
            private IWebElement breCreateInteriorItems;

            [FindsBy(How = How.CssSelector, Using = "h3.content-header")]
            private IWebElement headCreateInteriorItems;

            [FindsBy(How = How.CssSelector, Using = "ul#collapseSidemenu a.active")]
            private IWebElement btnSideMenuActive;

            [FindsBy(How = How.Id, Using = "SubmitButton")]
            public IWebElement btnSaveInteriorItem;

            [FindsBy(How = How.LinkText, Using = "Cancel")]
            public IWebElement btnCancel;

            [FindsBy(How = How.Id, Using = "actionTypeId")]
            public IWebElement cmbActionType;

            [FindsBy(How = How.CssSelector, Using = "option[label='Action Value']")]
            private IWebElement cmboptActionValue;

            [FindsBy(How = How.CssSelector, Using = "option[label='Counter']")]
            private IWebElement cmboptCounter;

            [FindsBy(How = How.CssSelector, Using = "option[label='Date']")]
            private IWebElement cmboptDate;

            [FindsBy(How = How.CssSelector, Using = "option[label='Status']")]
            private IWebElement cmboptStatus;

            [FindsBy(How = How.CssSelector, Using = "option[label='Pass/Fail']")]
            private IWebElement cmboptPassFail;

            [FindsBy(How = How.CssSelector, Using = "option[label='Signature']")]
            private IWebElement cmboptSignature;

            [FindsBy(How = How.Id, Using = "name")]
            public IWebElement txtName;

            [FindsBy(How = How.CssSelector, Using = "option[label = 'Each'][selected = 'selected']")]
            public IWebElement cmbEachOption;

            [FindsBy(How = How.CssSelector, Using = "input[id='action1caption'][placeholder='Value']")]
            public IWebElement txtValue1;

            [FindsBy(How = How.CssSelector, Using = "label[ng-show='form.name.$error.required']")]
            private IWebElement msgItemName;

            [FindsBy(How = How.CssSelector, Using = "label[class='control-label'][ng-show*='form.action1caption.$error.dependentRequired']")]
            private IWebElement msgItemValue;

            [FindsBy(How = How.Id, Using = "itemIsCondition")]
            public IWebElement chkIsCondition;

            [FindsBy(How = How.Id, Using = "associate-items-container")]
            public IWebElement contAssociateItems;

            [FindsBy(How = How.CssSelector, Using = "button[class='btn btn-default moveall']")]
            public IWebElement btnMoveAll;

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
            else if (option == "Status")
            {
                WaitForElement(cmboptStatus);
                cmboptStatus.Click();
            }
            else if (option == "PassFail")
            {
                WaitForElement(cmboptPassFail);
                cmboptPassFail.Click();
            }
            else if (option == "Signature")
            {
                WaitForElement(cmboptSignature);
                cmboptSignature.Click();
            }
            else
            {
                WaitForElement(cmboptActionValue);
                cmboptActionValue.Click();
            }
        }

        public void CompleteAVInteriorItem(string name, string value1)
        {
            WaitForOverlay();
            WaitForElement(cmbActionType);
            WaitForElement(cmbEachOption);
            //WaitForElement(txtName);
            WaitForOverlay();
            //txtName.SendKeys(name) -This is not working, is too fast, doesn't send the complete string;
            foreach (char c in name)
            {
                txtName.SendKeys(c.ToString());
            }
            txtValue1.SendKeys(value1);
        }

        public void CompleteInteriorItem(string name)
        {
            WaitForOverlay();
            WaitForElement(cmbActionType);
            WaitForElement(txtName);
            txtName.SendKeys(name);
        }

        public void ClickSave()
        {
            WaitForOverlay();
            WaitForElement(btnSaveInteriorItem);
            btnSaveInteriorItem.Click();
        }

        public void ClickCancel()
        {
            WaitForOverlay();
            WaitForElement(btnCancel);
            btnCancel.Click();
        }

        public void ClickCondition()
        {
            WaitForOverlay();
            WaitForElement(chkIsCondition);
            chkIsCondition.Click();
        }

        public void ClickMoveAll()
        {
            WaitForOverlay();
            WaitForElement(btnMoveAll);
            btnMoveAll.Click();
        }
        #endregion

        #region Properties

        public string PageBreadCrumb
        {
            get
            {
                WaitForOverlay();
                WaitForElement(cmbActionType);
                WaitForElement(breCreateInteriorItems);
                return breCreateInteriorItems.Text;
            }
        }

        public string PageHeader
        {
            get
            {
                WaitForElement(cmbActionType);
                WaitForElement(headCreateInteriorItems);
                return headCreateInteriorItems.Text;
            }
        }
        
        public bool SideMenuActiveButton
        {
            get
            {
                WaitForElement(cmbActionType);
                if (btnSideMenuActive.Text.Trim() == "INTERIOR ITEMS")
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
                return btnSaveInteriorItem;
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
                if (btnSaveInteriorItem != null)
                {
                    return btnSaveInteriorItem.Enabled;
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

        public IWebElement AssociateItemsContainer
        {
            get
            {
                WaitForElement(contAssociateItems);
                return contAssociateItems;
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
