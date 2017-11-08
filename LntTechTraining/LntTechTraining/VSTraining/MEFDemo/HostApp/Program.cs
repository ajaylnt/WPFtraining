using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostApp
{
  class Program
  {
    static void Main(string[] args)
    {
      var program = new ContractLib.Importer();
      program.ImportAll();
      Console.WriteLine("The {0} no of components are imported into this App", program.AvailableComponents);
      var allResults = program.CallAllOperations(123, 234, 345, 432, 234, 543, 432, 234);
      foreach(var result in allResults)
        Console.WriteLine(result);
      Console.WriteLine("All the operations are done....");
      Console.ReadKey();
    }
  }
}
