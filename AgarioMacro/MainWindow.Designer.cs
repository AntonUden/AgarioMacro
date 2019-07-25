namespace AgarioMacro
{
    partial class MainWindow
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
			this.gbx_modules = new System.Windows.Forms.GroupBox();
			this.p_Modules = new System.Windows.Forms.FlowLayoutPanel();
			this.btn_enableAll = new System.Windows.Forms.Button();
			this.btn_disableAll = new System.Windows.Forms.Button();
			this.gbx_modules.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbx_modules
			// 
			this.gbx_modules.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbx_modules.Controls.Add(this.p_Modules);
			this.gbx_modules.Location = new System.Drawing.Point(12, 41);
			this.gbx_modules.Name = "gbx_modules";
			this.gbx_modules.Size = new System.Drawing.Size(776, 397);
			this.gbx_modules.TabIndex = 1;
			this.gbx_modules.TabStop = false;
			this.gbx_modules.Text = "Modules";
			// 
			// p_Modules
			// 
			this.p_Modules.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.p_Modules.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.p_Modules.Location = new System.Drawing.Point(6, 19);
			this.p_Modules.Name = "p_Modules";
			this.p_Modules.Size = new System.Drawing.Size(764, 372);
			this.p_Modules.TabIndex = 0;
			this.p_Modules.Resize += new System.EventHandler(this.P_Modules_Resize);
			// 
			// btn_enableAll
			// 
			this.btn_enableAll.Location = new System.Drawing.Point(12, 12);
			this.btn_enableAll.Name = "btn_enableAll";
			this.btn_enableAll.Size = new System.Drawing.Size(75, 23);
			this.btn_enableAll.TabIndex = 2;
			this.btn_enableAll.Text = "Enable all";
			this.btn_enableAll.UseVisualStyleBackColor = true;
			this.btn_enableAll.Click += new System.EventHandler(this.Btn_enableAll_Click);
			// 
			// btn_disableAll
			// 
			this.btn_disableAll.Location = new System.Drawing.Point(93, 12);
			this.btn_disableAll.Name = "btn_disableAll";
			this.btn_disableAll.Size = new System.Drawing.Size(75, 23);
			this.btn_disableAll.TabIndex = 3;
			this.btn_disableAll.Text = "Disable all";
			this.btn_disableAll.UseVisualStyleBackColor = true;
			this.btn_disableAll.Click += new System.EventHandler(this.Btn_disableAll_Click);
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.btn_disableAll);
			this.Controls.Add(this.btn_enableAll);
			this.Controls.Add(this.gbx_modules);
			this.Name = "MainWindow";
			this.Text = "Form1";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainWindow_FormClosed);
			this.Load += new System.EventHandler(this.MainWindow_Load);
			this.gbx_modules.ResumeLayout(false);
			this.ResumeLayout(false);

        }

		#endregion
		private System.Windows.Forms.GroupBox gbx_modules;
		private System.Windows.Forms.FlowLayoutPanel p_Modules;
		private System.Windows.Forms.Button btn_enableAll;
		private System.Windows.Forms.Button btn_disableAll;
	}
}

