using Core.DriverFactory;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using POM;
using Core;

using static Core.DriverFactory.DriverProvider;
using Core.LoggerFolder;

namespace Practical_assessment
{
    public class Tests3
    {
        private NLogImplementation logger;
        IWebDriver driver;
        private LoginPage loginPage;
        WebDriverWait wait;

        public Tests3()
        {
            logger = new NLogImplementation("Tests3");
        }

        [SetUp]
        public void Setup()
        {
            logger.Info("Setting up the test");

            var browser = (Drivers)Enum.Parse(typeof(Drivers), Configuration.Model.Browser);
            driver = DriverProvider.GetDriverFactory(browser).CreateDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            loginPage = new LoginPage(driver);
            loginPage.NavigateToLoginPage();
        }

        [Test]
        public void Test1()
        {
            logger.Info("Starting Test3");

            loginPage.InputName();
            loginPage.InputPassword();            
            loginPage.Submit();
            Assert.IsTrue(loginPage.CheckSuccessfulLogin());

            logger.Info("Finished Test3");
        }

        [TearDown]
        public void TearDown()
        {
            logger.Info("Tearing down the test");

            driver.Dispose();
        }
    }
}