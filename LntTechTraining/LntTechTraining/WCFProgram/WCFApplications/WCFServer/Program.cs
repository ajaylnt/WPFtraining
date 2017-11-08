
//WCF needs 2 Assemblies: System.ServiceModel & System.Runtime.Serialization...
//ServiceModel namespace contain the Attributes required for WCF as well as Classes required for hosting and configuring the WCF Components.
//Self Hosting means an exclusive .NETApp would be created whose job is to create the objects of the WCF Components in it and these objects will be consumed by the Client Applications using RPC.
//There are 3 ways to create WCF Apps: WAS(Windows Activation Services), Self Hosting .NET Apps, IIS(the most prefered way). In Self hosting, we have regular .NET Apps to host and Windows Services(Services that run on the Windows OS using SCM(Service Controll Manager).

using System;
using System.ServiceModel;
using WCFServer.Components;

namespace WCFServer
{
  class Program
  {
    static void Main(string[] args)
    {
      createService();
    }

    private static void createService()
    {
      ServiceHost hostApp = new ServiceHost(typeof(EmpServiceComponent));
      //EXception Handling. 
      try
      {
        hostApp.Open();
        Console.WriteLine("The host is ready to recieve the requests");
        Console.WriteLine("Press any key to close the App...");
        Console.ReadKey();
        hostApp.Close();
      }
      catch (CommunicationException ex)
      {
        Console.WriteLine(ex.Message);
      }
      catch (Exception genEx)
      {
        Console.WriteLine(genEx.Message);
      }
      finally
      {
        Console.WriteLine("The Application has terminated...");
      }
    }
  }
}
