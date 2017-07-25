using Microsoft.VisualStudio.TestTools.UnitTesting;
using InfoTycoon.ProjectToTest;
using System.Threading;
using InfoTycoon.Fwk.TestAutomation.Helpers;
using InfoTycoon.Fwk.TestAutomation;
using System.Drawing.Imaging;
using System.Configuration;
using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace InfoTycoon.Test.Example._01.Login
{
    [TestClass]
    public class LoginTest : SetupAssemblyInitializer
    {
        #region Declare variables
        static string userName;
        static string userPass;
        static string userFullName;
        static string userWrongName;
        static string userWrongPass;
        static string toastErrorTitle;
        static string toastWrongNameMsg;
        static string toastWrongPassMsg;
        static string date;
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
            userWrongName = ConfigurationManager.AppSettings["WrongUserName"];
            userWrongPass = ConfigurationManager.AppSettings["WrongUserPass"];
            toastErrorTitle = ConfigurationManager.AppSettings["ToastErrorTitle"];
            toastWrongNameMsg = ConfigurationManager.AppSettings["ToastWrongNameMsg"];
            toastWrongPassMsg = ConfigurationManager.AppSettings["ToastWrongPassMsg"];
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
        [TestProperty("Page", "Login")]
        [Priority(1)]
        public void Login_PageUI()
        {
            CurrentTestCaseId = 5289;

            #region Arrange
            var loginPage = Pages.Login;
            #endregion

            #region Act
            Browser.GoToPage(loginPage);
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual(loginPage.Title, loginPage.PageHeader);
                Assert.IsNotNull(loginPage.LogoImage);
                Assert.IsNotNull(loginPage.EmailTextBox);
                Assert.IsNotNull(loginPage.PasswordTextBox);
                Assert.IsNotNull(loginPage.ForgotPasswordButton);
                Assert.IsNotNull(loginPage.SignInButton);
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
        [TestProperty("Page", "Login")]
        [Priority(1)]
        public void Login_UserLogin()
        {
            CurrentTestCaseId = 4940;

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
                Assert.AreEqual(userFullName, companiesPage.UserNameLabel);
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
        [TestProperty("Page", "Login")]
        [Priority(1)]
        public void Login_WrongUser()
        {
            CurrentTestCaseId = 4942;

            #region Arrange
            var loginPage = Pages.Login;
            #endregion

            #region Act
            Browser.GoToPage(loginPage);
            loginPage.SingIn(userWrongName, userPass);
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual(toastErrorTitle, loginPage.ToastTitle);
                Assert.AreEqual(toastWrongNameMsg, loginPage.ToastMessage);
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
        [TestProperty("Page", "Login")]
        [Priority(1)]
        public void Login_WrongPass()
        {
            CurrentTestCaseId = 4941;

            #region Arrange
            var loginPage = Pages.Login;
            #endregion

            #region Act
            Browser.GoToPage(loginPage);
            loginPage.SingIn(userName, userWrongPass);
            #endregion

            #region Assert
            try
            {
                Assert.AreEqual(toastErrorTitle, loginPage.ToastTitle);
                Assert.AreEqual(toastWrongPassMsg, loginPage.ToastMessage);
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

            reportHelper.GenerateReport(TestContext, AssertExceptionMessage);

            Browser.Quit();
        }     
    }
}
