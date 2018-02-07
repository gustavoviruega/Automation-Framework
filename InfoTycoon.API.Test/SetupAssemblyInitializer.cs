using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//-----------To enable integration with TestRail uncomment the lines 42, 92 and 97-----------

namespace InfoTycoon.API.Test
{
    [TestClass]
    public class SetupAssemblyInitializer
    {
        private static JArray ids = new JArray();

        private static JArray results = new JArray();

        protected static JObject TestRun { get; set; }

        protected static Gurock.TestRail.APIClient client;

        protected int CurrentTestCaseId { get; set; }

        protected string AssertExceptionMessage { get; set; }

        protected string MessageExtended { get; set; }


        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            client = new Gurock.TestRail.APIClient(ConfigurationManager.AppSettings["TestRailApiURL"]);
            client.User = ConfigurationManager.AppSettings["TestRailUser"]; //Put the e-mail of your user here
            client.Password = ConfigurationManager.AppSettings["TestRailPassword"]; //Put the password of your user here

            var testRunData = new Dictionary<string, object>
              {
                  { "suite_id", 7 },
                  { "include_all", false },
                  { "name", "API automated tests run " + DateTime.Now.ToString() }
              };

            //TestRun = (JObject)client.SendPost("add_run/4", testRunData);

        }

        protected void LogTest(UnitTestOutcome currentTestOutcome, int testCaseId)
        {
            ids.Add(testCaseId);

            JObject res = new JObject();

            if (currentTestOutcome == UnitTestOutcome.Passed)
            {
                res["case_id"] = testCaseId;
                res["status_id"] = 1;
                res["comments"] = "The test has passed!";
            }
            else if (currentTestOutcome == UnitTestOutcome.InProgress)
            {
                res["case_id"] = testCaseId;
                res["status_id"] = 4;
                res["comments"] = "The test has to be retested. The execution result was: Test In Progress...";
            }
            else if (currentTestOutcome == UnitTestOutcome.Timeout)
            {
                res["case_id"] = testCaseId;
                res["status_id"] = 5;
                res["comments"] = "The test has failed. The execution result was: Timeout.";
            }
            else if (currentTestOutcome == UnitTestOutcome.Inconclusive)
            {
                res["case_id"] = testCaseId;
                res["status_id"] = 5;
                res["comments"] = "The test has failed. The execution result was: Inconclusive, the assertion couldn't be verified.";
            }
            else
            {
                res["case_id"] = testCaseId;
                res["status_id"] = 5;
                res["comments"] = "The test has failed.";
            }

            results.Add(res);
        }

        [AssemblyCleanup]
        public static void AssemblyCleanUp()
        {
            var testToAdd = new Dictionary<string, object>();
            testToAdd["case_ids"] = ids;
            var updateRunUrl = "update_run/" + (TestRun["id"] ?? 0);
            //client.SendPost(updateRunUrl, testToAdd);

            var testResult = new Dictionary<string, object>();
            testResult["results"] = results;
            var addResultUrl = "add_results_for_cases/" + (TestRun["id"] ?? 0);
            //client.SendPost(addResultUrl, testResult);
        }
    }
}
