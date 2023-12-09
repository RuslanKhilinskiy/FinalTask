using System;
using System.Collections.Generic;

// класс Person
public abstract class Person
{
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }

    public Person(string lastName, DateTime dateOfBirth)
    {
        LastName = lastName;
        DateOfBirth = dateOfBirth;
    }

    public int CalculateAge()
    {
        DateTime today = DateTime.Today;
        int age = today.Year - DateOfBirth.Year;

        if (today < DateOfBirth.AddYears(age))
        {
            age--;
        }

        return age;
    }

    public abstract void DisplayInfo();
}

// Интерфейс IEmployee
public interface IEmployee
{
    double CalculateSalary();
}

// Класс Администратор
public class Administrator : Person, IEmployee
{
    public string Laboratory { get; set; }

    public Administrator(string lastName, DateTime dateOfBirth, string laboratory)
        : base(lastName, dateOfBirth)
    {
        Laboratory = laboratory;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Administrator: {LastName}, Age: {CalculateAge()}, Laboratory: {Laboratory}");
    }

    public double CalculateSalary()
    {
        // Расчет заработной платы администратора
        return 50000.0;
    }
}

// Класс Студент
public class Student : Person
{
    public string Faculty { get; set; }
    public string Group { get; set; }

    public Student(string lastName, DateTime dateOfBirth, string faculty, string group)
        : base(lastName, dateOfBirth)
    {
        Faculty = faculty;
        Group = group;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Student: {LastName}, Age: {CalculateAge()}, Faculty: {Faculty}, Group: {Group}");
    }
}

// Класс Преподаватель
public class Teacher : Person, IEmployee
{
    public string Faculty { get; set; }
    public string Position { get; set; }
    public int Experience { get; set; }

    public Teacher(string lastName, DateTime dateOfBirth, string faculty, string position, int experience)
        : base(lastName, dateOfBirth)
    {
        Faculty = faculty;
        Position = position;
        Experience = experience;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Teacher: {LastName}, Age: {CalculateAge()}, Faculty: {Faculty}, Position: {Position}, Experience: {Experience} years");
    }

    public double CalculateSalary()
    {
        // Расчет заработной платы преподавателя
        return 80000.0 + (Experience * 1000.0);
    }
}

// Класс Менеджер
public class Manager : Person, IEmployee
{
    public string Faculty { get; set; }
    public string Position { get; set; }

    public Manager(string lastName, DateTime dateOfBirth, string faculty, string position)
        : base(lastName, dateOfBirth)
    {
        Faculty = faculty;
        Position = position;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Manager: {LastName}, Age: {CalculateAge()}, Faculty: {Faculty}, Position: {Position}");
    }

    public double CalculateSalary()
    {
        // Расчет заработной платы менеджера
        return 60000.0;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Person> people = new List<Person>();

        people.Add(new Administrator("Ivanov", new DateTime(1990, 1, 11), "№ 5"));
        people.Add(new Student("Petrov", new DateTime(2000, 2, 12), "Computer science", "4"));
        people.Add(new Teacher("Sidorov", new DateTime(1985, 3, 13), "Mathematics", "Professor", 15));
        people.Add(new Manager("Kuznezov", new DateTime(1988, 4, 14), "Natural science", "Manager"));

        foreach (var person in people)
        {
            person.DisplayInfo();

            if (person is IEmployee employee)
            {
                Console.WriteLine($"Salary: {employee.CalculateSalary()}");
            }

            Console.WriteLine();
        }
    }
}

