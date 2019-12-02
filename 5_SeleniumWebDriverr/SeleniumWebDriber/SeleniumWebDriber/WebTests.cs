using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumWebDriver
{
    [TestFixture]
    public class WebTests
    {
        public IWebDriver webDriver;

        [SetUp]
        public void StartBrowserAndGoToTheSite()
        {
            webDriver = new OpenQA.Selenium.IE.InternetExplorerDriver();
            webDriver.Manage().Window.Maximize();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            webDriver.Navigate().GoToUrl("https://www.rentalcars.com/");
        }

        [TearDown]
        public void QuitDriver()
        {
            webDriver.Quit();
        }

        [Test]
        public void ViewListOfAvailableACar()
        {
            IWebElement listCountry = webDriver.FindElement(By.Id("pu-country"));
            listCountry.Click();
            IWebElement SelectCounry = webDriver.FindElement(By.XPath("//option[@value = 'Беларусь']"));
            SelectCounry.Click();
            string country = SelectCounry.Text;

            IWebElement listCity = webDriver.FindElement(By.Id("pu-city"));
            listCity.Click();
            IWebElement SelectCity = webDriver.FindElement(By.XPath("//option[@value = 'Минск']"));
            SelectCity.Click();
            string city = SelectCity.Text;

            IWebElement listLocation = webDriver.FindElement(By.Id("pu-location"));
            listLocation.Click();
            IWebElement selectLocation = webDriver.FindElement(By.XPath("//option[@value = '1202561']"));
            selectLocation.Click();

            TimeSpan.FromSeconds(3);
            IWebElement ButtonFind = webDriver.FindElement(By.Id("formsubmit"));
            ButtonFind.Click();
            Thread.Sleep(8000);

            int match = 0;
            if (webDriver.Url.Contains(country))
                match++;
            if (webDriver.Url.Contains("Минск"))
                match++;

            Assert.AreEqual(match, 2);
        }

        //[Test]
        //public void ViewPossibleCarsFromSpecificSupplier()
        //{
        //    IWebElement listCountry = webDriver.FindElement(By.Id("pu-country"));
        //    listCountry.Click();
        //    IWebElement SelectCounry = webDriver.FindElement(By.XPath("//option[@value = 'Беларусь']"));
        //    SelectCounry.Click();

        //    IWebElement listCity = webDriver.FindElement(By.Id("pu-city"));
        //    listCity.Click();
        //    IWebElement SelectCity = webDriver.FindElement(By.XPath("//option[@value = 'Минск']"));
        //    SelectCity.Click();

        //    IWebElement listLocation = webDriver.FindElement(By.Id("pu-location"));
        //    listLocation.Click();
        //    IWebElement selectLocation = webDriver.FindElement(By.XPath("//option[@value = '1202561']"));
        //    selectLocation.Click();

        //    //TimeSpan.FromSeconds(5);
        //    IWebElement ButtonFind = webDriver.FindElement(By.Id("formsubmit"));
        //    ButtonFind.Click();
        //    TimeSpan.FromSeconds(3);


        //    IWebElement listAuto = webDriver.FindElement(By.CssSelector("div.col-r.js-main-content div.carResultDiv"));
        //    IWebElement buttonReserve = listAuto.FindElement(By.CssSelector("table.carResultRow tbody tr.carResultRow_OfferInfo td.carResultRow_OfferInfo-toolbar a.carResultRow_OfferInfo-btn-primary"));
        //    buttonReserve.Click();

        //    //TimeSpan.FromSeconds(4);

        //    webDriver.SwitchTo().Window(webDriver.WindowHandles.Last());

        //    TimeSpan.FromSeconds(4);

        //    IWebElement openMoreServices = webDriver.FindElement(By.Id("more_extras_link"));
        //    openMoreServices.Click();

        //    Thread.Sleep(1000);

        //    IWebElement Service1 = webDriver.FindElement(By.Name("add1"));
        //    Service1.Click();
        //    IWebElement Service2 = webDriver.FindElement(By.Name("add2"));
        //    Service2.Click();

        //    TimeSpan.FromSeconds(4);

        //    IWebElement ReserveWithoutFullProtection = webDriver.FindElement(By.Id("removePolicyButton")) ;
        //    ReserveWithoutFullProtection.Click();

        //    TimeSpan.FromSeconds(2);

        //    IWebElement listAppeal = webDriver.FindElement(By.Id("title"));
        //    listAppeal.Click();
        //    IWebElement selectAppeal = webDriver.FindElement(By.XPath("//option[@value = 'Господин']"));
        //    selectAppeal.Click();
        //    IWebElement nameCustomer = webDriver.FindElement(By.Id("f_name_input"));
        //    nameCustomer.SendKeys("Dmiry");
        //    IWebElement surnameCustomer = webDriver.FindElement(By.Id("surname_input"));
        //    surnameCustomer.SendKeys("Platov");
        //    IWebElement emailCustomer = webDriver.FindElement(By.Id("booking-form-email"));
        //    emailCustomer.SendKeys("dima1111.17@gmail.com");
        //    IWebElement phoneCustomer = webDriver.FindElement(By.Id("phone_input"));
        //    phoneCustomer.SendKeys("+375292233000");

        //    TimeSpan.FromSeconds(2);

        //    IWebElement reserveAfterFIO = webDriver.FindElement(By.Id("btn-submit-dd"));
        //    reserveAfterFIO.Click();
        //    TimeSpan.FromSeconds(2);
        //    Assert.AreEqual(webDriver.Url, "https://www.rentalcars.com/PaymentDetails.do");
        //}
    }
}
