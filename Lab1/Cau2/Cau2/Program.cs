using System;
using System.Net.NetworkInformation;
using System.Net.Sockets;

class Program
{

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Thông tin IP của Localhost:\n");

        foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
        {
            // Chỉ lấy các card mạng đang hoạt động và không phải loopback
            if (ni.OperationalStatus == OperationalStatus.Up &&
                ni.NetworkInterfaceType != NetworkInterfaceType.Loopback)
            {
                Console.WriteLine("Interface: " + ni.Name);

                IPInterfaceProperties ipProps = ni.GetIPProperties();

                foreach (UnicastIPAddressInformation addr in ipProps.UnicastAddresses)
                {
                    if (addr.Address.AddressFamily == AddressFamily.InterNetwork)
                    {
                        Console.WriteLine("  - Địa chỉ IP     : " + addr.Address);
                        Console.WriteLine("  - Subnet Mask    : " + addr.IPv4Mask);
                    }
                }

                foreach (GatewayIPAddressInformation gw in ipProps.GatewayAddresses)
                {
                    if (gw.Address.AddressFamily == AddressFamily.InterNetwork)
                    {
                        Console.WriteLine("  - Default Gateway: " + gw.Address);
                    }
                }

                Console.WriteLine();
            }
        }

        Console.WriteLine("Nhấn phím bất kỳ để thoát...");
        Console.ReadKey();
    }
}
