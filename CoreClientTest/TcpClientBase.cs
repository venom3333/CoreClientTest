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

                var message = string.Empty;

                while (!message.Equals("quit", StringComparison.OrdinalIgnoreCase))
                {
                    Console.Write($"Enter data: ");
                    message = Console.ReadLine();

                    var sendData = Encoding.ASCII.GetBytes(message);

                    client.GetStream().Write(sendData, 0, sendData.Length);
                }
                client.Close();
                Console.WriteLine("Disconnected.");
            }
        }
    }
}