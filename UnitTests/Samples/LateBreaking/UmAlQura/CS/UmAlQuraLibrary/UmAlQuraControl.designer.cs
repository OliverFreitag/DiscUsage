namespace Microsoft.Samples.UmAlQuraLibrary
{


	public partial class UmAlQuraControl : System.Windows.Forms.UserControl
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
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UmAlQuraControl));
			this.HeaderPanel = new System.Windows.Forms.Panel();
			this.TableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.FrontButton = new System.Windows.Forms.Button();
			this.BackButton = new System.Windows.Forms.Button();
			this.HeaderLabel = new System.Windows.Forms.Label();
			this.FooterPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.FooterLabel = new System.Windows.Forms.Label();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.Daylabel1 = new System.Windows.Forms.Label();
			this.Daylabel2 = new System.Windows.Forms.Label();
			this.Daylabel3 = new System.Windows.Forms.Label();
			this.Daylabel4 = new System.Windows.Forms.Label();
			this.Daylabel5 = new System.Windows.Forms.Label();
			this.Daylabel6 = new System.Windows.Forms.Label();
			this.Daylabel7 = new System.Windows.Forms.Label();
			this.DayNo1 = new System.Windows.Forms.Label();
			this.DayNo2 = new System.Windows.Forms.Label();
			this.DayNo3 = new System.Windows.Forms.Label();
			this.DayNo4 = new System.Windows.Forms.Label();
			this.DayNo5 = new System.Windows.Forms.Label();
			this.DayNo6 = new System.Windows.Forms.Label();
			this.DayNo7 = new System.Windows.Forms.Label();
			this.DayNo8 = new System.Windows.Forms.Label();
			this.DayNo9 = new System.Windows.Forms.Label();
			this.DayNo10 = new System.Windows.Forms.Label();
			this.DayNo11 = new System.Windows.Forms.Label();
			this.DayNo12 = new System.Windows.Forms.Label();
			this.DayNo13 = new System.Windows.Forms.Label();
			this.DayNo14 = new System.Windows.Forms.Label();
			this.DayNo15 = new System.Windows.Forms.Label();
			this.DayNo16 = new System.Windows.Forms.Label();
			this.DayNo17 = new System.Windows.Forms.Label();
			this.DayNo18 = new System.Windows.Forms.Label();
			this.DayNo19 = new System.Windows.Forms.Label();
			this.DayNo20 = new System.Windows.Forms.Label();
			this.DayNo21 = new System.Windows.Forms.Label();
			this.DayNo22 = new System.Windows.Forms.Label();
			this.DayNo23 = new System.Windows.Forms.Label();
			this.DayNo24 = new System.Windows.Forms.Label();
			this.DayNo25 = new System.Windows.Forms.Label();
			this.DayNo26 = new System.Windows.Forms.Label();
			this.DayNo27 = new System.Windows.Forms.Label();
			this.DayNo28 = new System.Windows.Forms.Label();
			this.DayNo29 = new System.Windows.Forms.Label();
			this.DayNo30 = new System.Windows.Forms.Label();
			this.DayNo31 = new System.Windows.Forms.Label();
			this.DayNo32 = new System.Windows.Forms.Label();
			this.DayNo33 = new System.Windows.Forms.Label();
			this.DayNo34 = new System.Windows.Forms.Label();
			this.DayNo35 = new System.Windows.Forms.Label();
			this.HeaderPanel.SuspendLayout();
			this.TableLayoutPanel2.SuspendLayout();
			this.FooterPanel.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// HeaderPanel
			// 
			this.HeaderPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.HeaderPanel.Controls.Add(this.TableLayoutPanel2);
			resources.ApplyResources(this.HeaderPanel, "HeaderPanel");
			this.HeaderPanel.ForeColor = System.Drawing.Color.White;
			this.HeaderPanel.Name = "HeaderPanel";
			// 
			// TableLayoutPanel2
			// 
			resources.ApplyResources(this.TableLayoutPanel2, "TableLayoutPanel2");
			this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
			this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.TableLayoutPanel2.Controls.Add(this.FrontButton, 0, 0);
			this.TableLayoutPanel2.Controls.Add(this.BackButton, 2, 0);
			this.TableLayoutPanel2.Controls.Add(this.HeaderLabel, 1, 0);
			this.TableLayoutPanel2.Name = "TableLayoutPanel2";
			this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			// 
			// FrontButton
			// 
			resources.ApplyResources(this.FrontButton, "FrontButton");
			this.FrontButton.ForeColor = System.Drawing.Color.Black;
			this.FrontButton.Name = "FrontButton";
			this.FrontButton.Click += new System.EventHandler(this.FrontButton_Click);
			// 
			// BackButton
			// 
			resources.ApplyResources(this.BackButton, "BackButton");
			this.BackButton.ForeColor = System.Drawing.Color.Black;
			this.BackButton.Name = "BackButton";
			this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
			// 
			// HeaderLabel
			// 
			resources.ApplyResources(this.HeaderLabel, "HeaderLabel");
			this.HeaderLabel.Name = "HeaderLabel";
			// 
			// FooterPanel
			// 
			this.FooterPanel.BackColor = System.Drawing.Color.White;
			this.FooterPanel.Controls.Add(this.FooterLabel);
			resources.ApplyResources(this.FooterPanel, "FooterPanel");
			this.FooterPanel.Name = "FooterPanel";
			// 
			// FooterLabel
			// 
			resources.ApplyResources(this.FooterLabel, "FooterLabel");
			this.FooterLabel.BackColor = System.Drawing.Color.White;
			this.FooterLabel.Name = "FooterLabel";
			// 
			// tableLayoutPanel1
			// 
			resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
			this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.3F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.3F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.3F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.3F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.3F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.3F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.3F));
			this.tableLayoutPanel1.Controls.Add(this.Daylabel1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.Daylabel2, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.Daylabel3, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.Daylabel4, 3, 0);
			this.tableLayoutPanel1.Controls.Add(this.Daylabel5, 4, 0);
			this.tableLayoutPanel1.Controls.Add(this.Daylabel6, 5, 0);
			this.tableLayoutPanel1.Controls.Add(this.Daylabel7, 6, 0);
			this.tableLayoutPanel1.Controls.Add(this.DayNo1, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.DayNo2, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.DayNo3, 2, 1);
			this.tableLayoutPanel1.Controls.Add(this.DayNo4, 3, 1);
			this.tableLayoutPanel1.Controls.Add(this.DayNo5, 4, 1);
			this.tableLayoutPanel1.Controls.Add(this.DayNo6, 5, 1);
			this.tableLayoutPanel1.Controls.Add(this.DayNo7, 6, 1);
			this.tableLayoutPanel1.Controls.Add(this.DayNo8, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.DayNo9, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.DayNo10, 2, 2);
			this.tableLayoutPanel1.Controls.Add(this.DayNo11, 3, 2);
			this.tableLayoutPanel1.Controls.Add(this.DayNo12, 4, 2);
			this.tableLayoutPanel1.Controls.Add(this.DayNo13, 5, 2);
			this.tableLayoutPanel1.Controls.Add(this.DayNo14, 6, 2);
			this.tableLayoutPanel1.Controls.Add(this.DayNo15, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.DayNo16, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.DayNo17, 2, 3);
			this.tableLayoutPanel1.Controls.Add(this.DayNo18, 3, 3);
			this.tableLayoutPanel1.Controls.Add(this.DayNo19, 4, 3);
			this.tableLayoutPanel1.Controls.Add(this.DayNo20, 5, 3);
			this.tableLayoutPanel1.Controls.Add(this.DayNo21, 6, 3);
			this.tableLayoutPanel1.Controls.Add(this.DayNo22, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.DayNo23, 1, 4);
			this.tableLayoutPanel1.Controls.Add(this.DayNo24, 2, 4);
			this.tableLayoutPanel1.Controls.Add(this.DayNo25, 3, 4);
			this.tableLayoutPanel1.Controls.Add(this.DayNo26, 4, 4);
			this.tableLayoutPanel1.Controls.Add(this.DayNo27, 5, 4);
			this.tableLayoutPanel1.Controls.Add(this.DayNo28, 6, 4);
			this.tableLayoutPanel1.Controls.Add(this.DayNo29, 0, 5);
			this.tableLayoutPanel1.Controls.Add(this.DayNo30, 1, 5);
			this.tableLayoutPanel1.Controls.Add(this.DayNo31, 2, 5);
			this.tableLayoutPanel1.Controls.Add(this.DayNo32, 3, 5);
			this.tableLayoutPanel1.Controls.Add(this.DayNo33, 4, 5);
			this.tableLayoutPanel1.Controls.Add(this.DayNo34, 5, 5);
			this.tableLayoutPanel1.Controls.Add(this.DayNo35, 6, 5);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.82868F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.63426F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.63426F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.63426F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.63426F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.63426F));
			// 
			// Daylabel1
			// 
			resources.ApplyResources(this.Daylabel1, "Daylabel1");
			this.Daylabel1.BackColor = System.Drawing.Color.White;
			this.Daylabel1.ForeColor = System.Drawing.Color.Blue;
			this.Daylabel1.Margin = new System.Windows.Forms.Padding(1);
			this.Daylabel1.Name = "Daylabel1";
			// 
			// Daylabel2
			// 
			resources.ApplyResources(this.Daylabel2, "Daylabel2");
			this.Daylabel2.BackColor = System.Drawing.Color.White;
			this.Daylabel2.ForeColor = System.Drawing.Color.Blue;
			this.Daylabel2.Margin = new System.Windows.Forms.Padding(1);
			this.Daylabel2.Name = "Daylabel2";
			// 
			// Daylabel3
			// 
			resources.ApplyResources(this.Daylabel3, "Daylabel3");
			this.Daylabel3.BackColor = System.Drawing.Color.White;
			this.Daylabel3.ForeColor = System.Drawing.Color.Blue;
			this.Daylabel3.Margin = new System.Windows.Forms.Padding(1);
			this.Daylabel3.Name = "Daylabel3";
			// 
			// Daylabel4
			// 
			resources.ApplyResources(this.Daylabel4, "Daylabel4");
			this.Daylabel4.BackColor = System.Drawing.Color.White;
			this.Daylabel4.ForeColor = System.Drawing.Color.Blue;
			this.Daylabel4.Margin = new System.Windows.Forms.Padding(1);
			this.Daylabel4.Name = "Daylabel4";
			// 
			// Daylabel5
			// 
			resources.ApplyResources(this.Daylabel5, "Daylabel5");
			this.Daylabel5.BackColor = System.Drawing.Color.White;
			this.Daylabel5.ForeColor = System.Drawing.Color.Blue;
			this.Daylabel5.Margin = new System.Windows.Forms.Padding(1);
			this.Daylabel5.Name = "Daylabel5";
			// 
			// Daylabel6
			// 
			resources.ApplyResources(this.Daylabel6, "Daylabel6");
			this.Daylabel6.BackColor = System.Drawing.Color.White;
			this.Daylabel6.ForeColor = System.Drawing.Color.Blue;
			this.Daylabel6.Margin = new System.Windows.Forms.Padding(1);
			this.Daylabel6.Name = "Daylabel6";
			// 
			// Daylabel7
			// 
			resources.ApplyResources(this.Daylabel7, "Daylabel7");
			this.Daylabel7.BackColor = System.Drawing.Color.White;
			this.Daylabel7.ForeColor = System.Drawing.Color.Blue;
			this.Daylabel7.Margin = new System.Windows.Forms.Padding(1);
			this.Daylabel7.Name = "Daylabel7";
			// 
			// DayNo1
			// 
			resources.ApplyResources(this.DayNo1, "DayNo1");
			this.DayNo1.BackColor = System.Drawing.Color.White;
			this.DayNo1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.DayNo1.Name = "DayNo1";
			this.DayNo1.Click += new System.EventHandler(this.DayNo_Click);
			// 
			// DayNo2
			// 
			resources.ApplyResources(this.DayNo2, "DayNo2");
			this.DayNo2.BackColor = System.Drawing.Color.White;
			this.DayNo2.Name = "DayNo2";
			this.DayNo2.Click += new System.EventHandler(this.DayNo_Click);
			// 
			// DayNo3
			// 
			resources.ApplyResources(this.DayNo3, "DayNo3");
			this.DayNo3.BackColor = System.Drawing.Color.White;
			this.DayNo3.Name = "DayNo3";
			this.DayNo3.Click += new System.EventHandler(this.DayNo_Click);
			// 
			// DayNo4
			// 
			resources.ApplyResources(this.DayNo4, "DayNo4");
			this.DayNo4.BackColor = System.Drawing.Color.White;
			this.DayNo4.Name = "DayNo4";
			this.DayNo4.Click += new System.EventHandler(this.DayNo_Click);
			// 
			// DayNo5
			// 
			resources.ApplyResources(this.DayNo5, "DayNo5");
			this.DayNo5.BackColor = System.Drawing.Color.White;
			this.DayNo5.Name = "DayNo5";
			this.DayNo5.Click += new System.EventHandler(this.DayNo_Click);
			// 
			// DayNo6
			// 
			resources.ApplyResources(this.DayNo6, "DayNo6");
			this.DayNo6.BackColor = System.Drawing.Color.White;
			this.DayNo6.Name = "DayNo6";
			this.DayNo6.Click += new System.EventHandler(this.DayNo_Click);
			// 
			// DayNo7
			// 
			resources.ApplyResources(this.DayNo7, "DayNo7");
			this.DayNo7.BackColor = System.Drawing.Color.White;
			this.DayNo7.Name = "DayNo7";
			this.DayNo7.Click += new System.EventHandler(this.DayNo_Click);
			// 
			// DayNo8
			// 
			resources.ApplyResources(this.DayNo8, "DayNo8");
			this.DayNo8.BackColor = System.Drawing.Color.White;
			this.DayNo8.Name = "DayNo8";
			this.DayNo8.Click += new System.EventHandler(this.DayNo_Click);
			// 
			// DayNo9
			// 
			resources.ApplyResources(this.DayNo9, "DayNo9");
			this.DayNo9.BackColor = System.Drawing.Color.White;
			this.DayNo9.Name = "DayNo9";
			this.DayNo9.Click += new System.EventHandler(this.DayNo_Click);
			// 
			// DayNo10
			// 
			resources.ApplyResources(this.DayNo10, "DayNo10");
			this.DayNo10.BackColor = System.Drawing.Color.White;
			this.DayNo10.Name = "DayNo10";
			this.DayNo10.Click += new System.EventHandler(this.DayNo_Click);
			// 
			// DayNo11
			// 
			resources.ApplyResources(this.DayNo11, "DayNo11");
			this.DayNo11.BackColor = System.Drawing.Color.White;
			this.DayNo11.Name = "DayNo11";
			this.DayNo11.Click += new System.EventHandler(this.DayNo_Click);
			// 
			// DayNo12
			// 
			resources.ApplyResources(this.DayNo12, "DayNo12");
			this.DayNo12.BackColor = System.Drawing.Color.White;
			this.DayNo12.Name = "DayNo12";
			this.DayNo12.Click += new System.EventHandler(this.DayNo_Click);
			// 
			// DayNo13
			// 
			resources.ApplyResources(this.DayNo13, "DayNo13");
			this.DayNo13.BackColor = System.Drawing.Color.White;
			this.DayNo13.Name = "DayNo13";
			this.DayNo13.Click += new System.EventHandler(this.DayNo_Click);
			// 
			// DayNo14
			// 
			resources.ApplyResources(this.DayNo14, "DayNo14");
			this.DayNo14.BackColor = System.Drawing.Color.White;
			this.DayNo14.Name = "DayNo14";
			this.DayNo14.Click += new System.EventHandler(this.DayNo_Click);
			// 
			// DayNo15
			// 
			resources.ApplyResources(this.DayNo15, "DayNo15");
			this.DayNo15.BackColor = System.Drawing.Color.White;
			this.DayNo15.Name = "DayNo15";
			this.DayNo15.Click += new System.EventHandler(this.DayNo_Click);
			// 
			// DayNo16
			// 
			resources.ApplyResources(this.DayNo16, "DayNo16");
			this.DayNo16.BackColor = System.Drawing.Color.White;
			this.DayNo16.Name = "DayNo16";
			this.DayNo16.Click += new System.EventHandler(this.DayNo_Click);
			// 
			// DayNo17
			// 
			resources.ApplyResources(this.DayNo17, "DayNo17");
			this.DayNo17.BackColor = System.Drawing.Color.White;
			this.DayNo17.Name = "DayNo17";
			this.DayNo17.Click += new System.EventHandler(this.DayNo_Click);
			// 
			// DayNo18
			// 
			resources.ApplyResources(this.DayNo18, "DayNo18");
			this.DayNo18.BackColor = System.Drawing.Color.White;
			this.DayNo18.Name = "DayNo18";
			this.DayNo18.Click += new System.EventHandler(this.DayNo_Click);
			// 
			// DayNo19
			// 
			resources.ApplyResources(this.DayNo19, "DayNo19");
			this.DayNo19.BackColor = System.Drawing.Color.White;
			this.DayNo19.Name = "DayNo19";
			this.DayNo19.Click += new System.EventHandler(this.DayNo_Click);
			// 
			// DayNo20
			// 
			resources.ApplyResources(this.DayNo20, "DayNo20");
			this.DayNo20.BackColor = System.Drawing.Color.White;
			this.DayNo20.Name = "DayNo20";
			this.DayNo20.Click += new System.EventHandler(this.DayNo_Click);
			// 
			// DayNo21
			// 
			resources.ApplyResources(this.DayNo21, "DayNo21");
			this.DayNo21.BackColor = System.Drawing.Color.White;
			this.DayNo21.Name = "DayNo21";
			this.DayNo21.Click += new System.EventHandler(this.DayNo_Click);
			// 
			// DayNo22
			// 
			resources.ApplyResources(this.DayNo22, "DayNo22");
			this.DayNo22.BackColor = System.Drawing.Color.White;
			this.DayNo22.Name = "DayNo22";
			this.DayNo22.Click += new System.EventHandler(this.DayNo_Click);
			// 
			// DayNo23
			// 
			resources.ApplyResources(this.DayNo23, "DayNo23");
			this.DayNo23.BackColor = System.Drawing.Color.White;
			this.DayNo23.Name = "DayNo23";
			this.DayNo23.Click += new System.EventHandler(this.DayNo_Click);
			// 
			// DayNo24
			// 
			resources.ApplyResources(this.DayNo24, "DayNo24");
			this.DayNo24.BackColor = System.Drawing.Color.White;
			this.DayNo24.Name = "DayNo24";
			this.DayNo24.Click += new System.EventHandler(this.DayNo_Click);
			// 
			// DayNo25
			// 
			resources.ApplyResources(this.DayNo25, "DayNo25");
			this.DayNo25.BackColor = System.Drawing.Color.White;
			this.DayNo25.Name = "DayNo25";
			this.DayNo25.Click += new System.EventHandler(this.DayNo_Click);
			// 
			// DayNo26
			// 
			resources.ApplyResources(this.DayNo26, "DayNo26");
			this.DayNo26.BackColor = System.Drawing.Color.White;
			this.DayNo26.Name = "DayNo26";
			this.DayNo26.Click += new System.EventHandler(this.DayNo_Click);
			// 
			// DayNo27
			// 
			resources.ApplyResources(this.DayNo27, "DayNo27");
			this.DayNo27.BackColor = System.Drawing.Color.White;
			this.DayNo27.Name = "DayNo27";
			this.DayNo27.Click += new System.EventHandler(this.DayNo_Click);
			// 
			// DayNo28
			// 
			resources.ApplyResources(this.DayNo28, "DayNo28");
			this.DayNo28.BackColor = System.Drawing.Color.White;
			this.DayNo28.Name = "DayNo28";
			this.DayNo28.Click += new System.EventHandler(this.DayNo_Click);
			// 
			// DayNo29
			// 
			resources.ApplyResources(this.DayNo29, "DayNo29");
			this.DayNo29.BackColor = System.Drawing.Color.White;
			this.DayNo29.Name = "DayNo29";
			this.DayNo29.Click += new System.EventHandler(this.DayNo_Click);
			// 
			// DayNo30
			// 
			resources.ApplyResources(this.DayNo30, "DayNo30");
			this.DayNo30.BackColor = System.Drawing.Color.White;
			this.DayNo30.Name = "DayNo30";
			this.DayNo30.Click += new System.EventHandler(this.DayNo_Click);
			// 
			// DayNo31
			// 
			resources.ApplyResources(this.DayNo31, "DayNo31");
			this.DayNo31.BackColor = System.Drawing.Color.White;
			this.DayNo31.Name = "DayNo31";
			this.DayNo31.Click += new System.EventHandler(this.DayNo_Click);
			// 
			// DayNo32
			// 
			resources.ApplyResources(this.DayNo32, "DayNo32");
			this.DayNo32.BackColor = System.Drawing.Color.White;
			this.DayNo32.Name = "DayNo32";
			this.DayNo32.Click += new System.EventHandler(this.DayNo_Click);
			// 
			// DayNo33
			// 
			resources.ApplyResources(this.DayNo33, "DayNo33");
			this.DayNo33.BackColor = System.Drawing.Color.White;
			this.DayNo33.Name = "DayNo33";
			this.DayNo33.Click += new System.EventHandler(this.DayNo_Click);
			// 
			// DayNo34
			// 
			resources.ApplyResources(this.DayNo34, "DayNo34");
			this.DayNo34.BackColor = System.Drawing.Color.White;
			this.DayNo34.Name = "DayNo34";
			this.DayNo34.Click += new System.EventHandler(this.DayNo_Click);
			// 
			// DayNo35
			// 
			resources.ApplyResources(this.DayNo35, "DayNo35");
			this.DayNo35.BackColor = System.Drawing.Color.White;
			this.DayNo35.Name = "DayNo35";
			this.DayNo35.Click += new System.EventHandler(this.DayNo_Click);
			// 
			// UmAlQuraControl
			// 
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.FooterPanel);
			this.Controls.Add(this.HeaderPanel);
			this.Name = "UmAlQuraControl";
			resources.ApplyResources(this, "$this");
			this.Load += new System.EventHandler(this.UmAlQuraCalendar_Load);
			this.HeaderPanel.ResumeLayout(false);
			this.TableLayoutPanel2.ResumeLayout(false);
			this.TableLayoutPanel2.PerformLayout();
			this.FooterPanel.ResumeLayout(false);
			this.FooterPanel.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		internal System.Windows.Forms.Panel HeaderPanel;
		internal System.Windows.Forms.FlowLayoutPanel FooterPanel;
		internal System.Windows.Forms.Label FooterLabel;
		internal System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		internal System.Windows.Forms.Label Daylabel1;
		internal System.Windows.Forms.Label Daylabel2;
		internal System.Windows.Forms.Label Daylabel3;
		internal System.Windows.Forms.Label Daylabel4;
		internal System.Windows.Forms.Label Daylabel5;
		internal System.Windows.Forms.Label Daylabel6;
		internal System.Windows.Forms.Label Daylabel7;
		internal System.Windows.Forms.Label DayNo1;
		internal System.Windows.Forms.Label DayNo2;
		internal System.Windows.Forms.Label DayNo3;
		internal System.Windows.Forms.Label DayNo4;
		internal System.Windows.Forms.Label DayNo5;
		internal System.Windows.Forms.Label DayNo6;
		internal System.Windows.Forms.Label DayNo7;
		internal System.Windows.Forms.Label DayNo8;
		internal System.Windows.Forms.Label DayNo9;
		internal System.Windows.Forms.Label DayNo10;
		internal System.Windows.Forms.Label DayNo11;
		internal System.Windows.Forms.Label DayNo12;
		internal System.Windows.Forms.Label DayNo13;
		internal System.Windows.Forms.Label DayNo14;
		internal System.Windows.Forms.Label DayNo15;
		internal System.Windows.Forms.Label DayNo16;
		internal System.Windows.Forms.Label DayNo17;
		internal System.Windows.Forms.Label DayNo18;
		internal System.Windows.Forms.Label DayNo19;
		internal System.Windows.Forms.Label DayNo20;
		internal System.Windows.Forms.Label DayNo21;
		internal System.Windows.Forms.Label DayNo22;
		internal System.Windows.Forms.Label DayNo23;
		internal System.Windows.Forms.Label DayNo24;
		internal System.Windows.Forms.Label DayNo25;
		internal System.Windows.Forms.Label DayNo26;
		internal System.Windows.Forms.Label DayNo27;
		internal System.Windows.Forms.Label DayNo28;
		internal System.Windows.Forms.Label DayNo29;
		internal System.Windows.Forms.Label DayNo30;
		internal System.Windows.Forms.Label DayNo31;
		internal System.Windows.Forms.Label DayNo32;
		internal System.Windows.Forms.Label DayNo33;
		internal System.Windows.Forms.Label DayNo34;
		internal System.Windows.Forms.Label DayNo35;

		internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel2;
		internal System.Windows.Forms.Button FrontButton;
		internal System.Windows.Forms.Button BackButton;
		internal System.Windows.Forms.Label HeaderLabel;
	}


}
