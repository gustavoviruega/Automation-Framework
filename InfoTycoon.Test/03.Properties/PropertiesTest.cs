using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InfoTycoon.ProjectToTest;
using InfoTycoon.Fwk.TestAutomation;
using System.Threading;
using System.Configuration;
using InfoTycoon.Fwk.TestAutomation.Helpers;

namespace InfoTycoon.Test._03.Properties
{
    [TestClass]
    public class PropertiesTest : SetupAssemblyInitializer
    {
        #region Declare variables
        static string date;
        static string userName;
        static string userPass;
        static string userFullName;
        static string createNewButtonLabel;
        static string automationCompany;
        static string automationProperty;
        static string propertyName;
        static string propertyAddress1;
        static string propertyNameMsg;
        static string toastSuccessTitle;
        static string toastNewPropertyMsg;
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
            automationCompany = ConfigurationManager.AppSettings["AutomationCompany"];
            automationProperty = ConfigurationManager.AppSettings["AutomationProperty"];
            propertyName = ConfigurationManager.AppSettings["PropertyName"] + date;
            propertyAddress1 = ConfigurationManager.AppSettings["Address1"];
            propertyNameMsg = ConfigurationManager.AppSettings["MsgPropertyName"];
            toastSuccessTitle = ConfigurationManager.AppSettings["ToastSuccessTitle"];
            toastNewPropertyMsg = ConfigurationManager.AppSettings["ToastNewPropertyMsg"];
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
        [TestProperty("Page", "Properties")]
        [Priority(1)]
        public void Properties_PageUI()
        {
            CurrentTestCaseId = 5336;

            #region Arrange
            var loginPage = Pages.Login;
            var companiesPage = Pages.Companies;
            var propertiesPage = Pages.Properties;
            #endregion

            #region Act
            Browser.GoToPage(loginPage);
            loginPage.SingIn(userName, userPass);
            companiesPage.SearchCompany(automationCompany);
            companiesPage.SelectCompany(automationCompany);
            #endregion

            #region Assert
            try
            {
                Assert.IsNotNull(propertiesPage.RegionsButton);
                Assert.IsNotNull(propertiesPage.ActivityButton);
                Assert.IsNotNull(propertiesPage.PropertiesButton);
                Assert.IsNotNull(propertiesPage.UsersButton);
                Assert.IsNotNull(propertiesPage.CompanyInfoButton);
                Assert.IsNotNull(propertiesPage.ReportsButton);
                Assert.AreEqual(propertiesPage.Title, propertiesPage.PageHeader);
                Assert.IsNotNull(propertiesPage.CreateButton);
                Assert.IsNotNull(propertiesPage.SearchPropertyField);
                Assert.AreEqual(createNewButtonLabel, propertiesPage.CreateNewButtonName);
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
        [TestProperty("Page", "Properties")]
        [Priority(2)]
        public void Properties_SearchProperty()
        {
            CurrentTestCaseId = 5354;

            #region Arrange
            var loginPage = Pages.Login;
            var companiesPage = Pages.Companies;
            var propertiesPage = Pages.Properties;
            #endregion

            #region Act
            Browser.GoToPage(loginPage);
            loginPage.SingIn(userName, userPass);
            companiesPage.SearchCompany(automationCompany);
            companiesPage.SelectCompany(automationCompany);
            propertiesPage.SearchProperty(automationProperty);
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual(automationProperty, propertiesPage.SearchResult);
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
        [TestProperty("Page", "Properties")]
        [Priority(2)]
        public void Properties_SelectProperty()
        {
            CurrentTestCaseId = 5355;

            #region Arrange
            var loginPage = Pages.Login;
            var companiesPage = Pages.Companies;
            var propertiesPage = Pages.Properties;
            var propertyActivityPage = Pages.PropertyActivity;
            #endregion

            #region Act
            Browser.GoToPage(loginPage);
            loginPage.SingIn(userName, userPass);
            companiesPage.SearchCompany(automationCompany);
            companiesPage.SelectCompany(automationCompany);
            propertiesPage.SelectProperty(automationProperty);
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual(automationProperty, propertyActivityPage.PageBreadCrumb);
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
        [TestProperty("Page", "Property Activity")]
        [Priority(2)]
        public void Properties_ActivityPageUI()
        {
            CurrentTestCaseId = 5521;

            #region Arrange
            var loginPage = Pages.Login;
            var companiesPage = Pages.Companies;
            var propertiesPage = Pages.Properties;
            var propertyActivityPage = Pages.PropertyActivity;
            #endregion

            #region Act
            Browser.GoToPage(loginPage);
            loginPage.SingIn(userName, userPass);
            companiesPage.SearchCompany(automationCompany);
            companiesPage.SelectCompany(automationCompany);
            propertiesPage.SelectProperty(automationProperty);
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual(automationProperty, propertyActivityPage.PageBreadCrumb);
                Assert.AreEqual(propertyActivityPage.Title, propertyActivityPage.PageHeader);
                Assert.IsNotNull(propertyActivityPage.NotificationButton);
                Assert.IsNotNull(propertyActivityPage.PropertiesButton);
                Assert.IsNotNull(propertyActivityPage.ActivityButton);
                Assert.IsNotNull(propertyActivityPage.InspectionsButton);
                Assert.IsNotNull(propertyActivityPage.LFAButton);
                Assert.IsNotNull(propertyActivityPage.SetupButton);
                Assert.IsNotNull(propertyActivityPage.ReportsButton);
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
        [TestProperty("Page", "Create Property")]
        [Priority(1)]
        public void Properties_CreatePropertyPageUI()
        {
            CurrentTestCaseId = 5361;

            #region Arrange
            var loginPage = Pages.Login;
            var companiesPage = Pages.Companies;
            var propertiesPage = Pages.Properties;
            var createPropertyPage = Pages.CreateProperty;
            #endregion

            #region Act
            Browser.GoToPage(loginPage);
            loginPage.SingIn(userName, userPass);
            companiesPage.SearchCompany(automationCompany);
            companiesPage.SelectCompany(automationCompany);
            propertiesPage.ClickCreateNewButton();
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual(createPropertyPage.Title, createPropertyPage.PageHeader);
                Assert.IsNotNull(createPropertyPage.PropertyNameField);
                Assert.IsNotNull(createPropertyPage.SelectImageButton);
                Assert.IsFalse(createPropertyPage.SaveButtonEnabled);
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
        [TestProperty("Page", "Create Property")]
        [Priority(1)]
        public void Properties_CreateNewPropertyRequiredFields()
        {
            CurrentTestCaseId = 5373;

            #region Arrange
            var loginPage = Pages.Login;
            var companiesPage = Pages.Companies;
            var propertiesPage = Pages.Properties;
            var createPropertyPage = Pages.CreateProperty;
            #endregion

            #region Act
            Browser.GoToPage(loginPage);
            loginPage.SingIn(userName, userPass);
            companiesPage.SearchCompany(automationCompany);
            companiesPage.SelectCompany(automationCompany);
            propertiesPage.ClickCreateNewButton();
            createPropertyPage.AddAddress1(propertyAddress1);
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual(propertyNameMsg, createPropertyPage.PropertyNameMsg);
                Assert.IsFalse(createPropertyPage.SaveButtonEnabled);
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
        [TestProperty("Page", "Create Property")]
        [Priority(1)]
        public void Properties_CreateNewProperty()
        {
            CurrentTestCaseId = 5374;

            #region Arrange
            var loginPage = Pages.Login;
            var companiesPage = Pages.Companies;
            var propertiesPage = Pages.Properties;
            var createPropertyPage = Pages.CreateProperty;
            var propertyDetailsPage = Pages.PropertyDetails;
            #endregion

            #region Act
            Browser.GoToPage(loginPage);
            loginPage.SingIn(userName, userPass);
            companiesPage.SearchCompany(automationCompany);
            companiesPage.SelectCompany(automationCompany);
            propertiesPage.ClickCreateNewButton();
            createPropertyPage.CreateNewProperty("New " + propertyName);
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual("New " + propertyName, propertyDetailsPage.PageBreadCrumbNew);
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
        [TestProperty("Page", "Create Property")]
        [Priority(2)]
        public void Properties_CreateNewPropertyConfirmationMessage()
        {
            CurrentTestCaseId = 5375;

            #region Arrange
            var loginPage = Pages.Login;
            var companiesPage = Pages.Companies;
            var propertiesPage = Pages.Properties;
            var createPropertyPage = Pages.CreateProperty;
            var propertyDetails = Pages.PropertyDetails;
            #endregion

            #region Act
            Browser.GoToPage(loginPage);
            loginPage.SingIn(userName, userPass);
            companiesPage.SearchCompany(automationCompany);
            companiesPage.SelectCompany(automationCompany);
            propertiesPage.ClickCreateNewButton();
            createPropertyPage.CreateNewProperty(propertyName);
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual(toastSuccessTitle, propertyDetails.ToastTitle);
                Assert.AreEqual(toastNewPropertyMsg, propertyDetails.ToastMsg);
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
