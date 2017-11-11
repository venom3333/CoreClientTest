using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace CoreClientTest
{
    public static class TcpClientBase
    {
        //private static TcpClient Client { get; set; }

        public static void StartClient(IPAddress address, int port)
        {
            using (var client = new TcpClient())
            {
                client.Connect(address, port);

                if (!client.Connected)
                {
                    Console.WriteLine($"Can't connect to {address}:{port}");
                    return;
                }
                
                Console.WriteLine($"Connected to {address}:{port}");

                while (true)
                {
                    Console.Write($"Enter data: ");
                    var message = Console.ReadLine();

                    if (message.Equals("quit", StringComparison.OrdinalIgnoreCase))
                    {
                        break;
                    }
                    
                    var sendData = Encoding.ASCII.GetBytes(message);

                    client.GetStream().Write(sendData, 0, sendData.Length);
                }
                Console.WriteLine("Disconnecting.");
                client.Close();
            }
        }
    }
}