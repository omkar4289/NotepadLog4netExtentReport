
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Config;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace UnitTestProject1.Utility
{
    public class ExtentReport : SessionInit
    {
        public static ExtentReports _extentReports;
        public static ExtentTest _feature;
        public static ExtentTest _scenario;


        public static String testResultPath;// = @"C:\Users\omkarp\source\repos\OPautomation\UnitTestProject1\TestResults\index.html";  // +{DateTime.Now.ToString("ddMMyyyyhhmmss")}+".html";

        public static void ExtentReportInit()
        {
            string Todaysdate = DateTime.Now.ToString("-dd-MM-yyyy-(hh-mm-ss)");

            // to create directory with date and time name
            {
                Directory.CreateDirectory("C:\\Users\\omkarp\\source\\repos\\OPautomation\\UnitTestProject1\\TestResults\\ExtentReport" + Todaysdate);
            }
            testResultPath = "C:\\Users\\omkarp\\source\\repos\\OPautomation\\UnitTestProject1\\TestResults\\ExtentReport" + Todaysdate +"\\index.html"; // added index.htm to save extent report
            Console.WriteLine("================== Path: " + testResultPath);



            var htmlReporter = new ExtentSparkReporter(testResultPath);
            htmlReporter.Config.Theme = Theme.Standard;
            htmlReporter.Config.DocumentTitle = "Automation Status Report";
            htmlReporter.Config.ReportName = "Extent Report Status";

            _extentReports = new ExtentReports();
            _extentReports.AttachReporter(htmlReporter);

           //  _feature = _extentReports.CreateTest("Login Test").AssignAuthor("Omkar").AssignCategory("Smoke");
          //  _feature.Pass("Login successfull");

            //ExtentTest _feature1 = _extentReports.CreateTest("HomePage Test").AssignAuthor("Sachin").AssignCategory("Smoke").AssignCategory("Regression");
            //_feature1.Pass("Homepage opened");
            //_feature1.Fail("Homepage NOT opened");

           



        }

        public static void GetScreenshot(string filename, WindowsDriver<WindowsElement> session)
        {
            try
            {
               session = SessionInit.session;

                var screenshot = session.GetScreenshot();

                // string folderPath = @"\whatever\path";
                //  Directory.CreateDirectory(folderPath);
                string folderPath = "C:\\Users\\omkarp\\source\\repos\\OPautomation\\UnitTestProject1\\TestResults\\FailedTest";
                Directory.CreateDirectory(folderPath);
                var filePath = "C:\\Users\\omkarp\\source\\repos\\OPautomation\\UnitTestProject1\\TestResults\\FailedTest\\screen " + filename + ".png";
                Console.WriteLine("................ screenshot path" + filePath);
              //  count++;

                screenshot.SaveAsFile(filePath, ScreenshotImageFormat.Png);
                Console.WriteLine("Screenshot capture ....................");

            }
            catch (Exception e)
            {
                Console.WriteLine("Line Failed: " + e.Message);
                Console.WriteLine("** COULD NOT GET SCREENSHOT ***");
            }

        }



    }
}
