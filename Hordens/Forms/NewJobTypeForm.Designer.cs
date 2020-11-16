namespace Hordens
{
    partial class NewJobTypeForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cancel_Btn = new System.Windows.Forms.Button();
            this.save_Btn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.name_Txt = new System.Windows.Forms.TextBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.background_Lbl = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 675);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1394, 93);
            this.panel1.TabIndex = 23;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cancel_Btn);
            this.panel2.Controls.Add(this.save_Btn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1076, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(318, 93);
            this.panel2.TabIndex = 16;
            // 
            // cancel_Btn
            // 
            this.cancel_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancel_Btn.Location = new System.Drawing.Point(136, 7);
            this.cancel_Btn.Name = "cancel_Btn";
            this.cancel_Btn.Size = new System.Drawing.Size(104, 34);
            this.cancel_Btn.TabIndex = 24;
            this.cancel_Btn.Text = "Cancel";
            this.cancel_Btn.UseVisualStyleBackColor = true;
            this.cancel_Btn.Click += new System.EventHandler(this.cancel_Btn_Click);
            // 
            // save_Btn
            // 
            this.save_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save_Btn.Location = new System.Drawing.Point(13, 7);
            this.save_Btn.Name = "save_Btn";
            this.save_Btn.Size = new System.Drawing.Size(104, 34);
            this.save_Btn.TabIndex = 25;
            this.save_Btn.Text = "Save";
            this.save_Btn.UseVisualStyleBackColor = true;
            this.save_Btn.Click += new System.EventHandler(this.save_Btn_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1394, 49);
            this.label2.TabIndex = 22;
            this.label2.Text = "New Job Type";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 16);
            this.label1.TabIndex = 18;
            this.label1.Text = "Background";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 16);
            this.label3.TabIndex = 19;
            this.label3.Text = "Job Type Name:";
            // 
            // name_Txt
            // 
            this.name_Txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name_Txt.Location = new System.Drawing.Point(126, 91);
            this.name_Txt.Name = "name_Txt";
            this.name_Txt.Size = new System.Drawing.Size(174, 22);
            this.name_Txt.TabIndex = 1;
            // 
            // background_Lbl
            // 
            this.background_Lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.background_Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.background_Lbl.Location = new System.Drawing.Point(126, 131);
            this.background_Lbl.Name = "background_Lbl";
            this.background_Lbl.Size = new System.Drawing.Size(174, 23);
            this.background_Lbl.TabIndex = 24;
            this.background_Lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.background_Lbl.Click += new System.EventHandler(this.background_Lbl_Click);
            // 
            // NewJobTypeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1394, 768);
            this.Controls.Add(this.background_Lbl);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.name_Txt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NewJobTypeForm";
            this.Text = "NewJobType";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox name_Txt;
        private System.Windows.Forms.Button cancel_Btn;
        private System.Windows.Forms.Button save_Btn;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label background_Lbl;
    }
}