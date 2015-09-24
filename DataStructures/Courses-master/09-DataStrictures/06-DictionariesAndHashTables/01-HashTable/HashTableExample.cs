using System;

class Example
{
    static void Main()
    {
        // Arrange
        var hashTable = new HashTable<DateTime, string>();
        var date = new DateTime(1995, 7, 18);
        hashTable.Add(date, "Some value");

        // Act
        var containsKey = hashTable.ContainsKey(date);

        ///////////////////////////////////////////////////
        var grades = new HashTable<string, int>();
        Console.WriteLine("Grades:" + string.Join(",", grades));
        Console.WriteLine("--------------------");

        grades.Add("Peter", 3);
        grades.Add("Maria", 6);
        grades["George"] = 5;
        Console.WriteLine("Grades:" + string.Join(",", grades));
        Console.WriteLine("--------------------");

        grades.AddOrReplace("Peter", 33);
        grades.AddOrReplace("Tanya", 4);
        grades["George"] = 55;
        Console.WriteLine("Grades:" + string.Join(",", grades));
        Console.WriteLine("--------------------");

        Console.WriteLine("Keys: " + string.Join(", ", grades.Keys));
        Console.WriteLine("Values: " + string.Join(", ", grades.Values));
        Console.WriteLine("Count = " + string.Join(", ", grades.Count));
        Console.WriteLine("--------------------");

        grades.Remove("Peter");
        grades.Remove("George");
        grades.Remove("George");
        Console.WriteLine("Grades:" + string.Join(",", grades));
        Console.WriteLine("--------------------");

        Console.WriteLine("ContainsKey[\"Tanya\"] = " + grades.ContainsKey("Tanya"));
        Console.WriteLine("ContainsKey[\"George\"] = " + grades.ContainsKey("George"));
        Console.WriteLine("Grades[\"Tanya\"] = " + grades["Tanya"]);
        Console.WriteLine("--------------------");
    }
}
