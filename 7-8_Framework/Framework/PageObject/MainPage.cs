using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using Framework.Models;
using log4net;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace Framework.PageObject
{
    class MainPage
    {
        IWebDriver driver;
        Actions actions;

        [FindsBy(How = How.Id, Using = "js-closeCookieBanner")]
        private IWebElement buttonOK;

        [FindsBy(How = How.Id, Using = "formsubmit")]
        private IWebElement buttonFind;

        [FindsBy(How = How.Id, Using = "pu-country")]
        private IWebElement selectCountry;

        [FindsBy(How = How.Id, Using = "pu-city")]
        private IWebElement selectCity;

        [FindsBy(How = How.Id, Using = "pu-location")]
        private IWebElement selectLocation;

        [FindsBy(How = How.CssSelector, Using = "#SearchResultsForm > div:nth-child(5) > div.datetime-section.cf > fieldset.datetime-section__pu > div.a11y-panel > span")]
        private IWebElement calendarReceivingDate;

        [FindsBy(How = How.CssSelector, Using = "#SearchResultsForm > div:nth-child(5) > div.datetime-section.cf > fieldset.datetime-section__do > div.a11y-panel > span")]
        private IWebElement calendarReturnDate;

        [FindsBy(How = How.CssSelector, Using = "#SearchResultsForm > div:nth-child(5) > div.datetime-section.cf > fieldset.datetime-section__do > div.a11y-panel > span > div.date-panel__date-wrapper")]
        private IWebElement returnDateText;

        [FindsBy(How = How.CssSelector, Using = "tbody > tr:nth-child(3) > td:nth-child(5) > span.ui-state-default")]
        private IWebElement chooseReturnDate;

        [FindsBy(How = How.Id, Using = "doHour")]
        private IWebElement timeReturn;

        [FindsBy(How = How.CssSelector, Using = "#dateselect-calendar > div > table > tbody > tr:nth-child(4) > td:nth-child(4) > a")]
        private IWebElement choiseDate;

        [FindsBy(How = How.Id, Using = "driver-over-min-age")]
        private IWebElement checkboxAge;

        [FindsBy(How = How.Id, Using = "driver-age-input")]
        private IWebElement inputBoxDriverAge;

        [FindsBy(How = How.Id, Using = "footerContactLink")]
        private IWebElement linkContactUs;

        public MainPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
            actions = new Actions(this.driver);
            new WebDriverWait(driver, TimeSpan.FromMilliseconds(10)).Until(ExpectedConditions.ElementToBeClickable(buttonOK)).Click();
        }

        public MainPage ClickButtonFind()
        {
            Thread.Sleep(1000);
            //new WebDriverWait(driver, TimeSpan.FromMilliseconds(10)).Until(ExpectedConditions.ElementToBeClickable(buttonOK)).Click();
            actions.MoveToElement(buttonFind).Build().Perform();
            new WebDriverWait(driver, TimeSpan.FromMilliseconds(10)).Until(ExpectedConditions.ElementToBeClickable(buttonFind)).Click();
            //buttonFind.Click();
            return this;
        }

        public MainPage SelectCountry()
        {
            new SelectElement(selectCountry).SelectByText("Беларусь");
            return this;
        }

        public MainPage SelectCity()
        {
            new SelectElement(selectCity).SelectByText("Минск");
            return this;
        }

        public MainPage SelectLocation_MNA()
        {
            new SelectElement(selectLocation).SelectByText("Минск международный аэропорт");
            return this;
        }

        public MainPage SelectLocation_MALs()
        {
            new SelectElement(selectLocation).SelectByText("Минск (Все места)");
            return this;
        }

        public MainPage OpenCalenderReceivingDate()
        {
            actions.MoveToElement(buttonFind).Build().Perform();
            new WebDriverWait(driver, TimeSpan.FromMilliseconds(10)).Until(ExpectedConditions.ElementToBeClickable(calendarReceivingDate)).Click();
            //calendarReceivingDate.Click();
            return this;
        }

        public MainPage OpenCalenderReturnDate()
        {
            Thread.Sleep(1000);
            new WebDriverWait(driver, TimeSpan.FromMilliseconds(10)).Until(ExpectedConditions.ElementToBeClickable(calendarReturnDate)).Click();
            //calendarReturnDate.Click();
            return this;
        }

        public MainPage SelectReceivingAndReturnDate()
        {
            Thread.Sleep(1000);
            actions.MoveToElement(choiseDate).Build().Perform();
            new WebDriverWait(driver, TimeSpan.FromMilliseconds(10)).Until(ExpectedConditions.ElementToBeClickable(choiseDate)).Click();
            //choiseDate.Click();
            return this;
        }

        public MainPage SelectReturnTime()
        {
            new SelectElement(timeReturn).SelectByText("10");
            return this;
        }

        public MainPage SelectReturnDate()
        {
            Thread.Sleep(1000);
            new WebDriverWait(driver, TimeSpan.FromMilliseconds(10)).Until(ExpectedConditions.ElementToBeClickable(chooseReturnDate)).Click();
            //chooseReturnDate.Click();
            return this;
        }

        public MainPage EnableOrDisableCheckBoxAge()
        {
            //new WebDriverWait(driver, TimeSpan.FromMilliseconds(10)).Until(ExpectedConditions.ElementToBeClickable(buttonOK)).Click();
            actions.MoveToElement(buttonFind).Build().Perform();
            new WebDriverWait(driver, TimeSpan.FromMilliseconds(10)).Until(ExpectedConditions.ElementToBeClickable(checkboxAge)).Click();
            //checkboxAge.Click();
            return this;
        }

        public MainPage InputDriverAge(string age)
        {
            inputBoxDriverAge.Clear();
            Thread.Sleep(1000);
            inputBoxDriverAge.SendKeys(age);
            return this;
        }

        public string GetReturnDateText()
        {
            return returnDateText.Text;
        }

        public string GetAlertText()
        {
            return new WebDriverWait(driver, TimeSpan.FromMilliseconds(10)).Until(ExpectedConditions.AlertIsPresent()).Text;
        }

        public MainPage ClickContactUs()
        {
            //new WebDriverWait(driver, TimeSpan.FromMilliseconds(10)).Until(ExpectedConditions.ElementToBeClickable(buttonOK)).Click();
            actions.MoveToElement(linkContactUs).Build().Perform();
            new WebDriverWait(driver, TimeSpan.FromMilliseconds(10)).Until(ExpectedConditions.ElementToBeClickable(linkContactUs)).Click();
            //linkContactUs.Click();
            return this;
        }
    }
}
