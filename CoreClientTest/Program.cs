using System.Net;

namespace CoreClientTest
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var address = IPAddress.Parse("127.0.0.1");
            var port = 5678;
            if (args.Length > 1)
            {
                address = IPAddress.TryParse(args[0], out var parsedIp) ? parsedIp : address;
                port = int.TryParse(args[1], out var parsedPort) ? parsedPort : port;
            }
            
            TcpClientBase.StartClient(address, port);
        }
    }
}