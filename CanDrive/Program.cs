namespace CanDrive;

public class DrivingAgeService {
  public bool CanDrive(int age) {
    const int drivingAge = 16;
    return age >= drivingAge;
  }

  public static void Main() {
  }
}
