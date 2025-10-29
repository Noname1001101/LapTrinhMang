using System;
using System.Diagnostics.Metrics;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;

class UdpServer
{
    static void Main()
    {
        #region Cau 1,2,3,4
        //    Console.OutputEncoding = Encoding.UTF8;
        //    Console.InputEncoding = Encoding.UTF8;

        //    // Server lắng nghe port 5000
        //    UdpClient server = new UdpClient(5000);
        //    Console.WriteLine("🌐 Server đang chạy, chờ dữ liệu...");

        //    IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 0);

        //    while (true)
        //    {
        //        try
        //        {
        //            // Nhận dữ liệu từ client
        //            byte[] data = server.Receive(ref remoteEP);
        //            string message = Encoding.UTF8.GetString(data);
        //            Console.WriteLine($"📩 Nhận từ {remoteEP}: {message}");

        //            // Nếu client gửi “exit all” thì tắt server
        //            if (message.Trim().ToLower() == "exit all")
        //            {
        //                Console.WriteLine("❌ Nhận lệnh tắt server. Đang thoát...");
        //                break;
        //            }

        //            // Gửi phản hồi về cho client
        //            string reply = "✅ Server đã nhận: " + message;
        //            byte[] replyData = Encoding.UTF8.GetBytes(reply);
        //            server.Send(replyData, replyData.Length, remoteEP);
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine($"⚠️ Lỗi: {ex.Message}");
        //        }
        //    }

        //    server.Close();
        //    Console.WriteLine("🛑 Server đã tắt.");
        //}
        #endregion

        #region Câu 5
        //Console.OutputEncoding = Encoding.UTF8;

        //Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        //IPEndPoint local = new IPEndPoint(IPAddress.Any, 5000);
        //serverSocket.Bind(local);

        //Console.WriteLine("🌐 Server đang chạy, chờ 5 thông điệp...");

        //byte[] buff = new byte[1024];
        //EndPoint remote = new IPEndPoint(IPAddress.Any, 0);

        //for (int i = 1; i <= 5; i++)
        //{
        //    int byteReceive = serverSocket.ReceiveFrom(buff,0,buff.Length, SocketFlags.None, ref remote);
        //    string str = Encoding.UTF8.GetString(buff, 0, byteReceive);
        //    Console.WriteLine($"📩 Thông điệp {i}: {str}");
        //}

        //Console.WriteLine("✅ Đã nhận đủ 5 thông điệp, server kết thúc.");
        //serverSocket.Close();
        #endregion

        #region Câu 6
        //Console.OutputEncoding = Encoding.UTF8;
        //Console.InputEncoding = Encoding.UTF8;

        //// Tạo socket UDP
        //Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        //IPEndPoint local = new IPEndPoint(IPAddress.Any, 5000);
        //serverSocket.Bind(local);

        //Console.WriteLine("🌐 Server đang chạy... Nhập 'exit all' từ client để tắt.");

        //// Bộ đệm nhận dữ liệu
        //byte[] buff = new byte[1024];
        //EndPoint remote = new IPEndPoint(IPAddress.Any, 0);

        //while (true)
        //{
        //    // Nhận dữ liệu từ client
        //    int byteReceive = serverSocket.ReceiveFrom(buff, ref remote);
        //    string str = Encoding.UTF8.GetString(buff, 0, byteReceive);
        //    Console.WriteLine($"📩 Nhận từ {remote}: {str}");

        //    // Nếu client gửi “exit all” thì tắt server
        //    if (str.Trim().ToLower() == "exit all")
        //    {
        //        Console.WriteLine("❌ Nhận lệnh tắt server. Đang thoát...");
        //        break;
        //    }

        //    // Gửi phản hồi về client (cố tình gửi chuỗi dài để test bộ đệm nhỏ)
        //    string reply = "Server đã nhận thông điệp: " + str + " ✅";
        //    byte[] replyData = Encoding.UTF8.GetBytes(reply);
        //    serverSocket.SendTo(replyData, 0, replyData.Length, SocketFlags.None, remote);
        //}

        //serverSocket.Close();
        //Console.WriteLine("🛑 Server đã tắt.");
        #endregion

            #region Câu 7
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            // Tạo socket UDP
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint local = new IPEndPoint(IPAddress.Any, 5000);
            serverSocket.Bind(local);

            Console.WriteLine("🌐 Server đang chạy... Nhập 'exit all' từ client để tắt.");

            // Bộ đệm nhận dữ liệu
            byte[] buff = new byte[1024];
            EndPoint remote = new IPEndPoint(IPAddress.Any, 0);

            int counter = 0;
            while (true)
            {
                // Nhận dữ liệu từ client
                int byteReceive = serverSocket.ReceiveFrom(buff, ref remote);
                string str = Encoding.UTF8.GetString(buff, 0, byteReceive);
                Console.WriteLine($"📩 Nhận từ {remote}: {str}");

                // Nếu client gửi “exit all” thì tắt server
                if (str.Trim().ToLower() == "exit all")
                {
                    Console.WriteLine("❌ Nhận lệnh tắt server. Đang thoát...");
                    break;
                }

            counter++;
            // 🔸 Giả lập mất phản hồi 2 lần đầu
            if (counter <= 2)
            {
                Console.WriteLine("⚠️ Giả lập mất gói tin — không phản hồi lần này.");
                continue; // không gửi lại phản hồi
            }

            // Gửi phản hồi về client (cố tình gửi chuỗi dài để test bộ đệm nhỏ)

            string reply = "Server đã nhận thông điệp: " + str + " ✅";
                byte[] replyData = Encoding.UTF8.GetBytes(reply);
                serverSocket.SendTo(replyData, 0, replyData.Length, SocketFlags.None, remote);
            }

            serverSocket.Close();
            Console.WriteLine("🛑 Server đã tắt.");
            #endregion



    }
}
