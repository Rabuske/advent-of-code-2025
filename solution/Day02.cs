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

    var sumPart01 = 0L;
    var sumPart02 = 0L;

    foreach (var range in ranges)
    {
      for (var numberBeingEvaluated = range.min; numberBeingEvaluated <= range.max; numberBeingEvaluated++)
      {
        var numberBeingEvaluatedAsString = numberBeingEvaluated.ToString();
        var hasBeenAccounted = false;
        for(int patternLength = 1; patternLength <= numberBeingEvaluatedAsString.Length / 2; patternLength++)
        {
          var divisor = (Math.Pow(10, numberBeingEvaluatedAsString.Length) - 1) / (Math.Pow(10, patternLength) - 1);
          if(numberBeingEvaluated % divisor == 0)
          {
            var pattern = numberBeingEvaluated / divisor;
            if(!hasBeenAccounted)
            {
              sumPart02 += numberBeingEvaluated;
              hasBeenAccounted = true;
            }
            if(patternLength == numberBeingEvaluatedAsString.Length / 2 && numberBeingEvaluatedAsString.Length % 2 == 0)
            {
              sumPart01 += numberBeingEvaluated;
            }
          }
        }

      }
    }

    return $"""
               The sum of the ids with error is: {sumPart01} 
               The new password is: {sumPart02}
            """;
  }
}

 