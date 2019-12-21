using System;
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
    class CarPage
    {
        IWebDriver driver;

        [FindsBy(How = How.Id, Using = "more_extras_link")]
        private IWebElement openAdditionalServices;

        [FindsBy(How = How.Id, Using = "removePolicyButton")]
        private IWebElement buttonRemovePolicy;

        [FindsBy(How = How.Id, Using = "btn-submit-dd")]
        private IWebElement buttonReserve;

        [FindsBy(How = How.CssSelector, Using = "#errorTop > p")]
        private IWebElement errorMesseg;

        [FindsBy(How = How.CssSelector, Using = "div > div.extra-choice-extras > p:nth-child(1) > label > strong")]
        private IWebElement nameAdditionalService;

        [FindsBy(How = How.Id, Using = "11558698888010")]
        private IWebElement selectCountSeatForBaby;

        [FindsBy(How = How.Id, Using = "Title")]
        private IWebElement contacteCustomer;

        [FindsBy(How = How.Id, Using = "f_name_input")]
        private IWebElement FirstNameCustomer;

        [FindsBy(How = How.Id, Using = "surname_input")]
        private IWebElement SurNameCustomer;

        [FindsBy(How = How.Id, Using = "booking-form-email")]
        private IWebElement EmailCustomer;

        [FindsBy(How = How.Id, Using = "phone_input")]
        private IWebElement PhoneCustomer;

        [FindsBy(How = How.CssSelector, Using = "div > div.col-l > div.rc-box.price-summary-supplier.bg-white > div.price-items > div > ul > li > span.item")]
        private IWebElement correctNameAdditionalService;

        public CarPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }
        
        public CarPage OpenListAdditionalServices()
        {
            openAdditionalServices.Click();
            return this;
        }

        public CarPage ClickButtonRemovePolicy()
        {
            buttonRemovePolicy.Click();
            return this;
        }

        public CarPage ClickButtonReserve()
        {
            buttonReserve.Click();
            return this;
        }

        public CarPage SendkeysDataCustomer(string contact, string firstName, string surName, string email, string phone)
        {
            new SelectElement(contacteCustomer).SelectByText(contact);
            FirstNameCustomer.SendKeys(firstName);
            SurNameCustomer.SendKeys(surName);
            EmailCustomer.SendKeys(email);
            PhoneCustomer.SendKeys(phone);
            return this;
        }

        public CarPage ChoiseCountSeatForBaby()
        {
            new SelectElement(selectCountSeatForBaby).SelectByText("1");
            return this;
        }
        public string ReturnNameAdditionalService()
        {
            return nameAdditionalService.Text;
        }

        public string GetErrorMesseg()
        {
            return errorMesseg.Text;
        }

        public string ReturnCorrectAdditionalService()
        {
            return correctNameAdditionalService.Text;
        }
    }
}
