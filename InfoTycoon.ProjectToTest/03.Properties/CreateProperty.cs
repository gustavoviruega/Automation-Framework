using InfoTycoon.Fwk.TestAutomation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace InfoTycoon.ProjectToTest
{
    public class CreateProperty : PageBase
    {
        public CreateProperty() : base("CREATE PROPERTY", "https://dev-my.infotycoon.com/#/companydashboard/properties/create/")
        {
        }

        #region Page Elements
    
            #region Header
            [FindsBy(How = How.CssSelector, Using = "a[href='/#/companydashboard/regions/']")]
            private IWebElement btnRegions;

            [FindsBy(How = How.CssSelector, Using = "a[href='/#/companydashboard/activity/']")]
            private IWebElement btnActivity;

            [FindsBy(How = How.CssSelector, Using = "a[href='/#/companydashboard/properties/']")]
            private IWebElement btnProperties;

            [FindsBy(How = How.CssSelector, Using = "a[href='/#/companydashboard/users/']")]
            private IWebElement btnUsers;

            [FindsBy(How = How.CssSelector, Using = "a[href='/#/companydashboard/companies/details']")]
            private IWebElement btnCompanyInfo;

            [FindsBy(How = How.CssSelector, Using = "a[href='/#/reportswizard/myreports/']")]
            private IWebElement btnReports;
            #endregion

            #region Body
            [FindsBy(How = How.ClassName, Using = "content-header")]
            private IWebElement headCreateProperty;

            [FindsBy(How = How.Id, Using = "name")]
            private IWebElement txtPropertyName;

            [FindsBy(How = How.CssSelector, Using = "label[ng-show='form.name.$error.required']")]
            private IWebElement msgPropertyName;

            [FindsBy(How = How.CssSelector, Using = ".input-group-btn")]
            public IWebElement btnSelectImage;

            [FindsBy(How = How.CssSelector, Using = "#address1")]
            private IWebElement txtAddress1;

            [FindsBy(How = How.Id, Using = "SubmitButton")]
            public IWebElement btnSaveProperty; 
            #endregion

        #endregion

        #region Methods
        public void ClickSelectImageButton()
        {
            WaitForOverlay();
            WaitForElement(btnSelectImage);
            btnSelectImage.Click();
        }

        public void AddAddress1(string address1)
        {
            WaitForOverlay();
            WaitForElement(txtAddress1);
            txtAddress1.SendKeys(address1);
        }

        public void CreateNewProperty(string propertyname)
        {
            WaitForOverlay();
            WaitForElement(txtPropertyName);
            txtPropertyName.SendKeys(propertyname);
            WaitForOverlay();
            btnSaveProperty.Click();
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

        public string PageHeader
        {
            get
            {
                WaitForElement(txtPropertyName);
                WaitForElement(headCreateProperty);
                return headCreateProperty.Text;
            }
        }

        public IWebElement PropertyNameField
        {
            get
            {
                WaitForElement(txtPropertyName);
                return txtPropertyName;
            }
        }

        public string PropertyNameMsg
        {
            get
            {
                WaitForElement(msgPropertyName);
                return msgPropertyName.Text;
            }
        }

        public IWebElement SelectImageButton
        {
            get
            {
                WaitForElement(btnSelectImage);
                return btnSelectImage;
            }
        }

        public bool SaveButtonEnabled
        {
            get
            {
                if (btnSaveProperty != null)
                {
                    return btnSaveProperty.Enabled;
                }
                return false;
            }
        }
        #endregion
    }
}
