using InfoTycoon.Fwk.TestAutomation;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;

namespace InfoTycoon.ProjectToTest
{
    public class Companies : PageBase
    {
        public Companies() : base("COMPANIES", "https://dev-my.infotycoon.com/#/admindashboard/companies/")
        {
        }

        #region Page elements

            #region Companies

                #region Header
                [FindsBy(How = How.PartialLinkText, Using = "Companies")]
                private IWebElement btnCompanies;

                [FindsBy(How = How.PartialLinkText, Using = "Users")]
                private IWebElement btnUsers;

                [FindsBy(How = How.PartialLinkText, Using = "Admin")]
                private IWebElement btnAdmin;
                #endregion

                #region Body
                [FindsBy(How = How.CssSelector, Using = "#profile h5")]
                private IWebElement lblUserName;

                [FindsBy(How = How.ClassName, Using = "content-header")]
                private IWebElement headCompanies;

                [FindsBy(How = How.LinkText, Using = "Create New")]
                private IWebElement btnCreateNew;

                [FindsBy(How = How.CssSelector, Using = "tbody")]
                private IWebElement gridCompanies;

                [FindsBy(How = How.CssSelector, Using = "input[type='text']")]
                private IWebElement txtSearchCompany;

                [FindsBy(How = How.CssSelector, Using = ".input-group-btn")]
                private IWebElement btnSearchCompany;

                [FindsBy(How = How.XPath, Using = "//td[contains(text(),'Gustavo')]")]
                private IWebElement rowCreatedCompany;

                [FindsBy(How = How.XPath, Using = "//td[contains(text(),'Automation')]")]
                private IWebElement rowTestingCompany;

                [FindsBy(How = How.CssSelector, Using = "td:nth-of-type(2)")]
                private IWebElement rowSearchResult; 
                #endregion

            #endregion

            #region New Company
            [FindsBy(How = How.CssSelector, Using = "#modal h3")]
            private IWebElement headCreateCompany;

            [FindsBy(How = How.Id, Using = "companyType")]
            private IWebElement cmbCompanyType;

            [FindsBy(How = How.CssSelector, Using = "option[label='Owner']")]
            private IWebElement cmboptOwner;

            [FindsBy(How = How.Id, Using = "name")]
            private IWebElement txtCompanyName;

            [FindsBy(How = How.CssSelector, Using = "input[type='checkbox'][ng-model='company.attributes.leaseFileAudit']")]
            private IWebElement chkLeaseFileAudit;

            [FindsBy(How = How.Id, Using = "SubmitButton")]
            private IWebElement btnSaveComp;

            [FindsBy(How = How.ClassName, Using = "toast-title")]
            private IWebElement toastTitle;

            [FindsBy(How = How.ClassName, Using = "toast-message")]
            private IWebElement toastMessage;

            [FindsBy(How = How.CssSelector, Using = "label[ng-show='form.companyType.$error.required']")]
            private IWebElement msgCompanyType;

            [FindsBy(How = How.CssSelector, Using = "label[ng-show='form.name.$error.required']")]
            private IWebElement msgCompanyName;
            #endregion

        #endregion

        #region Methods
        public void ClickCreateNewButton()
        {
            WaitForOverlay();
            WaitForElement(btnCreateNew);
            WaitForElement(gridCompanies);
            btnCreateNew.Click();
        }

        public void SelectLeaseFileAuditCheck()
        {
            WaitForOverlay();
            WaitForElement(cmboptOwner);
            chkLeaseFileAudit.Click();
        }

        public void CreateNewCompany(string compname)
        {
            WaitForOverlay();
            WaitForElement(cmboptOwner);
            cmboptOwner.Click();
            txtCompanyName.SendKeys(compname);
            chkLeaseFileAudit.Click();
            btnSaveComp.Click();
        }

        public void SearchCompany(string compname)
        {
            WaitForOverlay();
            WaitForElement(txtSearchCompany);
            txtSearchCompany.SendKeys(compname);
            WaitForOverlay();
            WaitForAngular();
            btnSearchCompany.Click();
            WaitForOverlay();
        }

        public void SelectCompany(string compname)
        {
            WaitForOverlay();
            WaitForAngular();
            if (compname.Contains("Automation"))
            {
                WaitForElement(rowTestingCompany);
                WaitForOverlay();
                rowTestingCompany.Click();
            }
            else
            {
                WaitForElement(rowCreatedCompany);
                WaitForOverlay();
                rowCreatedCompany.Click();
            }
        }
        #endregion

        #region Properties

            #region Header
        public IWebElement CompaniesButton
        {
            get
            {
                WaitForElement(btnCompanies);
                return btnCompanies;
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

        public IWebElement AdminButton
        {
            get
            {
                WaitForElement(btnAdmin);
                return btnAdmin;
            }
        }
        #endregion

        public string UserNameLabel
        {
            get
            {
                WaitForOverlay();
                WaitForElement(lblUserName);
                return lblUserName.Text;
            }
        }

        public string PageHeader
        {
            get
            {
                WaitForElement(headCompanies);
                return headCompanies.Text;
            }
        }

        public string CreateNewButtonName
        {
            get
            {
                WaitForElement(btnCreateNew);
                return btnCreateNew.Text;
            }
        }

        public IWebElement CreateButton
        {
            get
            {
                WaitForElement(btnCreateNew);
                return btnCreateNew;
            }
        }

        public IWebElement SearchCompanyField
        {
            get
            {
                WaitForElement(txtSearchCompany);
                return txtSearchCompany;
            }
        }

        public string SearchResult
        {
            get
            {
                WaitForElement(rowSearchResult);
                return rowSearchResult.Text;
            }
        }

        public string CreateNewCompanyHeader
        {
            get
            {
                WaitForElement(headCreateCompany);
                return headCreateCompany.Text;
            }
        }

        public IWebElement CompanyTypeCombo
        {
            get
            {
                WaitForElement(cmbCompanyType);
                return cmbCompanyType;
            }
        }

        public IWebElement CompanyNameField
        {
            get
            {
                WaitForElement(txtCompanyName);
                return txtCompanyName;
            }
        }

        public bool SaveButtonEnabled
        {
            get
            {
                if (btnSaveComp != null)
                {
                    return btnSaveComp.Enabled;
                }
                return false;
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

        public string CompanyTypeMsg
        {
            get
            {
                WaitForElement(msgCompanyType);
                return msgCompanyType.Text;
            }
        }

        public string CompanyNameMsg
        {
            get
            {
                WaitForElement(msgCompanyName);
                return msgCompanyName.Text;
            }
        }
        #endregion
    }
}