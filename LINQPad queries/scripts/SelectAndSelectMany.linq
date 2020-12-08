<Query Kind="Statements" />

var numbers = Enumerable.Range(1,4);
var squares = numbers.Select(x => x*x);
Console.WriteLine(squares);

string sentence = "I love .net";

var wordsWithLength = sentence.Split().Select(i => new { i, i.Length});
Console.WriteLine(wordsWithLength);

string [] objects = { "house", "car", "book", "pipe" };
string [] colors = { "black", "white", "red" };

// math tuple (basically returns lists of lists - cross join)
var pairs = colors.SelectMany(_ => objects,
	(c, o) => $"{c} {o}");
Console.WriteLine(pairs);