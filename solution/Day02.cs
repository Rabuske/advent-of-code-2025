using System.Runtime.InteropServices.Marshalling;

class Day02 : IDayCommand
{
  public string Execute()
  {
    var lines = new FileReader(02).Read();
    var ranges = lines.First().Split(",").Select(rangeAsString =>
    {
      var numbers = rangeAsString.Split("-");
      return (min: long.Parse(numbers[0]), max: long.Parse(numbers[1]));
    }).ToList();

    var sum = 0L;

    foreach (var range in ranges)
    {
      for (var i = range.min; i <= range.max; i++)
      {
        var numberAsString = i.ToString();
        if(numberAsString.Length % 2 != 0) continue;
        var halfNumberAsString = numberAsString[..(numberAsString.Length / 2)];
        if(long.Parse(halfNumberAsString + halfNumberAsString) == i)
        {
          sum += i;
        }
      }
    }

    return $"""
               The sum of the ids with error is: {sum} 
               The new password is: {sum}
            """;
  }
}

 