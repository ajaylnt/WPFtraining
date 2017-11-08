using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContractLib;
using System.ComponentModel.Composition;

namespace MyNewExtension
{
  [Export(typeof(IComponent))]
  public class FirstComponent : IComponent
  {
    public string Description
    {
      get
      {
        return "This component does the Addition operation for the component";
      }
    }

    public string PerformOperation(params double[] args)
    {
      var result = args.Sum();
      return string.Format("The Sum of these values are {0}", result);
    }
  }

  [Export(typeof(IComponent))]
  public class SecondComponent : IComponent
  {
    public string Description
    {
      get
      {
        return "This component does the Max Item  of the component";
      }
    }

    public string PerformOperation(params double[] args)
    {
      var result = args.Max();
      return string.Format("The Max of these values are {0}", result);
    }
  }

  [Export(typeof(IComponent))]
  public class MinComponent : IComponent
  {
    public string Description
    {
      get
      {
        return "This component does the Mim Item  of the component";
      }
    }

    public string PerformOperation(params double[] args)
    {
      var result = args.Min();
      return string.Format("The Min of these values are {0}", result);
    }
  }
}
