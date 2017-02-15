using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using remoting_study.Common;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting;

namespace remoting_study
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            /*
            TcpChannel channel = new TcpChannel(8080);
            ChannelServices.RegisterChannel(channel);
            */
            System.Runtime.Remoting.RemotingConfiguration.Configure("RemoteServer.exe.config");
            Console.ReadLine();
        }
    }
}
