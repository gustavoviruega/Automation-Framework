using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InfoTycoon.ProjectToTest;
using InfoTycoon.Fwk.TestAutomation;
using System.Threading;
using System.Configuration;
using InfoTycoon.Fwk.TestAutomation.Helpers;

namespace InfoTycoon.Test.Example._04.Setup
{
    [TestClass]
    public class SetupTest : SetupAssemblyInitializer
    {
        #region Declare variables
        static string date;
        static string userName;
        static string userPass;
        static string userFullName;
        static string automationCompany;
        static string automationProperty;
        static string propertyNameMsg;
        static string itemNameMsg;
        static string itemValueMsg;
        static string propertyAddress1;
        static string generalitemName;
        static string generalitemValue1;
        static string toastSuccessTitle;
        static string toastEditPropertyMsg;
        static string toastNewGeneralItemMsg;
        #endregion

        #region Report settings
        public TestContext TestContext { get; set; }
        private ReportHelper reportHelper = new ReportHelper();
        #endregion

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            #region Initialize variables
            date = DateTime.Now.ToString("ssmmHH_yyyyMMdd_");
            userName = ConfigurationManager.AppSettings["UserName"];
            userPass = ConfigurationManager.AppSettings["UserPass"];
            userFullName = ConfigurationManager.AppSettings["FullName"];
            automationCompany = ConfigurationManager.AppSettings["AutomationCompany"];
            automationProperty = ConfigurationManager.AppSettings["AutomationProperty"];
            propertyNameMsg = ConfigurationManager.AppSettings["MsgPropertyName"];
            itemNameMsg = ConfigurationManager.AppSettings["MsgItemName"];
            itemValueMsg = ConfigurationManager.AppSettings["MsgItemValue"];
            propertyAddress1 = ConfigurationManager.AppSettings["Address1"];
            generalitemName = date + ConfigurationManager.AppSettings["GeneralItemName"];
            generalitemValue1 = ConfigurationManager.AppSettings["GeneralItemValue1"];
            toastSuccessTitle = ConfigurationManager.AppSettings["ToastSuccessTitle"];
            toastEditPropertyMsg = ConfigurationManager.AppSettings["ToastEditPropertyMsg"];
            toastNewGeneralItemMsg = ConfigurationManager.AppSettings["ToastNewGeneralItemMsg"];
            #endregion
        }

        [TestInitialize]
        public void Initialize()
        {
            Browser.Initializes(true);
        }

        [TestMethod]
        [TestCategory("E2E")]
        [TestProperty("Page", "Property Details")]
        [Priority(1)]
        public void Setup_PropertyDetailsUI()
        {
            CurrentTestCaseId = 5522;

            #region Arrange
            var loginPage = Pages.Login;
            var companiesPage = Pages.Companies;
            var propertiesPage = Pages.Properties;
            var propertyActivityPage = Pages.PropertyActivity;
            var propertyDetailsPage = Pages.PropertyDetails;
            #endregion

            #region Act
            Browser.GoToPage(loginPage);
            loginPage.SingIn(userName, userPass);
            companiesPage.SearchCompany(automationCompany);
            companiesPage.SelectCompany(automationCompany);
            propertiesPage.SelectProperty(automationProperty);
            propertyActivityPage.ClickSetupButton();
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual(automationProperty, propertyDetailsPage.PageBreadCrumb);
                Assert.AreEqual(propertyDetailsPage.Title, propertyDetailsPage.PageHeader);
                Assert.IsTrue(propertyDetailsPage.SideMenuActiveButton);
                Assert.AreEqual(automationProperty, propertyDetailsPage.PropertyNameText);
                Assert.IsNotNull(propertyDetailsPage.PropertiesButton);
                Assert.IsNotNull(propertyDetailsPage.ActivityButton);
                Assert.IsNotNull(propertyDetailsPage.InspectionsButton);
                Assert.IsNotNull(propertyDetailsPage.LFAButton);
                Assert.IsNotNull(propertyDetailsPage.SetupButton);
                Assert.IsNotNull(propertyDetailsPage.ReportsButton);
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
        [TestProperty("Page", "Property Details")]
        [Priority(2)]
        public void Setup_EditPropertyDetailsRequiredFields()
        {
            CurrentTestCaseId = 5524;

            #region Arrange
            var loginPage = Pages.Login;
            var companiesPage = Pages.Companies;
            var propertiesPage = Pages.Properties;
            var propertyActivityPage = Pages.PropertyActivity;
            var propertyDetailsPage = Pages.PropertyDetails;
            #endregion

            #region Act
            Browser.GoToPage(loginPage);
            loginPage.SingIn(userName, userPass);
            companiesPage.SearchCompany(automationCompany);
            companiesPage.SelectCompany(automationCompany);
            propertiesPage.SelectProperty(automationProperty);
            propertyActivityPage.ClickSetupButton();
            propertyDetailsPage.DeletePropertyName();
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual(propertyNameMsg, propertyDetailsPage.PropertyNameMsg);
                Assert.IsFalse(propertyDetailsPage.SaveButtonEnabled);
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
        [TestProperty("Page", "Property Details")]
        [Priority(1)]
        public void Setup_EditPropertyDetails()
        {
            CurrentTestCaseId = 5525;

            #region Arrange
            var loginPage = Pages.Login;
            var companiesPage = Pages.Companies;
            var propertiesPage = Pages.Properties;
            var propertyActivityPage = Pages.PropertyActivity;
            var propertyDetailsPage = Pages.PropertyDetails;
            #endregion

            #region Act
            Browser.GoToPage(loginPage);
            loginPage.SingIn(userName, userPass);
            companiesPage.SearchCompany(automationCompany);
            companiesPage.SelectCompany(automationCompany);
            propertiesPage.SelectProperty(automationProperty);
            propertyActivityPage.ClickSetupButton();
            propertyDetailsPage.EditProperty(propertyAddress1 + date);
            propertyDetailsPage.ClickSave();
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual(toastSuccessTitle, propertyDetailsPage.ToastTitle + "!");
                Assert.AreEqual(toastEditPropertyMsg, propertyDetailsPage.ToastMsg);
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
        [TestProperty("Page", "General Items")]
        [Priority(1)]
        public void Setup_GeneralItemsUI()
        {
            CurrentTestCaseId = 5523;

            #region Arrange
            var loginPage = Pages.Login;
            var companiesPage = Pages.Companies;
            var propertiesPage = Pages.Properties;
            var propertyActivityPage = Pages.PropertyActivity;
            var propertyDetailsPage = Pages.PropertyDetails;
            var propertyGeneralItemsPage = Pages.GeneralItems;
            #endregion

            #region Act
            Browser.GoToPage(loginPage);
            loginPage.SingIn(userName, userPass);
            companiesPage.SearchCompany(automationCompany);
            companiesPage.SelectCompany(automationCompany);
            propertiesPage.SelectProperty(automationProperty);
            propertyActivityPage.ClickSetupButton();
            propertyDetailsPage.SelectGeneralItemsOption();
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual(automationProperty, propertyGeneralItemsPage.PageBreadCrumb);
                Assert.AreEqual(propertyGeneralItemsPage.Title, propertyGeneralItemsPage.PageHeader);
                Assert.IsTrue(propertyGeneralItemsPage.SideMenuActiveButton);
                Assert.IsNotNull(propertyGeneralItemsPage.CreateNewButton);
                Assert.IsNotNull(propertyGeneralItemsPage.CloneButton);
                Assert.IsNotNull(propertyGeneralItemsPage.ApplyToCategoriesButton);
                Assert.IsNotNull(propertyGeneralItemsPage.PropertiesButton);
                Assert.IsNotNull(propertyGeneralItemsPage.ActivityButton);
                Assert.IsNotNull(propertyGeneralItemsPage.InspectionsButton);
                Assert.IsNotNull(propertyGeneralItemsPage.LFAButton);
                Assert.IsNotNull(propertyGeneralItemsPage.SetupButton);
                Assert.IsNotNull(propertyGeneralItemsPage.ReportsButton);
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
        [TestProperty("Page", "Create General Item")]
        [Priority(1)]
        public void Setup_CreateGeneralItemUI()
        {
            CurrentTestCaseId = 5526;

            #region Arrange
            var loginPage = Pages.Login;
            var companiesPage = Pages.Companies;
            var propertiesPage = Pages.Properties;
            var propertyActivityPage = Pages.PropertyActivity;
            var propertyDetailsPage = Pages.PropertyDetails;
            var propertyGeneralItemsPage = Pages.GeneralItems;
            var propertyCreateGeneralItemsPage = Pages.CreateGeneralItems;
            #endregion

            #region Act
            Browser.GoToPage(loginPage);
            loginPage.SingIn(userName, userPass);
            companiesPage.SearchCompany(automationCompany);
            companiesPage.SelectCompany(automationCompany);
            propertiesPage.SelectProperty(automationProperty);
            propertyActivityPage.ClickSetupButton();
            propertyDetailsPage.SelectGeneralItemsOption();
            propertyGeneralItemsPage.ClickCreateNew();
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual(automationProperty, propertyCreateGeneralItemsPage.PageBreadCrumb);
                Assert.AreEqual(propertyCreateGeneralItemsPage.Title, propertyCreateGeneralItemsPage.PageHeader);
                Assert.IsTrue(propertyCreateGeneralItemsPage.SideMenuActiveButton);
                Assert.IsFalse(propertyCreateGeneralItemsPage.SaveButtonEnabled);
                Assert.IsNotNull(propertyCreateGeneralItemsPage.SaveButton);
                Assert.IsNotNull(propertyCreateGeneralItemsPage.CancelButton);
                Assert.IsNotNull(propertyCreateGeneralItemsPage.ActionTypeField);
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
        [TestProperty("Page", "Create General Item")]
        [Priority(2)]
        public void Setup_CreateGeneralItemConfirmationMessage()
        {
            CurrentTestCaseId = 5537;

            #region Arrange
            var loginPage = Pages.Login;
            var companiesPage = Pages.Companies;
            var propertiesPage = Pages.Properties;
            var propertyActivityPage = Pages.PropertyActivity;
            var propertyDetailsPage = Pages.PropertyDetails;
            var propertyGeneralItemsPage = Pages.GeneralItems;
            var propertyCreateGeneralItemsPage = Pages.CreateGeneralItems;
            #endregion

            #region Act
            Browser.GoToPage(loginPage);
            loginPage.SingIn(userName, userPass);
            companiesPage.SearchCompany(automationCompany);
            companiesPage.SelectCompany(automationCompany);
            propertiesPage.SelectProperty(automationProperty);
            propertyActivityPage.ClickSetupButton();
            propertyDetailsPage.SelectGeneralItemsOption();
            propertyGeneralItemsPage.ClickCreateNew();
            propertyCreateGeneralItemsPage.CompleteAVGeneralItem(generalitemName, generalitemValue1);
            propertyCreateGeneralItemsPage.ClickSave();
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual(toastSuccessTitle, propertyGeneralItemsPage.ToastTitle);
                Assert.AreEqual(toastNewGeneralItemMsg, propertyGeneralItemsPage.ToastMsg);
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
        [TestProperty("Page", "Create General Item")]
        [Priority(3)]
        public void Setup_CancelGeneralItemCreation()
        {
            CurrentTestCaseId = 5544;

            #region Arrange
            var loginPage = Pages.Login;
            var companiesPage = Pages.Companies;
            var propertiesPage = Pages.Properties;
            var propertyActivityPage = Pages.PropertyActivity;
            var propertyDetailsPage = Pages.PropertyDetails;
            var propertyGeneralItemsPage = Pages.GeneralItems;
            var propertyCreateGeneralItemsPage = Pages.CreateGeneralItems;
            #endregion

            #region Act
            Browser.GoToPage(loginPage);
            loginPage.SingIn(userName, userPass);
            companiesPage.SearchCompany(automationCompany);
            companiesPage.SelectCompany(automationCompany);
            propertiesPage.SelectProperty(automationProperty);
            propertyActivityPage.ClickSetupButton();
            propertyDetailsPage.SelectGeneralItemsOption();
            propertyGeneralItemsPage.ClickCreateNew();
            propertyCreateGeneralItemsPage.CompleteAVGeneralItem(generalitemName, generalitemValue1);
            propertyCreateGeneralItemsPage.ClickCancel();
            propertyGeneralItemsPage.SearchGeneralItem(generalitemName);
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual(0, propertyGeneralItemsPage.GridRowsCount);
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
        [TestProperty("Page", "Create General Item")]
        [Priority(1)]
        public void Setup_CreateAVGeneralItem()
        {
            CurrentTestCaseId = 5545;

            #region Arrange
            var loginPage = Pages.Login;
            var companiesPage = Pages.Companies;
            var propertiesPage = Pages.Properties;
            var propertyActivityPage = Pages.PropertyActivity;
            var propertyDetailsPage = Pages.PropertyDetails;
            var propertyGeneralItemsPage = Pages.GeneralItems;
            var propertyCreateGeneralItemsPage = Pages.CreateGeneralItems;
            #endregion

            #region Act
            Browser.GoToPage(loginPage);
            loginPage.SingIn(userName, userPass);
            companiesPage.SearchCompany(automationCompany);
            companiesPage.SelectCompany(automationCompany);
            propertiesPage.SelectProperty(automationProperty);
            propertyActivityPage.ClickSetupButton();
            propertyDetailsPage.SelectGeneralItemsOption();
            propertyGeneralItemsPage.ClickCreateNew();
            propertyCreateGeneralItemsPage.CompleteAVGeneralItem("AV" + "_" + generalitemName, generalitemValue1);
            propertyCreateGeneralItemsPage.ClickSave();
            propertyGeneralItemsPage.SearchGeneralItem("AV" + "_" + generalitemName);
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual("AV" + "_" + generalitemName, propertyGeneralItemsPage.SearchResult);
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
        [TestProperty("Page", "Create General Item")]
        [Priority(2)]
        public void Setup_CreateAVGeneralItemRequiredFields()
        {
            CurrentTestCaseId = 5624;

            #region Arrange
            var loginPage = Pages.Login;
            var companiesPage = Pages.Companies;
            var propertiesPage = Pages.Properties;
            var propertyActivityPage = Pages.PropertyActivity;
            var propertyDetailsPage = Pages.PropertyDetails;
            var propertyGeneralItemsPage = Pages.GeneralItems;
            var propertyCreateGeneralItemsPage = Pages.CreateGeneralItems;
            #endregion

            #region Act
            Browser.GoToPage(loginPage);
            loginPage.SingIn(userName, userPass);
            companiesPage.SearchCompany(automationCompany);
            companiesPage.SelectCompany(automationCompany);
            propertiesPage.SelectProperty(automationProperty);
            propertyActivityPage.ClickSetupButton();
            propertyDetailsPage.SelectGeneralItemsOption();
            propertyGeneralItemsPage.ClickCreateNew();
            propertyCreateGeneralItemsPage.CompleteAVGeneralItem(" ", " ");
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual(itemNameMsg, propertyCreateGeneralItemsPage.ItemNameMsg);
                Assert.AreEqual(itemValueMsg, propertyCreateGeneralItemsPage.ItemValueMsg);
                Assert.IsFalse(propertyCreateGeneralItemsPage.SaveButtonEnabled);
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
        [TestProperty("Page", "Create General Item")]
        [Priority(1)]
        public void Setup_CreateSurveyGeneralItem()
        {
            CurrentTestCaseId = 5625;

            #region Arrange
            var loginPage = Pages.Login;
            var companiesPage = Pages.Companies;
            var propertiesPage = Pages.Properties;
            var propertyActivityPage = Pages.PropertyActivity;
            var propertyDetailsPage = Pages.PropertyDetails;
            var propertyGeneralItemsPage = Pages.GeneralItems;
            var propertyCreateGeneralItemsPage = Pages.CreateGeneralItems;
            #endregion

            #region Act
            Browser.GoToPage(loginPage);
            loginPage.SingIn(userName, userPass);
            companiesPage.SearchCompany(automationCompany);
            companiesPage.SelectCompany(automationCompany);
            propertiesPage.SelectProperty(automationProperty);
            propertyActivityPage.ClickSetupButton();
            propertyDetailsPage.SelectGeneralItemsOption();
            propertyGeneralItemsPage.ClickCreateNew();
            propertyCreateGeneralItemsPage.ClickActionTypeOption("Survey");
            propertyCreateGeneralItemsPage.CompleteGeneralItem("Survey" + "_" + generalitemName);
            propertyCreateGeneralItemsPage.ClickSave();
            propertyGeneralItemsPage.SearchGeneralItem("Survey" + "_" + generalitemName);
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual("Survey" + "_" + generalitemName, propertyGeneralItemsPage.SearchResult);
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
        [TestProperty("Page", "Create General Item")]
        [Priority(1)]
        public void Setup_CreateCounterGeneralItem()
        {
            CurrentTestCaseId = 5659;

            #region Arrange
            var loginPage = Pages.Login;
            var companiesPage = Pages.Companies;
            var propertiesPage = Pages.Properties;
            var propertyActivityPage = Pages.PropertyActivity;
            var propertyDetailsPage = Pages.PropertyDetails;
            var propertyGeneralItemsPage = Pages.GeneralItems;
            var propertyCreateGeneralItemsPage = Pages.CreateGeneralItems;
            #endregion

            #region Act
            Browser.GoToPage(loginPage);
            loginPage.SingIn(userName, userPass);
            companiesPage.SearchCompany(automationCompany);
            companiesPage.SelectCompany(automationCompany);
            propertiesPage.SelectProperty(automationProperty);
            propertyActivityPage.ClickSetupButton();
            propertyDetailsPage.SelectGeneralItemsOption();
            propertyGeneralItemsPage.ClickCreateNew();
            propertyCreateGeneralItemsPage.ClickActionTypeOption("Counter");
            propertyCreateGeneralItemsPage.CompleteGeneralItem("Counter" + "_" + generalitemName);
            propertyCreateGeneralItemsPage.ClickSave();
            propertyGeneralItemsPage.SearchGeneralItem("Counter" + "_" + generalitemName);
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual("Counter" + "_" + generalitemName, propertyGeneralItemsPage.SearchResult);
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
        [TestProperty("Page", "Create General Item")]
        [Priority(1)]
        public void Setup_CreateDateGeneralItem()
        {
            CurrentTestCaseId = 5660;

            #region Arrange
            var loginPage = Pages.Login;
            var companiesPage = Pages.Companies;
            var propertiesPage = Pages.Properties;
            var propertyActivityPage = Pages.PropertyActivity;
            var propertyDetailsPage = Pages.PropertyDetails;
            var propertyGeneralItemsPage = Pages.GeneralItems;
            var propertyCreateGeneralItemsPage = Pages.CreateGeneralItems;
            #endregion

            #region Act
            Browser.GoToPage(loginPage);
            loginPage.SingIn(userName, userPass);
            companiesPage.SearchCompany(automationCompany);
            companiesPage.SelectCompany(automationCompany);
            propertiesPage.SelectProperty(automationProperty);
            propertyActivityPage.ClickSetupButton();
            propertyDetailsPage.SelectGeneralItemsOption();
            propertyGeneralItemsPage.ClickCreateNew();
            propertyCreateGeneralItemsPage.ClickActionTypeOption("Date");
            propertyCreateGeneralItemsPage.CompleteGeneralItem("Date" + "_" + generalitemName);
            propertyCreateGeneralItemsPage.ClickSave();
            propertyGeneralItemsPage.SearchGeneralItem("Date" + "_" + generalitemName);
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual("Date" + "_" + generalitemName, propertyGeneralItemsPage.SearchResult);
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
        [TestProperty("Page", "Create General Item")]
        [Priority(1)]
        public void Setup_CreatePettyCashGeneralItem()
        {
            CurrentTestCaseId = 5661;

            #region Arrange
            var loginPage = Pages.Login;
            var companiesPage = Pages.Companies;
            var propertiesPage = Pages.Properties;
            var propertyActivityPage = Pages.PropertyActivity;
            var propertyDetailsPage = Pages.PropertyDetails;
            var propertyGeneralItemsPage = Pages.GeneralItems;
            var propertyCreateGeneralItemsPage = Pages.CreateGeneralItems;
            #endregion

            #region Act
            Browser.GoToPage(loginPage);
            loginPage.SingIn(userName, userPass);
            companiesPage.SearchCompany(automationCompany);
            companiesPage.SelectCompany(automationCompany);
            propertiesPage.SelectProperty(automationProperty);
            propertyActivityPage.ClickSetupButton();
            propertyDetailsPage.SelectGeneralItemsOption();
            propertyGeneralItemsPage.ClickCreateNew();
            propertyCreateGeneralItemsPage.ClickActionTypeOption("Petty Cash");
            propertyCreateGeneralItemsPage.CompleteGeneralItem("Petty_Cash" + "_" + generalitemName);
            propertyCreateGeneralItemsPage.ClickSave();
            propertyGeneralItemsPage.SearchGeneralItem("Petty_Cash" + "_" + generalitemName);
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual("Petty_Cash" + "_" + generalitemName, propertyGeneralItemsPage.SearchResult);
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
