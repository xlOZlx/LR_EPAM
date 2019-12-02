using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;

namespace PagaObject
{
    [TestFixture]
    public class Tests
    {

        IWebDriver Browser;
        private static string URL_Site = "https://www.rentalcars.com/";

        [Test]
        public void StartSearchWithoutParameters()
        {
            Browser = new ChromeDriver();
            Browser.Manage().Window.Maximize();
            Browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            Browser.Navigate().GoToUrl(URL_Site);

            MainPage mainPage = new MainPage(Browser);
            mainPage.AutoSelectParameters_V2();
            mainPage.ClickButtonFind();

            ListFoundCars listFound = new ListFoundCars(Browser);
            Assert.AreEqual("Минск (Все места)", listFound.correctInfo.Text);

            Browser.Quit();
        }

        [Test]
        public void ListCarsFromSelectedProvider()
        {
            Browser = new ChromeDriver();
            Browser.Manage().Window.Maximize();
            Browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            Browser.Navigate().GoToUrl(URL_Site);

            MainPage mainPage = new MainPage(Browser);
            mainPage.AutoSelectParameters_V1();
            mainPage.ClickButtonFind();

            ListFoundCars listFound = new ListFoundCars(Browser);
            listFound.AutoSelectProvider();
            TimeSpan.FromSeconds(2);
            Assert.AreEqual(listFound.selectNameProvider.Text, "Avis");

            Browser.Quit();
        }
    }
}
