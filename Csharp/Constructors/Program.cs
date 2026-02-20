using System;
class Student
{
    //static variable
    static string collegeName;


    public int Id; //insatnce variable - defaultvalue   
        public string Name;

    static Student()
    {
        collegeName = "Arya college";
        Console.WriteLine("Static constructor is called");
    }

    public Student()
    {
         Id = 0;
            Name = "Unknown";
        Console.WriteLine("Default  constructor is called");
    }


    public Student(int id , string name)
    {
        Id = id;
                Name = name;
        Console.WriteLine("Parameterized constructor is called");
    }

    public Student(Student obj)
    {
        Id = obj.Id;
                Name = obj.Name;
        Console.WriteLine("Copy constructor is called");
    }

    private Student(string secret)
    {
        Console.WriteLine("Private Constructor Executed");
    }

    // Static method to call private constructor
    public static Student CreatePrivateObject()
    {
        return new Student("secret");
    }

    public void Display()
    {
        Console.WriteLine($"Id: {Id}, Name: {Name}, College: {collegeName}");
    }
}
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Main method started " );
Student s1 = new Student();
        s1.Display();
        Console.WriteLine();

        Student s2 = new Student(161, "Sneh");
s2.Display();

        Console.WriteLine() ;

        Student s3 = new Student();
        s3.Display();

        Console.WriteLine();

        Student s4 = Student.CreatePrivateObject();
        Console.ReadLine();

    }
}