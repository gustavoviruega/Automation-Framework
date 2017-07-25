using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RelevantCodes.ExtentReports;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Globalization;
using System.Drawing.Imaging;

namespace InfoTycoon.Fwk.TestAutomation.Helpers
{
    public class ReportHelper
    {
        private static String filePath = ConfigurationManager.AppSettings["DefaultReportPath"];
        private static String fileName = String.Format("Automation Report_{0}.html", DateTime.Now.ToString("yyyyMMdd_HHmm"));
        private static readonly ExtentReports _instance = new ExtentReports(filePath + fileName, DisplayOrder.OldestFirst);
        public TestContext TestContext { get; set; }

        protected ExtentReports ExtentReport
        {
            get 
            {
                return _instance; 
            }
        }

        protected ExtentTest test;

        public void GenerateReport(TestContext testContext, string assertExceptionMessage = null)
        {
            var status = testContext.CurrentTestOutcome;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("es-ES");

            LogStatus logstatus;

            switch (status)
            {
                case UnitTestOutcome.Failed:
                    logstatus = LogStatus.Fail;
                    break;
                case UnitTestOutcome.Inconclusive:
                    logstatus = LogStatus.Warning;
                    break;
                default:
                    logstatus = LogStatus.Pass;
                    break;
            }

            test = ExtentReport.StartTest(testContext.TestName);
            var testClassName = testContext.FullyQualifiedTestClassName.Split('.').Last();
            test.AssignCategory(testClassName);

            var fileName = String.Format("Test_{0}_{1}", testContext.TestName, DateTime.Now.ToString("yyyyMMdd_HHmm"));
            Browser.PrintScreen(fileName, ImageFormat.Jpeg);
            var fileToAdd = ConfigurationManager.AppSettings["DefaultImagePath"] + fileName + "." + ImageFormat.Jpeg;

            if (logstatus.ToString() == "Fail")
            {
                test.Log(logstatus, "<b>Test status:</b> " + logstatus + "</br>" + "<b>Snapshot: </b>" + test.AddScreenCapture(fileToAdd) + "</br>" + "<b>Error info: </b>" + "</br>" + assertExceptionMessage.Replace("<", "[").Replace(">", "]"));
            }
            else
            { 
                test.Log(logstatus, "<b>Test status:</b> " + logstatus + "</br>" + "<b>Snapshot: </b>" + test.AddScreenCapture(fileToAdd));
            }

            ExtentReport.EndTest(test);
            ExtentReport.Flush();
        }
    }
}
