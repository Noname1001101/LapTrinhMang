using System;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;

class UdpClientConnectApp
{

    class RetryUdpClient
    {
        static byte[] data = new byte[1024];
        static EndPoint Remote = new IPEndPoint(IPAddress.Any, 0);


        // 🔹 Hàm gửi và nhận dữ liệu, có cơ chế gửi lại khi timeout
        private static int SndRcvData(Socket s, byte[] message, EndPoint rmtdevice)
        {
            int recv;
            int retry = 0;

            while (true)
            {
                Console.WriteLine("Truyền lại lần thứ: #{0}", retry);

                try
                {
                    s.SendTo(message, message.Length, SocketFlags.None, rmtdevice);
                    data = new byte[1024];
                    recv = s.ReceiveFrom(data, ref Remote);
                }
                catch (SocketException)
                {
                    recv = 0; // timeout
                }

                if (recv > 0)
                {
                    return recv;
                }
                else
                {
                    retry++;
                    if (retry > 4)
                        return 0; // sau 5 lần retry thì bỏ cuộc
                }
            }
        }
        static void Main()
        {
            #region Câu 1,2,3,4
            //Console.OutputEncoding = Encoding.UTF8;
            //Console.InputEncoding = Encoding.UTF8;

            //// 1️Tạo client
            //UdpClient client = new UdpClient();

            //// 2️ Thiết lập “kết nối logic” tới server
            //client.Connect(IPAddress.Loopback, 5000);
            //Console.WriteLine("🔹 Client đã connect tới server");

            //Console.WriteLine("Nhập tin nhắn (gõ 'exit' để thoát, 'exit all' để tắt server):");

            //while (true)
            //{
            //    Console.Write("➡️  Bạn: ");
            //    string message = Console.ReadLine()?.Trim() ?? "";
            //    byte[] data = Encoding.UTF8.GetBytes(message);

            //    // 3️ Gửi trực tiếp, không cần IPEndPoint
            //    client.Send(data, data.Length);

            //    if (message.Equals("exit", StringComparison.OrdinalIgnoreCase))
            //    {
            //        Console.WriteLine("👋 Client đóng kết nối...");
            //        break;
            //    }

            //    if (message.Equals("exit all", StringComparison.OrdinalIgnoreCase))
            //    {
            //        Console.WriteLine("🚨 Gửi lệnh tắt server, đồng thời đóng client...");
            //        break;
            //    }

            //    // 4️ Nhận phản hồi
            //    IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 0);
            //    byte[] recvData = client.Receive(ref remoteEP);
            //    string reply = Encoding.UTF8.GetString(recvData);
            //    Console.WriteLine("📥 Server: " + reply);
            //}

            //client.Close();
            #endregion

            #region Câu 5
            //Console.OutputEncoding = Encoding.UTF8;

            //Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            //IPEndPoint remote = new IPEndPoint(IPAddress.Loopback, 5000);

            //// "Kết nối logic"
            //serverSocket.Connect(remote);

            //Console.WriteLine("🔹 Đang gửi 5 thông điệp tới server...");


            //for (int i = 1; i <= 5; i++)
            //{
            //    byte[] buff = Encoding.UTF8.GetBytes("Thong Diep " + i.ToString());
            //    serverSocket.SendTo(buff, 0, buff.Length, SocketFlags.None, remote);

            //}

            //Console.WriteLine("✅ Đã gửi đủ 5 thông điệp, client kết thúc.");
            //serverSocket.Close();
            #endregion

            #region Câu 6
            //Console.OutputEncoding = Encoding.UTF8;
            //Console.InputEncoding = Encoding.UTF8;

            //Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            //IPEndPoint remote = new IPEndPoint(IPAddress.Loopback, 5000);

            //clientSocket.Connect(remote);

            //Console.WriteLine("🔹 Nhập thông điệp (gõ 'exit' để thoát, 'exit all' để tắt server):");

            //int bufferSize = 30;

            //while (true)
            //{
            //    //string? str = Console.ReadLine();
            //    //if (string.IsNullOrWhiteSpace(str)) continue;
            //    //if (str.Trim().ToLower() == "exit") break;

            //    //byte[] buff = Encoding.UTF8.GetBytes(str);
            //    //clientSocket.SendTo(buff, 0, buff.Length, SocketFlags.None, remote);

            //    //// ❗ Bộ đệm nhận nhỏ (10 byte) để minh họa mất dữ liệu
            //    //buff = new byte[10];
            //    //EndPoint remoteEP = new IPEndPoint(IPAddress.Any, 0);

            //    //int byteReceive = clientSocket.ReceiveFrom(buff, ref remoteEP);
            //    //str = Encoding.UTF8.GetString(buff, 0, byteReceive);

            //    //Console.WriteLine("🔸 Server trả lời: " + str);

            //    string? input = Console.ReadLine();
            //    if (string.IsNullOrWhiteSpace(input))
            //        continue;

            //    if (input.Trim().ToLower() == "exit")
            //        break;

            //    // Gửi dữ liệu đến server
            //    byte[] sendData = Encoding.UTF8.GetBytes(input);
            //    clientSocket.SendTo(sendData, remote);

            //    // Nhận phản hồi
            //    byte[] receiveData = new byte[bufferSize];
            //    EndPoint remoteEP = new IPEndPoint(IPAddress.Any, 0);

            //    try
            //    {
            //        int recv = clientSocket.ReceiveFrom(receiveData, ref remoteEP);
            //        string stringData = Encoding.UTF8.GetString(receiveData, 0, recv);
            //        Console.WriteLine("🔸 Server trả lời: " + stringData);
            //    }
            //    catch (SocketException)
            //    {
            //        Console.WriteLine("⚠️ Cảnh báo: dữ liệu bị mất, tăng kích thước bộ đệm và thử lại.");
            //        bufferSize += 10; // tăng kích thước bộ đệm khi lỗi
            //    }
            //}

            //Console.WriteLine("✅ Client kết thúc.");
            //clientSocket.Close();
            #endregion

            #region Câu 7
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            string input, stringData;
            int recv;

            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5000);
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            object? option = server.GetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout);
            int sockopt = option as int? ?? 0;
            Console.WriteLine("Giá trị timeout mặc định: {0}", sockopt);

            server.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 3000);

            option = server.GetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout);
            sockopt = option as int? ?? 0;
            Console.WriteLine("Giá trị timeout mới: {0}", sockopt);

            string welcome = "Xin chào Server";
            data = Encoding.UTF8.GetBytes(welcome);

            recv = SndRcvData(server, data, ipep);
            if (recv > 0)
            {
                stringData = Encoding.UTF8.GetString(data, 0, recv);
                Console.WriteLine(stringData);
            }
            else
            {
                Console.WriteLine("Không thể liên lạc với thiết bị ở xa");
                return;
            }

            while (true)
            {
                string? line = Console.ReadLine();     // có thể null
                input = line ?? "";              // nếu null thì gán chuỗi rỗng

                if (input == "exit")
                    break;

                recv = SndRcvData(server, Encoding.UTF8.GetBytes(input), ipep);
                if (recv > 0)
                {
                    stringData = Encoding.UTF8.GetString(data, 0, recv);
                    Console.WriteLine(stringData);
                }
                else
                {
                    Console.WriteLine("Không nhận được câu trả lời");
                }
            }


            Console.WriteLine("Dang dong client");
            server.Close();
            #endregion
        }

    }
}
    
