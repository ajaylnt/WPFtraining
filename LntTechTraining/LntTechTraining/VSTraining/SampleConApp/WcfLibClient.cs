using SampleConApp.myWcfServices;
using System;
namespace WcfClientApp
{
  class Mainclass
  {
    static void Main(string[] args)
    {
      var com = new MathComponentClient();
      var result = com.AddFunc(123, 234);
      Console.WriteLine("The added value is " + result);
      Console.ReadLine();
    }
  }
}