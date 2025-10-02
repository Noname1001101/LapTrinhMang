using System.Net;
using System.Net.Sockets;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Any, 5000);

        Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        serverSocket.Bind(serverEndPoint);
        serverSocket.Listen(10);

        Console.WriteLine("Server đang lắng nghe trên cổng 5000...");

        Socket clientSocket = serverSocket.Accept();

        EndPoint clientEndPoint = clientSocket.RemoteEndPoint;
        Console.WriteLine("Kết nối từ: " + clientEndPoint.ToString());

        byte[] buff;
        string hello = "Hello Client";
        buff = Encoding.UTF8.GetBytes(hello);
        clientSocket.Send(buff, 0, buff.Length, SocketFlags.None);

        while (true)
        {
            try
            {
                buff = new byte[1024];
                int byteReceive = clientSocket.Receive(buff, 0, buff.Length, SocketFlags.None);

                if (byteReceive == 0)
                {
                    Console.WriteLine("Client đã ngắt kết nối.");
                    break;
                }

                string str = Encoding.UTF8.GetString(buff, 0, byteReceive);
                Console.WriteLine("Client gửi: " + str);

                if (str.ToLower() == "exit")
                {
                    Console.WriteLine("Client yêu cầu thoát. Ngắt kết nối.");
                    break;
                }

                // Thực hiện tính toán
                string result = TinhToan(str);

                // Gửi lại kết quả
                buff = Encoding.UTF8.GetBytes(result);
                clientSocket.Send(buff, 0, buff.Length, SocketFlags.None);
            }
            catch (SocketException)
            {
                Console.WriteLine("Client ngắt kết nối đột ngột.");
                break;
            }
        }

        clientSocket.Close();
        serverSocket.Close();

        Console.ReadLine();
    }

    static string TinhToan(string expr)
    {
        try
        {
            string[] parts = expr.Split(' ');
            if (parts.Length != 3) return "Lỗi cú pháp! Hãy nhập theo dạng: a + b";

            double a = double.Parse(parts[0]);
            string op = parts[1];
            double b = double.Parse(parts[2]);
            double result = 0;

            switch (op)
            {
                case "+": result = a + b; break;
                case "-": result = a - b; break;
                case "*": result = a * b; break;
                case "/":
                    if (b == 0) return "Lỗi: chia cho 0!";
                    result = a / b;
                    break;
                default: return "Toán tử không hợp lệ!";
            }

            return $"Kết quả = {result}";
        }
        catch
        {
            return "Lỗi khi tính toán!";
        }
    }
}
