<Query Kind="Statements" />

var list = new ArrayList();
list.Add(1);
list.Add(2);
list.Add(3);

// ArrayList is not a generic, does not have select operator provided by linq.
// Console.WriteLine(list.Select(i => (int)i).Sum());
Console.WriteLine(list.Cast<int>().Average());

var numbers = Enumerable.Range(1,10);
var arr = numbers.ToArray();