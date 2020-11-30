namespace Hordens
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.headerPanel = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonGroup = new System.Windows.Forms.ToolStrip();
            this.booking_Btn = new System.Windows.Forms.ToolStripButton();
            this.technician_Btn = new System.Windows.Forms.ToolStripButton();
            this.jobType_Btn = new System.Windows.Forms.ToolStripButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.clock_Lbl = new System.Windows.Forms.Label();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.headerPanel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.buttonGroup.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.headerPanel.Controls.Add(this.panel3);
            this.headerPanel.Controls.Add(this.panel2);
            this.headerPanel.Controls.Add(this.panel1);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Margin = new System.Windows.Forms.Padding(0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(1226, 50);
            this.headerPanel.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.buttonGroup);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(179, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(823, 50);
            this.panel3.TabIndex = 5;
            // 
            // buttonGroup
            // 
            this.buttonGroup.BackColor = System.Drawing.Color.Black;
            this.buttonGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonGroup.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGroup.GripMargin = new System.Windows.Forms.Padding(0);
            this.buttonGroup.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.buttonGroup.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.booking_Btn,
            this.technician_Btn,
            this.jobType_Btn});
            this.buttonGroup.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.buttonGroup.Location = new System.Drawing.Point(0, 0);
            this.buttonGroup.Name = "buttonGroup";
            this.buttonGroup.Padding = new System.Windows.Forms.Padding(0);
            this.buttonGroup.Size = new System.Drawing.Size(823, 50);
            this.buttonGroup.TabIndex = 1;
            this.buttonGroup.Text = "toolStrip1";
            // 
            // booking_Btn
            // 
            this.booking_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.booking_Btn.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.booking_Btn.ForeColor = System.Drawing.Color.White;
            this.booking_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.booking_Btn.Name = "booking_Btn";
            this.booking_Btn.Size = new System.Drawing.Size(92, 47);
            this.booking_Btn.Text = "Booking";
            this.booking_Btn.Click += new System.EventHandler(this.booking_Btn_Click);
            // 
            // technician_Btn
            // 
            this.technician_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.technician_Btn.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.technician_Btn.ForeColor = System.Drawing.Color.White;
            this.technician_Btn.Image = ((System.Drawing.Image)(resources.GetObject("technician_Btn.Image")));
            this.technician_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.technician_Btn.Name = "technician_Btn";
            this.technician_Btn.Size = new System.Drawing.Size(114, 47);
            this.technician_Btn.Text = "Technician";
            this.technician_Btn.ToolTipText = "Technician";
            this.technician_Btn.Visible = false;
            this.technician_Btn.Click += new System.EventHandler(this.technician_Btn_Click);
            // 
            // jobType_Btn
            // 
            this.jobType_Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.jobType_Btn.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jobType_Btn.ForeColor = System.Drawing.Color.White;
            this.jobType_Btn.Image = ((System.Drawing.Image)(resources.GetObject("jobType_Btn.Image")));
            this.jobType_Btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.jobType_Btn.Name = "jobType_Btn";
            this.jobType_Btn.Size = new System.Drawing.Size(98, 47);
            this.jobType_Btn.Text = "Job Type";
            this.jobType_Btn.Click += new System.EventHandler(this.jobType_Btn_Click);
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::Hordens.Properties.Resources.Logo;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(179, 50);
            this.panel2.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.clock_Lbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1002, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(224, 50);
            this.panel1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::Hordens.Properties.Resources.closebutton;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(184, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(34, 31);
            this.button1.TabIndex = 3;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.close_Btn_Click);
            // 
            // clock_Lbl
            // 
            this.clock_Lbl.Dock = System.Windows.Forms.DockStyle.Left;
            this.clock_Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clock_Lbl.ForeColor = System.Drawing.Color.White;
            this.clock_Lbl.Location = new System.Drawing.Point(0, 0);
            this.clock_Lbl.Name = "clock_Lbl";
            this.clock_Lbl.Size = new System.Drawing.Size(173, 50);
            this.clock_Lbl.TabIndex = 2;
            this.clock_Lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // contentPanel
            // 
            this.contentPanel.AutoScroll = true;
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.contentPanel.Location = new System.Drawing.Point(0, 45);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(1226, 729);
            this.contentPanel.TabIndex = 3;
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1226, 774);
            this.Controls.Add(this.headerPanel);
            this.Controls.Add(this.contentPanel);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hordens";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.mainForm_Closing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.headerPanel.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.buttonGroup.ResumeLayout(false);
            this.buttonGroup.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label clock_Lbl;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStrip buttonGroup;
        private System.Windows.Forms.ToolStripButton booking_Btn;
        private System.Windows.Forms.ToolStripButton technician_Btn;
        private System.Windows.Forms.ToolStripButton jobType_Btn;
    }
}