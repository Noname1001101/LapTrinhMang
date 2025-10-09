using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{

    public partial class ClientForm : Form
    {
        private Socket clientSocket;
        private Thread receiveThread;
        private bool connected = false;
        public ClientForm()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                clientSocket.Connect(new IPEndPoint(IPAddress.Loopback, 5000));

                connected = true;
                Log("Kết nối thành công đến server.");
                lblStatusClient.ForeColor = Color.Green;
                lblXinChao.Text = "Xin chào";
       

                receiveThread = new Thread(ReceiveData);
                receiveThread.IsBackground = true;
                receiveThread.Start();
            }
            catch (Exception ex)
            {
                Log("Không thể kết nối: " + ex.Message);
            }
        }

        private void ReceiveData()
        {
            try
            {
                while (connected)
                {
                    byte[] buff = new byte[1024];
                    int received = clientSocket.Receive(buff);
                    if (received == 0) break;

                    string msg = Encoding.UTF8.GetString(buff, 0, received);

                    if (msg.StartsWith("Kết quả"))
                    {
                        string result = msg.Replace("Kết quả =", "").Trim();
                        Invoke(new Action(() => lblOutPut.Text = result));
                    }
                    else
                    {
                        Log(msg); 
                    }

                }
            }
            catch (Exception ex)
            {
                Log("Mất kết nối: " + ex.Message);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (!connected)
            {
                Log("Chưa kết nối đến server!");
                return;
            }

            string msg = txtInput.Text.Trim();
            if (string.IsNullOrEmpty(msg)) return;

            byte[] data = Encoding.UTF8.GetBytes(msg);
            clientSocket.Send(data);

            if (msg.ToLower() == "exit")
            {
                connected = false;
                clientSocket.Close();
                Log("Đã ngắt kết nối.");
            }

            //txtInput.Clear();
        }

        private void Log(string text)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => lblStatusClient.Text = text));
            }
            else
            {
                lblStatusClient.Text = text;
            }
        }

       
    }
}
