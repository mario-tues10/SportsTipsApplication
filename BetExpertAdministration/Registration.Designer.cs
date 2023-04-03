namespace BetExpertAdministration
{
    partial class Registration
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.username = new System.Windows.Forms.TextBox();
            this.email = new System.Windows.Forms.TextBox();
            this.register = new System.Windows.Forms.Button();
            this.registeredAlready = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sylfaen", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(275, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "Register";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Sylfaen", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(180, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Username: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Sylfaen", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(180, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 29);
            this.label3.TabIndex = 2;
            this.label3.Text = "E-mail: ";
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(409, 146);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(175, 27);
            this.username.TabIndex = 3;
            // 
            // email
            // 
            this.email.Location = new System.Drawing.Point(409, 194);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(175, 27);
            this.email.TabIndex = 4;
            // 
            // register
            // 
            this.register.Location = new System.Drawing.Point(180, 295);
            this.register.Name = "register";
            this.register.Size = new System.Drawing.Size(404, 43);
            this.register.TabIndex = 5;
            this.register.Text = "Register";
            this.register.UseVisualStyleBackColor = true;
            this.register.Click += new System.EventHandler(this.register_Click);
            // 
            // registeredAlready
            // 
            this.registeredAlready.Location = new System.Drawing.Point(180, 360);
            this.registeredAlready.Name = "registeredAlready";
            this.registeredAlready.Size = new System.Drawing.Size(404, 43);
            this.registeredAlready.TabIndex = 6;
            this.registeredAlready.Text = "Have account? Login";
            this.registeredAlready.UseVisualStyleBackColor = true;
            this.registeredAlready.Click += new System.EventHandler(this.registeredAlready_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Sylfaen", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(180, 244);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 29);
            this.label4.TabIndex = 7;
            this.label4.Text = "Password: ";
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(409, 244);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(175, 27);
            this.password.TabIndex = 8;
            // 
            // Registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.password);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.registeredAlready);
            this.Controls.Add(this.register);
            this.Controls.Add(this.email);
            this.Controls.Add(this.username);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Registration";
            this.Text = "Registration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox username;
        private TextBox email;
        private Button register;
        private Button registeredAlready;
        private Label label4;
        private TextBox password;
    }
}