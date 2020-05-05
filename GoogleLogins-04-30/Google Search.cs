using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace GoogleLogins_04_30
{
    public class Tests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver("C:/Users/Striokai/Desktop/TUTA");
            driver.Manage().Window.FullScreen();
        }

        public void goToUrl()
        {
            driver.Url = "https://www.google.com/";

        }
        public void steps(string key)
        {
            goToUrl();
            driver.FindElement(By.Name("q")).SendKeys(key);
            driver.FindElement(By.Name("q")).SendKeys(Keys.Enter);
            Assert.AreEqual(key, driver.FindElement(By.ClassName("kno-ecr-pt")).Text);
        }

        [Test]
        public void Test1()
        {
            steps("Dog");
            steps("Cat");
        }
        [TearDown]
        public void Close()
        {
            driver.Close();
        }
    }
}