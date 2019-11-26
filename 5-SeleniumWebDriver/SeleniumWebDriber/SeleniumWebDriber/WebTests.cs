using System;
using System.Collections.Generic;
using System.Linq;
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
            webDriver = new ChromeDriver();
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

            IWebElement listCity = webDriver.FindElement(By.Id("pu-city"));
            listCity.Click();
            IWebElement SelectCity = webDriver.FindElement(By.XPath("//option[@value = 'Минск']"));
            SelectCity.Click();

            IWebElement listLocation = webDriver.FindElement(By.Id("pu-location"));
            listLocation.Click();
            IWebElement selectLocation = webDriver.FindElement(By.XPath("//option[@value = '1202561']"));
            selectLocation.Click();

            Thread.Sleep(1000);
            IWebElement ButtonFind = webDriver.FindElement(By.Id("formsubmit"));
            ButtonFind.Click();
            Thread.Sleep(2000);
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

        //    //Thread.Sleep(5000);
        //    IWebElement ButtonFind = webDriver.FindElement(By.Id("formsubmit"));
        //    ButtonFind.Click();
        //    Thread.Sleep(3000);


        //    IWebElement listAuto = webDriver.FindElement(By.CssSelector("div.col-r.js-main-content div.carResultDiv"));
        //    IWebElement buttonReserve = listAuto.FindElement(By.CssSelector("table.carResultRow tbody tr.carResultRow_OfferInfo td.carResultRow_OfferInfo-toolbar a.carResultRow_OfferInfo-btn-primary"));
        //    buttonReserve.Click();

        //    //Thread.Sleep(3500);

        //    webDriver.SwitchTo().Window(webDriver.WindowHandles.Last());

        //    Thread.Sleep(3500);

        //    IWebElement openMoreServices = webDriver.FindElement(By.Id("more_extras_link"));
        //    openMoreServices.Click();

        //    Thread.Sleep(1000);

        //    IWebElement Service1 = webDriver.FindElement(By.Name("add1"));
        //    Service1.Click();
        //    IWebElement Service2 = webDriver.FindElement(By.Name("add2"));
        //    Service2.Click();

        //    Thread.Sleep(2500);

        //    IWebElement ReserveWithoutFullProtection = webDriver.FindElement(By.Id("removePolicyButton")) ;
        //    ReserveWithoutFullProtection.Click();

        //    Thread.Sleep(1500);

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

        //    Thread.Sleep(1500);

        //    IWebElement reserveAfterFIO = webDriver.FindElement(By.Id("btn-submit-dd"));
        //    reserveAfterFIO.Click();
        //    Thread.Sleep(1500);
        //    Assert.AreEqual(webDriver.Url, "https://www.rentalcars.com/PaymentDetails.do");
        //}
    }
}
