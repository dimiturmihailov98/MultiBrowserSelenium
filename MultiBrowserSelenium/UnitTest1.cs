using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;

namespace Selenium_Examples
{
    [TestFixture(typeof(FirefoxOptions))]
    [TestFixture(typeof(ChromeOptions))]
    [Parallelizable(ParallelScope.Self)]
    public class MultiTest<TOptions> where TOptions : DriverOptions, new()
    {
        private IWebDriver driver;

        [OneTimeSetUp]
        public void Setup()
        {
            var options = new TOptions();
            driver = new RemoteWebDriver(
                new Uri("http://localhost:4444/wd/hub"), options);
        }

        [Test]
        public void Test_NakovCom_Title()
        {
            driver.Navigate().GoToUrl("https://nakov.com");
            Assert.That(driver.Title.Contains("Svetlin Nakov"));
        }

        [Test]
        public void Test_Wikipedia_Title()
        {
            driver.Navigate().GoToUrl("https://wikipedia.org");
            Assert.That(driver.Title.Contains("Wikipedia"));
        }

        [Test]
        public void Test_Google_Title()
        {
            driver.Navigate().GoToUrl("https://google.com");
            Assert.That(driver.Title.Contains("Google"));
        }

        [OneTimeTearDown]
        public void Shutdown()
        {
            driver.Quit();
        }
    }
}