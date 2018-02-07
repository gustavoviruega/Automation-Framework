using InfoTycoon.Fwk.TestAutomation;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;
using System;
using System.Collections.Generic;

namespace InfoTycoon.ProjectToTest
{
    public class Companies : PageBase
    {
        public Companies() : base("COMPANIES", "https://dev-my.infotycoon.com/#/admindashboard/companies/")
        {
        }

        #region Page elements


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
                private IWebElement cellSearchResult;

                [FindsBy(How = How.CssSelector, Using = "tbody > tr")]
                private IList<IWebElement> rowsCompanies;

                [FindsBy(How = How.CssSelector, Using = "#_pendo-close-guide_")]
                private IWebElement btnClosePendo;

                [FindsBy(How = How.CssSelector, Using = "button.dismiss-button._pendo-guide-next_")]
                private IWebElement btnGotIt;

                [FindsBy(How = How.ClassName, Using = "toast-title")]
                private IWebElement toastTitle;

                [FindsBy(How = How.ClassName, Using = "toast-message")]
                private IWebElement toastMessage;
        #endregion

        #endregion

        #region Methods
        public void ClickCreateNewButton()
        {
            WaitForOverlay();
            ClosePendoModal();
            WaitForElement(btnCreateNew);
            WaitForElement(gridCompanies);
            btnCreateNew.Click();
        }

        public void SearchCompany(string compname)
        {
            WaitForOverlay();
            WaitForElement(txtSearchCompany);
            txtSearchCompany.SendKeys(compname);
            WaitForOverlay();
            WaitForAngular();
            btnSearchCompany.Click();
            WaitFor1RowOnly(rowsCompanies);
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

        public string Header
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
                WaitForElement(cellSearchResult);
                return cellSearchResult.Text;
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