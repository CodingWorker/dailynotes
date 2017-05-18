using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace ClientDemo
{
    class Program
    {
        public static void Main(string[] args)
        {
            string domain = "127.0.0.1";
            int port = 5566;

            EndPoint endpoint = new IPEndPoint(IPAddress.Parse(domain), port);
            
            //create socket
            Socket socket = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
            
            //connect
            socket.Connect(endpoint);

            if (socket.Connected)
            {
                Console.WriteLine("连接成功" + socket.RemoteEndPoint.ToString());
            }

            while (true)
            {
                string data = Console.ReadLine();
                if (!string.IsNullOrEmpty(data))
                {
                    Console.WriteLine("\r\n数据发送中...");
                    socket.Send(Encoding.UTF8.GetBytes(data));
                }
            }
        }
    }
}
