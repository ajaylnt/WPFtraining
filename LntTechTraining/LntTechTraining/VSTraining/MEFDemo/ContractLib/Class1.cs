using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;

//MEF stands for Managed Extension Framework. It contains a repository of components that can be added into the List of Components that support a common set of interfaces. This repository is called as Catelog. MEF is available from VS 2012 onwards.
//MEF App is made of 3 or more Project. One DLL Project is define the common interface that UR Application must support. This is called as ContractLib. The Components are created as seperate dlls each of it implementing the interfaces in their own way.
//Host Application which will bundle these components at runtime and execute the operations as per the client needs.. 

namespace ContractLib
{
   //create an interface that contain the common operations that UR components  should do....
   public interface IComponent
  {
    string Description { get; }
    string PerformOperation(params double[] args);
  }

  public class Importer
  {
    [ImportMany(typeof(IComponent))]
    private IEnumerable<Lazy<IComponent>> operations;
    //This list contain the list of components that are loaded at runtim by UR Assembly.

    public void ImportAll()
    {
      var cat = new AggregateCatalog();
      //Contain the info about the location of all the assemblies that this App should load...
      cat.Catalogs.Add(new DirectoryCatalog(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)));

      CompositionContainer container = new CompositionContainer(cat);
      container.ComposeParts(this);//This function will look for all components that have implemented the interface IComponent and load them into the Application...
    }

    public int AvailableComponents
    {
      get { return operations != null ? operations.Count() : 0; }
    }

    public List<string> CallAllOperations(params double [] args)
    {
      var result = new List<string>();
      foreach(var com in operations)
      {
        Console.WriteLine(com.Value.Description);
        result.Add(com.Value.PerformOperation(args));
      }
      return result;
    }
  }
}
