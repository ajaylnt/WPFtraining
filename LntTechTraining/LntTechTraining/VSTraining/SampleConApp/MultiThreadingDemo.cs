using System;
using System.Runtime.Remoting.Messaging;
using System.Threading;
//U go for new thread when U want 2 or more operations to be done simultaneously.
//delegates have a mechanism of invoking methods asynchronously. This is similar to the way the threads work. Unlike threads, its light weight and would be usefull for creating small async tasks...
//From .NET 4, we have 2 generic delegates called Action and Func. The Action is used for void functions and Func is used for return type functions. Its generic form has 17 overloads which means U could use 17 parameters of different types in it.

namespace MultiThreading
{
  class MainClass
  {
    static Thread thread = null;
    static int number = 0;
    static void InvokeFuncAsyc(int x)
    {
      for (int i = 0; i < x; i++)
      {
        Console.WriteLine("Function executed with Beep#" + i);
        Thread.Sleep(1000);
        
      }
    }
    static void Main()
    {
      //actionMethod();
      //functionMethod();
      threadMethod();
    }

    static void threadFunc()
    {
      lock (typeof(MainClass))//lock keyword is alias for Monitor class which is similar to CriticalSection of the Windows OS...
      {
        for (int i = 0; i < 10; i++)
        {
          number += i;
          Console.WriteLine("Thread Func is executing with loop#{0}...", i);
          Thread.Sleep(1000);
          Console.WriteLine("The Value of number now is " + number);
          //if (i == 5)
          //  thread.Suspend();//Suspends the Thread indefinetly until its resumed..
        }
        number = 0;
      }
      
    }
    //create a new thread and invoke the method parallelly..
    private static void threadMethod()
    {
      Console.WriteLine("Main program is running...");
      thread = new Thread(threadFunc);
      //thread.IsBackground = true;//make it background
      thread.Start();//Start the thread...
      Console.WriteLine("Main program is running again...");
      for (int i = 0; i < 5; i++)
      {
        Console.WriteLine("Main is doing some big job...");
        Thread.Sleep(1000);
      }
      Thread th2 = new Thread(threadFunc);
      th2.Start();
      //By Default, all threads that U Create are foreground threads. The calling thread will wait till the Foreground child thread completes its operations. In this case, the Main Thread will wait till the worker thread completes its operations.. 
      Console.WriteLine("Main program is Closing and terminating");
    }

    //This function takes the string[] args, runs thro the array, display the names and return the no of names...
    private static int getEmployeeNo(string[] args)
    {
      Console.WriteLine("This code in the Async Function is executed by ThreadID:" + Thread.CurrentThread.ManagedThreadId);
      for (int i = 0; i < args.Length; i++)
      {
        Console.WriteLine("The Employee name:{0}\tNumber:{1}", args[i], i);
        Thread.Sleep(1000);
      }
      return args.Length;
    }

    private static void callMe(IAsyncResult res)
    {
      Console.WriteLine("This function is called after the Async function completes its job...");
      AsyncResult status = (AsyncResult)res;
      var actualFunc = status.AsyncDelegate as Func<string[], int>;
      var returnValue = actualFunc.EndInvoke(res);
      Console.WriteLine("The result of this function is " + returnValue);
    }
    private static void functionMethod()
    {
      Console.WriteLine("This code is executed by ThreadID:" + Thread.CurrentThread.ManagedThreadId);
      Console.WriteLine("Main program is running...");
      Func<string[], int> myFunction = getEmployeeNo;
      var res = myFunction.BeginInvoke(new string[] { "Apple","Mango", "Orange", "PineApple", "Banana"},callMe,null);
      
      Console.WriteLine("Main program is running again...");
      Console.WriteLine("Main program is Closing and terminating");
      while (res.IsCompleted == false)
      {
        Console.WriteLine("Waiting for result....");
        Thread.Sleep(1000);
      }
    }

    private static void actionMethod()
    {
      Console.WriteLine("Main program is running...");

      Action<int> function = InvokeFuncAsyc;
      var res = function.BeginInvoke(10, null, null);
      Console.WriteLine("Main program is running again...");
      for (int i = 0; i < 5; i++)
      {
        Console.WriteLine("Main is doing some big job...");
        Thread.Sleep(1000);
      }
      Console.WriteLine("Main program is Closing and terminating");
      function.EndInvoke(res);//Makes the calling thread wait till the task is accomplished by the Async function...
    }
  }
}