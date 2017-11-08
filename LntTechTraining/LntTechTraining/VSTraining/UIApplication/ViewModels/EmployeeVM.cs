using DataAccessLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIApplication.ViewModels
{
  public class EmployeeVM
  {
    private static IEmpComponent component = new EmpDataComponent();
    public EmployeeVM()
    {
      AllEmployees = component.GetAllEmployees();
    }
    public List<Employee> AllEmployees { get; set; }
  }
}
