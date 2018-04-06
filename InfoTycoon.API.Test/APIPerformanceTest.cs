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
using System.Text;

namespace InfoTycoon.API.Test
{
    [TestClass]
    public class APIPerformanceTest : SetupAssemblyInitializer
    {
        protected static JObject TokenResponse { get; set; }

        #region Declare variables
        //static string inspectionID;
        static string token;
        static readonly string SUCCESS = "success";
        static readonly string FAIL = "fail";
        #endregion

        #region Report settings
        public TestContext TestContext { get; set; }
        private ReportHelper reportHelper = new ReportHelper();
        #endregion

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            
            //Obtain the token to use in the tests.
            var tokenLoginRequest = new RestClient();
            TokenResponse = (JObject)tokenLoginRequest.ObtainToken();
            token = TokenResponse["access_token"].ToString();
        }

        [TestInitialize]
        public void Initialize()
        {
        }

        [TestMethod]
        [TestCategory("API Performance")]
        [TestProperty("API", "Inspection Detail")]
        [Priority(1)]
        public void API_FullInspectionDetail_ResponseTime()
        {
            CurrentTestCaseId = 6879;

            #region Arrange
            var client = new RestClient();
            StringBuilder str = new StringBuilder();
            client.Header = "Bearer " + token;

            var inspections = ConnectionDB.GetInspections(); 
            #endregion

            #region Act
            try
            {
                foreach (long inspectionID in inspections)
                {

                    client.EndPoint = String.Format("https://dev-m.infotycoon.com/api/inspectionModule/getfullinspectiondetailv2?inspectionId={0}&format=array", inspectionID);

                    Stopwatch sw = new Stopwatch();
                    string response = string.Empty;

                    sw.Start();
                    response = client.MakeRequestString();
                    sw.Stop();

                    str.AppendFormat("InspectionID : {0} - Time elapsed : {1} </br>", inspectionID, sw.Elapsed);

                }

                MessageExtended = str.ToString();

            }
            catch (Exception ex)
            {
                AssertExceptionMessage = ex.Message;
                throw;
            } 
            #endregion
        }

        [TestMethod]
        [TestCategory("API Performance")]
        [TestProperty("API", "Inspection Detail")]
        [Priority(1)]
        public void API_SQLiteInspection_ResponseTime()
        {
            CurrentTestCaseId = 6880;

            #region Arrange
            StringBuilder str = new StringBuilder();
            var client = new RestClient();
            client.Header = "Bearer " + token;

            var inspections = ConnectionDB.GetInspections();
            #endregion

            #region Act
            try
            {
                foreach (long inspectionID in inspections)
                {

                    client.EndPoint = String.Format("https://dev-m.infotycoon.com/api/v2/sqliteinspection/{0}", inspectionID);

                    Stopwatch sw = new Stopwatch();
                    string response = string.Empty;

                    sw.Start();
                    response = client.MakeRequestString();
                    sw.Stop();

                    str.AppendFormat("InspectionID : {0} - Time elapsed : {1} </br>", inspectionID, sw.Elapsed);

                }

                MessageExtended = str.ToString();

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
            reportHelper.GenerateReport(TestContext, AssertExceptionMessage, MessageExtended);
        }
    }
}
