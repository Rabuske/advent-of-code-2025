using System.Runtime.InteropServices.Marshalling;

class Day03 : IDayCommand
{
  public string Execute()
  {
    var lines = new FileReader(03).Read();
    var batteries = lines.Select(line => line.ToCharArray().Select(c => (int)char.GetNumericValue(c)).ToList()).ToList();
    var sumPart01 = 0L;
    var sumPart02 = 0L;

    foreach (var battery in batteries)
    {
      // The 10s are more important
      var max10Value = -1;
      var max10Index = 0;
      for (int i = 0; i < battery.Count - 1; i++)
      {
        if(battery[i] > max10Value)
        {
          max10Value = battery[i];
          max10Index = i;
        }
      }

      // Now find units
      var maxUnit = battery[(max10Index + 1)..].Max();
      sumPart01 += max10Value * 10 + maxUnit;

    }

    return $"""
               The sum of the ids with error is: {sumPart01} 
               The new password is: {sumPart02}
            """;
  }
}

 