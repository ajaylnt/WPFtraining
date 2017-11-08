using System;

//Make sure that the namespace, project name and the class names are same in UR program..
namespace RemoteObjectLib
{
  //If the class instance has to be accessed remotely, then the class should be derived from MarshalByRefObject class.. Then the object of this class could be accessed remotely thro a PROXY object created by the client...
  public class Messenger : MarshalByRefObject
  {
      public void PostMessage(string message)
      {
        string user = Environment.UserName; //Gives the current user logged to the Windows OS..
        Console.WriteLine("{0}:{1}", user, message);
      }
  }
}
/*NOTES about remoting:
Remoting was the first framework for developing SOA in .NET
Simplified version, works only in TCP and HTTP practically.
Remoting works only with .NET to .NET Applications. U cannot use REMOTING for cross platform clients like J2EE Apps and Linux Apps..
Remoting does not support other Protocols.  
For working with multiple platforms, U should use XML based Web Services. 
*/
