using System;
using System.Net;
using System.Windows.Forms;

namespace Cau3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();      
        }

        private void bntPhanGiai_Click(object sender, EventArgs e)
        {
            string tenMien = txtTenMien.Text.Trim();

            if (string.IsNullOrEmpty(tenMien))
            {
                MessageBox.Show("Vui lòng nhập tên miền cần tra cứu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                IPHostEntry hostInfo = Dns.GetHostEntry(tenMien);

                // Gộp tất cả địa chỉ IP thành chuỗi
                string diaChiIP = string.Join(", ", Array.ConvertAll(hostInfo.AddressList, ip => ip.ToString()));

                lblDiaChiIP.Text = diaChiIP;
            }
            catch (Exception ex)
            {
                lblDiaChiIP.Text = "Không phân giải được!";
                MessageBox.Show("Lỗi: " + ex.Message, "Không thể phân giải", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
