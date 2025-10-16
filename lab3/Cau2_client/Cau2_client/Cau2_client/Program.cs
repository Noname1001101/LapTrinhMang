using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class UdpClientApp
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        UdpClient client = new UdpClient();
        IPEndPoint serverEP = new IPEndPoint(IPAddress.Loopback, 5000);

        Console.WriteLine("🔹 Nhập tin nhắn (gõ 'exit' để thoát client, 'exit all' để tắt server):");

        while (true)
        {
            Console.Write("➡️  Bạn: ");
            string message = Console.ReadLine()?.Trim() ?? "";

            byte[] data = Encoding.UTF8.GetBytes(message);
            client.Send(data, data.Length, serverEP);

            if (message.Equals("exit", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("👋 Client đóng kết nối...");
                break;
            }

            if (message.Equals("exit all", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("🚨 Gửi lệnh tắt server, đồng thời đóng client...");
                break;
            }

            // Nhận phản hồi
            IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 0);
            byte[] recvData = client.Receive(ref remoteEP);
            string reply = Encoding.UTF8.GetString(recvData);
            Console.WriteLine("📥 Server: " + reply);
        }

        client.Close();
    }
}
