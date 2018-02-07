using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InfoTycoon.ProjectToTest;
using InfoTycoon.Fwk.TestAutomation;
using System.Threading;
using System.Configuration;
using InfoTycoon.Fwk.TestAutomation.Helpers;

namespace InfoTycoon.Test._02.Companies
{
    [TestClass]
    public class CompaniesTest : SetupAssemblyInitializer
    {
        #region Declare variables
        static string date;
        static string userName;
        static string userPass;
        static string userFullName;
        static string createNewButtonLabel;
        static string createNewCompanyHeader;
        static string companyName;
        static string automationCompany;
        static string toastSuccessTitle;
        static string toastNewCompanyMsg;
        static string companyTypeMsg;
        static string companyNameMsg;
        #endregion

        #region Report settings
        public TestContext TestContext { get; set; }
        private ReportHelper reportHelper = new ReportHelper();
        #endregion

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            #region Initialize variables
            date = DateTime.Now.ToString("_yyyyMMdd_HHmmss");
            userName = ConfigurationManager.AppSettings["UserName"];
            userPass = ConfigurationManager.AppSettings["UserPass"];
            userFullName = ConfigurationManager.AppSettings["FullName"];
            createNewButtonLabel = ConfigurationManager.AppSettings["CreateNewButtonLabel"];
            createNewCompanyHeader = ConfigurationManager.AppSettings["CreateNewCompanyHeader"];
            companyName = ConfigurationManager.AppSettings["CompanyName"] + date;
            automationCompany = ConfigurationManager.AppSettings["AutomationCompany"];
            toastSuccessTitle = ConfigurationManager.AppSettings["ToastSuccessTitle"];
            toastNewCompanyMsg = ConfigurationManager.AppSettings["ToastNewCompanyMsg"];
            companyTypeMsg = ConfigurationManager.AppSettings["MsgCompanyType"];
            companyNameMsg = ConfigurationManager.AppSettings["MsgCompanyName"];
            #endregion
        }

        [TestInitialize]
        public void Initialize()
        {
            Browser.Initializes(true);
        }

        //Evaluate if this test should be splitted in more tests, one test per assertion.
        [TestMethod]
        [TestCategory("E2E")]
        [TestProperty("Page", "Companies")]
        [Priority(1)]
        public void Companies_PageUI()
        {
            CurrentTestCaseId = 4943;

            #region Arrange
            var loginPage = Pages.Login;
            var companiesPage = Pages.Companies;
            #endregion

            #region Act
            Browser.GoToPage(loginPage);
            loginPage.SingIn(userName, userPass);
            #endregion

            #region Assert
            try
            {
                Assert.IsNotNull(companiesPage.CompaniesButton);
                Assert.IsNotNull(companiesPage.UsersButton);
                Assert.IsNotNull(companiesPage.AdminButton);
                Assert.AreEqual(companiesPage.Title, companiesPage.Header);
                Assert.IsNotNull(companiesPage.CreateButton);
                Assert.IsNotNull(companiesPage.SearchCompanyField);
                Assert.AreEqual(createNewButtonLabel, companiesPage.CreateNewButtonName);
            }
            catch (Exception ex)
            {
                AssertExceptionMessage = ex.Message;
                throw;
            }
            #endregion
        }

        [TestMethod]
        [TestCategory("E2E")]
        [TestProperty("Page", "Companies")]
        [Priority(2)]
        public void Companies_SearchCompany()
        {
            CurrentTestCaseId = 5327;

            #region Arrange
            var loginPage = Pages.Login;
            var companiesPage = Pages.Companies;
            #endregion

            #region Act
            Browser.GoToPage(loginPage);
            loginPage.SingIn(userName, userPass);
            companiesPage.SearchCompany(automationCompany);
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual(automationCompany, companiesPage.SearchResult);
            }
            catch (Exception ex)
            {
                AssertExceptionMessage = ex.Message;
                throw;
            }
            #endregion
        }

        [TestMethod]
        [TestCategory("E2E")]
        [TestProperty("Page", "Create Company")]
        [Priority(1)]
        public void Companies_CreateNewCompanyPopUpUI()
        {
            CurrentTestCaseId = 4944;

            #region Arrange
            var loginPage = Pages.Login;
            var companiesPage = Pages.Companies;
            var createCompanyPage = Pages.CreateCompany;
            #endregion

            #region Act
            Browser.GoToPage(loginPage);
            loginPage.SingIn(userName, userPass);
            companiesPage.ClickCreateNewButton();
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual(createCompanyPage.Title, createCompanyPage.Header);
                Assert.IsNotNull(createCompanyPage.CompanyTypeCombo);
                Assert.IsNotNull(createCompanyPage.CompanyNameField);
                Assert.IsFalse(createCompanyPage.SaveButtonEnabled);
            }
            catch (Exception ex)
            {
                AssertExceptionMessage = ex.Message;
                throw;
            }
            #endregion
        }

        [TestMethod]
        [TestCategory("E2E")]
        [TestProperty("Page", "Create Company")]
        [Priority(1)]
        public void Companies_CreateNewCompanyRequiredFields()
        {
            CurrentTestCaseId = 5335;

            #region Arrange
            var loginPage = Pages.Login;
            var companiesPage = Pages.Companies;
            var createCompanyPage = Pages.CreateCompany;
            #endregion

            #region Act
            Browser.GoToPage(loginPage);
            loginPage.SingIn(userName, userPass);
            companiesPage.ClickCreateNewButton();
            createCompanyPage.SelectLeaseFileAuditCheck();
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual(companyTypeMsg, createCompanyPage.CompanyTypeMsg);
                Assert.AreEqual(companyNameMsg, createCompanyPage.CompanyNameMsg);
                Assert.IsFalse(createCompanyPage.SaveButtonEnabled);
            }
            catch (Exception ex)
            {
                AssertExceptionMessage = ex.Message;
                throw;
            }
            #endregion
        }

        [TestMethod]
        [TestCategory("E2E")]
        [TestProperty("Page", "Create Company")]
        [Priority(2)]
        public void Companies_CreateNewCompanyConfirmationMessage()
        {
            CurrentTestCaseId = 4945;

            #region Arrange
            var loginPage = Pages.Login;
            var companiesPage = Pages.Companies;
            var createCompanyPage = Pages.CreateCompany;
            #endregion

            #region Act
            Browser.GoToPage(loginPage);
            loginPage.SingIn(userName, userPass);
            companiesPage.ClickCreateNewButton();
            createCompanyPage.CreateNewCompany(companyName);
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual(toastSuccessTitle, companiesPage.ToastTitle);
                Assert.AreEqual(toastNewCompanyMsg, companiesPage.ToastMsg);
            }
            catch (Exception ex)
            {
                AssertExceptionMessage = ex.Message;
                throw;
            }
            #endregion
        }

        [TestMethod]
        [TestCategory("E2E")]
        [TestProperty("Page", "Create Company")]
        [Priority(1)]
        public void Companies_CreateNewCompany()
        {
            CurrentTestCaseId = 4946;

            #region Arrange
            var loginPage = Pages.Login;
            var companiesPage = Pages.Companies;
            var createCompanyPage = Pages.CreateCompany;
            var propertiesPage = Pages.Properties;
            #endregion

            #region Act
            Browser.GoToPage(loginPage);
            loginPage.SingIn(userName, userPass);
            companiesPage.ClickCreateNewButton();
            createCompanyPage.CreateNewCompany("New " + companyName);
            companiesPage.SearchCompany("New " + companyName);
            companiesPage.SelectCompany("New " + companyName);
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual("New " + companyName, propertiesPage.PageBreadCrumb);
            }
            catch (Exception ex)
            {
                AssertExceptionMessage = ex.Message;
                throw;
            }
            #endregion
        }

        [TestCleanup]
        public void CleanUp()
        {
            //LogTest(TestContext.CurrentTestOutcome, CurrentTestCaseId);

            //reportHelper.GenerateReport(TestContext, AssertExceptionMessage);

            Browser.Quit();
        }
    }
}
