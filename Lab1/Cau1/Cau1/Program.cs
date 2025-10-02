using System.Net;

static void GetHostInfo(string host)
{
    try
    {
        IPHostEntry hostInfo = Dns.GetHostEntry(host);

        // Hiển thị tên miền
        Console.WriteLine("Tên miền: " + hostInfo.HostName);

        // Hiển thị danh sách địa chỉ IP
        Console.Write("Địa chỉ IP: ");
        foreach (IPAddress ipaddr in hostInfo.AddressList)
        {
            Console.Write(ipaddr.ToString() + " ");
        }
        Console.WriteLine();
    }
    catch (Exception e)
    {
        Console.WriteLine("Không phân giải được tên miền: " + host + "\nLỗi: " + e.Message);
    }
}
Console.OutputEncoding = System.Text.Encoding.UTF8;
GetHostInfo("google.com");
Console.WriteLine("Nhấn Enter để thoát...");
Console.ReadLine(); // giữ cửa sổ console
