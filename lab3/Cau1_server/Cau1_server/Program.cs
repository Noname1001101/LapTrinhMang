using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class UdpServer
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        // Server lắng nghe port 5000
        UdpClient server = new UdpClient(5000);
        Console.WriteLine("🌐 Server đang chạy, chờ dữ liệu...");

        IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 0);

        while (true)
        {
            try
            {
                // Nhận dữ liệu từ client
                byte[] data = server.Receive(ref remoteEP);
                string message = Encoding.UTF8.GetString(data);
                Console.WriteLine($"📩 Nhận từ {remoteEP}: {message}");

                // Nếu client gửi “exit all” thì tắt server
                if (message.Trim().ToLower() == "exit all")
                {
                    Console.WriteLine("❌ Nhận lệnh tắt server. Đang thoát...");
                    break;
                }

                // Gửi phản hồi về cho client
                string reply = "✅ Server đã nhận: " + message;
                byte[] replyData = Encoding.UTF8.GetBytes(reply);
                server.Send(replyData, replyData.Length, remoteEP);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠️ Lỗi: {ex.Message}");
            }
        }

        server.Close();
        Console.WriteLine("🛑 Server đã tắt.");
    }
}
