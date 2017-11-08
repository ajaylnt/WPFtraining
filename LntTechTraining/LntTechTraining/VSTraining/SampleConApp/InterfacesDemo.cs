using System;
namespace InterfaceDemo
{
  //If U want to seperate the implementation and declaration in C#, U should do it with interfaces..
  interface IExample
  {
    //Methods are not implemented. They are only public.  U dont mention the access specifier. interface cannot have fields. 
    void ExampleFunc();
  }

  interface ISimple
  {
    void SimpleFunc();
    void ExampleFunc();
  }
  class ExampleClass : IExample, ISimple
  {
    //If a class implements the interface, it should provide public definitions for the methods. It should implement all the methods of the interface.
    public void ExampleFunc()
    {
      Console.WriteLine("Example Func implemented here");
    }

    //This is called as Explicit implementation of the interface. 
    void IExample.ExampleFunc()
    {
      Console.WriteLine("IExample's version of ExampleFunc");
    }

    void ISimple.ExampleFunc()
    {
      Console.WriteLine("ISimple's version of ExampleFunc");
    }
    public void SimpleFunc()
    {
      Console.WriteLine("Simple Func implemented here");
    }
  }
  class MainClass
  {
    static void Main(string[] args)
    {
      IExample ex = new ExampleClass();
      ex.ExampleFunc();//The interface cannot be instantiated.We create a variable of the interface but instantiate it to the class that has implemented the interface...

      ISimple sim = new ExampleClass();
      //sim.SimpleFunc();
      sim.ExampleFunc();

      ExampleClass cls = new ExampleClass();
      cls.ExampleFunc();
    }
  }
}