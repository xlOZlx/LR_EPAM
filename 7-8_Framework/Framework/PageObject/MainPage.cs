﻿using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using Framework.Models;
using log4net;

namespace Framework.PageObject
{
    class MainPage
    {
        IWebDriver driver;

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

        [FindsBy(How = How.CssSelector, Using = "#dateselect-calendar > div > table > tbody > tr:nth-child(5) > td:nth-child(6) > a")]
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
        }

        public MainPage ClickButtonFind()
        {
            buttonFind.Click();
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
            calendarReceivingDate.Click();
            return this;
        }

        public MainPage OpenCalenderReturnDate()
        {
            calendarReturnDate.Click();
            return this;
        }

        public MainPage SelectReceivingAndReturnDate()
        {
            choiseDate.Click();
            return this;
        }

        public MainPage SelectReturnTime()
        {
            new SelectElement(timeReturn).SelectByText("10");
            return this;
        }

        public MainPage SelectReturnDate()
        {
            chooseReturnDate.Click();
            return this;
        }

        public MainPage EnableOrDisableCheckBoxAge()
        {
            checkboxAge.Click();
            return this;
        }

        public MainPage InputDriverAge(string age)
        {
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
            linkContactUs.Click();
            return this;
        }
    }
}