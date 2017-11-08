using RemoteObjectLib;
using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

//When U do the IPC, U should the select the channel thro' which UR clients will talk to the server. This is called as CHANNEL. In Remoting there are majorly 2 types: HTTP and TCP. HTTP is used for internet Application communication and TCP is used for Intranet Application Communication. 
//When U communicate, U need a gateway thro which UR server will respond. This gate way is called as PORT. Any 32 Bit no could be a port. This port no is unique to the instance of the OS within the machine.  Once U associate a port no to UR App, it should be registered in the Remoting Services, so that this no will no longer be available for any other application or services that are created in the future till this instance is closed...

//Add the reference of System.Runtime.Remoting dll...
namespace RemoteServer
{
  class ServerProgram
  {
    static void Main(string[] args)
    {
      TcpServerChannel channel = new TcpServerChannel(1234);
      ChannelServices.RegisterChannel(channel, true);
      RemotingConfiguration.RegisterWellKnownServiceType(typeof(Messenger), "MessengerService", WellKnownObjectMode.Singleton);
      Console.WriteLine("Server is ready to handle the requests\nPress any key to exit the service");
      Console.ReadKey();    //To stop the App from closing, the App will close only after the user presses the key.... Make sure the App is running while client Apps access the messenger...
    }
  }
}
