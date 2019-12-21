using System;
using Framework.Models;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Framework.PageObject
{
    class ContactsPage
    {
        IWebDriver driver;

        [FindsBy(How = How.CssSelector, Using = "div > div.hero-content > h1")]
        private IWebElement headerHelpAndSupport;
        public ContactsPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }

        public string GetHeaderHelpAndSupport()
        {
            return headerHelpAndSupport.Text;
        }

    }
}
