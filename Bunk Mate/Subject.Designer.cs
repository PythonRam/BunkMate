namespace Bunk_Mate
{
    partial class Subject
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Subject));
            this.lblSubjectTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotalClasses = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblAttended = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.lblBunked = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblPercentage = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblS2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblS1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblAss = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblSubjectTitle
            // 
            this.lblSubjectTitle.AutoSize = true;
            this.lblSubjectTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubjectTitle.Location = new System.Drawing.Point(45, 9);
            this.lblSubjectTitle.Name = "lblSubjectTitle";
            this.lblSubjectTitle.Size = new System.Drawing.Size(41, 13);
            this.lblSubjectTitle.TabIndex = 0;
            this.lblSubjectTitle.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Total:";
            // 
            // lblTotalClasses
            // 
            this.lblTotalClasses.AutoSize = true;
            this.lblTotalClasses.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalClasses.Location = new System.Drawing.Point(63, 35);
            this.lblTotalClasses.Margin = new System.Windows.Forms.Padding(0);
            this.lblTotalClasses.Name = "lblTotalClasses";
            this.lblTotalClasses.Size = new System.Drawing.Size(41, 13);
            this.lblTotalClasses.TabIndex = 2;
            this.lblTotalClasses.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(136, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Attended:";
            // 
            // lblAttended
            // 
            this.lblAttended.AutoSize = true;
            this.lblAttended.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttended.Location = new System.Drawing.Point(192, 35);
            this.lblAttended.Margin = new System.Windows.Forms.Padding(0);
            this.lblAttended.Name = "lblAttended";
            this.lblAttended.Size = new System.Drawing.Size(41, 13);
            this.lblAttended.TabIndex = 4;
            this.lblAttended.Text = "label4";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(17, 159);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 20);
            this.button1.TabIndex = 5;
            this.button1.Text = "Atttedance";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(120, 159);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 20);
            this.button2.TabIndex = 6;
            this.button2.Text = "Internals";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(213, 160);
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(184, 20);
            this.txtComment.TabIndex = 7;
            // 
            // lblBunked
            // 
            this.lblBunked.AutoSize = true;
            this.lblBunked.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBunked.Location = new System.Drawing.Point(304, 35);
            this.lblBunked.Margin = new System.Windows.Forms.Padding(0);
            this.lblBunked.Name = "lblBunked";
            this.lblBunked.Size = new System.Drawing.Size(41, 13);
            this.lblBunked.TabIndex = 9;
            this.lblBunked.Text = "label5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(254, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Bunked:";
            // 
            // lblPercentage
            // 
            this.lblPercentage.AutoSize = true;
            this.lblPercentage.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPercentage.Location = new System.Drawing.Point(262, 112);
            this.lblPercentage.Name = "lblPercentage";
            this.lblPercentage.Size = new System.Drawing.Size(70, 25);
            this.lblPercentage.TabIndex = 11;
            this.lblPercentage.Text = "label4";
            this.lblPercentage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(290, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 25);
            this.label2.TabIndex = 12;
            this.label2.Text = "%";
            // 
            // lblS2
            // 
            this.lblS2.AutoSize = true;
            this.lblS2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblS2.Location = new System.Drawing.Point(192, 81);
            this.lblS2.Margin = new System.Windows.Forms.Padding(0);
            this.lblS2.Name = "lblS2";
            this.lblS2.Size = new System.Drawing.Size(41, 13);
            this.lblS2.TabIndex = 16;
            this.lblS2.Text = "label4";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(136, 81);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "S-II:";
            // 
            // lblS1
            // 
            this.lblS1.AutoSize = true;
            this.lblS1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblS1.Location = new System.Drawing.Point(63, 81);
            this.lblS1.Margin = new System.Windows.Forms.Padding(0);
            this.lblS1.Name = "lblS1";
            this.lblS1.Size = new System.Drawing.Size(41, 13);
            this.lblS1.TabIndex = 14;
            this.lblS1.Text = "label2";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(23, 81);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(23, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "S-I:";
            // 
            // lblAss
            // 
            this.lblAss.AutoSize = true;
            this.lblAss.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAss.Location = new System.Drawing.Point(118, 112);
            this.lblAss.Name = "lblAss";
            this.lblAss.Size = new System.Drawing.Size(41, 13);
            this.lblAss.TabIndex = 20;
            this.lblAss.Text = "label5";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Assignments:";
            // 
            // Subject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(409, 192);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblAss);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblS2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblS1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblPercentage);
            this.Controls.Add(this.lblBunked);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblAttended);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTotalClasses);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblSubjectTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Subject";
            this.Text = "Subject";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSubjectTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotalClasses;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblAttended;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Label lblBunked;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblPercentage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblS2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblS1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblAss;
        private System.Windows.Forms.Label label5;
    }
}