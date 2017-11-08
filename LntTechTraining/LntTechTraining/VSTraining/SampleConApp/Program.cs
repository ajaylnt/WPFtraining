using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using DataAccessLib;//First add the reference of the DLL before testing it....
using SampleConApp.myWebReferences;

namespace SampleConApp
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.ReadKey();
      var proxy = new EmpService();
      var dataset = proxy.GetAllEmployees();
      foreach(DataRow row in dataset.Tables[0].Rows)
        Console.WriteLine(row[1]);//2nd column of each row is displayed 
      //var component = new EmpDataComponent();
      //var data = component.GetAllEmployees();
      //foreach(var item in data)
      //  Console.WriteLine(item.EmpName);
    }
  }
}
