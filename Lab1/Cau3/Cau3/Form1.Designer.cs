namespace Cau3
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtTenMien = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDiaChiIP = new System.Windows.Forms.Label();
            this.bntPhanGiai = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(44, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên miền:";
            // 
            // txtTenMien
            // 
            this.txtTenMien.Location = new System.Drawing.Point(137, 48);
            this.txtTenMien.Name = "txtTenMien";
            this.txtTenMien.Size = new System.Drawing.Size(187, 22);
            this.txtTenMien.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(41, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Địa chỉ IP:";
            // 
            // lblDiaChiIP
            // 
            this.lblDiaChiIP.AutoSize = true;
            this.lblDiaChiIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiaChiIP.Location = new System.Drawing.Point(133, 100);
            this.lblDiaChiIP.Name = "lblDiaChiIP";
            this.lblDiaChiIP.Size = new System.Drawing.Size(13, 20);
            this.lblDiaChiIP.TabIndex = 3;
            this.lblDiaChiIP.Text = ".";
            // 
            // bntPhanGiai
            // 
            this.bntPhanGiai.AutoSize = true;
            this.bntPhanGiai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntPhanGiai.Location = new System.Drawing.Point(344, 43);
            this.bntPhanGiai.Name = "bntPhanGiai";
            this.bntPhanGiai.Size = new System.Drawing.Size(92, 30);
            this.bntPhanGiai.TabIndex = 4;
            this.bntPhanGiai.Text = "Phân Giải";
            this.bntPhanGiai.UseVisualStyleBackColor = true;
            this.bntPhanGiai.Click += new System.EventHandler(this.bntPhanGiai_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bntPhanGiai);
            this.Controls.Add(this.lblDiaChiIP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTenMien);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTenMien;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDiaChiIP;
        private System.Windows.Forms.Button bntPhanGiai;
    }
}

