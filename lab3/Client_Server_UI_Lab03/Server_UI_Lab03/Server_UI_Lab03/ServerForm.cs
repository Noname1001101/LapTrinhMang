using System;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server_UI_Lab03
{
    public partial class ServerForm : Form
    {
        private Socket serverSocket;
        private bool isRunning = false;
        private EndPoint remoteEP;
        private Task listenTask;

        public ServerForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false; // cho phép cập nhật UI từ thread khác
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (isRunning) return;

            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            serverSocket.Bind(new IPEndPoint(IPAddress.Any, 5000));
            remoteEP = new IPEndPoint(IPAddress.Any, 0);

            isRunning = true;
            lblStatus.Text = "🟢 Server đang chạy trên cổng 5000...";
            lblStatus.ForeColor = Color.ForestGreen;


            listenTask = Task.Run(() => ListenLoop());
        }

        private void ListenLoop()
        {
            byte[] buffer = new byte[1024];
            int counter = 0;

            while (isRunning)
            {
                try
                {
                    int bytes = serverSocket.ReceiveFrom(buffer, ref remoteEP);
                    string message = Encoding.UTF8.GetString(buffer, 0, bytes);
                    lstLog.Items.Add($"📩 {remoteEP}: {message}");

                    if (message.Trim().ToLower() == "exit all")
                    {
                        lstLog.Items.Add("❌ Nhận lệnh tắt server.");
                        StopServer();
                        break;
                    }

                    counter++;
                    if (counter <= 2)
                    {
                        lstLog.Items.Add("⚠️ Giả lập mất gói tin — không phản hồi lần này, vui lòng gửi lại ");
                        continue;
                    }

                    string reply = "Server đã nhận thông điệp: " + message + " ✅";
                    byte[] replyData = Encoding.UTF8.GetBytes(reply);
                    serverSocket.SendTo(replyData, replyData.Length, SocketFlags.None, remoteEP);
                }
                catch (Exception ex)
                {
                    lstLog.Items.Add($"Lỗi: {ex.Message}");
                }
            }
        }

        private void StopServer()
        {
            if (!isRunning) return;
            isRunning = false;
            serverSocket?.Close();

            lblStatus.Text = "🔴 Server đã dừng.";
            lblStatus.ForeColor = Color.Red;
            lstLog.Items.Add("🛑 Server đã dừng.");
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            StopServer();
        }
    }
}
