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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Player1Picture = new System.Windows.Forms.PictureBox();
            this.Player2Picture = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Player1Picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Player2Picture)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Enabled = false;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(872, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(380, 669);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Player1Picture
            // 
            this.Player1Picture.BackColor = System.Drawing.Color.Transparent;
            this.Player1Picture.Image = ((System.Drawing.Image)(resources.GetObject("Player1Picture.Image")));
            this.Player1Picture.InitialImage = ((System.Drawing.Image)(resources.GetObject("Player1Picture.InitialImage")));
            this.Player1Picture.Location = new System.Drawing.Point(21, 23);
            this.Player1Picture.Name = "Player1Picture";
            this.Player1Picture.Size = new System.Drawing.Size(126, 168);
            this.Player1Picture.TabIndex = 4;
            this.Player1Picture.TabStop = false;
            // 
            // Player2Picture
            // 
            this.Player2Picture.BackColor = System.Drawing.Color.Transparent;
            this.Player2Picture.Image = ((System.Drawing.Image)(resources.GetObject("Player2Picture.Image")));
            this.Player2Picture.InitialImage = ((System.Drawing.Image)(resources.GetObject("Player2Picture.InitialImage")));
            this.Player2Picture.Location = new System.Drawing.Point(740, 23);
            this.Player2Picture.Name = "Player2Picture";
            this.Player2Picture.Size = new System.Drawing.Size(126, 168);
            this.Player2Picture.TabIndex = 5;
            this.Player2Picture.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(872, 687);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 761);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Player2Picture);
            this.Controls.Add(this.Player1Picture);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Game";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.Player1Picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Player2Picture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.PictureBox Player1Picture;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox Player2Picture;
        private System.Windows.Forms.Button button1;
    }
}

