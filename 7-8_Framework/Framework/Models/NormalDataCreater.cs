using System;
using Framework.Service;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Framework.Models
{
    public class NormalDataCreater
    {
        public string Contact;
        public string FirstName;
        public string SurName;
        public string MobilePhone;
        public string MailAdress;

        public NormalDataCreater()
        {
            Contact = NormalDataReader.GetData("Contact");
            FirstName = NormalDataReader.GetData("FirstName");
            SurName = NormalDataReader.GetData("SurName");
            MobilePhone = NormalDataReader.GetData("MobilePhone");
            MailAdress = NormalDataReader.GetData("MailAdress"); 
        }
    }
}
