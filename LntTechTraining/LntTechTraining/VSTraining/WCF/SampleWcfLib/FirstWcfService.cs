/*
WCF stands for Windows Communication Foundation, the next generation Service oriented Application Framework for developing services across different platforms and different protocols. U could use the same framework for developing all sorts of Service oriented components like REST, Web based Services, Windows Services and many more...
It supports various protocols like WSHttp, Http, Https, Tcp, Soap and many more. All the protocols are configurable thro XML Config file. There will be a loose coupling of the Service Components and its exposed operations.
System.ServiceModel and System.Runtime.Serialization are the important assemblies that are referenced when U create a Wcf service. 
WCF supports functions to be exposed as interfaces. U always create an interface that contain the methods that U wish to expose. 
WCF also uses WSDL for exposing its services to outside non-.NET Clients. So here also, we use attributes for exposing the components.
Interfaces are provided with attribute called ServiceContract. This means that the service exposed the methods of this interface...
The methods that are exposed are called OperationContracts.  
*/

using System;
using System.ServiceModel;

namespace WcfProgramming
{
  [ServiceContract]
  public interface IMathComponent
  { 
    [OperationContract]
    double AddFunc(double v1, double v2);

  [OperationContract]
    double SubFunc(double v1, double v2);
  }

  //This is the class that implements the service contract. This class will be hidden to the Clients. Clients are exposed only to the ServiceContract, not the implementor Class...
  public class MathComponent : IMathComponent
  {
    public double AddFunc(double v1, double v2)
    {
      return v1 + v2;
    }

    public double SubFunc(double v1, double v2)
    {
      return v1 - v2;
    }
  }
}