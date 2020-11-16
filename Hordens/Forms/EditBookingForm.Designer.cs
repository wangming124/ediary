namespace Hordens
{
    partial class EditBookingForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.estimatedTime_Cmb = new System.Windows.Forms.ComboBox();
            this.jobType_Cmb = new System.Windows.Forms.ComboBox();
            this.insurance_Cmb = new System.Windows.Forms.ComboBox();
            this.bookedBy_Cmb = new System.Windows.Forms.ComboBox();
            this.timeOut_Dt = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.timeIn_Dt = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.loanCar_Cmb = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.notes_Txt = new System.Windows.Forms.TextBox();
            this.jobDescription_Txt = new System.Windows.Forms.TextBox();
            this.vehicleRegNo_Txt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.vehicleModel_Txt = new System.Windows.Forms.TextBox();
            this.vehicleMake_Txt = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.customer_Txt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.jobNO_Txt = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cancel_Btn = new System.Windows.Forms.Button();
            this.save_Btn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 49);
            this.label1.TabIndex = 2;
            this.label1.Text = "Edit Booking";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.cancel_Btn);
            this.panel1.Controls.Add(this.save_Btn);
            this.panel1.Controls.Add(this.estimatedTime_Cmb);
            this.panel1.Controls.Add(this.jobType_Cmb);
            this.panel1.Controls.Add(this.insurance_Cmb);
            this.panel1.Controls.Add(this.bookedBy_Cmb);
            this.panel1.Controls.Add(this.timeOut_Dt);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.timeIn_Dt);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.loanCar_Cmb);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.notes_Txt);
            this.panel1.Controls.Add(this.jobDescription_Txt);
            this.panel1.Controls.Add(this.vehicleRegNo_Txt);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.vehicleModel_Txt);
            this.panel1.Controls.Add(this.vehicleMake_Txt);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.customer_Txt);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.jobNO_Txt);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Location = new System.Drawing.Point(1, 48);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(870, 554);
            this.panel1.TabIndex = 6;
            // 
            // estimatedTime_Cmb
            // 
            this.estimatedTime_Cmb.FormattingEnabled = true;
            this.estimatedTime_Cmb.ItemHeight = 13;
            this.estimatedTime_Cmb.Location = new System.Drawing.Point(579, 168);
            this.estimatedTime_Cmb.Name = "estimatedTime_Cmb";
            this.estimatedTime_Cmb.Size = new System.Drawing.Size(174, 21);
            this.estimatedTime_Cmb.TabIndex = 17;
            // 
            // jobType_Cmb
            // 
            this.jobType_Cmb.FormattingEnabled = true;
            this.jobType_Cmb.Location = new System.Drawing.Point(184, 50);
            this.jobType_Cmb.Name = "jobType_Cmb";
            this.jobType_Cmb.Size = new System.Drawing.Size(174, 21);
            this.jobType_Cmb.TabIndex = 7;
            // 
            // insurance_Cmb
            // 
            this.insurance_Cmb.FormattingEnabled = true;
            this.insurance_Cmb.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.insurance_Cmb.Location = new System.Drawing.Point(579, 139);
            this.insurance_Cmb.Name = "insurance_Cmb";
            this.insurance_Cmb.Size = new System.Drawing.Size(121, 21);
            this.insurance_Cmb.TabIndex = 5;
            // 
            // bookedBy_Cmb
            // 
            this.bookedBy_Cmb.FormattingEnabled = true;
            this.bookedBy_Cmb.Location = new System.Drawing.Point(579, 107);
            this.bookedBy_Cmb.Name = "bookedBy_Cmb";
            this.bookedBy_Cmb.Size = new System.Drawing.Size(121, 21);
            this.bookedBy_Cmb.TabIndex = 4;
            // 
            // timeOut_Dt
            // 
            this.timeOut_Dt.Location = new System.Drawing.Point(579, 79);
            this.timeOut_Dt.Name = "timeOut_Dt";
            this.timeOut_Dt.Size = new System.Drawing.Size(200, 20);
            this.timeOut_Dt.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(500, 83);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 16);
            this.label9.TabIndex = 0;
            this.label9.Text = "Time Out:";
            // 
            // timeIn_Dt
            // 
            this.timeIn_Dt.Location = new System.Drawing.Point(579, 53);
            this.timeIn_Dt.Name = "timeIn_Dt";
            this.timeIn_Dt.Size = new System.Drawing.Size(200, 20);
            this.timeIn_Dt.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(510, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "Time In:";
            // 
            // loanCar_Cmb
            // 
            this.loanCar_Cmb.FormattingEnabled = true;
            this.loanCar_Cmb.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.loanCar_Cmb.Location = new System.Drawing.Point(580, 22);
            this.loanCar_Cmb.Name = "loanCar_Cmb";
            this.loanCar_Cmb.Size = new System.Drawing.Size(121, 21);
            this.loanCar_Cmb.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(125, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Job #:";
            // 
            // notes_Txt
            // 
            this.notes_Txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notes_Txt.Location = new System.Drawing.Point(37, 318);
            this.notes_Txt.Multiline = true;
            this.notes_Txt.Name = "notes_Txt";
            this.notes_Txt.Size = new System.Drawing.Size(813, 110);
            this.notes_Txt.TabIndex = 1;
            // 
            // jobDescription_Txt
            // 
            this.jobDescription_Txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jobDescription_Txt.Location = new System.Drawing.Point(184, 213);
            this.jobDescription_Txt.Name = "jobDescription_Txt";
            this.jobDescription_Txt.Size = new System.Drawing.Size(615, 22);
            this.jobDescription_Txt.TabIndex = 1;
            // 
            // vehicleRegNo_Txt
            // 
            this.vehicleRegNo_Txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vehicleRegNo_Txt.Location = new System.Drawing.Point(184, 165);
            this.vehicleRegNo_Txt.Name = "vehicleRegNo_Txt";
            this.vehicleRegNo_Txt.Size = new System.Drawing.Size(174, 22);
            this.vehicleRegNo_Txt.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(100, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Job Type:";
            // 
            // vehicleModel_Txt
            // 
            this.vehicleModel_Txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vehicleModel_Txt.Location = new System.Drawing.Point(184, 137);
            this.vehicleModel_Txt.Name = "vehicleModel_Txt";
            this.vehicleModel_Txt.Size = new System.Drawing.Size(174, 22);
            this.vehicleModel_Txt.TabIndex = 1;
            // 
            // vehicleMake_Txt
            // 
            this.vehicleMake_Txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vehicleMake_Txt.Location = new System.Drawing.Point(184, 107);
            this.vehicleMake_Txt.Name = "vehicleMake_Txt";
            this.vehicleMake_Txt.Size = new System.Drawing.Size(174, 22);
            this.vehicleMake_Txt.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(487, 109);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 16);
            this.label10.TabIndex = 0;
            this.label10.Text = "Booked By:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(438, 140);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(128, 16);
            this.label12.TabIndex = 0;
            this.label12.Text = "Insurance Required:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(460, 168);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(105, 16);
            this.label11.TabIndex = 0;
            this.label11.Text = "Estimated Time:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(100, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Customer:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(71, 140);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(97, 16);
            this.label15.TabIndex = 0;
            this.label15.Text = "Vehicle Model:";
            // 
            // customer_Txt
            // 
            this.customer_Txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customer_Txt.Location = new System.Drawing.Point(184, 78);
            this.customer_Txt.Name = "customer_Txt";
            this.customer_Txt.Size = new System.Drawing.Size(174, 22);
            this.customer_Txt.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(76, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Vehicle Make:";
            // 
            // jobNO_Txt
            // 
            this.jobNO_Txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jobNO_Txt.Location = new System.Drawing.Point(184, 21);
            this.jobNO_Txt.Name = "jobNO_Txt";
            this.jobNO_Txt.Size = new System.Drawing.Size(174, 22);
            this.jobNO_Txt.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(60, 282);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 16);
            this.label14.TabIndex = 0;
            this.label14.Text = "Notes";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(64, 216);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(105, 16);
            this.label13.TabIndex = 0;
            this.label13.Text = "Job Description:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(60, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "Vehicel Reg.NO:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(501, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 16);
            this.label8.TabIndex = 0;
            this.label8.Text = "Loan Car:";
            // 
            // cancel_Btn
            // 
            this.cancel_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancel_Btn.Location = new System.Drawing.Point(746, 490);
            this.cancel_Btn.Name = "cancel_Btn";
            this.cancel_Btn.Size = new System.Drawing.Size(104, 34);
            this.cancel_Btn.TabIndex = 20;
            this.cancel_Btn.Text = "Cancel";
            this.cancel_Btn.UseVisualStyleBackColor = true;
            this.cancel_Btn.Click += new System.EventHandler(this.cancel_Btn_Click);
            // 
            // save_Btn
            // 
            this.save_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save_Btn.Location = new System.Drawing.Point(623, 490);
            this.save_Btn.Name = "save_Btn";
            this.save_Btn.Size = new System.Drawing.Size(104, 34);
            this.save_Btn.TabIndex = 21;
            this.save_Btn.Text = "Save";
            this.save_Btn.UseVisualStyleBackColor = true;
            this.save_Btn.Click += new System.EventHandler(this.save_Btn_Click);
            // 
            // EditBookingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1331, 719);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "EditBookingForm";
            this.Text = "EditBookingForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox insurance_Cmb;
        private System.Windows.Forms.ComboBox bookedBy_Cmb;
        private System.Windows.Forms.DateTimePicker timeOut_Dt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker timeIn_Dt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox loanCar_Cmb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox notes_Txt;
        private System.Windows.Forms.TextBox jobDescription_Txt;
        private System.Windows.Forms.TextBox vehicleRegNo_Txt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox vehicleMake_Txt;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox customer_Txt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox jobNO_Txt;
        private System.Windows.Forms.TextBox vehicleModel_Txt;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox jobType_Cmb;
        private System.Windows.Forms.ComboBox estimatedTime_Cmb;
        private System.Windows.Forms.Button cancel_Btn;
        private System.Windows.Forms.Button save_Btn;
    }
}