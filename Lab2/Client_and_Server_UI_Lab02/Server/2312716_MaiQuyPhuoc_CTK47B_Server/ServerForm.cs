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

namespace Bai2_Server_
{
    public partial class ServerForm : Form
    {
        private Socket serverSocket;
        private Socket clientSocket;
        private Thread listenThread;
        private bool isRunning = false;
        public ServerForm()
        {
            InitializeComponent();
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                serverSocket.Bind(new IPEndPoint(IPAddress.Any, 5000));
                serverSocket.Listen(10);

                isRunning = true;
                listenThread = new Thread(ListenClient);
                listenThread.IsBackground = true;
                listenThread.Start();

             
                SetStatus("Server đang chạy (đang chờ Client)...", true);
            }
            catch (Exception ex)
            {
       
                SetStatus("Server lỗi!", false);
            }
        }


        private void ListenClient()
        {
            try
            {
                clientSocket = serverSocket.Accept();
                SetStatus("Đã có client kết nối!", true);

                byte[] buff = new byte[1024];
                while (isRunning)
                {
                    int received = clientSocket.Receive(buff);
                    if (received == 0)
                    {
                        break;
                    }

                    string msg = Encoding.UTF8.GetString(buff, 0, received);

                    if (msg.ToLower() == "exit")
                    {
                        break;
                    }

   
                    if (InvokeRequired)
                    {
                        Invoke(new Action(() => txtHienThi.Text = msg));
                    }
                    else
                    {
                        txtHienThi.Text = msg;
                    }
                   
                    string result = TinhToan(msg);
                    SendMessage(result);
                }

                clientSocket.Close();
            }
            catch (Exception ex)
            {
        
                 Invoke(new Action(() => SetStatus("Lỗi: " + ex.Message, false)));
            }
        }


        private void SendMessage(string msg)
        {
            byte[] data = Encoding.UTF8.GetBytes(msg);
            clientSocket.Send(data);
        }

    

        private string TinhToan(string expr)
        {
            try
            {
                string[] parts = expr.Split(' ');
                if (parts.Length != 3) return "Lỗi cú pháp! Dạng: a + b";

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
                        if (b == 0) return "Lỗi: chia 0!";
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

        private void btnStop_Click(object sender, EventArgs e)
        {
            isRunning = false;
            clientSocket?.Close();
            serverSocket?.Close();
            listenThread?.Abort();
      
            SetStatus("Server: đã dừng", false);
        }

        private void SetStatus(string message, bool isRunning)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => SetStatus(message, isRunning)));
            }
            else
            {
                lblStatusServer.Text = message;
                lblStatusServer.ForeColor = isRunning ? Color.Green : Color.Red;
            }
        }

    }
}

