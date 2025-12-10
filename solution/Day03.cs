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
      sumPart01 += GetMaxValueForGivenSize(battery, 2);
      sumPart02 += GetMaxValueForGivenSize(battery, 12);
    }

    return $"""
               The sum of the ids with error is: {sumPart01} 
               The new password is: {sumPart02}
            """;
  }


  (int value, int index) GetNextMaxValue(List<int> battery, int startIndex, int remainingDigits)
  {
      var maxValue = -1;
      var indexOfMaxValue = 0;
      for (int i = startIndex; i < battery.Count - remainingDigits; i++)
      {
        if(battery[i] > maxValue)
        {
          maxValue = battery[i];
          indexOfMaxValue = i;
        }
      }   
      return (maxValue, indexOfMaxValue);
  }

  long GetMaxValueForGivenSize(List<int> battery, int size)
  {
      var startIndex = 0;
      var number = new List<int>();
      for (int i = 0; i < size; i++)
      {
        var remainingDigits = size - i - 1;
        var nextNumberAndIndex = GetNextMaxValue(battery, startIndex, remainingDigits);
        startIndex = nextNumberAndIndex.index + 1;
        number.Add(nextNumberAndIndex.value);
      }

      return long.Parse(String.Join("", number));    
  }


}

 