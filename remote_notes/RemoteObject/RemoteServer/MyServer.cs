using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;

namespace RemoteServer
{
    class MyServer
    {
        [STAThread]
        static void Main(string[] args)
        {
            //RemotingConfiguration.Configure("RemoteServer.exe.config");
            //Console.ReadLine();

            //注册通道
            TcpChannel channel = new TcpChannel(9999);
            ChannelServices.RegisterChannel(channel);

            //注册对象
            System.Runtime.Remoting.RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteObject.MyObject),"haha",System.Runtime.Remoting.WellKnownObjectMode.Singleton);
            Console.ReadLine();

        }
    }
}
