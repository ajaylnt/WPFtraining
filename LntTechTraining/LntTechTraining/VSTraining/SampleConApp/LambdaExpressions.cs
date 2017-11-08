using System;
using System.Collections.Generic;
using System.Linq;

namespace LambdaExpressions
{
  class Employee
  {
    public int EmpID { get; set; }
    public string Empname { get; set; }
    public string Empaddress { get; set; }

  }
  class MainClass
  {
    static void Main(string[] args)
    {
      //firstDemo();
      secondDemo();
    }

    private static List<Employee> createEmpList()
    {
      return new List<Employee>
      {
        new Employee { EmpID = 123, Empname ="Phaniraj", Empaddress="bangalore" },
        new Employee { EmpID = 124, Empname ="Mohan", Empaddress="mysore" },
        new Employee { EmpID = 125, Empname ="Raj Kumar", Empaddress="bangalore" },
        new Employee { EmpID = 126, Empname ="Ananth", Empaddress="chennai" },
        new Employee { EmpID = 127, Empname ="Sudeep", Empaddress="chennai" },
        new Employee { EmpID = 128, Empname ="Arjun", Empaddress="mysore" },
        new Employee { EmpID = 129, Empname ="Zaheer", Empaddress="bangalore" },
        new Employee { EmpID = 130, Empname ="Tony", Empaddress="mysore" },
        new Employee { EmpID = 131, Empname ="Frank", Empaddress="mysore" },
        new Employee { EmpID = 132, Empname ="Louis", Empaddress="bangalore" },
        new Employee { EmpID = 133, Empname ="George", Empaddress="chennai" }
      };
    }
    private static void secondDemo()
    {
      List<Employee> employees = createEmpList();
      Console.WriteLine("Find the Employees by city");
      string city = Console.ReadLine();
      //FindAll is a function of the List<T> class that takes a delegate object called Predicate as its arg. It looks for a bool function that takes the T as arg. The arg is used to perform the finding criteria/logic, whichever object that returns true on the criteria will be the found object. The fn will be iterated thro all the objects of the collection and returns a sublist of matching items.
      var tempList = employees.FindAll(delegate (Employee emp)
      {
        return emp.Empaddress.ToUpper() == city.ToUpper();
      });
      //var tempList = employees.FindAll((emp) => emp.Empaddress.ToUpper() == city.ToUpper());
      foreach(var emp in tempList)
        Console.WriteLine("{0} from {1}", emp.Empname, emp.Empaddress);

    }

    private static void firstDemo()
    {
      int[] scores = { 67, 76, 56, 87, 58, 96, 78, 67, 86, 78 };
      //These functions were added to support LINQ operations on Collections...
      Console.WriteLine("The max score is " + scores.Max());
      Console.WriteLine("The min score is " + scores.Min());
      Console.WriteLine("The Avg score is " + scores.Average());
      //Get the scores greater than average...
      var greaterScores = scores.Where(s => s > scores.Average());
      foreach(var score in greaterScores)
        Console.WriteLine(score);
      Console.WriteLine("Enter the score to find");
      int findingScore = int.Parse(Console.ReadLine());
      var selectedScores = scores.Where(s => s == findingScore);
      //All Extension methods of LINQ will return a collection, whose values are extracted using foreach statement...
      foreach(var item in selectedScores)
        Console.WriteLine(item);
    }
  }
}