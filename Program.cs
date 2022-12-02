using System.Text.Json;
using System.Xml.Serialization;
/*using (FileStream fileStream=new FileStream("user.json",FileMode.OpenOrCreate))
{
    Person person = new Person("Bob", 20);
    JsonSerializer.Serialize<Person>(fileStream, person);
    Console.WriteLine("Yes");
}

using(FileStream fileStream1 =new FileStream("user.json",FileMode.OpenOrCreate))
{
    Person? person = JsonSerializer.Deserialize<Person>(fileStream1);
    Console.WriteLine($"Name:{person.name}  Age:{person.age}");
}
*/
Person[] people = new Person[]
{
    new Person("Bob",20,new School("Brd",20)),
    new Person("Eva",30,new School("Brd",20)),
    new Person("Tom",40,new School("Brd",6))
};

XmlSerializer xmlSerializer=new XmlSerializer(typeof(Person[]));

using (FileStream fileStream=new FileStream("persons.xml",FileMode.OpenOrCreate))
{
    xmlSerializer.Serialize(fileStream, people);
}
using(FileStream fileStream1=new FileStream("persons.xml",FileMode.OpenOrCreate))
{
    Person[] people1 = xmlSerializer.Deserialize(fileStream1) as Person[];
    if(people1!=null)
    {
        foreach(var item in people1)
        {
            Console.WriteLine($"Name: {item.name} Age: {item.age}" +
                $" {item.school.number} {item.school.town}");
        }
    }
}
Console.ReadKey();
public class Person
{
    public string name { get; set; }
    public int age { get; set; }
    public School school { get; set; }
    public Person(string name, int age, School school)
    {
        this.name = name;
        this.age = age;
        this.school = school;
    }
    public Person()
    { }
}

public class School
{
    public string town { get; set; }
    public int number { get; set; }
    public School() { }
    public School(string town, int number)
    {
        this.town = town;
        this.number = number;
    }
}
