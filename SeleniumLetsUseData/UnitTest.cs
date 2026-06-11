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
    _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
    _driver.Navigate().GoToUrl("https://www.yourlearningpal.com/login");
  }

  [TestMethod]
  public void TestCorrectLogin() {
    Init();
    (var elUsername, var elPassword, var elSubmit) = GetLoginPane(_driver);

    elUsername.SendKeys(_loginUsername);
    elPassword.SendKeys(_loginPassword);
    elSubmit.Click();

    try { _driver.FindElement(By.Id("user-profile-image")); }
    catch { throw new AssertFailedException("User profile icon not found. Login failed."); }

    _driver.Close();
  }

  [TestMethod]
  public void TestIncorrectLogin() {
    Init();
    (var elUsername, var elPassword, var elSubmit) = GetLoginPane(_driver);

    elUsername.SendKeys(_loginUsername);
    elPassword.SendKeys(_loginWrongPassword);
    elSubmit.Click();

    var elResponse = _driver.FindElement(By.Id("lblMessage"));
    Assert.AreEqual("Password was incorrect.", elResponse.Text);

    _driver.Close();
  }
}
