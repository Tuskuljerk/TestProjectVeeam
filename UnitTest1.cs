using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestProjectVeeam
{
    public class Tests
    {
        private IWebDriver driver;

        private readonly By _groupDropDownButton = By.XPath("//button[text() = 'Все отделы']");

        private readonly By _developerButton = By.XPath("//a[text() = 'Разработка продуктов']");

        private readonly By _allLanguagesDropDownButton = By.XPath("//Button[text() = 'Все языки']");

        private readonly By _englishLangButton = By.XPath("//label[@for = 'lang-option-0']");

        private readonly By _vakanciesCount = By.XPath("//a[@class = 'card card-no-hover card-sm']");

        private const int _exceptedVacansies = 5;


        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl("https://careers.veeam.ru/vacancies");
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1()
        {
            var dropDown = driver.FindElement(_groupDropDownButton);
            dropDown.Click();

            var devButton = driver.FindElement(_developerButton);
            devButton.Click();

            var languagesButton = driver.FindElement(_allLanguagesDropDownButton);
            languagesButton.Click();

            var englishLangButton = driver.FindElement(_englishLangButton);
            englishLangButton.Click();

            languagesButton.Click();

            var actualVacancies = driver.FindElements(_vakanciesCount).Count;

            Assert.AreEqual(_exceptedVacansies, actualVacancies, "actual not equal excepted");

        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}