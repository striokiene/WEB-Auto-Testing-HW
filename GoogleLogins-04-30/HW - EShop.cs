using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace GoogleLogins_04_30
{
    public class Shop
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
            driver.Url = "http://automationpractice.com/index.php";
        }

        public void LogIn(string username, string password)
        {
            goToUrl();
            driver.FindElement(By.ClassName("login")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Id("email")).SendKeys(username);
            driver.FindElement(By.Id("passwd")).SendKeys(password);
            driver.FindElement(By.Id("SubmitLogin")).Click();
        }
        public void testLogIn(string username, string password)
        {
            LogIn(username, password);
            string actual = driver.FindElement(By.ClassName("account")).Text;
            string expected = "Tu Ta";
            Assert.AreEqual(expected, actual);

        }
        public void SearchForItem(string key)
        {
            driver.FindElement(By.Id("search_query_top")).SendKeys(key);
            driver.FindElement(By.Name("submit_search")).Click();
            Thread.Sleep(2000); 
        }
        public void testSearchForItem(string key)
        {
            SearchForItem(key);
            string actual = driver.FindElement(By.ClassName("product-name")).Text;
            string expected = "Blouse";
            Assert.AreEqual(expected, actual);
        }
        public void Order()
        {
            driver.FindElement(By.ClassName("ajax_add_to_cart_button")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.ClassName("button-medium")).Click();
            driver.FindElement(By.ClassName("standard-checkout")).Click();
            driver.FindElement(By.Name("processAddress")).Click();
            driver.FindElement(By.ClassName("checker")).Click();
            driver.FindElement(By.Name("processCarrier")).Click();
            driver.FindElement(By.ClassName("bankwire")).Click();
            driver.FindElement(By.XPath("//*[@id='cart_navigation']/button")).Click();
            Thread.Sleep(2000); 
        }
        public void testOrder()
        {
            Order();
            string actual = driver.FindElement(By.ClassName("dark")).Text;
            string expected = "Your order on My Store is complete.";
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Test()
        {
            LogIn("tuta@tuta.com", "tuta123");
            SearchForItem("blouse");
            Order();
        }
        [TearDown]
        public void Close()
        {
            driver.Close();
        }
    }
}
