using System.Runtime.InteropServices.Marshalling;

class Day04: IDayCommand
{
  public string Execute()
  {
    var lines = new FileReader(04).Read();
    var map = new Map<char>(lines.Select(l => l.ToCharArray().Select(c => new Node<char>(c))), true);

    var removedNodes = map.Nodes.Where(n => n.Value == '@' && n.AdjacentNodes.Where(n => n.Value.Value == '@').Count() < 4).ToList();
    var sumPart01 = removedNodes.Count;
    var sumPart02 = 0;

    while(removedNodes.Count > 0)
    {
      sumPart02 += removedNodes.Count;
      removedNodes.ForEach(n => n.Value = '.');
      removedNodes = map.Nodes.Where(n => n.Value == '@' && n.AdjacentNodes.Where(n => n.Value.Value == '@').Count() < 4).ToList();
    }

    return $"""
               Solution day 1: {sumPart01} 
               Solution day 2: {sumPart02}
            """;
  }

}
