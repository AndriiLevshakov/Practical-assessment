using Core.DriverFactory;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using POM;
using Core;

using static Core.DriverFactory.DriverProvider;

namespace Practical_assessment
{
    public class Tests2
    {
        IWebDriver driver;
        private LoginPage loginPage;
        WebDriverWait wait;

        [SetUp]
        public void Setup()
        {
            var browser = (Drivers)Enum.Parse(typeof(Drivers), Configuration.Model.Browser);
            driver = DriverProvider.GetDriverFactory(browser).CreateDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            loginPage = new LoginPage(driver);
            loginPage.NavigateToLoginPage();
        }

        [Test]
        public void Test1()
        {
            loginPage.InputName();
            loginPage.InputPassword();
            loginPage.ClearPasswordInput();
            loginPage.Submit();
            Assert.IsTrue(loginPage.CheckEmptyPasswordInputError());
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}