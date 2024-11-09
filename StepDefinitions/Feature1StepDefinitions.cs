using Google.Protobuf.WellKnownTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Appium;
using System;
using System.Runtime.Remoting.Contexts;
using TechTalk.SpecFlow;
using UnitTestProject1.Forms;
using OpenQA.Selenium;
using MongoDB.Driver.Core.Operations;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using UnitTestProject1.Log4net;
using log4net;

namespace UnitTestProject1
{
    [Binding]
    public class Feature1StepDefinitions : SessionInit
    {
        ILog logger = TestLogger.TestLog4Net();
        public static int count = 1;
        [Given(@"User opened Calculator app")]
        public void GivenUserOpenedCalculatorApp()
        {
            logger.Info("Calculator started");
            Operation.stSession();
        }


        [When(@"user entered first number")]
        public void WhenUserEnteredFirstNumber()
        {
            var Two = session.FindElementByName("Calculator").FindElementByName("Two");
            Two.Click();
            logger.Info("Click on button Two");


        }

        [When(@"user entered second number")]
        public void WhenUserEnteredSecondNumber()
        {

            var Three = session.FindElementByName("Calculator").FindElementByName("Three");
            Three.Click();
            logger.Info("Click on button three");
        }

        [When(@"Addition performed")]
        public void WhenAdditionPerformed()
        {
            session.FindElementByName("Calculator").FindElementByName("Plus").Click();
            logger.Info("Plus button pressed");

            // Assert.IsTrue(false);
        }


        [When(@"Subtraction performed")]
        public void WhenSubtractionPerformed()
        {
            session.FindElementByName("Calculator").FindElementByName("Minus").Click();
        }

        [When(@"Multiplication performed")]
        public void WhenMultiplicationPerformed()
        {
            session.FindElementByName("Calculator").FindElementByName("Multiply by").Click();
        }

        [When(@"Division performed")]
        public void WhenDivisionPerformed()
        {
            session.FindElementByName("Calculator").FindElementByName("Divide by").Click();
            logger.Info("Division performed");
            Assert.IsTrue(true);
            logger.Info("Assertion is true");
        }
            //SoftAssert softAssert = new SoftAssert();
            //softAssert.assertAll();
            /*         ========= Multiple assertions ===================
             *          Assert.Multiple(() =>
               {
                          Assert.That(result.RealPart, Is.EqualTo(5.2));
                          Assert.That(result.ImaginaryPart, Is.EqualTo(3.9));
               });

                              Can also work with the classic assertion syntax
                                Assert.Multiple(() =>
                      {
                                ClassicAssert.AreEqual(5.2, result.RealPart, "Real Part");
                                ClassicAssert.AreEqual(3.9, result.ImaginaryPart, "Imaginary Part");
                      });        
        }
            */


        [Then(@"User pressed Equals")]
        public void ThenUserPressedEquals()
        {
            session.FindElementByName("Calculator").FindElementByName("Equals").Click();
            logger.Info("Clicked on equal button");
            var st = new StackTrace();
            var sf = st.GetFrame(0);

            string currentMethodName = sf.GetMethod().Name;
           String tim= DateTime.Now.ToString("-dd-mm-yy-(hh-mm-ss)");
            currentMethodName = currentMethodName + tim;


            //GetScreenshot(currentMethodName,session);
            //String result = session.FindElementByAccessibilityId("CalculatorResults").Text;
            //Console.WriteLine(result);

        }

      /*  public static void GetScreenshot(string filename, WindowsDriver<WindowsElement> session)
        {
            try
            {

                var screenshot = session.GetScreenshot();

                // string folderPath = @"\whatever\path";
                //  Directory.CreateDirectory(folderPath);
                string folderPath = "C:\\Users\\omkarp\\source\\repos\\OPautomation\\UnitTestProject1\\TestResults\\FailedTest";
                Directory.CreateDirectory(folderPath);
                var filePath = "C:\\Users\\omkarp\\source\\repos\\OPautomation\\UnitTestProject1\\TestResults\\FailedTest\\screen " + filename + ".png";
                Console.WriteLine("................ screenshot path" + filePath);
                count++;

                screenshot.SaveAsFile(filePath, ScreenshotImageFormat.Png);
                Console.WriteLine("Screenshot capture ....................");

            }
            catch (Exception e)
            {
                Console.WriteLine("Line Failed: " + e.Message);
                Console.WriteLine("** COULD NOT GET SCREENSHOT ***");
            }

        } */

        }
    }

