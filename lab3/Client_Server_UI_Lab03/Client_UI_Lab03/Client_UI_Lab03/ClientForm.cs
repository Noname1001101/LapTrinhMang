using System;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Client_UI_Lab03
{
    public partial class ClientForm : Form
    {
        private Socket clientSocket;
        private IPEndPoint serverEP;
        private EndPoint remoteEP;
        private byte[] buffer = new byte[1024];

        public ClientForm()
        {
            InitializeComponent();
            lblClientStatus.Text = "🟢 Client đã khởi động.";
            lblClientStatus.ForeColor = Color.ForestGreen;


            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            serverEP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5000);
            remoteEP = new IPEndPoint(IPAddress.Any, 0);
            clientSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 3000);


        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string msg = txtMessage.Text.Trim();
            if (string.IsNullOrEmpty(msg)) return;

            byte[] data = Encoding.UTF8.GetBytes(msg);
            clientSocket.SendTo(data, data.Length, SocketFlags.None, serverEP);
            lblClientStatus.Text = "🕓 Đang chờ phản hồi từ server...";
            lblClientStatus.ForeColor = Color.DarkOrange;
            lblClientStatus.Refresh();

            try
            {
                int recv = clientSocket.ReceiveFrom(buffer, ref remoteEP);
                string response = Encoding.UTF8.GetString(buffer, 0, recv);
                lstMessages.Items.Add($"📨 Server: {response}");

                // ✅ Cập nhật lại trạng thái kết nối thành OK
                lblClientStatus.Text = "🟢 Đã kết nối với server.";
                lblClientStatus.ForeColor = Color.ForestGreen;
            }

            catch (SocketException)
            {
                lstMessages.Items.Add("⚠️ Timeout: Không nhận được phản hồi từ server.");
                lblClientStatus.Text = "⚠️ Mất kết nối tạm thời với server.";
                lblClientStatus.ForeColor = Color.Goldenrod;
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                clientSocket.Close();
            }
            catch { }

            lblClientStatus.Text = "🔴 Client đã ngắt kết nối.";
            lblClientStatus.ForeColor = Color.Red;
            lstMessages.Items.Add("🛑 Client đã ngắt kết nối.");
            Close();
        }

    }
}
