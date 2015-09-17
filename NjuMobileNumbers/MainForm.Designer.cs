namespace NjuMobileNumbers
{
	partial class MainForm
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
			this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
			this.buttonWebScrap = new System.Windows.Forms.Button();
			this.webBrowser = new System.Windows.Forms.WebBrowser();
			this.listBoxNumbers = new System.Windows.Forms.ListBox();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.ItemColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonWebScrap
			// 
			this.buttonWebScrap.Location = new System.Drawing.Point(626, 502);
			this.buttonWebScrap.Name = "buttonWebScrap";
			this.buttonWebScrap.Size = new System.Drawing.Size(200, 23);
			this.buttonWebScrap.TabIndex = 1;
			this.buttonWebScrap.Text = "WebScrap this!";
			this.buttonWebScrap.UseVisualStyleBackColor = true;
			this.buttonWebScrap.Click += new System.EventHandler(this.buttonWebScrap_Click);
			// 
			// webBrowser
			// 
			this.webBrowser.Location = new System.Drawing.Point(12, 12);
			this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
			this.webBrowser.Name = "webBrowser";
			this.webBrowser.Size = new System.Drawing.Size(628, 484);
			this.webBrowser.TabIndex = 0;
			this.webBrowser.Url = new System.Uri("http://www.njumobile.pl/zakup?propozycja=prepaid_high", System.UriKind.Absolute);
			// 
			// listBoxNumbers
			// 
			this.listBoxNumbers.FormattingEnabled = true;
			this.listBoxNumbers.Location = new System.Drawing.Point(646, 11);
			this.listBoxNumbers.Name = "listBoxNumbers";
			this.listBoxNumbers.Size = new System.Drawing.Size(180, 485);
			this.listBoxNumbers.TabIndex = 2;
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.AllowUserToResizeColumns = false;
			this.dataGridView1.AllowUserToResizeRows = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemColumn});
			this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.dataGridView1.Location = new System.Drawing.Point(832, 12);
			this.dataGridView1.MultiSelect = false;
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.Size = new System.Drawing.Size(230, 484);
			this.dataGridView1.TabIndex = 3;
			this.dataGridView1.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dataGridView1_CellValueNeeded);
			// 
			// ItemColumn
			// 
			this.ItemColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.ItemColumn.HeaderText = "ItemColumn";
			this.ItemColumn.Name = "ItemColumn";
			this.ItemColumn.ReadOnly = true;
			this.ItemColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.ItemColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1211, 534);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.webBrowser);
			this.Controls.Add(this.listBoxNumbers);
			this.Controls.Add(this.buttonWebScrap);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.Text = "MainForm";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.Load += new System.EventHandler(this.MainForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.ComponentModel.BackgroundWorker backgroundWorker;
		private System.Windows.Forms.Button buttonWebScrap;
		private System.Windows.Forms.WebBrowser webBrowser;
		private System.Windows.Forms.ListBox listBoxNumbers;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.DataGridViewTextBoxColumn ItemColumn;
	}
}

