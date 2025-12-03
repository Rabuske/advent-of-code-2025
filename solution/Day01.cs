using System.Runtime.InteropServices.Marshalling;

class Day01 : IDayCommand
{
  public string Execute()
  {
    var lines = new FileReader(01).Read();
    var commands = lines.Select(line => (direction: line[0], steps: int.Parse(line[1..]))).ToList();

    var password = 0;
    var newPassword = 0;
    var currentPosition = 50;

    foreach (var (direction, steps) in commands)
    {
      int completeRounds = steps / 100;
      int stepsToRotate = steps % 100;
      bool startsFromZero = currentPosition == 0;

      currentPosition += direction == 'L' ? -stepsToRotate : stepsToRotate;

      if (!startsFromZero && (currentPosition > 100 || currentPosition < 0))
      {
        newPassword++;
      }
      currentPosition = MathExtensions.Mod(currentPosition, 100);
      if (currentPosition == 0)
      {
        password++;
        newPassword++;
      }
      newPassword += completeRounds;
    }

    return $"""
               The password is: {password} 
               The new password is: {newPassword}
            """;
  }
}