using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InfoTycoon.ProjectToTest;
using InfoTycoon.Fwk.TestAutomation;
using System.Threading;
using System.Configuration;
using InfoTycoon.Fwk.TestAutomation.Helpers;

namespace InfoTycoon.Test._04.Setup
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
        static string automationGeneralCategory;
        static string propertyAddress1;
        static string generalItemName;
        static string interiorItemName;
        static string exteriorItemName;
        static string generalCategoryName;
        static string itemValue1;
        static string propertyNameMsg;
        static string itemNameMsg;
        static string itemValueMsg;
        static string categoryNameMsg;
        static string categoryTypeMsg;
        static string toastSuccessTitle;
        static string toastEditPropertyMsg;
        static string toastNewGeneralItemMsg;
        static string toastNewInteriorItemMsg;
        static string toastNewExteriorItemMsg;
        static string toastNewGeneralCategoryMsg;
        #endregion

        #region Report settings
        public TestContext TestContext { get; set; }
        private ReportHelper reportHelper = new ReportHelper();
        #endregion

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            #region Initialize variables
            date = DateTime.Now.ToString("HHmmss_yyyyMMdd_");
            userName = ConfigurationManager.AppSettings["UserName"];
            userPass = ConfigurationManager.AppSettings["UserPass"];
            userFullName = ConfigurationManager.AppSettings["FullName"];
            automationCompany = ConfigurationManager.AppSettings["AutomationCompany"];
            automationProperty = ConfigurationManager.AppSettings["AutomationProperty"];
            automationGeneralCategory = ConfigurationManager.AppSettings["AutomationGeneralCategory"];
            propertyAddress1 = ConfigurationManager.AppSettings["Address1"];
            generalItemName = date + ConfigurationManager.AppSettings["GeneralItemName"];
            interiorItemName = date + ConfigurationManager.AppSettings["InteriorItemName"];
            exteriorItemName = date + ConfigurationManager.AppSettings["ExteriorItemName"];
            generalCategoryName = date + ConfigurationManager.AppSettings["GeneralCategoryName"];
            itemValue1 = ConfigurationManager.AppSettings["ItemValue1"];
            propertyNameMsg = ConfigurationManager.AppSettings["MsgPropertyName"];
            itemNameMsg = ConfigurationManager.AppSettings["MsgItemName"];
            itemValueMsg = ConfigurationManager.AppSettings["MsgItemValue"];
            categoryNameMsg = ConfigurationManager.AppSettings["MsgCategoryName"];
            categoryTypeMsg = ConfigurationManager.AppSettings["MsgCategoryType"];
            toastSuccessTitle = ConfigurationManager.AppSettings["ToastSuccessTitle"];
            toastEditPropertyMsg = ConfigurationManager.AppSettings["ToastEditPropertyMsg"];
            toastNewGeneralItemMsg = ConfigurationManager.AppSettings["ToastNewGeneralItemMsg"];
            toastNewInteriorItemMsg = ConfigurationManager.AppSettings["ToastNewInteriorItemMsg"];
            toastNewExteriorItemMsg = ConfigurationManager.AppSettings["ToastNewExteriorItemMsg"];
            toastNewGeneralCategoryMsg = ConfigurationManager.AppSettings["ToastNewGeneralCategoryMsg"];
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
        [TestProperty("Page", "Create General Items")]
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
        [TestProperty("Page", "Create General Items")]
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
            propertyCreateGeneralItemsPage.CompleteAVGeneralItem(generalItemName, itemValue1);
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
        [TestProperty("Page", "Create General Items")]
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
            propertyCreateGeneralItemsPage.CompleteAVGeneralItem(generalItemName, itemValue1);
            propertyCreateGeneralItemsPage.ClickCancel();
            propertyGeneralItemsPage.SearchGeneralItem(generalItemName);
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
        [TestProperty("Page", "Create General Items")]
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
            propertyCreateGeneralItemsPage.CompleteAVGeneralItem("AV" + "_" + generalItemName, itemValue1);
            propertyCreateGeneralItemsPage.ClickSave();
            propertyGeneralItemsPage.SearchGeneralItem("AV" + "_" + generalItemName);
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual("AV" + "_" + generalItemName, propertyGeneralItemsPage.SearchResult);
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
        [TestProperty("Page", "Create General Items")]
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
        [TestProperty("Page", "Create General Items")]
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
            propertyCreateGeneralItemsPage.CompleteGeneralItem("Survey" + "_" + generalItemName);
            propertyCreateGeneralItemsPage.ClickSave();
            propertyGeneralItemsPage.SearchGeneralItem("Survey" + "_" + generalItemName);
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual("Survey" + "_" + generalItemName, propertyGeneralItemsPage.SearchResult);
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
        public void Setup_CreateSurveyGeneralItemRequiredFields()
        {
            CurrentTestCaseId = 5724;

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
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual(itemNameMsg, propertyCreateGeneralItemsPage.ItemNameMsg);
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
        [TestProperty("Page", "Create General Items")]
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
            propertyCreateGeneralItemsPage.CompleteGeneralItem("Counter" + "_" + generalItemName);
            propertyCreateGeneralItemsPage.ClickSave();
            propertyGeneralItemsPage.SearchGeneralItem("Counter" + "_" + generalItemName);
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual("Counter" + "_" + generalItemName, propertyGeneralItemsPage.SearchResult);
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
        [TestProperty("Page", "Create General Items")]
        [Priority(2)]
        public void Setup_CreateCounterGeneralItemRequiredFields()
        {
            CurrentTestCaseId = 5776;

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
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual(itemNameMsg, propertyCreateGeneralItemsPage.ItemNameMsg);
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
        [TestProperty("Page", "Create General Items")]
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
            propertyCreateGeneralItemsPage.CompleteGeneralItem("Date" + "_" + generalItemName);
            propertyCreateGeneralItemsPage.ClickSave();
            propertyGeneralItemsPage.SearchGeneralItem("Date" + "_" + generalItemName);
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual("Date" + "_" + generalItemName, propertyGeneralItemsPage.SearchResult);
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
        [TestProperty("Page", "Create General Items")]
        [Priority(2)]
        public void Setup_CreateDateGeneralItemRequiredFields()
        {
            CurrentTestCaseId = 5777;

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
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual(itemNameMsg, propertyCreateGeneralItemsPage.ItemNameMsg);
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
        [TestProperty("Page", "Create General Items")]
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
            propertyCreateGeneralItemsPage.CompleteGeneralItem("Petty_Cash" + "_" + generalItemName);
            propertyCreateGeneralItemsPage.ClickSave();
            propertyGeneralItemsPage.SearchGeneralItem("Petty_Cash" + "_" + generalItemName);
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual("Petty_Cash" + "_" + generalItemName, propertyGeneralItemsPage.SearchResult);
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
        [TestProperty("Page", "Create General Items")]
        [Priority(2)]
        public void Setup_CreatePettyCashGeneralItemRequiredFields()
        {
            CurrentTestCaseId = 5778;

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
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual(itemNameMsg, propertyCreateGeneralItemsPage.ItemNameMsg);
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
        [TestProperty("Page", "Interior Items")]
        [Priority(1)]
        public void Setup_InteriorItemsUI()
        {
            CurrentTestCaseId = 6432;

            #region Arrange
            var loginPage = Pages.Login;
            var companiesPage = Pages.Companies;
            var propertiesPage = Pages.Properties;
            var propertyActivityPage = Pages.PropertyActivity;
            var propertyDetailsPage = Pages.PropertyDetails;
            var propertyInteriorItemsPage = Pages.InteriorItems;
            #endregion

            #region Act
            Browser.GoToPage(loginPage);
            loginPage.SingIn(userName, userPass);
            companiesPage.SearchCompany(automationCompany);
            companiesPage.SelectCompany(automationCompany);
            propertiesPage.SelectProperty(automationProperty);
            propertyActivityPage.ClickSetupButton();
            propertyDetailsPage.SelectInteriorItemsOption();
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual(automationProperty, propertyInteriorItemsPage.PageBreadCrumb);
                Assert.AreEqual(propertyInteriorItemsPage.Title, propertyInteriorItemsPage.PageHeader);
                Assert.IsTrue(propertyInteriorItemsPage.SideMenuActiveButton);
                Assert.IsNotNull(propertyInteriorItemsPage.CreateNewButton);
                Assert.IsNotNull(propertyInteriorItemsPage.CloneButton);
                Assert.IsNotNull(propertyInteriorItemsPage.ApplyToCategoriesButton);
                Assert.IsNotNull(propertyInteriorItemsPage.PropertiesButton);
                Assert.IsNotNull(propertyInteriorItemsPage.ActivityButton);
                Assert.IsNotNull(propertyInteriorItemsPage.InspectionsButton);
                Assert.IsNotNull(propertyInteriorItemsPage.LFAButton);
                Assert.IsNotNull(propertyInteriorItemsPage.SetupButton);
                Assert.IsNotNull(propertyInteriorItemsPage.ReportsButton);
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
        [TestProperty("Page", "Create Interior Items")]
        [Priority(1)]
        public void Setup_CreateInteriorItemUI()
        {
            CurrentTestCaseId = 6433;

            #region Arrange
            var loginPage = Pages.Login;
            var companiesPage = Pages.Companies;
            var propertiesPage = Pages.Properties;
            var propertyActivityPage = Pages.PropertyActivity;
            var propertyDetailsPage = Pages.PropertyDetails;
            var propertyInteriorItemsPage = Pages.InteriorItems;
            var propertyCreateInteriorItemsPage = Pages.CreateInteriorItems;
            #endregion

            #region Act
            Browser.GoToPage(loginPage);
            loginPage.SingIn(userName, userPass);
            companiesPage.SearchCompany(automationCompany);
            companiesPage.SelectCompany(automationCompany);
            propertiesPage.SelectProperty(automationProperty);
            propertyActivityPage.ClickSetupButton();
            propertyDetailsPage.SelectInteriorItemsOption();
            propertyInteriorItemsPage.ClickCreateNew();
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual(automationProperty, propertyCreateInteriorItemsPage.PageBreadCrumb);
                Assert.AreEqual(propertyCreateInteriorItemsPage.Title, propertyCreateInteriorItemsPage.PageHeader);
                Assert.IsTrue(propertyCreateInteriorItemsPage.SideMenuActiveButton);
                Assert.IsFalse(propertyCreateInteriorItemsPage.SaveButtonEnabled);
                Assert.IsNotNull(propertyCreateInteriorItemsPage.SaveButton);
                Assert.IsNotNull(propertyCreateInteriorItemsPage.CancelButton);
                Assert.IsNotNull(propertyCreateInteriorItemsPage.ActionTypeField);
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
        [TestProperty("Page", "Create Interior Items")]
        [Priority(2)]
        public void Setup_CreateInteriorItemConfirmationMessage()
        {
            CurrentTestCaseId = 6434;

            #region Arrange
            var loginPage = Pages.Login;
            var companiesPage = Pages.Companies;
            var propertiesPage = Pages.Properties;
            var propertyActivityPage = Pages.PropertyActivity;
            var propertyDetailsPage = Pages.PropertyDetails;
            var propertyInteriorItemsPage = Pages.InteriorItems;
            var propertyCreateInteriorItemsPage = Pages.CreateInteriorItems;
            #endregion

            #region Act
            Browser.GoToPage(loginPage);
            loginPage.SingIn(userName, userPass);
            companiesPage.SearchCompany(automationCompany);
            companiesPage.SelectCompany(automationCompany);
            propertiesPage.SelectProperty(automationProperty);
            propertyActivityPage.ClickSetupButton();
            propertyDetailsPage.SelectInteriorItemsOption();
            propertyInteriorItemsPage.ClickCreateNew();
            propertyCreateInteriorItemsPage.CompleteAVInteriorItem(interiorItemName, itemValue1);
            propertyCreateInteriorItemsPage.ClickSave();
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual(toastSuccessTitle, propertyInteriorItemsPage.ToastTitle);
                Assert.AreEqual(toastNewInteriorItemMsg, propertyInteriorItemsPage.ToastMsg);
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
        [TestProperty("Page", "Create Interior Items")]
        [Priority(3)]
        public void Setup_CancelInteriortemCreation()
        {
            CurrentTestCaseId = 6435;

            #region Arrange
            var loginPage = Pages.Login;
            var companiesPage = Pages.Companies;
            var propertiesPage = Pages.Properties;
            var propertyActivityPage = Pages.PropertyActivity;
            var propertyDetailsPage = Pages.PropertyDetails;
            var propertyInteriorItemsPage = Pages.InteriorItems;
            var propertyCreateInteriorItemsPage = Pages.CreateInteriorItems;
            #endregion

            #region Act
            Browser.GoToPage(loginPage);
            loginPage.SingIn(userName, userPass);
            companiesPage.SearchCompany(automationCompany);
            companiesPage.SelectCompany(automationCompany);
            propertiesPage.SelectProperty(automationProperty);
            propertyActivityPage.ClickSetupButton();
            propertyDetailsPage.SelectInteriorItemsOption();
            propertyInteriorItemsPage.ClickCreateNew();
            propertyCreateInteriorItemsPage.CompleteAVInteriorItem(interiorItemName, itemValue1);
            propertyCreateInteriorItemsPage.ClickCancel();
            propertyInteriorItemsPage.SearchInteriorItem(interiorItemName);
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual(0, propertyInteriorItemsPage.GridRowsCount);
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
        [TestProperty("Page", "Create Interior Items")]
        [Priority(1)]
        public void Setup_CreateAVInteriorItem()
        {
            CurrentTestCaseId = 6436;

            #region Arrange
            var loginPage = Pages.Login;
            var companiesPage = Pages.Companies;
            var propertiesPage = Pages.Properties;
            var propertyActivityPage = Pages.PropertyActivity;
            var propertyDetailsPage = Pages.PropertyDetails;
            var propertyInteriorItemsPage = Pages.InteriorItems;
            var propertyCreateInteriorItemsPage = Pages.CreateInteriorItems;
            #endregion

            #region Act
            Browser.GoToPage(loginPage);
            loginPage.SingIn(userName, userPass);
            companiesPage.SearchCompany(automationCompany);
            companiesPage.SelectCompany(automationCompany);
            propertiesPage.SelectProperty(automationProperty);
            propertyActivityPage.ClickSetupButton();
            propertyDetailsPage.SelectInteriorItemsOption();
            propertyInteriorItemsPage.ClickCreateNew();
            propertyCreateInteriorItemsPage.CompleteAVInteriorItem("AV" + "_" + interiorItemName, itemValue1);
            propertyCreateInteriorItemsPage.ClickSave();
            propertyInteriorItemsPage.SearchInteriorItem("AV" + "_" + interiorItemName);
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual("AV" + "_" + interiorItemName, propertyInteriorItemsPage.SearchResult);
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
        [TestProperty("Page", "Create Interior Items")]
        [Priority(2)]
        public void Setup_CreateAVInteriorItemRequiredFields()
        {
            CurrentTestCaseId = 6437;

            #region Arrange
            var loginPage = Pages.Login;
            var companiesPage = Pages.Companies;
            var propertiesPage = Pages.Properties;
            var propertyActivityPage = Pages.PropertyActivity;
            var propertyDetailsPage = Pages.PropertyDetails;
            var propertyInteriorItemsPage = Pages.InteriorItems;
            var propertyCreateInteriorItemsPage = Pages.CreateInteriorItems;
            #endregion

            #region Act
            Browser.GoToPage(loginPage);
            loginPage.SingIn(userName, userPass);
            companiesPage.SearchCompany(automationCompany);
            companiesPage.SelectCompany(automationCompany);
            propertiesPage.SelectProperty(automationProperty);
            propertyActivityPage.ClickSetupButton();
            propertyDetailsPage.SelectInteriorItemsOption();
            propertyInteriorItemsPage.ClickCreateNew();
            propertyCreateInteriorItemsPage.CompleteAVInteriorItem(" ", " ");
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual(itemNameMsg, propertyCreateInteriorItemsPage.ItemNameMsg);
                Assert.AreEqual(itemValueMsg, propertyCreateInteriorItemsPage.ItemValueMsg);
                Assert.IsFalse(propertyCreateInteriorItemsPage.SaveButtonEnabled);
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
        [TestProperty("Page", "Create Interior Items")]
        [Priority(2)]
        public void Setup_AVInteriorItemIsConditionCheck()
        {
            CurrentTestCaseId = 6438;

            #region Arrange
            var loginPage = Pages.Login;
            var companiesPage = Pages.Companies;
            var propertiesPage = Pages.Properties;
            var propertyActivityPage = Pages.PropertyActivity;
            var propertyDetailsPage = Pages.PropertyDetails;
            var propertyInteriorItemsPage = Pages.InteriorItems;
            var propertyCreateInteriorItemsPage = Pages.CreateInteriorItems;
            #endregion

            #region Act
            Browser.GoToPage(loginPage);
            loginPage.SingIn(userName, userPass);
            companiesPage.SearchCompany(automationCompany);
            companiesPage.SelectCompany(automationCompany);
            propertiesPage.SelectProperty(automationProperty);
            propertyActivityPage.ClickSetupButton();
            propertyDetailsPage.SelectInteriorItemsOption();
            propertyInteriorItemsPage.ClickCreateNew();
            propertyCreateInteriorItemsPage.CompleteAVInteriorItem("Condition" + "_" + interiorItemName, itemValue1);
            propertyCreateInteriorItemsPage.ClickCondition();
            #endregion

            #region Assert
            try
            {
                Assert.IsNotNull(propertyCreateInteriorItemsPage.AssociateItemsContainer);
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
        [TestProperty("Page", "Create Interior Items")]
        [Priority(2)]
        public void Setup_CreateAVInteriorItemIsCondition()
        {
            CurrentTestCaseId = 6439;

            #region Arrange
            var loginPage = Pages.Login;
            var companiesPage = Pages.Companies;
            var propertiesPage = Pages.Properties;
            var propertyActivityPage = Pages.PropertyActivity;
            var propertyDetailsPage = Pages.PropertyDetails;
            var propertyInteriorItemsPage = Pages.InteriorItems;
            var propertyCreateInteriorItemsPage = Pages.CreateInteriorItems;
            #endregion

            #region Act
            Browser.GoToPage(loginPage);
            loginPage.SingIn(userName, userPass);
            companiesPage.SearchCompany(automationCompany);
            companiesPage.SelectCompany(automationCompany);
            propertiesPage.SelectProperty(automationProperty);
            propertyActivityPage.ClickSetupButton();
            propertyDetailsPage.SelectInteriorItemsOption();
            propertyInteriorItemsPage.ClickCreateNew();
            propertyCreateInteriorItemsPage.CompleteAVInteriorItem("Condition" + "_" + interiorItemName, itemValue1);
            propertyCreateInteriorItemsPage.ClickCondition();
            propertyCreateInteriorItemsPage.ClickMoveAll();
            propertyCreateInteriorItemsPage.ClickSave();
            propertyInteriorItemsPage.SearchInteriorItem("Condition" + "_" + interiorItemName);
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual("Condition" + "_" + interiorItemName, propertyInteriorItemsPage.SearchResult);
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
        [TestProperty("Page", "Create Interior Items")]
        [Priority(1)]
        public void Setup_CreateCounterInteriorItem()
        {
            CurrentTestCaseId = 6440;

            #region Arrange
            var loginPage = Pages.Login;
            var companiesPage = Pages.Companies;
            var propertiesPage = Pages.Properties;
            var propertyActivityPage = Pages.PropertyActivity;
            var propertyDetailsPage = Pages.PropertyDetails;
            var propertyInteriorItemsPage = Pages.InteriorItems;
            var propertyCreateInteriorItemsPage = Pages.CreateInteriorItems;
            #endregion

            #region Act
            Browser.GoToPage(loginPage);
            loginPage.SingIn(userName, userPass);
            companiesPage.SearchCompany(automationCompany);
            companiesPage.SelectCompany(automationCompany);
            propertiesPage.SelectProperty(automationProperty);
            propertyActivityPage.ClickSetupButton();
            propertyDetailsPage.SelectInteriorItemsOption();
            propertyInteriorItemsPage.ClickCreateNew();
            propertyCreateInteriorItemsPage.ClickActionTypeOption("Counter");
            propertyCreateInteriorItemsPage.CompleteInteriorItem("Counter" + "_" + interiorItemName);
            propertyCreateInteriorItemsPage.ClickSave();
            propertyInteriorItemsPage.SearchInteriorItem("Counter" + "_" + interiorItemName);
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual("Counter" + "_" + interiorItemName, propertyInteriorItemsPage.SearchResult);
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
        [TestProperty("Page", "Create Interior Items")]
        [Priority(2)]
        public void Setup_CreateCounterInteriorItemRequiredFields()
        {
            CurrentTestCaseId = 6441;

            #region Arrange
            var loginPage = Pages.Login;
            var companiesPage = Pages.Companies;
            var propertiesPage = Pages.Properties;
            var propertyActivityPage = Pages.PropertyActivity;
            var propertyDetailsPage = Pages.PropertyDetails;
            var propertyInteriorItemsPage = Pages.InteriorItems;
            var propertyCreateInteriorItemsPage = Pages.CreateInteriorItems;
            #endregion

            #region Act
            Browser.GoToPage(loginPage);
            loginPage.SingIn(userName, userPass);
            companiesPage.SearchCompany(automationCompany);
            companiesPage.SelectCompany(automationCompany);
            propertiesPage.SelectProperty(automationProperty);
            propertyActivityPage.ClickSetupButton();
            propertyDetailsPage.SelectInteriorItemsOption();
            propertyInteriorItemsPage.ClickCreateNew();
            propertyCreateInteriorItemsPage.ClickActionTypeOption("Counter");
            propertyCreateInteriorItemsPage.CompleteInteriorItem(" ");
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual(itemNameMsg, propertyCreateInteriorItemsPage.ItemNameMsg);
                Assert.IsFalse(propertyCreateInteriorItemsPage.SaveButtonEnabled);
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
        [TestProperty("Page", "Create Interior Items")]
        [Priority(1)]
        public void Setup_CreateDateInteriorItem()
        {
            CurrentTestCaseId = 6442;

            #region Arrange
            var loginPage = Pages.Login;
            var companiesPage = Pages.Companies;
            var propertiesPage = Pages.Properties;
            var propertyActivityPage = Pages.PropertyActivity;
            var propertyDetailsPage = Pages.PropertyDetails;
            var propertyInteriorItemsPage = Pages.InteriorItems;
            var propertyCreateInteriorItemsPage = Pages.CreateInteriorItems;
            #endregion

            #region Act
            Browser.GoToPage(loginPage);
            loginPage.SingIn(userName, userPass);
            companiesPage.SearchCompany(automationCompany);
            companiesPage.SelectCompany(automationCompany);
            propertiesPage.SelectProperty(automationProperty);
            propertyActivityPage.ClickSetupButton();
            propertyDetailsPage.SelectInteriorItemsOption();
            propertyInteriorItemsPage.ClickCreateNew();
            propertyCreateInteriorItemsPage.ClickActionTypeOption("Date");
            propertyCreateInteriorItemsPage.CompleteInteriorItem("Date" + "_" + interiorItemName);
            propertyCreateInteriorItemsPage.ClickSave();
            propertyInteriorItemsPage.SearchInteriorItem("Date" + "_" + interiorItemName);
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual("Date" + "_" + interiorItemName, propertyInteriorItemsPage.SearchResult);
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
        [TestProperty("Page", "Create Interior Items")]
        [Priority(2)]
        public void Setup_CreateDateInteriorItemRequiredFields()
        {
            CurrentTestCaseId = 6443;

            #region Arrange
            var loginPage = Pages.Login;
            var companiesPage = Pages.Companies;
            var propertiesPage = Pages.Properties;
            var propertyActivityPage = Pages.PropertyActivity;
            var propertyDetailsPage = Pages.PropertyDetails;
            var propertyInteriorItemsPage = Pages.InteriorItems;
            var propertyCreateInteriorItemsPage = Pages.CreateInteriorItems;
            #endregion

            #region Act
            Browser.GoToPage(loginPage);
            loginPage.SingIn(userName, userPass);
            companiesPage.SearchCompany(automationCompany);
            companiesPage.SelectCompany(automationCompany);
            propertiesPage.SelectProperty(automationProperty);
            propertyActivityPage.ClickSetupButton();
            propertyDetailsPage.SelectInteriorItemsOption();
            propertyInteriorItemsPage.ClickCreateNew();
            propertyCreateInteriorItemsPage.ClickActionTypeOption("Date");
            propertyCreateInteriorItemsPage.CompleteInteriorItem(" ");
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual(itemNameMsg, propertyCreateInteriorItemsPage.ItemNameMsg);
                Assert.IsFalse(propertyCreateInteriorItemsPage.SaveButtonEnabled);
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
        [TestProperty("Page", "Create Interior Items")]
        [Priority(1)]
        public void Setup_CreateStatusInteriorItem()
        {
            CurrentTestCaseId = 6444;

            #region Arrange
            var loginPage = Pages.Login;
            var companiesPage = Pages.Companies;
            var propertiesPage = Pages.Properties;
            var propertyActivityPage = Pages.PropertyActivity;
            var propertyDetailsPage = Pages.PropertyDetails;
            var propertyInteriorItemsPage = Pages.InteriorItems;
            var propertyCreateInteriorItemsPage = Pages.CreateInteriorItems;
            #endregion

            #region Act
            Browser.GoToPage(loginPage);
            loginPage.SingIn(userName, userPass);
            companiesPage.SearchCompany(automationCompany);
            companiesPage.SelectCompany(automationCompany);
            propertiesPage.SelectProperty(automationProperty);
            propertyActivityPage.ClickSetupButton();
            propertyDetailsPage.SelectInteriorItemsOption();
            propertyInteriorItemsPage.ClickCreateNew();
            propertyCreateInteriorItemsPage.ClickActionTypeOption("Status");
            propertyCreateInteriorItemsPage.CompleteInteriorItem("Status" + "_" + interiorItemName);
            propertyCreateInteriorItemsPage.ClickSave();
            propertyInteriorItemsPage.SearchInteriorItem("Status" + "_" + interiorItemName);
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual("Status" + "_" + interiorItemName, propertyInteriorItemsPage.SearchResult);
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
        [TestProperty("Page", "Create Interior Items")]
        [Priority(2)]
        public void Setup_CreateStatusInteriorItemRequiredFields()
        {
            CurrentTestCaseId = 6445;

            #region Arrange
            var loginPage = Pages.Login;
            var companiesPage = Pages.Companies;
            var propertiesPage = Pages.Properties;
            var propertyActivityPage = Pages.PropertyActivity;
            var propertyDetailsPage = Pages.PropertyDetails;
            var propertyInteriorItemsPage = Pages.InteriorItems;
            var propertyCreateInteriorItemsPage = Pages.CreateInteriorItems;
            #endregion

            #region Act
            Browser.GoToPage(loginPage);
            loginPage.SingIn(userName, userPass);
            companiesPage.SearchCompany(automationCompany);
            companiesPage.SelectCompany(automationCompany);
            propertiesPage.SelectProperty(automationProperty);
            propertyActivityPage.ClickSetupButton();
            propertyDetailsPage.SelectInteriorItemsOption();
            propertyInteriorItemsPage.ClickCreateNew();
            propertyCreateInteriorItemsPage.ClickActionTypeOption("Status");
            propertyCreateInteriorItemsPage.CompleteInteriorItem(" ");
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual(itemNameMsg, propertyCreateInteriorItemsPage.ItemNameMsg);
                Assert.IsFalse(propertyCreateInteriorItemsPage.SaveButtonEnabled);
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
        [TestProperty("Page", "Create Interior Items")]
        [Priority(1)]
        public void Setup_CreatePassFailInteriorItem()
        {
            CurrentTestCaseId = 6446;

            #region Arrange
            var loginPage = Pages.Login;
            var companiesPage = Pages.Companies;
            var propertiesPage = Pages.Properties;
            var propertyActivityPage = Pages.PropertyActivity;
            var propertyDetailsPage = Pages.PropertyDetails;
            var propertyInteriorItemsPage = Pages.InteriorItems;
            var propertyCreateInteriorItemsPage = Pages.CreateInteriorItems;
            #endregion

            #region Act
            Browser.GoToPage(loginPage);
            loginPage.SingIn(userName, userPass);
            companiesPage.SearchCompany(automationCompany);
            companiesPage.SelectCompany(automationCompany);
            propertiesPage.SelectProperty(automationProperty);
            propertyActivityPage.ClickSetupButton();
            propertyDetailsPage.SelectInteriorItemsOption();
            propertyInteriorItemsPage.ClickCreateNew();
            propertyCreateInteriorItemsPage.ClickActionTypeOption("PassFail");
            propertyCreateInteriorItemsPage.CompleteInteriorItem("PassFail" + "_" + interiorItemName);
            propertyCreateInteriorItemsPage.ClickSave();
            propertyInteriorItemsPage.SearchInteriorItem("PassFail" + "_" + interiorItemName);
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual("PassFail" + "_" + interiorItemName, propertyInteriorItemsPage.SearchResult);
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
        [TestProperty("Page", "Create Interior Items")]
        [Priority(2)]
        public void Setup_CreatePassFailInteriorItemRequiredFields()
        {
            CurrentTestCaseId = 6447;

            #region Arrange
            var loginPage = Pages.Login;
            var companiesPage = Pages.Companies;
            var propertiesPage = Pages.Properties;
            var propertyActivityPage = Pages.PropertyActivity;
            var propertyDetailsPage = Pages.PropertyDetails;
            var propertyInteriorItemsPage = Pages.InteriorItems;
            var propertyCreateInteriorItemsPage = Pages.CreateInteriorItems;
            #endregion

            #region Act
            Browser.GoToPage(loginPage);
            loginPage.SingIn(userName, userPass);
            companiesPage.SearchCompany(automationCompany);
            companiesPage.SelectCompany(automationCompany);
            propertiesPage.SelectProperty(automationProperty);
            propertyActivityPage.ClickSetupButton();
            propertyDetailsPage.SelectInteriorItemsOption();
            propertyInteriorItemsPage.ClickCreateNew();
            propertyCreateInteriorItemsPage.ClickActionTypeOption("PassFail");
            propertyCreateInteriorItemsPage.CompleteInteriorItem(" ");
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual(itemNameMsg, propertyCreateInteriorItemsPage.ItemNameMsg);
                Assert.IsFalse(propertyCreateInteriorItemsPage.SaveButtonEnabled);
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
        [TestProperty("Page", "Create Interior Items")]
        [Priority(1)]
        public void Setup_CreateSignatureInteriorItem()
        {
            CurrentTestCaseId = 6448;

            #region Arrange
            var loginPage = Pages.Login;
            var companiesPage = Pages.Companies;
            var propertiesPage = Pages.Properties;
            var propertyActivityPage = Pages.PropertyActivity;
            var propertyDetailsPage = Pages.PropertyDetails;
            var propertyInteriorItemsPage = Pages.InteriorItems;
            var propertyCreateInteriorItemsPage = Pages.CreateInteriorItems;
            #endregion

            #region Act
            Browser.GoToPage(loginPage);
            loginPage.SingIn(userName, userPass);
            companiesPage.SearchCompany(automationCompany);
            companiesPage.SelectCompany(automationCompany);
            propertiesPage.SelectProperty(automationProperty);
            propertyActivityPage.ClickSetupButton();
            propertyDetailsPage.SelectInteriorItemsOption();
            propertyInteriorItemsPage.ClickCreateNew();
            propertyCreateInteriorItemsPage.ClickActionTypeOption("Signature");
            propertyCreateInteriorItemsPage.CompleteInteriorItem("Signature" + "_" + interiorItemName);
            propertyCreateInteriorItemsPage.ClickSave();
            propertyInteriorItemsPage.SearchInteriorItem("Signature" + "_" + interiorItemName);
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual("Signature" + "_" + interiorItemName, propertyInteriorItemsPage.SearchResult);
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
        [TestProperty("Page", "Create Interior Items")]
        [Priority(2)]
        public void Setup_CreateSignatureInteriorItemRequiredFields()
        {
            CurrentTestCaseId = 6449;

            #region Arrange
            var loginPage = Pages.Login;
            var companiesPage = Pages.Companies;
            var propertiesPage = Pages.Properties;
            var propertyActivityPage = Pages.PropertyActivity;
            var propertyDetailsPage = Pages.PropertyDetails;
            var propertyInteriorItemsPage = Pages.InteriorItems;
            var propertyCreateInteriorItemsPage = Pages.CreateInteriorItems;
            #endregion

            #region Act
            Browser.GoToPage(loginPage);
            loginPage.SingIn(userName, userPass);
            companiesPage.SearchCompany(automationCompany);
            companiesPage.SelectCompany(automationCompany);
            propertiesPage.SelectProperty(automationProperty);
            propertyActivityPage.ClickSetupButton();
            propertyDetailsPage.SelectInteriorItemsOption();
            propertyInteriorItemsPage.ClickCreateNew();
            propertyCreateInteriorItemsPage.ClickActionTypeOption("Signature");
            propertyCreateInteriorItemsPage.CompleteInteriorItem(" ");
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual(itemNameMsg, propertyCreateInteriorItemsPage.ItemNameMsg);
                Assert.IsFalse(propertyCreateInteriorItemsPage.SaveButtonEnabled);
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
        [TestProperty("Page", "Exterior Items")]
        [Priority(1)]
        public void Setup_ExteriorItemsUI()
        {
            CurrentTestCaseId = 6741;

            #region Arrange
            var loginPage = Pages.Login;
            var companiesPage = Pages.Companies;
            var propertiesPage = Pages.Properties;
            var propertyActivityPage = Pages.PropertyActivity;
            var propertyDetailsPage = Pages.PropertyDetails;
            var propertyExteriorItemsPage = Pages.ExteriorItems;
            #endregion

            #region Act
            Browser.GoToPage(loginPage);
            loginPage.SingIn(userName, userPass);
            companiesPage.SearchCompany(automationCompany);
            companiesPage.SelectCompany(automationCompany);
            propertiesPage.SelectProperty(automationProperty);
            propertyActivityPage.ClickSetupButton();
            propertyDetailsPage.SelectExteriorItemsOption();
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual(automationProperty, propertyExteriorItemsPage.PageBreadCrumb);
                Assert.AreEqual(propertyExteriorItemsPage.Title, propertyExteriorItemsPage.PageHeader);
                Assert.IsTrue(propertyExteriorItemsPage.SideMenuActiveButton);
                Assert.IsNotNull(propertyExteriorItemsPage.CreateNewButton);
                Assert.IsNotNull(propertyExteriorItemsPage.CloneButton);
                Assert.IsNotNull(propertyExteriorItemsPage.ApplyToCategoriesButton);
                Assert.IsNotNull(propertyExteriorItemsPage.PropertiesButton);
                Assert.IsNotNull(propertyExteriorItemsPage.ActivityButton);
                Assert.IsNotNull(propertyExteriorItemsPage.InspectionsButton);
                Assert.IsNotNull(propertyExteriorItemsPage.LFAButton);
                Assert.IsNotNull(propertyExteriorItemsPage.SetupButton);
                Assert.IsNotNull(propertyExteriorItemsPage.ReportsButton);
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
        [TestProperty("Page", "Create Exterior Items")]
        [Priority(1)]
        public void Setup_CreateExteriorItemUI()
        {
            CurrentTestCaseId = 6742;

            #region Arrange
            var loginPage = Pages.Login;
            var companiesPage = Pages.Companies;
            var propertiesPage = Pages.Properties;
            var propertyActivityPage = Pages.PropertyActivity;
            var propertyDetailsPage = Pages.PropertyDetails;
            var propertyExteriorItemsPage = Pages.ExteriorItems;
            var propertyCreateExteriorItemsPage = Pages.CreateExteriorItems;
            #endregion

            #region Act
            Browser.GoToPage(loginPage);
            loginPage.SingIn(userName, userPass);
            companiesPage.SearchCompany(automationCompany);
            companiesPage.SelectCompany(automationCompany);
            propertiesPage.SelectProperty(automationProperty);
            propertyActivityPage.ClickSetupButton();
            propertyDetailsPage.SelectExteriorItemsOption();
            propertyExteriorItemsPage.ClickCreateNew();
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual(automationProperty, propertyCreateExteriorItemsPage.PageBreadCrumb);
                Assert.AreEqual(propertyCreateExteriorItemsPage.Title, propertyCreateExteriorItemsPage.PageHeader);
                Assert.IsTrue(propertyCreateExteriorItemsPage.SideMenuActiveButton);
                Assert.IsFalse(propertyCreateExteriorItemsPage.SaveButtonEnabled);
                Assert.IsNotNull(propertyCreateExteriorItemsPage.SaveButton);
                Assert.IsNotNull(propertyCreateExteriorItemsPage.BackButton);
                Assert.IsNotNull(propertyCreateExteriorItemsPage.ActionTypeField);
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
        [TestProperty("Page", "Create Exterior Items")]
        [Priority(2)]
        public void Setup_CreateExteriorItemConfirmationMessage()
        {
            CurrentTestCaseId = 6752;

            #region Arrange
            var loginPage = Pages.Login;
            var companiesPage = Pages.Companies;
            var propertiesPage = Pages.Properties;
            var propertyActivityPage = Pages.PropertyActivity;
            var propertyDetailsPage = Pages.PropertyDetails;
            var propertyExteriorItemsPage = Pages.ExteriorItems;
            var propertyCreateExteriorItemsPage = Pages.CreateExteriorItems;
            #endregion

            #region Act
            Browser.GoToPage(loginPage);
            loginPage.SingIn(userName, userPass);
            companiesPage.SearchCompany(automationCompany);
            companiesPage.SelectCompany(automationCompany);
            propertiesPage.SelectProperty(automationProperty);
            propertyActivityPage.ClickSetupButton();
            propertyDetailsPage.SelectExteriorItemsOption();
            propertyExteriorItemsPage.ClickCreateNew();
            propertyCreateExteriorItemsPage.CompleteAVExteriorItem(exteriorItemName, itemValue1);
            propertyCreateExteriorItemsPage.ClickSave();
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual(toastSuccessTitle, propertyExteriorItemsPage.ToastTitle);
                Assert.AreEqual(toastNewExteriorItemMsg, propertyExteriorItemsPage.ToastMsg);
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
        [TestProperty("Page", "Create Exterior Items")]
        [Priority(3)]
        public void Setup_CancelExteriorItemCreation()
        {
            CurrentTestCaseId = 6753;

            #region Arrange
            var loginPage = Pages.Login;
            var companiesPage = Pages.Companies;
            var propertiesPage = Pages.Properties;
            var propertyActivityPage = Pages.PropertyActivity;
            var propertyDetailsPage = Pages.PropertyDetails;
            var propertyExteriorItemsPage = Pages.ExteriorItems;
            var propertyCreateExteriorItemsPage = Pages.CreateExteriorItems;
            #endregion

            #region Act
            Browser.GoToPage(loginPage);
            loginPage.SingIn(userName, userPass);
            companiesPage.SearchCompany(automationCompany);
            companiesPage.SelectCompany(automationCompany);
            propertiesPage.SelectProperty(automationProperty);
            propertyActivityPage.ClickSetupButton();
            propertyDetailsPage.SelectExteriorItemsOption();
            propertyExteriorItemsPage.ClickCreateNew();
            propertyCreateExteriorItemsPage.CompleteAVExteriorItem(exteriorItemName, itemValue1);
            propertyCreateExteriorItemsPage.ClickBack();
            propertyExteriorItemsPage.SearchExteriorItem(exteriorItemName);
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual(0, propertyExteriorItemsPage.GridRowsCount);
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
        [TestProperty("Page", "Create Exterior Items")]
        [Priority(1)]
        public void Setup_CreateAVExteriorItem()
        {
            CurrentTestCaseId = 6754;

            #region Arrange
            var loginPage = Pages.Login;
            var companiesPage = Pages.Companies;
            var propertiesPage = Pages.Properties;
            var propertyActivityPage = Pages.PropertyActivity;
            var propertyDetailsPage = Pages.PropertyDetails;
            var propertyExteriorItemsPage = Pages.ExteriorItems;
            var propertyCreateExteriorItemsPage = Pages.CreateExteriorItems;
            #endregion

            #region Act
            Browser.GoToPage(loginPage);
            loginPage.SingIn(userName, userPass);
            companiesPage.SearchCompany(automationCompany);
            companiesPage.SelectCompany(automationCompany);
            propertiesPage.SelectProperty(automationProperty);
            propertyActivityPage.ClickSetupButton();
            propertyDetailsPage.SelectExteriorItemsOption();
            propertyExteriorItemsPage.ClickCreateNew();
            propertyCreateExteriorItemsPage.CompleteAVExteriorItem("AV" + "_" + exteriorItemName, itemValue1);
            propertyCreateExteriorItemsPage.ClickSave();
            propertyExteriorItemsPage.SearchExteriorItem("AV" + "_" + exteriorItemName);
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual("AV" + "_" + exteriorItemName, propertyExteriorItemsPage.SearchResult);
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
        [TestProperty("Page", "Create Exterior Items")]
        [Priority(2)]
        public void Setup_CreateAVExteriorItemRequiredFields()
        {
            CurrentTestCaseId = 6755;

            #region Arrange
            var loginPage = Pages.Login;
            var companiesPage = Pages.Companies;
            var propertiesPage = Pages.Properties;
            var propertyActivityPage = Pages.PropertyActivity;
            var propertyDetailsPage = Pages.PropertyDetails;
            var propertyExteriorItemsPage = Pages.ExteriorItems;
            var propertyCreateExteriorItemsPage = Pages.CreateExteriorItems;
            #endregion

            #region Act
            Browser.GoToPage(loginPage);
            loginPage.SingIn(userName, userPass);
            companiesPage.SearchCompany(automationCompany);
            companiesPage.SelectCompany(automationCompany);
            propertiesPage.SelectProperty(automationProperty);
            propertyActivityPage.ClickSetupButton();
            propertyDetailsPage.SelectExteriorItemsOption();
            propertyExteriorItemsPage.ClickCreateNew();
            propertyCreateExteriorItemsPage.CompleteAVExteriorItem(" ", " ");
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual(itemNameMsg, propertyCreateExteriorItemsPage.ItemNameMsg);
                Assert.AreEqual(itemValueMsg, propertyCreateExteriorItemsPage.ItemValueMsg);
                Assert.IsFalse(propertyCreateExteriorItemsPage.SaveButtonEnabled);
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
        [TestProperty("Page", "Create Exterior Items")]
        [Priority(1)]
        public void Setup_CreateCounterExteriorItem()
        {
            CurrentTestCaseId = 6756;

            #region Arrange
            var loginPage = Pages.Login;
            var companiesPage = Pages.Companies;
            var propertiesPage = Pages.Properties;
            var propertyActivityPage = Pages.PropertyActivity;
            var propertyDetailsPage = Pages.PropertyDetails;
            var propertyExteriorItemsPage = Pages.ExteriorItems;
            var propertyCreateExteriorItemsPage = Pages.CreateExteriorItems;
            #endregion

            #region Act
            Browser.GoToPage(loginPage);
            loginPage.SingIn(userName, userPass);
            companiesPage.SearchCompany(automationCompany);
            companiesPage.SelectCompany(automationCompany);
            propertiesPage.SelectProperty(automationProperty);
            propertyActivityPage.ClickSetupButton();
            propertyDetailsPage.SelectExteriorItemsOption();
            propertyExteriorItemsPage.ClickCreateNew();
            propertyCreateExteriorItemsPage.ClickActionTypeOption("Counter");
            propertyCreateExteriorItemsPage.CompleteExteriorItem("Counter" + "_" + exteriorItemName);
            propertyCreateExteriorItemsPage.ClickSave();
            propertyExteriorItemsPage.SearchExteriorItem("Counter" + "_" + exteriorItemName);
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual("Counter" + "_" + exteriorItemName, propertyExteriorItemsPage.SearchResult);
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
        [TestProperty("Page", "Create Exterior Items")]
        [Priority(2)]
        public void Setup_CreateCounterExteriorItemRequiredFields()
        {
            CurrentTestCaseId = 6757;

            #region Arrange
            var loginPage = Pages.Login;
            var companiesPage = Pages.Companies;
            var propertiesPage = Pages.Properties;
            var propertyActivityPage = Pages.PropertyActivity;
            var propertyDetailsPage = Pages.PropertyDetails;
            var propertyExteriorItemsPage = Pages.ExteriorItems;
            var propertyCreateExteriorItemsPage = Pages.CreateExteriorItems;
            #endregion

            #region Act
            Browser.GoToPage(loginPage);
            loginPage.SingIn(userName, userPass);
            companiesPage.SearchCompany(automationCompany);
            companiesPage.SelectCompany(automationCompany);
            propertiesPage.SelectProperty(automationProperty);
            propertyActivityPage.ClickSetupButton();
            propertyDetailsPage.SelectExteriorItemsOption();
            propertyExteriorItemsPage.ClickCreateNew();
            propertyCreateExteriorItemsPage.ClickActionTypeOption("Counter");
            propertyCreateExteriorItemsPage.CompleteExteriorItem(" ");
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual(itemNameMsg, propertyCreateExteriorItemsPage.ItemNameMsg);
                Assert.IsFalse(propertyCreateExteriorItemsPage.SaveButtonEnabled);
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
        [TestProperty("Page", "Create Exterior Items")]
        [Priority(1)]
        public void Setup_CreateDateExteriorItem()
        {
            CurrentTestCaseId = 6758;

            #region Arrange
            var loginPage = Pages.Login;
            var companiesPage = Pages.Companies;
            var propertiesPage = Pages.Properties;
            var propertyActivityPage = Pages.PropertyActivity;
            var propertyDetailsPage = Pages.PropertyDetails;
            var propertyExteriorItemsPage = Pages.ExteriorItems;
            var propertyCreateExteriorItemsPage = Pages.CreateExteriorItems;
            #endregion

            #region Act
            Browser.GoToPage(loginPage);
            loginPage.SingIn(userName, userPass);
            companiesPage.SearchCompany(automationCompany);
            companiesPage.SelectCompany(automationCompany);
            propertiesPage.SelectProperty(automationProperty);
            propertyActivityPage.ClickSetupButton();
            propertyDetailsPage.SelectExteriorItemsOption();
            propertyExteriorItemsPage.ClickCreateNew();
            propertyCreateExteriorItemsPage.ClickActionTypeOption("Date");
            propertyCreateExteriorItemsPage.CompleteExteriorItem("Date" + "_" + exteriorItemName);
            propertyCreateExteriorItemsPage.ClickSave();
            propertyExteriorItemsPage.SearchExteriorItem("Date" + "_" + exteriorItemName);
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual("Date" + "_" + exteriorItemName, propertyExteriorItemsPage.SearchResult);
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
        [TestProperty("Page", "Create Exterior Items")]
        [Priority(2)]
        public void Setup_CreateDateExteriorItemRequiredFields()
        {
            CurrentTestCaseId = 6759;

            #region Arrange
            var loginPage = Pages.Login;
            var companiesPage = Pages.Companies;
            var propertiesPage = Pages.Properties;
            var propertyActivityPage = Pages.PropertyActivity;
            var propertyDetailsPage = Pages.PropertyDetails;
            var propertyExteriorItemsPage = Pages.ExteriorItems;
            var propertyCreateExteriorItemsPage = Pages.CreateExteriorItems;
            #endregion

            #region Act
            Browser.GoToPage(loginPage);
            loginPage.SingIn(userName, userPass);
            companiesPage.SearchCompany(automationCompany);
            companiesPage.SelectCompany(automationCompany);
            propertiesPage.SelectProperty(automationProperty);
            propertyActivityPage.ClickSetupButton();
            propertyDetailsPage.SelectExteriorItemsOption();
            propertyExteriorItemsPage.ClickCreateNew();
            propertyCreateExteriorItemsPage.ClickActionTypeOption("Date");
            propertyCreateExteriorItemsPage.CompleteExteriorItem(" ");
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual(itemNameMsg, propertyCreateExteriorItemsPage.ItemNameMsg);
                Assert.IsFalse(propertyCreateExteriorItemsPage.SaveButtonEnabled);
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
        [TestProperty("Page", "General Categories")]
        [Priority(1)]
        public void Setup_GeneralCategoriesUI()
        {
            CurrentTestCaseId = 6839;

            #region Arrange
            var loginPage = Pages.Login;
            var companiesPage = Pages.Companies;
            var propertiesPage = Pages.Properties;
            var propertyActivityPage = Pages.PropertyActivity;
            var propertyDetailsPage = Pages.PropertyDetails;
            var propertyGeneralCategoriesPage = Pages.GeneralCategories;
            #endregion

            #region Act
            Browser.GoToPage(loginPage);
            loginPage.SingIn(userName, userPass);
            companiesPage.SearchCompany(automationCompany);
            companiesPage.SelectCompany(automationCompany);
            propertiesPage.SelectProperty(automationProperty);
            propertyActivityPage.ClickSetupButton();
            propertyDetailsPage.SelectGeneralCategoriesOption();
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual(automationProperty, propertyGeneralCategoriesPage.PageBreadCrumb);
                Assert.AreEqual(propertyGeneralCategoriesPage.Title, propertyGeneralCategoriesPage.PageHeader);
                Assert.IsTrue(propertyGeneralCategoriesPage.SideMenuActiveButton);
                Assert.IsNotNull(propertyGeneralCategoriesPage.CreateNewButton);
                Assert.IsNotNull(propertyGeneralCategoriesPage.CloneButton);
                Assert.IsNotNull(propertyGeneralCategoriesPage.PropertiesButton);
                Assert.IsNotNull(propertyGeneralCategoriesPage.ActivityButton);
                Assert.IsNotNull(propertyGeneralCategoriesPage.InspectionsButton);
                Assert.IsNotNull(propertyGeneralCategoriesPage.LFAButton);
                Assert.IsNotNull(propertyGeneralCategoriesPage.SetupButton);
                Assert.IsNotNull(propertyGeneralCategoriesPage.ReportsButton);
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
        [TestProperty("Page", "Create General Category")]
        [Priority(1)]
        public void Setup_CreateGeneralCategoryUI()
        {
            CurrentTestCaseId = 6840;

            #region Arrange
            var loginPage = Pages.Login;
            var companiesPage = Pages.Companies;
            var propertiesPage = Pages.Properties;
            var propertyActivityPage = Pages.PropertyActivity;
            var propertyDetailsPage = Pages.PropertyDetails;
            var propertyGeneralCategoriesPage = Pages.GeneralCategories;
            var propertyCreateGeneralCategoryPage = Pages.CreateGeneralCategory;
            #endregion

            #region Act
            Browser.GoToPage(loginPage);
            loginPage.SingIn(userName, userPass);
            companiesPage.SearchCompany(automationCompany);
            companiesPage.SelectCompany(automationCompany);
            propertiesPage.SelectProperty(automationProperty);
            propertyActivityPage.ClickSetupButton();
            propertyDetailsPage.SelectGeneralCategoriesOption();
            propertyGeneralCategoriesPage.ClickCreateNew();
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual(automationProperty, propertyCreateGeneralCategoryPage.PageBreadCrumb);
                Assert.AreEqual(propertyCreateGeneralCategoryPage.Title, propertyCreateGeneralCategoryPage.PageHeader);
                Assert.IsTrue(propertyCreateGeneralCategoryPage.SideMenuActiveButton);
                Assert.IsFalse(propertyCreateGeneralCategoryPage.SaveButtonEnabled);
                Assert.IsNotNull(propertyCreateGeneralCategoryPage.SaveButton);
                Assert.IsNotNull(propertyCreateGeneralCategoryPage.BackButton);
                Assert.IsNotNull(propertyCreateGeneralCategoryPage.NameField);
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
        [TestProperty("Page", "Create General Category")]
        [Priority(2)]
        public void Setup_CreateGeneralCategoryConfirmationMessage()
        {
            CurrentTestCaseId = 6841;

            #region Arrange
            var loginPage = Pages.Login;
            var companiesPage = Pages.Companies;
            var propertiesPage = Pages.Properties;
            var propertyActivityPage = Pages.PropertyActivity;
            var propertyDetailsPage = Pages.PropertyDetails;
            var propertyGeneralCategoriesPage = Pages.GeneralCategories;
            var propertyCreateGeneralCategoryPage = Pages.CreateGeneralCategory;
            var propertyGeneralCategoryInfoPage = Pages.GeneralCategoryInfo;
            #endregion

            #region Act
            Browser.GoToPage(loginPage);
            loginPage.SingIn(userName, userPass);
            companiesPage.SearchCompany(automationCompany);
            companiesPage.SelectCompany(automationCompany);
            propertiesPage.SelectProperty(automationProperty);
            propertyActivityPage.ClickSetupButton();
            propertyDetailsPage.SelectGeneralCategoriesOption();
            propertyGeneralCategoriesPage.ClickCreateNew();
            propertyCreateGeneralCategoryPage.CompleteGeneralCategory(generalCategoryName, "Administrative");
            propertyCreateGeneralCategoryPage.ClickSave();
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual(toastSuccessTitle, propertyGeneralCategoryInfoPage.ToastTitle);
                Assert.AreEqual(toastNewGeneralCategoryMsg, propertyGeneralCategoryInfoPage.ToastMsg);
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
        [TestProperty("Page", "Create General Category")]
        [Priority(3)]
        public void Setup_CancelGeneralCategoryCreation()
        {
            CurrentTestCaseId = 6842;

            #region Arrange
            var loginPage = Pages.Login;
            var companiesPage = Pages.Companies;
            var propertiesPage = Pages.Properties;
            var propertyActivityPage = Pages.PropertyActivity;
            var propertyDetailsPage = Pages.PropertyDetails;
            var propertyGeneralCategoriesPage = Pages.GeneralCategories;
            var propertyCreateGeneralCategoryPage = Pages.CreateGeneralCategory;
            #endregion

            #region Act
            Browser.GoToPage(loginPage);
            loginPage.SingIn(userName, userPass);
            companiesPage.SearchCompany(automationCompany);
            companiesPage.SelectCompany(automationCompany);
            propertiesPage.SelectProperty(automationProperty);
            propertyActivityPage.ClickSetupButton();
            propertyDetailsPage.SelectGeneralCategoriesOption();
            propertyGeneralCategoriesPage.ClickCreateNew();
            propertyCreateGeneralCategoryPage.CompleteGeneralCategory(generalCategoryName, "Administrative");
            propertyCreateGeneralCategoryPage.ClickBack();
            propertyGeneralCategoriesPage.SearchGeneralCategory(generalCategoryName);
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual(0, propertyGeneralCategoriesPage.GridRowsCount);
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
        [TestProperty("Page", "Create General Category")]
        [Priority(2)]
        public void Setup_CreateGeneralCategoryRequiredFields()
        {
            CurrentTestCaseId = 6843;

            #region Arrange
            var loginPage = Pages.Login;
            var companiesPage = Pages.Companies;
            var propertiesPage = Pages.Properties;
            var propertyActivityPage = Pages.PropertyActivity;
            var propertyDetailsPage = Pages.PropertyDetails;
            var propertyGeneralCategoriesPage = Pages.GeneralCategories;
            var propertyCreateGeneralCategoryPage = Pages.CreateGeneralCategory;
            #endregion

            #region Act
            Browser.GoToPage(loginPage);
            loginPage.SingIn(userName, userPass);
            companiesPage.SearchCompany(automationCompany);
            companiesPage.SelectCompany(automationCompany);
            propertiesPage.SelectProperty(automationProperty);
            propertyActivityPage.ClickSetupButton();
            propertyDetailsPage.SelectGeneralCategoriesOption();
            propertyGeneralCategoriesPage.ClickCreateNew();
            propertyCreateGeneralCategoryPage.CompleteGeneralCategory(" ", null);
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual(categoryNameMsg, propertyCreateGeneralCategoryPage.CategoryNameMsg);
                Assert.AreEqual(categoryTypeMsg, propertyCreateGeneralCategoryPage.CategoryTypeMsg);
                Assert.IsFalse(propertyCreateGeneralCategoryPage.SaveButtonEnabled);
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
        [TestProperty("Page", "Create General Category")]
        [Priority(1)]
        public void Setup_CreateAdministrativeGeneralCategory()
        {
            CurrentTestCaseId = 6844;

            #region Arrange
            var loginPage = Pages.Login;
            var companiesPage = Pages.Companies;
            var propertiesPage = Pages.Properties;
            var propertyActivityPage = Pages.PropertyActivity;
            var propertyDetailsPage = Pages.PropertyDetails;
            var propertyGeneralCategoriesPage = Pages.GeneralCategories;
            var propertyCreateGeneralCategoryPage = Pages.CreateGeneralCategory;
            var propertyGeneralCategoryInfoPage = Pages.GeneralCategoryInfo;
            #endregion

            #region Act
            Browser.GoToPage(loginPage);
            loginPage.SingIn(userName, userPass);
            companiesPage.SearchCompany(automationCompany);
            companiesPage.SelectCompany(automationCompany);
            propertiesPage.SelectProperty(automationProperty);
            propertyActivityPage.ClickSetupButton();
            propertyDetailsPage.SelectGeneralCategoriesOption();
            propertyGeneralCategoriesPage.ClickCreateNew();
            propertyCreateGeneralCategoryPage.CompleteGeneralCategory(generalCategoryName + "_Administrative", "Administrative");
            propertyCreateGeneralCategoryPage.ClickSave();
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual(generalCategoryName + "_Administrative", propertyGeneralCategoryInfoPage.CategoryName);
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
        [TestProperty("Page", "Create General Category")]
        [Priority(1)]
        public void Setup_CreateLeasingGeneralCategory()
        {
            CurrentTestCaseId = 6845;

            #region Arrange
            var loginPage = Pages.Login;
            var companiesPage = Pages.Companies;
            var propertiesPage = Pages.Properties;
            var propertyActivityPage = Pages.PropertyActivity;
            var propertyDetailsPage = Pages.PropertyDetails;
            var propertyGeneralCategoriesPage = Pages.GeneralCategories;
            var propertyCreateGeneralCategoryPage = Pages.CreateGeneralCategory;
            var propertyGeneralCategoryInfoPage = Pages.GeneralCategoryInfo;
            #endregion

            #region Act
            Browser.GoToPage(loginPage);
            loginPage.SingIn(userName, userPass);
            companiesPage.SearchCompany(automationCompany);
            companiesPage.SelectCompany(automationCompany);
            propertiesPage.SelectProperty(automationProperty);
            propertyActivityPage.ClickSetupButton();
            propertyDetailsPage.SelectGeneralCategoriesOption();
            propertyGeneralCategoriesPage.ClickCreateNew();
            propertyCreateGeneralCategoryPage.CompleteGeneralCategory(generalCategoryName + "_Leasing", "Leasing");
            propertyCreateGeneralCategoryPage.ClickSave();
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual(generalCategoryName + "_Leasing", propertyGeneralCategoryInfoPage.CategoryName);
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
        [TestProperty("Page", "Create General Category")]
        [Priority(1)]
        public void Setup_CreateOperationsGeneralCategory()
        {
            CurrentTestCaseId = 6846;

            #region Arrange
            var loginPage = Pages.Login;
            var companiesPage = Pages.Companies;
            var propertiesPage = Pages.Properties;
            var propertyActivityPage = Pages.PropertyActivity;
            var propertyDetailsPage = Pages.PropertyDetails;
            var propertyGeneralCategoriesPage = Pages.GeneralCategories;
            var propertyCreateGeneralCategoryPage = Pages.CreateGeneralCategory;
            var propertyGeneralCategoryInfoPage = Pages.GeneralCategoryInfo;
            #endregion

            #region Act
            Browser.GoToPage(loginPage);
            loginPage.SingIn(userName, userPass);
            companiesPage.SearchCompany(automationCompany);
            companiesPage.SelectCompany(automationCompany);
            propertiesPage.SelectProperty(automationProperty);
            propertyActivityPage.ClickSetupButton();
            propertyDetailsPage.SelectGeneralCategoriesOption();
            propertyGeneralCategoriesPage.ClickCreateNew();
            propertyCreateGeneralCategoryPage.CompleteGeneralCategory(generalCategoryName + "_Operations", "Operations");
            propertyCreateGeneralCategoryPage.ClickSave();
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual(generalCategoryName + "_Operations", propertyGeneralCategoryInfoPage.CategoryName);
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
        [TestProperty("Page", "General Category Info")]
        [Priority(1)]
        public void Setup_GeneralCategoryInfoUI()
        {
            CurrentTestCaseId = 6847;

            #region Arrange
            var loginPage = Pages.Login;
            var companiesPage = Pages.Companies;
            var propertiesPage = Pages.Properties;
            var propertyActivityPage = Pages.PropertyActivity;
            var propertyDetailsPage = Pages.PropertyDetails;
            var propertyGeneralCategoriesPage = Pages.GeneralCategories;
            var propertyGeneralCategoryInfoPage = Pages.GeneralCategoryInfo;
            #endregion

            #region Act
            Browser.GoToPage(loginPage);
            loginPage.SingIn(userName, userPass);
            companiesPage.SearchCompany(automationCompany);
            companiesPage.SelectCompany(automationCompany);
            propertiesPage.SelectProperty(automationProperty);
            propertyActivityPage.ClickSetupButton();
            propertyDetailsPage.SelectGeneralCategoriesOption();
            propertyGeneralCategoriesPage.SelectGeneralCategory(automationGeneralCategory);
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual(automationProperty, propertyGeneralCategoryInfoPage.PageBreadCrumb);
                Assert.AreEqual(propertyGeneralCategoryInfoPage.Title, propertyGeneralCategoryInfoPage.PageHeader);
                Assert.IsTrue(propertyGeneralCategoryInfoPage.SideMenuActiveButton);
                Assert.IsNotNull(propertyGeneralCategoryInfoPage.AddGeneralItemsButton);
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
        [TestProperty("Page", "General Category Info")]
        [Priority(3)]
        public void Setup_GeneralCategoryInfoBackButton()
        {
            CurrentTestCaseId = 6848;

            #region Arrange
            var loginPage = Pages.Login;
            var companiesPage = Pages.Companies;
            var propertiesPage = Pages.Properties;
            var propertyActivityPage = Pages.PropertyActivity;
            var propertyDetailsPage = Pages.PropertyDetails;
            var propertyGeneralCategoriesPage = Pages.GeneralCategories;
            var propertyGeneralCategoryInfoPage = Pages.GeneralCategoryInfo;
            #endregion

            #region Act
            Browser.GoToPage(loginPage);
            loginPage.SingIn(userName, userPass);
            companiesPage.SearchCompany(automationCompany);
            companiesPage.SelectCompany(automationCompany);
            propertiesPage.SelectProperty(automationProperty);
            propertyActivityPage.ClickSetupButton();
            propertyDetailsPage.SelectGeneralCategoriesOption();
            propertyGeneralCategoriesPage.SelectGeneralCategory(automationGeneralCategory);
            propertyGeneralCategoryInfoPage.ClickBack();
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual(propertyGeneralCategoriesPage.Title, propertyGeneralCategoriesPage.PageHeader);
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
