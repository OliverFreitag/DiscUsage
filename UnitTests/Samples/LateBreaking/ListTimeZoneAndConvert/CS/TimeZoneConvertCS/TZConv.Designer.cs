namespace Microsoft.Samples.TimeZoneConvertCS
{
	partial class TZConv
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
            this.label2 = new System.Windows.Forms.Label();
            this.btnConvert = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbDestTZ = new System.Windows.Forms.ComboBox();
            this.txtSourceDate = new System.Windows.Forms.TextBox();
            this.lblDestDate = new System.Windows.Forms.Label();
            this.lblUTCDate = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(223, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Source Date (in current TimeZone)";
            // 
            // btnConvert
            // 
            this.btnConvert.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConvert.Location = new System.Drawing.Point(12, 117);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(95, 27);
            this.btnConvert.TabIndex = 3;
            this.btnConvert.Text = "&Convert";
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(487, 117);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(95, 27);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "&Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Target TimeZone";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(387, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Target Date";
            // 
            // cmbDestTZ
            // 
            this.cmbDestTZ.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDestTZ.FormattingEnabled = true;
            this.cmbDestTZ.Location = new System.Drawing.Point(12, 80);
            this.cmbDestTZ.Name = "cmbDestTZ";
            this.cmbDestTZ.Size = new System.Drawing.Size(368, 22);
            this.cmbDestTZ.TabIndex = 2;
            // 
            // txtSourceDate
            // 
            this.txtSourceDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSourceDate.Location = new System.Drawing.Point(12, 32);
            this.txtSourceDate.Name = "txtSourceDate";
            this.txtSourceDate.Size = new System.Drawing.Size(264, 22);
            this.txtSourceDate.TabIndex = 1;
            // 
            // lblDestDate
            // 
            this.lblDestDate.AutoSize = true;
            this.lblDestDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDestDate.Location = new System.Drawing.Point(387, 83);
            this.lblDestDate.Name = "lblDestDate";
            this.lblDestDate.Size = new System.Drawing.Size(9, 17);
            this.lblDestDate.TabIndex = 5;
            this.lblDestDate.Text = ".";
            // 
            // lblUTCDate
            // 
            this.lblUTCDate.AutoSize = true;
            this.lblUTCDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUTCDate.Location = new System.Drawing.Point(387, 35);
            this.lblUTCDate.Name = "lblUTCDate";
            this.lblUTCDate.Size = new System.Drawing.Size(9, 17);
            this.lblUTCDate.TabIndex = 8;
            this.lblUTCDate.Text = ".";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(387, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "UTC Date";
            // 
            // TZConv
            // 
            this.ClientSize = new System.Drawing.Size(594, 155);
            this.Controls.Add(this.lblUTCDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblDestDate);
            this.Controls.Add(this.txtSourceDate);
            this.Controls.Add(this.cmbDestTZ);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.label2);
            this.Name = "TZConv";
            this.Text = "Convert Dates between TimeZones";
            this.Load += new System.EventHandler(this.TZConv_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

		#endregion

        private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnConvert;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbDestTZ;
		private System.Windows.Forms.TextBox txtSourceDate;
        private System.Windows.Forms.Label lblDestDate;
        private System.Windows.Forms.Label lblUTCDate;
        private System.Windows.Forms.Label label6;
	}
}

