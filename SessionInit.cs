using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class SessionInit
    {
      //  protected static WindowsDriver<WindowsElement> sessionb;
        public static WindowsDriver<WindowsElement> session;
        [TestMethod]
        public static void StartSession(TestContext context)
        {

            AppiumOptions appiumOptions = new AppiumOptions();
            appiumOptions.AddAdditionalCapability("platformName", "Windows");
            appiumOptions.AddAdditionalCapability("app", "Root");
            appiumOptions.AddAdditionalCapability("deviceName", "WindowsPC");

            
            

            
             session = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), appiumOptions);
            session.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            // Attaching to existing Application Window
            var listOfWindows = session.FindElementsByXPath(@"//Window");
            Console.WriteLine(listOfWindows.Count);
            foreach (var window in listOfWindows)
            {
                if(window.Text.Contains("Notepad"))
                {
                    var topLevelWindowHandle = window.GetAttribute("NativeWindowHandle");
                    Console.WriteLine("********" + topLevelWindowHandle);
                    topLevelWindowHandle = int.Parse(topLevelWindowHandle).ToString("X");
                    appiumOptions = new AppiumOptions();
                    appiumOptions.AddAdditionalCapability("appTopLevelWindow", topLevelWindowHandle);
                    session = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), appiumOptions);
                    break;
                }
            }
           // var applicationwindow = session.FindElementByName("Calculator");
          //  var topLevelWindowHandle = applicationwindow.GetAttribute("NativeWindowHandle");
            //Console.WriteLine("********"+topLevelWindowHandle);
            //topLevelWindowHandle = int.Parse(topLevelWindowHandle).ToString("X");   // X mandatory

            //appiumOptions = new AppiumOptions();
            //appiumOptions.AddAdditionalCapability("appTopLevelWindow", topLevelWindowHandle);
            //session = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), appiumOptions);


          

           

            

            if (session==null)
            {
                Console.WriteLine("Session not started");
            }
            else
            {
                Console.WriteLine("Session started");
            }
        }
    }
}
