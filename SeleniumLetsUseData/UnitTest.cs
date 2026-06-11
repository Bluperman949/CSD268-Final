using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Internal.Logging;

[TestClass]
public class UnitTests {

  const string
    _loginUsername = "test1",
    _loginPassword = "Test12456",
    _loginWrongPassword = "test1234";

  IWebDriver _driver = new ChromeDriver();

  static (IWebElement, IWebElement, IWebElement) GetLoginPane(IWebDriver driver) => (
    driver.FindElement(By.Id("txtUser")),
    driver.FindElement(By.Id("txtPassword")),
    driver.FindElement(By.XPath("//button[text()='Login']"))
  );

  void Init() {
    Log.SetLevel(LogEventLevel.Info);
    _driver.Navigate().GoToUrl("https://www.yourlearningpal.com/login");
  }

  [TestMethod]
  public void TestCorrectLogin() {
    Init();
    (var elUsername, var elPassword, var elSubmit) = GetLoginPane(_driver);

    elUsername.SendKeys(_loginUsername);
    elPassword.SendKeys(_loginWrongPassword);
    elSubmit.Click();

    // TODO: test for success
  }

  [TestMethod]
  public void TestIncorrctLogin() {
    Init();
    (var elUsername, var elPassword, var elSubmit) = GetLoginPane(_driver);

    elUsername.SendKeys(_loginUsername);
    elPassword.SendKeys(_loginPassword);
    elSubmit.Click();

    // TODO: test for failure
  }
}
