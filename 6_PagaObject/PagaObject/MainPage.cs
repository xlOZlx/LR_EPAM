using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;

namespace PagaObject
{
    class MainPage
    {
        [FindsBy(How = How.Id, Using = "formsubmit")]
        private IWebElement buttonFind { get; set; }
        [FindsBy(How = How.Id, Using = "pu-country")]
        private IWebElement listCountry;
        [FindsBy(How = How.XPath, Using = @"//option[@value = 'Беларусь']")]
        private IWebElement selectCountry;
        [FindsBy(How = How.Id, Using = "pu-city")]
        private IWebElement listCity;
        [FindsBy(How = How.XPath, Using = @"//option[@value = 'Минск']")]
        private IWebElement selectCity;
        [FindsBy(How = How.Id, Using = "pu-location")]
        private IWebElement listLocation;
        [FindsBy(How = How.XPath, Using = @"//option[@value = '1202561']")]
        private IWebElement selectLocation_V1;
        [FindsBy(How = How.XPath, Using = @"//option[@value = '-1']")]
        private IWebElement selectLocation_V2;
        public MainPage(IWebDriver browser)
        {
            PageFactory.InitElements(browser, this);
        }
        public MainPage ClickButtonFind()
        {
            buttonFind.Click();
            return this;
        }
        public MainPage AutoSelectParameters_V1()
        {
            listCountry.Click();
            TimeSpan.FromSeconds(2);
            selectCountry.Click();
            listCity.Click();
            TimeSpan.FromSeconds(2);
            selectCity.Click();
            listLocation.Click();
            TimeSpan.FromSeconds(2);
            selectLocation_V1.Click();
            return this;
        }
        public MainPage AutoSelectParameters_V2()
        {
            listCountry.Click();
            TimeSpan.FromSeconds(2);
            selectCountry.Click();
            listCity.Click();
            TimeSpan.FromSeconds(2);
            selectCity.Click();
            listLocation.Click();
            TimeSpan.FromSeconds(2);
            selectLocation_V2.Click();
            return this;
        }
    }
}
