using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.IO;
using System.Threading;

namespace FrameworkUITesting
{
    [TestClass]
    public class MainTests
    {
        private static WindowsDriver<WindowsElement> Driver;
        private const string TESTING_OUT_DIR = @"C:\MyTestingFolder\";

        [ClassInitialize]
        public static void TestFixtureSetup(TestContext context)
        {
            var appiumOptions = new OpenQA.Selenium.Appium.AppiumOptions();
            appiumOptions.AddAdditionalCapability("app",
                @"C:\Users\jwhaley\source\repos\FrameworkUIAutomation\FrameworkUIAutomation\bin\Debug\FrameworkUIAutomation.exe");
            appiumOptions.AddAdditionalCapability("appWorkingDir", TESTING_OUT_DIR);

            Driver = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), appiumOptions);
            File.WriteAllText($"{TESTING_OUT_DIR}{DateTime.Now:MM-dd-yyyy}_UITestResults.log", Driver.PageSource);
        }

        [TestMethod]
        public void ButtonClickTest()
        {
            // Press Button and check label
            var btnTestMe = Driver.FindElementByName("button1");
            var lblResultText = Driver.FindElementByName("label1");
            btnTestMe.Click();
            Thread.Sleep(2000);
            Assert.IsTrue(lblResultText.Text.Equals("Clicked!"));
            Thread.Sleep(2000);
            //
        }

        [TestMethod]
        public void CheckboxClickTest()
        {
            // Press CheckBox
            var chkbxCheckMe = Driver.FindElementByName("checkBox1");
            chkbxCheckMe.Click();
            // Assert.True(chkbxCheckMe.)
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            Driver.Quit();
            Driver = null;
        }
    }
}
