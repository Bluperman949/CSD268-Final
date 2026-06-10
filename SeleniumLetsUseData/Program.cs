using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Internal.Logging;

class Program {

  static IWebDriver _chromeDriver = new ChromeDriver();

  public static void Main() {
    Log.SetLevel(LogEventLevel.Debug);
    TestLetsUseData(_chromeDriver);
  }

  static void TestLetsUseData(IWebDriver driver) {
    driver.Navigate().GoToUrl("https://www.yourlearningpal.com/login");

  }
}
