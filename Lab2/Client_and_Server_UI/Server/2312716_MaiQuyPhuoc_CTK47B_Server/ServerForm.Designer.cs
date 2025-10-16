namespace Bai2_Server_
{
    partial class ServerForm
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
            this.bntStart = new System.Windows.Forms.Button();
            this.bntStop = new System.Windows.Forms.Button();
            this.txtHienThi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblStatusServer = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bntStart
            // 
            this.bntStart.AutoSize = true;
            this.bntStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntStart.Location = new System.Drawing.Point(38, 25);
            this.bntStart.Name = "bntStart";
            this.bntStart.Size = new System.Drawing.Size(147, 30);
            this.bntStart.TabIndex = 0;
            this.bntStart.Text = "Khởi động Server";
            this.bntStart.UseVisualStyleBackColor = true;
            this.bntStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // bntStop
            // 
            this.bntStop.AutoSize = true;
            this.bntStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntStop.Location = new System.Drawing.Point(38, 165);
            this.bntStop.Name = "bntStop";
            this.bntStop.Size = new System.Drawing.Size(120, 30);
            this.bntStop.TabIndex = 1;
            this.bntStop.Text = " Dừng Server";
            this.bntStop.UseVisualStyleBackColor = true;
            this.bntStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // txtHienThi
            // 
            this.txtHienThi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHienThi.Location = new System.Drawing.Point(38, 114);
            this.txtHienThi.Name = "txtHienThi";
            this.txtHienThi.Size = new System.Drawing.Size(250, 26);
            this.txtHienThi.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Server:";
            // 
            // lblStatusServer
            // 
            this.lblStatusServer.AutoSize = true;
            this.lblStatusServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusServer.Location = new System.Drawing.Point(124, 68);
            this.lblStatusServer.Name = "lblStatusServer";
            this.lblStatusServer.Size = new System.Drawing.Size(79, 20);
            this.lblStatusServer.TabIndex = 4;
            this.lblStatusServer.Text = "trạng thái";
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblStatusServer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtHienThi);
            this.Controls.Add(this.bntStop);
            this.Controls.Add(this.bntStart);
            this.Name = "ServerForm";
            this.Text = "Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bntStart;
        private System.Windows.Forms.Button bntStop;
        private System.Windows.Forms.TextBox txtHienThi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblStatusServer;
    }
}

