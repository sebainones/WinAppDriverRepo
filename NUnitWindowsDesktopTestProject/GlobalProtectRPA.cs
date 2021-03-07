using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;

namespace NUnitWindowsDesktopTestProject
{
    public class GlobalProtectRPA
    {
        private WindowsDriver<WindowsElement> _driver;

        [SetUp]
        public void Setup()
        {
            var options = new AppiumOptions();
            options.AddAdditionalCapability("app", @"C:\Program Files\Palo Alto Networks\GlobalProtect\PanGPA.exe");
            options.AddAdditionalCapability("deviceName", "WindowsPC");
            _driver = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), options);

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [TearDown]
        public void TestCleanup()
        {
            if (_driver != null)
            {
                _driver.Quit();
                _driver = null;
            }
        }

        [Test]
        public void ConnectWithGlobalProtect()
        {
            var notConnectedElement = _driver.FindElementByName("Not Connected");
            if (notConnectedElement != null)
            {
                _driver.FindElementByName("Connect").Click();  //"1160"
                Assert.Pass();
            }
            else
                Assert.Fail();
        }
    }
}