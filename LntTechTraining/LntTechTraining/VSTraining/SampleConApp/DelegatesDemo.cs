using System;
namespace DelegatesDemo
{
  //A function which calls another function that is passed as argument to it, the function that is passed as argument  is called as callback function. This function will be usually called after the current function finishes its operation and then invokes the function as an acknowledgement. 
  //U need a reference of a function to be passed as argument. This is called as DELEGATE. 
  delegate void InvokeMethod();
  delegate double MathOperation(double op1, double op2);
  class MainClass
  {
    static void CallBackFunc(InvokeMethod method)
    {
      Console.WriteLine("Doing some job in the callback function");
      method();//Invoke the reference object that is passed as argument....
    }
    static void Main(string[] args)
    {
      //InvokeMethod method = new InvokeMethod(TestFunc);
      //CallBackFunc(method); 

      //Newer syntax is:
      //CallBackFunc(TestFunc);

      //Anonymous methods in C#. Here U have created a method with no name, so its called as Anoymous methods...
     InvokeMethod delegateObj = delegate ()
      { 
        Console.WriteLine("Anonymous func is called by the Callback function");
      };
      //CallBackFunc(delegateObj);//invoking thro anoymous method...

      CallBackFunc(() => {
        Console.WriteLine("Lambda Expression isinvoked by callback func");
        Console.WriteLine("One more line of execution");
        Console.WriteLine("Finishing the function job");
      });

      //Delegate instances are also called alias to methods that it is invoking. 
      //MathOperation addFunc = delegate (double v1, double v2)
      //{
      //  return v1 + v2;
      //};
      //var res = addFunc(123, 234);
      //Console.WriteLine(res);
      //res = addFunc(534, 234);
      //Console.WriteLine(res);
      //Console.WriteLine("The Added value is " + addFunc(123, 234));

      InvokeMethod op = () => Console.WriteLine("Testing 123");
      op();

      MathOperation anyFunc =  (v1, v2) => (2 * v1 * 4 * v2) / v1 + v2 * v1 - v1;
      
      var res = anyFunc(234, 234);
      Console.WriteLine(res);
    }


    //A function has been created only to be associated with a delegate instance which is against the rule of creating method...
    //static void TestFunc()
    //{
    //  Console.WriteLine("Test func is called by the Callback function");
    //}
  }
}