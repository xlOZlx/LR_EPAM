using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Framework.PageObject
{
    class ListFoundCars
    {
        IWebDriver driver;
        Actions actions;

        [FindsBy(How = How.CssSelector, Using = @"div.search-summary__section.search-summary__section--pick-up > div:nth-child(2) > div.search-summary__location")]
        public IWebElement correctInfo;

        [FindsBy(How = How.CssSelector, Using = @"div.sr-toolbar > span.sr-toolbar-left > ul > li:nth-child(2) > a")]
        public IWebElement selectNameProvider;

        [FindsBy(How = How.CssSelector, Using = @"#supplier-filter-content li:nth-child(1) label div.checkbox")]
        private IWebElement selectProvider;

        [FindsBy(How = How.CssSelector, Using = "table > tbody > tr:nth-child(3) > td.carResultRow_OfferInfo-toolbar > a > span:nth-child(2)")]
        private IWebElement buttonReserve;

        public ListFoundCars(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
            actions = new Actions(this.driver);
        }

        public ListFoundCars AutoSelectProvider()
        {
            actions.MoveToElement(selectProvider).Build().Perform();
            new WebDriverWait(driver, TimeSpan.FromMilliseconds(10)).Until(ExpectedConditions.ElementToBeClickable(selectProvider)).Click();
            //selectProvider.Click();
            return this;
        }
        public ListFoundCars ClickButtonReser()
        {
            actions.MoveToElement(buttonReserve).Build().Perform();
            new WebDriverWait(driver, TimeSpan.FromMilliseconds(10)).Until(ExpectedConditions.ElementToBeClickable(buttonReserve)).Click();
            //buttonReserve.Click();
            return this;
        }
    }
}
