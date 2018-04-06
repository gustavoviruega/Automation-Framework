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
using System.Text.RegularExpressions;
using System.Diagnostics;
//using InfoTycoon.Test;
using System.Text;

namespace InfoTycoon.API.Test
{
    [TestClass]
    public class APIFunctionalTests : SetupAssemblyInitializer
    {
        protected static JObject TokenResponse { get; set; }

        #region Declare variables
        static string inspectionID;
        static string token;
        #endregion

        #region Report settings
        public TestContext TestContext { get; set; }
        private ReportHelper reportHelper = new ReportHelper();
        #endregion

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            #region Initialize variables
            inspectionID = ConfigurationManager.AppSettings["InspectionID"];
            #endregion

            //Obtain the token to use in the tests.
            var tokenLoginRequest = new RestClient();
            TokenResponse = (JObject)tokenLoginRequest.ObtainToken();
            token = TokenResponse["access_token"].ToString();
        }

        [TestInitialize]
        public void Initialize()
        {
            //Browser.Initializes(true);
        }

        [TestMethod]
        [TestCategory("API Functional")]
        [TestProperty("API", "Login")]
        [Priority(1)]
        public void API_InspectionLoginWithToken()
        {
            CurrentTestCaseId = 6874;

            #region Arrange
            var client = new RestClient();
            client.EndPoint = "https://dev-m.infotycoon.com/token";
            client.Method = HttpVerb.POST;
            client.PostData = "grant_type=password&username=gviruega@velocitypartners.net&password=test_123";
            client.ContentType = "application/x-www-form-urlencoded";
            #endregion

            #region Act
            var response = (JObject)client.MakeRequestJson();
            #endregion

            #region Assert
            try
            {
                //StringAssert.Contains(response, "6f51ddcf-e479-462c-bbad-2aba38977d85"); --This is in case we use the MakeRequestString() method.
                Assert.AreEqual("Gustavo", response["firstName"]); 
            }
            catch (Exception ex)
            {
                AssertExceptionMessage = ex.Message;
                throw;
            }
            #endregion
        }

        [TestMethod]
        [TestCategory("API Functional")]
        [TestProperty("API", "Login")]
        [Priority(1)]
        public void API_InspectionLoginNoToken()
        {
            CurrentTestCaseId = 6875;

            #region Arrange
            var client = new RestClient();
            client.EndPoint = "https://dev-m.infotycoon.com/api/Auth/";
            client.Method = HttpVerb.POST;
            client.PostData = "{'username': 'gviruega@velocitypartners.net', 'password': 'test_123', 'application': 0}";
            #endregion

            #region Act
            var response = (JObject)client.MakeRequestJson();
            #endregion

            #region Assert
            try
            {
                //StringAssert.Contains(response, "6f51ddcf-e479-462c-bbad-2aba38977d85"); --This is in case we use the MakeRequestString() method.
                Assert.AreEqual("Gustavo", response["firstName"]);
            }
            catch (Exception ex)
            {
                AssertExceptionMessage = ex.Message;
                throw;
            }
            #endregion
        }

        [TestMethod]
        [TestCategory("API Functional")]
        [TestProperty("API", "Login")]
        [Priority(1)]
        public void API_InspectionLogout()
        {
            CurrentTestCaseId = 6876;

            #region Arrange
            var client = new RestClient();
            client.EndPoint = "https://dev-m.infotycoon.com/api/Auth/";
            client.Method = HttpVerb.DELETE;
            #endregion

            #region Act
            var json = client.MakeRequestString();
            #endregion

            #region Assert
            try
            {
                //THIS IS PENDING
            }
            catch (Exception ex)
            {
                AssertExceptionMessage = ex.Message;
                throw;
            }
            #endregion
        }

        [TestMethod]
        [TestCategory("API Functional")]
        [TestProperty("API", "Inspection Detail")]
        [Priority(1)]
        public void API_FullInspectionDetail()
        {
            CurrentTestCaseId = 6877;

            #region Arrange
            var client = new RestClient();
            client.EndPoint = "https://dev-m.infotycoon.com/api/inspectionModule/getfullinspectiondetailv2?inspectionId=" + inspectionID + "&format=array";
            client.Header = "Bearer " + token;
            #endregion

            #region Act
            var response = client.MakeRequestString();
            #endregion

            #region Assert
            try
            {
                StringAssert.Contains(response, "Test special instructions");
            }
            catch (Exception ex)
            {
                AssertExceptionMessage = ex.Message;
                throw;
            }
            #endregion
        }

        [TestMethod]
        [TestCategory("API Functional")]
        [TestProperty("API", "Inspection Detail")]
        [Priority(1)]
        public void API_SQLiteInspection()
        {
            CurrentTestCaseId = 6878;

            #region Arrange
            var client = new RestClient();
            client.EndPoint = @"https://dev-m.infotycoon.com/api/v2/sqliteinspection/" + inspectionID;
            client.Header = "Bearer " + token;
            #endregion

            #region Act
            var response = client.MakeRequestString();
            #endregion

            #region Assert
            try
            {
                StringAssert.Contains(response, "SQLite");
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
        }
    }
}
