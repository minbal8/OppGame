namespace GameClient
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Player1Picture = new System.Windows.Forms.PictureBox();
            this.Player2Picture = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chatTextField = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Player1Picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Player2Picture)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Player1Picture
            // 
            this.Player1Picture.BackColor = System.Drawing.Color.Transparent;
            this.Player1Picture.Image = ((System.Drawing.Image)(resources.GetObject("Player1Picture.Image")));
            this.Player1Picture.InitialImage = null;
            this.Player1Picture.Location = new System.Drawing.Point(29, 6);
            this.Player1Picture.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Player1Picture.Name = "Player1Picture";
            this.Player1Picture.Size = new System.Drawing.Size(100, 105);
            this.Player1Picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Player1Picture.TabIndex = 4;
            this.Player1Picture.TabStop = false;
            // 
            // Player2Picture
            // 
            this.Player2Picture.BackColor = System.Drawing.Color.Transparent;
            this.Player2Picture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Player2Picture.Image = ((System.Drawing.Image)(resources.GetObject("Player2Picture.Image")));
            this.Player2Picture.InitialImage = null;
            this.Player2Picture.Location = new System.Drawing.Point(1584, 6);
            this.Player2Picture.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Player2Picture.Name = "Player2Picture";
            this.Player2Picture.Size = new System.Drawing.Size(100, 105);
            this.Player2Picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Player2Picture.TabIndex = 5;
            this.Player2Picture.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1488, 794);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(181, 54);
            this.button1.TabIndex = 7;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 857);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 31);
            this.label1.TabIndex = 8;
            this.label1.Text = "Player1Health";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1473, 857);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 31);
            this.label2.TabIndex = 9;
            this.label2.Text = "Player2Health";
            // 
            // chatTextField
            // 
            this.chatTextField.Enabled = false;
            this.chatTextField.Location = new System.Drawing.Point(29, 914);
            this.chatTextField.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chatTextField.Name = "chatTextField";
            this.chatTextField.ReadOnly = true;
            this.chatTextField.Size = new System.Drawing.Size(1652, 94);
            this.chatTextField.TabIndex = 10;
            this.chatTextField.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1699, 1024);
            this.Controls.Add(this.chatTextField);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Player2Picture);
            this.Controls.Add(this.Player1Picture);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.Player1Picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Player2Picture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox Player1Picture;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox Player2Picture;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox chatTextField;
    }
}

