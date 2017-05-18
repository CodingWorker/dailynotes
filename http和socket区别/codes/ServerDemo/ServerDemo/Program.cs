using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ServerDemo
{
    class Program
    {
        public static void Main(string[] args)
        {
            
            Socket socket = CreateSocket();

            Socket serverSocket = socket.Accept();

            while (true)
            {
                if (null != serverSocket.RemoteEndPoint)
                {
                    Console.WriteLine("connected,remoting:Domain=>" + serverSocket.RemoteEndPoint.AddressFamily.ToString());
                    break;
                }
            }

            serverSocket.ReceiveBufferSize = 1024;

            while (true)
            {
                byte[] receiveBytes = new byte[1024];
                int len = serverSocket.Receive(receiveBytes, receiveBytes.Length, 0);//返回的是读取的长度
                if (len>0)
                {
                    string data = Encoding.UTF8.GetString(receiveBytes,0,len);
                    Console.WriteLine(data);
                    if (data.Equals("close"))
                    {
                        Console.WriteLine("the server is going to be closed in 3 seconds !!!");
                        Thread.Sleep(3000);
                        socket.Close();
                        break;
                    }
                }
            }
        }

        private static Socket CreateSocket()
        {
            string domain = "127.0.0.1";
            int port = 5566;

            EndPoint endpoint = new IPEndPoint(IPAddress.Parse(domain), port);

            //create socket
            Socket socket = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);

            //bind
            socket.Bind(endpoint); //listen
            
            //set the timeout
            socket.ReceiveTimeout = 0;

            //socket.Connect(endpoint);

            int backlog = 10;
            socket.Listen(backlog);

            Console.WriteLine("create socket:\r\n" +"Domain=>"+domain+", Port=>"+port);

            return socket;
        }
    }
}
