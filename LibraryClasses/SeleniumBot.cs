using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

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
            string[] englishPronouns = {
                "I", "you", "he", "she", "it", "we", "they",
                "me", "you", "him", "her", "us", "them",
                "my", "your", "his", "her", "its", "our", "their",
                "mine", "yours", "his", "hers", "ours", "theirs",
                "myself", "yourself", "himself", "herself", "itself", "ourselves", "yourselves", "themselves",
                "in", "on", "at", "for", "by", "with", "the", "a"
            };

            _driver.Navigate().GoToUrl("https://www.bbc.com/news");
            Thread.Sleep(5000);
            IList<IWebElement> newsHeadlines = _driver.FindElements(By.CssSelector("p[class='ssrcss-17zglt8-PromoHeadline exn3ah96'] span")).ToList();

            Dictionary<string, int> wordCount = new Dictionary<string, int>();
            foreach (IWebElement element in newsHeadlines)
            {
                string[] words = element.Text.Split(' ');

                IEnumerable<string> filteredWords = words.Where(word => word.Length > 2 && !englishPronouns.Contains(word.ToLower()));

                foreach (string word in filteredWords)
                {
                    if (wordCount.ContainsKey(word.ToLower()))
                    {
                        wordCount[word.ToLower()]++;
                    }
                    else
                    {
                        wordCount[word.ToLower()] = 1;
                    }
                }
            }

            return wordCount.OrderByDescending(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
        }

        static public void Quit()
        {
            _driver.Quit();
        }
    }
}