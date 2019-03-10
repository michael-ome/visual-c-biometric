namespace finalyearproject.cs
{
    partial class staffregistration
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
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtconfirmpassword = new System.Windows.Forms.TextBox();
            this.txtnewpassword = new System.Windows.Forms.TextBox();
            this.txtcurrentusername = new System.Windows.Forms.TextBox();
            this.txtstaffid = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtcurrentpassword = new System.Windows.Forms.TextBox();
            this.txtnewusername = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtnewstaffid = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(277, 359);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(55, 23);
            this.button2.TabIndex = 41;
            this.button2.Text = "back";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(177, 359);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 40;
            this.button1.Text = "Change";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtconfirmpassword
            // 
            this.txtconfirmpassword.Location = new System.Drawing.Point(137, 314);
            this.txtconfirmpassword.Name = "txtconfirmpassword";
            this.txtconfirmpassword.Size = new System.Drawing.Size(132, 20);
            this.txtconfirmpassword.TabIndex = 38;
            this.txtconfirmpassword.UseSystemPasswordChar = true;
            this.txtconfirmpassword.TextChanged += new System.EventHandler(this.txtconfirmpassword_TextChanged);
            // 
            // txtnewpassword
            // 
            this.txtnewpassword.Location = new System.Drawing.Point(137, 280);
            this.txtnewpassword.Name = "txtnewpassword";
            this.txtnewpassword.Size = new System.Drawing.Size(132, 20);
            this.txtnewpassword.TabIndex = 37;
            this.txtnewpassword.UseSystemPasswordChar = true;
            this.txtnewpassword.TextChanged += new System.EventHandler(this.txtnewpassword_TextChanged);
            // 
            // txtcurrentusername
            // 
            this.txtcurrentusername.Location = new System.Drawing.Point(137, 141);
            this.txtcurrentusername.Name = "txtcurrentusername";
            this.txtcurrentusername.Size = new System.Drawing.Size(132, 20);
            this.txtcurrentusername.TabIndex = 36;
            this.txtcurrentusername.TextChanged += new System.EventHandler(this.txtusername_TextChanged);
            // 
            // txtstaffid
            // 
            this.txtstaffid.Location = new System.Drawing.Point(137, 103);
            this.txtstaffid.Name = "txtstaffid";
            this.txtstaffid.Size = new System.Drawing.Size(132, 20);
            this.txtstaffid.TabIndex = 35;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 287);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "New Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 317);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Confirm Password";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Current Username";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Current Staff ID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 42;
            this.label5.Text = "Current Password";
            // 
            // txtcurrentpassword
            // 
            this.txtcurrentpassword.Location = new System.Drawing.Point(137, 173);
            this.txtcurrentpassword.Name = "txtcurrentpassword";
            this.txtcurrentpassword.Size = new System.Drawing.Size(132, 20);
            this.txtcurrentpassword.TabIndex = 43;
            this.txtcurrentpassword.UseSystemPasswordChar = true;
            this.txtcurrentpassword.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txtnewusername
            // 
            this.txtnewusername.Location = new System.Drawing.Point(137, 241);
            this.txtnewusername.Name = "txtnewusername";
            this.txtnewusername.Size = new System.Drawing.Size(132, 20);
            this.txtnewusername.TabIndex = 44;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 248);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 45;
            this.label6.Text = "New username";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // txtnewstaffid
            // 
            this.txtnewstaffid.Location = new System.Drawing.Point(137, 209);
            this.txtnewstaffid.Name = "txtnewstaffid";
            this.txtnewstaffid.Size = new System.Drawing.Size(132, 20);
            this.txtnewstaffid.TabIndex = 46;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 216);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 47;
            this.label7.Text = "New Staff ID";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::finalyearproject.cs.Properties.Resources.images;
            this.pictureBox1.Location = new System.Drawing.Point(21, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(336, 77);
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // staffregistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.ClientSize = new System.Drawing.Size(377, 402);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtnewstaffid);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtnewusername);
            this.Controls.Add(this.txtcurrentpassword);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtconfirmpassword);
            this.Controls.Add(this.txtnewpassword);
            this.Controls.Add(this.txtcurrentusername);
            this.Controls.Add(this.txtstaffid);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "staffregistration";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtconfirmpassword;
        private System.Windows.Forms.TextBox txtnewpassword;
        private System.Windows.Forms.TextBox txtcurrentusername;
        private System.Windows.Forms.TextBox txtstaffid;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtcurrentpassword;
        private System.Windows.Forms.TextBox txtnewusername;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox txtnewstaffid;
        private System.Windows.Forms.Label label7;
    }
}