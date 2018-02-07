using InfoTycoon.Fwk.TestAutomation;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;

namespace InfoTycoon.ProjectToTest
{
    public class CreateCompany : PageBase
    {
        public CreateCompany() : base("CREATE NEW COMPANY", "https://dev-my.infotycoon.com/#/admindashboard/companies/create/")
        {
        }

        #region Page elements
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

            [FindsBy(How = How.CssSelector, Using = "label[ng-show='form.companyType.$error.required']")]
            private IWebElement msgCompanyType;

            [FindsBy(How = How.CssSelector, Using = "label[ng-show='form.name.$error.required']")]
            private IWebElement msgCompanyName;

        #endregion

        #region Methods
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
        #endregion

        #region Properties
        public string Header
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