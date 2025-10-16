using System.Net;
using System.Net.Sockets;
using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Any, 5000);

        Socket serverSocet = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        serverSocet.Bind(serverEndPoint);
        serverSocet.Listen(10);

        Console.WriteLine("Server đang lắng nghe trên cổng 5000...");

        Socket clientSocket = serverSocet.Accept();

        EndPoint clientEndPoint = clientSocket.RemoteEndPoint;
        Console.WriteLine("Kết nối từ: " + clientEndPoint.ToString());

        // Giữ chương trình không kết thúc ngay
        Console.ReadLine();
    }
}


