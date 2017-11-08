using System;
using System.Runtime.Remoting.Channels;//For Channel services...
using System.Runtime.Remoting.Channels.Tcp;//TcpClientChannel
using RemoteObjectLib;//For the Messenger class
//Add the reference of Remoting Lib and RemoteObjectLib dll that we have created...
namespace RemoteClient
{
  class ClientProgram
  {
    static void Main(string[] args)
    {
      TcpClientChannel channel = new TcpClientChannel();
      ChannelServices.RegisterChannel(channel, true);
     var proxy  = Activator.GetObject(typeof(Messenger), "tcp://localhost:1234/MessengerService") as Messenger;
      bool process = true;
      while (process)
      {
        Console.WriteLine("Enter the message to post");
        proxy.PostMessage(Console.ReadLine());
        Console.WriteLine("Press Y to send new message");
        process = Console.ReadLine() == "Y";
      }
      Console.WriteLine("The Application is terminating....");
    }
  }
}
