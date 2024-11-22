using System.Reflection;
using AdventOfCode.Library;
using AdventOfCode.Runner;

var assembly = Assembly.GetAssembly(typeof(BaseDay));
var types = assembly.GetTypes()
    .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(BaseDay)));

var days = types.Select(t => (BaseDay)Activator.CreateInstance(t));

var results= days.Select(d => d.RunTests())
    .OrderBy(s => s[0].BaseDay.Year)
    .ThenBy(s => s[0].BaseDay.Day)
    .ToList();

results.ForEach(ResultPrinter.PrintResult);
;
Console.ReadLine();