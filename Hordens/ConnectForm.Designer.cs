namespace Hordens
{
    partial class ConnectForm
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
            this.hostAddress_Txt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.user_Txt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.password_Txt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.port_Txt = new System.Windows.Forms.TextBox();
            this.connect_Bt = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.database_Txt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Host Address";
            // 
            // hostAddress_Txt
            // 
            this.hostAddress_Txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hostAddress_Txt.Location = new System.Drawing.Point(127, 18);
            this.hostAddress_Txt.Name = "hostAddress_Txt";
            this.hostAddress_Txt.Size = new System.Drawing.Size(164, 22);
            this.hostAddress_Txt.TabIndex = 1;
            this.hostAddress_Txt.Text = "192.168.100.34";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "User";
            // 
            // user_Txt
            // 
            this.user_Txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user_Txt.Location = new System.Drawing.Point(127, 64);
            this.user_Txt.Name = "user_Txt";
            this.user_Txt.Size = new System.Drawing.Size(164, 22);
            this.user_Txt.TabIndex = 2;
            this.user_Txt.Text = "sa";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(31, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Password";
            // 
            // password_Txt
            // 
            this.password_Txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password_Txt.Location = new System.Drawing.Point(127, 109);
            this.password_Txt.Name = "password_Txt";
            this.password_Txt.PasswordChar = '*';
            this.password_Txt.Size = new System.Drawing.Size(164, 22);
            this.password_Txt.TabIndex = 3;
            this.password_Txt.Text = "admin@123.com";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(31, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Port";
            // 
            // port_Txt
            // 
            this.port_Txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.port_Txt.Location = new System.Drawing.Point(127, 152);
            this.port_Txt.Name = "port_Txt";
            this.port_Txt.Size = new System.Drawing.Size(68, 22);
            this.port_Txt.TabIndex = 4;
            this.port_Txt.Text = "1433";
            // 
            // connect_Bt
            // 
            this.connect_Bt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connect_Bt.Location = new System.Drawing.Point(216, 245);
            this.connect_Bt.Name = "connect_Bt";
            this.connect_Bt.Size = new System.Drawing.Size(75, 23);
            this.connect_Bt.TabIndex = 2;
            this.connect_Bt.Text = "Connect";
            this.connect_Bt.UseVisualStyleBackColor = true;
            this.connect_Bt.Click += new System.EventHandler(this.connect_Bt_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(31, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Database";
            // 
            // database_Txt
            // 
            this.database_Txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.database_Txt.Location = new System.Drawing.Point(127, 190);
            this.database_Txt.Name = "database_Txt";
            this.database_Txt.Size = new System.Drawing.Size(164, 22);
            this.database_Txt.TabIndex = 3;
            this.database_Txt.Text = "Horderns";
            // 
            // ConnectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 303);
            this.Controls.Add(this.connect_Bt);
            this.Controls.Add(this.port_Txt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.database_Txt);
            this.Controls.Add(this.password_Txt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.user_Txt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.hostAddress_Txt);
            this.Controls.Add(this.label1);
            this.Name = "ConnectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connect to SQL Host";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox hostAddress_Txt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox user_Txt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox password_Txt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox port_Txt;
        private System.Windows.Forms.Button connect_Bt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox database_Txt;
    }
}

