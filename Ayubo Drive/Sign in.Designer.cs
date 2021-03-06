﻿namespace Ayubo_Drive
{
    partial class Form_sign_in
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
            this.label_welcome = new System.Windows.Forms.Label();
            this.label_username = new System.Windows.Forms.Label();
            this.label_password = new System.Windows.Forms.Label();
            this.button_sign_in = new System.Windows.Forms.Button();
            this.button_sign_up = new System.Windows.Forms.Button();
            this.label_new_user = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_welcome
            // 
            this.label_welcome.AutoSize = true;
            this.label_welcome.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label_welcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_welcome.Location = new System.Drawing.Point(184, 9);
            this.label_welcome.Name = "label_welcome";
            this.label_welcome.Size = new System.Drawing.Size(344, 33);
            this.label_welcome.TabIndex = 0;
            this.label_welcome.Text = "Welcome to Ayubo Drive!";
            this.label_welcome.Click += new System.EventHandler(this.label1_Click);
            // 
            // label_username
            // 
            this.label_username.AutoSize = true;
            this.label_username.Location = new System.Drawing.Point(6, 34);
            this.label_username.Name = "label_username";
            this.label_username.Size = new System.Drawing.Size(55, 13);
            this.label_username.TabIndex = 1;
            this.label_username.Text = "Username";
            this.label_username.Click += new System.EventHandler(this.label_username_Click);
            // 
            // label_password
            // 
            this.label_password.AutoSize = true;
            this.label_password.Location = new System.Drawing.Point(6, 73);
            this.label_password.Name = "label_password";
            this.label_password.Size = new System.Drawing.Size(53, 13);
            this.label_password.TabIndex = 2;
            this.label_password.Text = "Password";
            this.label_password.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // button_sign_in
            // 
            this.button_sign_in.Location = new System.Drawing.Point(119, 109);
            this.button_sign_in.Name = "button_sign_in";
            this.button_sign_in.Size = new System.Drawing.Size(75, 23);
            this.button_sign_in.TabIndex = 4;
            this.button_sign_in.Text = "Sign in";
            this.button_sign_in.UseVisualStyleBackColor = true;
            this.button_sign_in.Click += new System.EventHandler(this.button_sign_in_Click);
            // 
            // button_sign_up
            // 
            this.button_sign_up.Location = new System.Drawing.Point(119, 262);
            this.button_sign_up.Name = "button_sign_up";
            this.button_sign_up.Size = new System.Drawing.Size(75, 23);
            this.button_sign_up.TabIndex = 6;
            this.button_sign_up.Text = "Sign up";
            this.button_sign_up.UseVisualStyleBackColor = true;
            this.button_sign_up.Click += new System.EventHandler(this.button_sign_up_Click);
            // 
            // label_new_user
            // 
            this.label_new_user.AutoSize = true;
            this.label_new_user.Location = new System.Drawing.Point(6, 267);
            this.label_new_user.Name = "label_new_user";
            this.label_new_user.Size = new System.Drawing.Size(58, 13);
            this.label_new_user.TabIndex = 5;
            this.label_new_user.Text = "New user?";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(94, 73);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 3;
            this.textBox2.UseSystemPasswordChar = true;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label_username);
            this.groupBox1.Controls.Add(this.button_sign_up);
            this.groupBox1.Controls.Add(this.label_new_user);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.button_sign_in);
            this.groupBox1.Controls.Add(this.label_password);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox1.Location = new System.Drawing.Point(21, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(224, 302);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sign-in";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(62, 34);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // Form_sign_in
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Ayubo_Drive.Properties.Resources.xzbGk82;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(682, 387);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label_welcome);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Form_sign_in";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_welcome;
        private System.Windows.Forms.Label label_username;
        private System.Windows.Forms.Label label_password;
        private System.Windows.Forms.Button button_sign_in;
        private System.Windows.Forms.Button button_sign_up;
        private System.Windows.Forms.Label label_new_user;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
    }
}

