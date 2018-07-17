namespace Microsoft.Samples.UmAlQuraForm
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
			this.umAlQuraControl1 = new UmAlQuraLibrary.UmAlQuraControl();
			this.SuspendLayout();
			// 
			// umAlQuraControl1
			// 
			this.umAlQuraControl1.Day = 15;
			this.umAlQuraControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.umAlQuraControl1.Location = new System.Drawing.Point(0, 0);
			this.umAlQuraControl1.Month = 10;
			this.umAlQuraControl1.Name = "umAlQuraControl1";
			this.umAlQuraControl1.Size = new System.Drawing.Size(372, 280);
			this.umAlQuraControl1.TabIndex = 0;
			this.umAlQuraControl1.Year = 1425;
			// 
			// Form1
			// 
			this.ClientSize = new System.Drawing.Size(372, 280);
			this.Controls.Add(this.umAlQuraControl1);
			this.Name = "Form1";
			this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.RightToLeftLayout = true;
			this.Text = "تقويم ام القرى الهجري";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private UmAlQuraLibrary.UmAlQuraControl umAlQuraControl1;





	}
}

