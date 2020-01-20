using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;
using Framework.PageObject;
using Framework.Test;
using Framework.Service;
using Framework.Models;
using log4net;
using System.Threading;
using System.Linq;

namespace Framework.Test
{
    class Tests : TestConfig
    {
        [Test]
        public void PressButtonFindWithoutDataSearch()
        {
            MainPage mainPage = new MainPage(Driver).ClickButtonFind();
            Assert.AreEqual("Страна получения - необходимо указать\r\n" +
                "Место получения - необходимо указать\r\n" +
                "Город получения - необходимо указать\r\n",
                mainPage.GetAlertText());
        }

        [Test]
        public void ChooseReturnDateAutoBeforReceivingDate()
        {
            MainPage mainPage = new MainPage(Driver).SelectCountry()
                .SelectCity()
                .SelectLocation_MNA();
            string returnDateReforeChoise = mainPage.GetReturnDateText();
            mainPage.OpenCalenderReturnDate()
                .SelectReturnDate()
                .OpenCalenderReturnDate();
            string returnDateAfterChoise = mainPage.GetReturnDateText();
            Assert.AreEqual(returnDateReforeChoise, returnDateAfterChoise);
        }

        [Test]
        public void ReceiptDateIsEqualReturnDateByHour()
        {
            MainPage mainPage = new MainPage(Driver).SelectCountry()
                .SelectCity()
                .SelectLocation_MNA()
                .OpenCalenderReceivingDate()
                .SelectReceivingAndReturnDate()
                .OpenCalenderReturnDate()
                .SelectReceivingAndReturnDate()
                .SelectReturnTime()
                .ClickButtonFind();
            string errorMesseg = mainPage.GetAlertText();
            Assert.AreEqual(" Должно быть не менее одного часа между получением и возвратом автомобиля\r\n", errorMesseg);
        }

        [Test]
        public void SetDriverAgeToZero()
        {
            InvalidDataCreater invalidDataCreater = new InvalidDataCreater();
            MainPage mainPage = new MainPage(Driver).SelectCountry()
                .SelectCity()
                .SelectLocation_MNA()
                .EnableOrDisableCheckBoxAge()
                .InputDriverAge(invalidDataCreater.DriverAge)
                .ClickButtonFind();
            Assert.AreEqual("Возраст водителя должно быть по крайней мере 18\r\n", mainPage.GetAlertText());
        }

        [Test]
        public void SeeListAvailablePlacesGetCars()
        {
            MainPage mainPage = new MainPage(Driver).SelectCountry()
                .SelectCity()
                .SelectLocation_MALs()
                .ClickButtonFind();
            ListFoundCars listFound = new ListFoundCars(Driver);
            Assert.AreEqual("Минск (Все места)", listFound.correctInfo.Text);
        }

        [Test]
        public void StartSearchAuto()
        {
            MainPage mainPage = new MainPage(Driver).SelectCountry()
                .SelectCity()
                .SelectLocation_MNA()
                .ClickButtonFind();
            ListFoundCars listFound = new ListFoundCars(Driver);
            Assert.AreEqual("Минск международный аэропорт", listFound.correctInfo.Text);
        }

        [Test]
        public void ReserveCarWithoutCutomerData()
        {
            MainPage mainPage = new MainPage(Driver).SelectCountry()
                .SelectCity()
                .SelectLocation_MNA()
                .ClickButtonFind();
            ListFoundCars listFound = new ListFoundCars(Driver).ClickButtonReser();
            Driver.SwitchTo().Window(Driver.WindowHandles.Last());
            CarPage carPage = new CarPage(Driver).ClickButtonRemovePolicy();
            CarPage carPageData = new CarPage(Driver)
                .ClickButtonReserve();
            Assert.AreEqual("Пропущенные поля показаны красным...", carPageData.GetErrorMesseg());
        }

        [Test]
        public void ReserveCarWithAdditionalServices()
        {
            NormalDataCreater normalDataCreater = new NormalDataCreater();
            MainPage mainPage = new MainPage(Driver).SelectCountry()
                .SelectCity()
                .SelectLocation_MNA()
                .ClickButtonFind();
            ListFoundCars listFound = new ListFoundCars(Driver).ClickButtonReser();
            Driver.SwitchTo().Window(Driver.WindowHandles.Last());
            CarPage carPage = new CarPage(Driver);
            carPage.OpenListAdditionalServices()
                .ChoiseCountSeatForBaby();
            string nameAddService = carPage.ReturnNameAdditionalService();
            carPage.ClickButtonRemovePolicy();
            CarPage carPageData = new CarPage(Driver).SendkeysDataCustomer(normalDataCreater.Contact,
                                                                           normalDataCreater.FirstName,
                                                                           normalDataCreater.SurName,
                                                                           normalDataCreater.MailAdress,
                                                                           normalDataCreater.MobilePhone)
                .ClickButtonReserve();
            CarPage carPageCorrectData = new CarPage(Driver);
            Assert.AreEqual(nameAddService, carPageCorrectData.ReturnCorrectAdditionalService());
        }

        [Test]
        public void ListCarsFromSelectedProvider()
        {
            MainPage mainPage = new MainPage(Driver).SelectCountry()
                .SelectCity()
                .SelectLocation_MNA()
                .ClickButtonFind();
            ListFoundCars listFound = new ListFoundCars(Driver);
            listFound.AutoSelectProvider();
            ListFoundCars listFoundWithProvider = new ListFoundCars(Driver);
            Assert.AreEqual(listFoundWithProvider.selectNameProvider.Text, "Avis");
        }

        [Test]
        public void ContactRepresentative()
        {
            MainPage mainPage = new MainPage(Driver);
            mainPage.ClickContactUs();
            ContactsPage contactsPage = new ContactsPage(Driver);
            Assert.AreEqual("Помощь и поддержка", contactsPage.GetHeaderHelpAndSupport());
        }
    }
}
