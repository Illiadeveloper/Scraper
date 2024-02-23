using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Security.RightsManagement;

namespace LibraryClasses
{
    static public class SeleniumBot
    {
        static private IWebDriver _driver;

        static SeleniumBot() {
            _driver = new ChromeDriver();
        }

        static public Dictionary<string, int> GetPopularWords()
        {
            return new Dictionary<string, int>();
        }
        static public void Quit()
        {
            _driver.Quit();
        }
    }
}