using System;
using System.Collections.Generic;
using System.IO;
using WCFClientApp.myWcfServices;
//Add the service reference by providing the URL of the service:
//net.tcp://localhost:1234/myServices/
namespace WCFClientApp
{
  class Program
  {
    static IEmpService component = new EmpServiceClient();
    static void Main(string[] args)
    {
      var fileName = args[0];//Path of the file to read...
      StreamReader reader = new StreamReader(fileName);
      //StreamReader is a .NET Class that is used to read Text based files...
      bool processing = true;
      string menu = reader.ReadToEnd();
      do
      {
        Console.Clear();
        string choice = getString(menu);
        processing = processMenu(choice);
        Console.WriteLine("Press any key to display the menu");
        Console.ReadKey();
      } while (processing);      
    }

    private static bool processMenu(string choice)
    {
      switch (choice)
      {
        default:
          return false;
        case "1":
          readAllEmployees();
          return true;
        case "2":
          findEmployee();
          return true;
        case "3":
          addingEmployee();
          return true;
        case "4":
        case "5":
          return true;
      }
    }

    private static void addingEmployee()
    {
      var emp = new Employee();
      emp.EmpName = UIHelper.GetString("Enter the Name");
      emp.EmpAddress = UIHelper.GetString("Enter the Address");
      emp.EmpSalary = UIHelper.GetInteger("Enter salary");
      emp.DeptID = UIHelper.GetInteger("Enter the DeptID");
      if (component.AddNewEmployee(emp))
      {
        Console.WriteLine("Employee added"); ;
      }
      else
        Console.WriteLine("Employee not added");
    }

    private static void findEmployee()
    {
      //Before U Run this program, configure the Collection to hold List<T> instead of Array...
      var employees = component.GetAllEmployees();
      foreach(var emp in employees)
        Console.WriteLine(emp.EmpName);
      Console.WriteLine("Please enter the Name or part of the Name to find the details");
      string name = Console.ReadLine();
      var tempList = employees.FindAll(e => e.EmpName.Contains(name));
      foreach(var emp in tempList)
        Console.WriteLine(string.Format("Name:{0}\tAddress:{1}\tSalary:{2}", emp.EmpName, emp.EmpAddress, emp.EmpSalary));
    }

    private static void readAllEmployees()
    {
      var employees = component.GetAllEmployees();
      foreach(var emp in employees)
        Console.WriteLine(string.Format("Name:{0}\tAddress:{1}\tSalary:{2}", emp.EmpName, emp.EmpAddress, emp.EmpSalary));
    }

    private static string getString(string question)
    {
      Console.WriteLine(question);
      return Console.ReadLine();
    }
  }

  //A Class which contain only static members...
  static class UIHelper
  {
    public static int  GetInteger(string question)
    {
      Console.WriteLine(question);
      return int.Parse(Console.ReadLine());
    }

    public static string GetString(string question)
    {
      Console.WriteLine(question);
      return Console.ReadLine();
    }
  }
}
//Steps to debug the Service.
/*
Create a break point in the Client Application and allow the App to hit the break point. 
Open the processes window of the Debug windows. Right Click on the Executing process id to attach the server process.
Identify the Server process and attach it to the Client App.
Press F11 to into the Server function and then continue with F10 or any appropriate Functional Key...
After hitting, exit the Application Instance.
*/