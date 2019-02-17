using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;

using TestUkrNet.Pages;
using TestUkrNet.Data;

namespace TestUkrNet.Tests
{
    class UkrNetTests
    {
        IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            driver.Navigate().GoToUrl("https://www.ukr.net/ua/");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void invalidLoginTest()
        {
            //Arrange
            var expectedLoginDataErrorMessage = "Неправильні дані";
            var actualLoginDataErrorMessage ="";
            var inputLogin = "TestLogin";
            var inputPass = "TestPass";

            //Act
            UkrNetMainPage ukrNetMainPage = new UkrNetMainPage(driver);
            //SelectElement lngDropdown = new SelectElement(ukrNetMainPage.languageDropdown);
            //lngDropdown.SelectByText("Українською");
            ukrNetMainPage.loginField.Clear();
            ukrNetMainPage.loginField.SendKeys(inputLogin);
            ukrNetMainPage.passwordField.SendKeys(inputPass);
            ukrNetMainPage.submitButton.Click();
            actualLoginDataErrorMessage = ukrNetMainPage.loginDataErrorMessage.Text;

            Thread.Sleep(3000);

            //Assert
            Assert.True(expectedLoginDataErrorMessage.Equals(actualLoginDataErrorMessage), $"Login Error Message ia INCORRECT! Actual message is <{actualLoginDataErrorMessage}>.\nExpected message is <{expectedLoginDataErrorMessage}>");
            Console.WriteLine("Login Error Message ia CORRECT.");
        }

        [Test]
        public void sendLetterTest()
        {
            //Arrange
            var actualMsgAfterSending = "";
            var expectedTextAfterLetterSending01 = "Ваш";
            var expectedTextAfterLetterSending02 = "лист";
            var expectedTextAfterLetterSending03 = "надіслано";

            //Act
            AccountData accountData = new AccountData();
            UkrNetMainPage ukrNetMainPage = new UkrNetMainPage(driver);
            ukrNetMainPage.loginField.Clear();
            ukrNetMainPage.loginField.SendKeys(accountData.loginUkrNet);
            ukrNetMainPage.passwordField.SendKeys(accountData.paswordUkrNet);
            ukrNetMainPage.submitButton.Click();
            Thread.Sleep(2000);

            DataForLetter dataForLetter = new DataForLetter();
            UkrNetMailPage ukrNetMailPage = new UkrNetMailPage(driver);
            ukrNetMailPage.sendToField.SendKeys(dataForLetter.addressSendTo);
            ukrNetMailPage.letterThemeField.SendKeys(dataForLetter.textForTheme);
            ukrNetMailPage.letterTextField.SendKeys(dataForLetter.textForLetter);
            ukrNetMailPage.sendButton.Click();
            actualMsgAfterSending = ukrNetMailPage.letterWasSentMsg.Text;

            //Assert
            var result01 = actualMsgAfterSending.Contains(expectedTextAfterLetterSending01);
            var result02 = actualMsgAfterSending.Contains(expectedTextAfterLetterSending02);
            var result03 = actualMsgAfterSending.Contains(expectedTextAfterLetterSending03);

            Assert.True(result01 && result02 && result03, "Unexpected message is displayed after sending of the letter.\n" +
                $"<{expectedTextAfterLetterSending01}> - {result01}\n" +
                $"<{expectedTextAfterLetterSending02}> - {result02}\n" +
                $"<{expectedTextAfterLetterSending03}> - {result03}\n"
                );
            Console.WriteLine("The letter was sent SUCCESSFULLY.");
        }

        [Test]
        public void Test1()
        {
            //Thread.Sleep(10000);
            IWebElement element = driver.FindElement(By.XPath("//*[@id='search-input']"));
            element.Click();
            element.SendKeys("abc");

            Thread.Sleep(3000);
        }

        [Test]
        public void Test2()
        {
            DataForLetter dataForLetter = new DataForLetter();
            UkrNetMainPage ukrNetMainPage = new UkrNetMainPage (driver);
            ukrNetMainPage.searchField.SendKeys(dataForLetter.trashTest);

            Thread.Sleep(3000);
        }

        [Test]
        public void Test3()
        {
            DataForLetter dataForLetter = new DataForLetter();
            UkrNetMainPage ukrNetMainPage = new UkrNetMainPage(driver);
            ukrNetMainPage.searchField.SendKeys(dataForLetter.trashTest);
            ukrNetMainPage.submitButton.Click();

            Thread.Sleep(3000);
        }
    }
}
