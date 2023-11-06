using Core.DriverFactory;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using POM;
using Core;
using NLog;

using static Core.DriverFactory.DriverProvider;
using Core.LoggerFolder;

namespace Practical_assessment
{
    [Parallelizable((ParallelScope)2)]
    public class Tests
    {
        private NLogImplementation logger; 
        IWebDriver driver;
        private LoginPage loginPage;
        WebDriverWait wait;

        public Tests()
        {
            logger = new NLogImplementation("Tests");
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
            logger.Info("Starting Test1");

            loginPage.InputName();
            loginPage.InputPassword();
            loginPage.ClearNameInput();
            loginPage.ClearPasswordInput();
            loginPage.RefreshPage();
            loginPage.Submit();
            Assert.IsTrue(loginPage.CheckEmptyNameInputError());
            Console.WriteLine(Environment.CurrentDirectory);
            
            logger.Info("Finished Test1");
        }

        [Test]
        public void Test2()
        {
            logger.Info("Starting Test2");

            loginPage.InputName();
            loginPage.InputPassword();
            loginPage.ClearPasswordInput();
            loginPage.Submit();
            Assert.IsTrue(loginPage.CheckEmptyPasswordInputError());

            logger.Info("Finished Test2");
        }

        [Test]
        public void Test3()
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