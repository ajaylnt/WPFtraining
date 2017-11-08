using System;
using System.Collections.Generic;
using System.Linq;


namespace DataAccessLib
{
  public class Employee
  {
    public int EmpID { get; set; }
    public string EmpName { get; set; }
    public string EmpAddress { get; set; }
    public double EmpSalary { get; set; }
  }

  public interface IEmpComponent
  {
    /// <summary>
    /// Adds a new Employee
    /// </summary>
    /// <param name="emp">Employee to Add</param>
    /// <exception cref="NullReferenceException"/>
    void AddNewEmployee(Employee emp);
    void DeleteEmployee(int empID);
    void UpdateEmployee(Employee emp);
    List<Employee> GetAllEmployees();
  }

  public class EmpDataComponent : IEmpComponent
  {
    //Whenever there is an association, U create a default constructor and instantiate the Associated object..
    public EmpDataComponent()
    {
      Employees = new List<Employee>();
    }

    private List<Employee> Employees
    {
      get;
      set;
    }

    /// <summary>
    /// Adds a new Employee to the database...
    /// </summary>
    /// <param name="emp">Employee to add</param>
    /// <exception cref="System.NullReferenceException"></exception>
    public void AddNewEmployee(Employee emp)
    {
      if (emp == null)
        throw new NullReferenceException("Employee is not filled with the required data...");
      //When working with ORM Components, U will have a repository class called DataContext. The DataContext class will contain the operations to interact with the database. This class is auto generated when U created the DBML file. 

      //Create the instance of the dataContext object....
      EmployeeDataContext context = new EmployeeDataContext();
      //Add the new Employee to the Employee collection which is a property...
      context.EmpTables.InsertOnSubmit(new EmpTable {
          EmpName = emp.EmpName,
          EmpAddress = emp.EmpAddress,
          EmpSalary = (int)emp.EmpSalary
      });
      //Save the changes to the database...
      context.SubmitChanges();//API to save the changes to the actual Database.....
    }

    public void DeleteEmployee(int empID)
    {
      //Create the instance of the dataContext object....
      //Find the Employee from the Employee collection based on criteria...
      //Remove the record from the collection
      //Save the changes to the database...
    }

    /// <summary>
    /// Gets the List of Employees from the database storage...
    /// </summary>
    /// <returns></returns>
    public List<Employee> GetAllEmployees()
    {
      //Create the instance of the dataContext object....
      var context = new EmployeeDataContext();
      //Convert the data to a List<T>
      var allRecords = from emp in context.EmpTables
                       select new Employee
                       {
                         EmpID = emp.EmpID,
                         EmpName = emp.EmpName,
                         EmpAddress = emp.EmpAddress,
                         EmpSalary = emp.EmpSalary
                       };
      return allRecords.ToList();//Converts UR Collection to List...
      //return the data...
    }

    public void UpdateEmployee(Employee emp)
    {
      //Create the instance of the dataContext object....
      //Find the record to update and update the data....
      //Save the changes to the database...
    }
  }
}
