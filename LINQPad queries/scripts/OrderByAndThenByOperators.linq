<Query Kind="Program" />

void Main()
{
	var rand = new Random();
	var randomValues = Enumerable.Range(1,10).Select(_ => rand.Next(10)-5);
	Console.WriteLine(randomValues);
	
	var csvString = new Func<IEnumerable<int>, string>(values =>
	{
		return string.Join(",", values.Select(v => v.ToString()).ToArray());
	});
	
	// Every time you interate the random values you get different sequence
	Console.WriteLine(csvString(randomValues.OrderByDescending(x => x)));
	
	var people = new List<Person>
	{
		new Person{ Name = "Tomas", Age = 53 },
		new Person{ Name = "Emil", Age = 24 },
		new Person{ Name = "Bruno", Age = 13 },
		new Person{ Name = "Tomas", Age = 24 },
	};
	
	// type is IOrderedEnumerable<Person>
	Console.WriteLine(people.OrderBy(p => p.Name));
	
	// using ThenBy statement
	Console.WriteLine(people.OrderBy(p => p.Age)
							.ThenByDescending(p => p.Name));
}

class Person
{
	public string Name;
	public int Age;
}

