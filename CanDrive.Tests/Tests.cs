namespace CanDrive.Tests;

[TestClass]
public class UnitTests
{
  private readonly DrivingAgeService _service = new();

  [TestMethod]
  public void TestMethod1()
  {
    Assert.IsFalse(_service.CanDrive(15));
  }

  [TestMethod]
  public void TestMethod2()
  {
    Assert.IsTrue(_service.CanDrive(16));
  }

  [TestMethod]
  public void TestMethod3()
  {
    Assert.IsTrue(_service.CanDrive(17));
  }

  [TestMethod]
  public void TestMethod4()
  {
    Assert.IsFalse(_service.CanDrive(0));
  }

  [TestMethod]
  public void TestMethod5()
  {
    Assert.IsFalse(_service.CanDrive(-1));
  }

  [TestMethod]
  public void TestMethod6()
  {
    Assert.IsTrue(_service.CanDrive(100));
  }
}
