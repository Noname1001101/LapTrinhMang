using System.Net;
using System.Net.Sockets;
using System.Text;

class ClientProgram
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Loopback, 5000);

        Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        Console.WriteLine("Đang kết nối với server...");

        try
        {
            serverSocket.Connect(serverEndPoint);

            if (serverSocket.Connected)
            {
                Console.WriteLine("Kết nối thành công với server...");

                byte[] buff = new byte[1024];
                int byteReceive = serverSocket.Receive(buff, 0, buff.Length, SocketFlags.None);

                string str = Encoding.UTF8.GetString(buff, 0, byteReceive);
                Console.WriteLine("Server chào: " + str);

                while (true)
                {
                    Console.Write("Nhập phép tính vd:7 * 2 hoặc 'exit' để thoát: ");
                    str = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(str))
                        continue;

                    if (str.ToLower() == "exit")
                    {
                        serverSocket.Send(Encoding.UTF8.GetBytes("exit"));
                        Console.WriteLine("Đã thoát khỏi chương trình.");
                        break;
                    }



                    // Gửi dữ liệu lên server
                    buff = Encoding.UTF8.GetBytes(str);
                    serverSocket.Send(buff, 0, buff.Length, SocketFlags.None);

                    // Nhận phản hồi từ server
                    buff = new byte[1024];
                    byteReceive = serverSocket.Receive(buff, 0, buff.Length, SocketFlags.None);
                    str = Encoding.UTF8.GetString(buff, 0, byteReceive);

                    Console.WriteLine("Server trả về: " + str);
                }
            }
        }
        catch (SocketException se)
        {
            Console.WriteLine("Không thể kết nối đến server. Chi tiết: " + se.Message);
        }
        finally
        {
            serverSocket.Close();
        }
    }
}