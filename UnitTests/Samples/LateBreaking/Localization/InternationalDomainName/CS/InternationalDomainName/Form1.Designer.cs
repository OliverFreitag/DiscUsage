namespace Microsoft.Samples.InternationalDomainName
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
			this.LabelAddress = new System.Windows.Forms.Label();
			this.LabelPunycode = new System.Windows.Forms.Label();
			this.textBoxAddress = new System.Windows.Forms.TextBox();
			this.ButtonGo = new System.Windows.Forms.Button();
			this.textBoxPunycode = new System.Windows.Forms.TextBox();
			this.webBrowser1 = new System.Windows.Forms.WebBrowser();
			this.SuspendLayout();
			// 
			// LabelAddress
			// 
			this.LabelAddress.AutoSize = true;
			this.LabelAddress.Location = new System.Drawing.Point(12, 12);
			this.LabelAddress.Name = "LabelAddress";
			this.LabelAddress.Size = new System.Drawing.Size(93, 27);
			this.LabelAddress.TabIndex = 0;
			this.LabelAddress.Text = "Address:";
			// 
			// LabelPunycode
			// 
			this.LabelPunycode.AutoSize = true;
			this.LabelPunycode.Location = new System.Drawing.Point(13, 46);
			this.LabelPunycode.Name = "LabelPunycode";
			this.LabelPunycode.Size = new System.Drawing.Size(110, 27);
			this.LabelPunycode.TabIndex = 1;
			this.LabelPunycode.Text = "Punycode:";
			// 
			// textBoxAddress
			// 
			this.textBoxAddress.Location = new System.Drawing.Point(138, 8);
			this.textBoxAddress.Name = "textBoxAddress";
			this.textBoxAddress.Size = new System.Drawing.Size(453, 31);
			this.textBoxAddress.TabIndex = 2;
			this.textBoxAddress.Text = "http://www.bücher.de/";
			// 
			// ButtonGo
			// 
			this.ButtonGo.Location = new System.Drawing.Point(611, 8);
			this.ButtonGo.Name = "ButtonGo";
			this.ButtonGo.Size = new System.Drawing.Size(75, 31);
			this.ButtonGo.TabIndex = 3;
			this.ButtonGo.Text = "Go";
			this.ButtonGo.Click += new System.EventHandler(this.ButtonGo_Click);
			// 
			// textBoxPunycode
			// 
			this.textBoxPunycode.Location = new System.Drawing.Point(138, 46);
			this.textBoxPunycode.Name = "textBoxPunycode";
			this.textBoxPunycode.Size = new System.Drawing.Size(453, 31);
			this.textBoxPunycode.TabIndex = 4;
			// 
			// webBrowser1
			// 
			this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.webBrowser1.Location = new System.Drawing.Point(13, 84);
			this.webBrowser1.Name = "webBrowser1";
			this.webBrowser1.Size = new System.Drawing.Size(673, 338);
			this.webBrowser1.TabIndex = 5;
			// 
			// Form1
			// 
			this.ClientSize = new System.Drawing.Size(700, 432);
			this.Controls.Add(this.webBrowser1);
			this.Controls.Add(this.textBoxPunycode);
			this.Controls.Add(this.ButtonGo);
			this.Controls.Add(this.textBoxAddress);
			this.Controls.Add(this.LabelPunycode);
			this.Controls.Add(this.LabelAddress);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "Form1";
			this.Text = "International Domain Name Browser";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label LabelAddress;
		private System.Windows.Forms.Label LabelPunycode;
		private System.Windows.Forms.TextBox textBoxAddress;
		private System.Windows.Forms.Button ButtonGo;
		private System.Windows.Forms.TextBox textBoxPunycode;
		private System.Windows.Forms.WebBrowser webBrowser1;
	}
}

