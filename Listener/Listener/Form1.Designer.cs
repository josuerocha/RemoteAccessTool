namespace Listener
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.shiftButton = new System.Windows.Forms.Button();
            this.controlButton = new System.Windows.Forms.Button();
            this.rightMouse = new System.Windows.Forms.Button();
            this.leftMouse = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.clear2 = new System.Windows.Forms.Button();
            this.clear1 = new System.Windows.Forms.Button();
            this.middleMouse = new System.Windows.Forms.Button();
            this.volUp = new System.Windows.Forms.Button();
            this.volDown = new System.Windows.Forms.Button();
            this.volMute = new System.Windows.Forms.Button();
            this.desktopBox = new System.Windows.Forms.PictureBox();
            this.enterText = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.desktopBox)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.MenuText;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.Lime;
            this.textBox1.Location = new System.Drawing.Point(91, 2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(653, 266);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // textBox2
            // 
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox2.Location = new System.Drawing.Point(0, 573);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(1124, 20);
            this.textBox2.TabIndex = 2;
            this.textBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Textbox2_KeyDown);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 548);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1124, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(86, 22);
            this.toolStripLabel1.Text = "toolStripLabel1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Message";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(0, 61);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Beep";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(0, 90);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "Eject CD";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(0, 119);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 10;
            this.button7.Text = "Close CD";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(0, 148);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 11;
            this.button8.Text = "Blue Screen";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(0, 177);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 12;
            this.button9.Text = "Shell";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(0, 206);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 23);
            this.button10.TabIndex = 13;
            this.button10.Text = "Capture Desktop";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(0, 234);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 14;
            this.button6.Text = "Help";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.InfoText;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.ForeColor = System.Drawing.Color.Lime;
            this.textBox3.Location = new System.Drawing.Point(750, 2);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox3.Size = new System.Drawing.Size(378, 266);
            this.textBox3.TabIndex = 15;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // shiftButton
            // 
            this.shiftButton.Location = new System.Drawing.Point(978, 274);
            this.shiftButton.Name = "shiftButton";
            this.shiftButton.Size = new System.Drawing.Size(55, 23);
            this.shiftButton.TabIndex = 16;
            this.shiftButton.Text = "Shift";
            this.shiftButton.UseVisualStyleBackColor = true;
            // 
            // controlButton
            // 
            this.controlButton.Location = new System.Drawing.Point(978, 303);
            this.controlButton.Name = "controlButton";
            this.controlButton.Size = new System.Drawing.Size(55, 23);
            this.controlButton.TabIndex = 17;
            this.controlButton.Text = "Control";
            this.controlButton.UseVisualStyleBackColor = true;
            // 
            // rightMouse
            // 
            this.rightMouse.Location = new System.Drawing.Point(1089, 290);
            this.rightMouse.Name = "rightMouse";
            this.rightMouse.Size = new System.Drawing.Size(20, 22);
            this.rightMouse.TabIndex = 18;
            this.rightMouse.Text = "Right Mouse";
            this.rightMouse.UseVisualStyleBackColor = true;
            // 
            // leftMouse
            // 
            this.leftMouse.Location = new System.Drawing.Point(1039, 290);
            this.leftMouse.Name = "leftMouse";
            this.leftMouse.Size = new System.Drawing.Size(25, 22);
            this.leftMouse.TabIndex = 19;
            this.leftMouse.Text = "Left Mouse";
            this.leftMouse.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(1039, 274);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 110);
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // clear2
            // 
            this.clear2.ForeColor = System.Drawing.Color.Red;
            this.clear2.Location = new System.Drawing.Point(750, 245);
            this.clear2.Name = "clear2";
            this.clear2.Size = new System.Drawing.Size(55, 23);
            this.clear2.TabIndex = 21;
            this.clear2.Text = "Clear";
            this.clear2.UseVisualStyleBackColor = true;
            this.clear2.Click += new System.EventHandler(this.clear2_Click);
            // 
            // clear1
            // 
            this.clear1.BackColor = System.Drawing.Color.White;
            this.clear1.ForeColor = System.Drawing.Color.Red;
            this.clear1.Location = new System.Drawing.Point(91, 245);
            this.clear1.Name = "clear1";
            this.clear1.Size = new System.Drawing.Size(55, 23);
            this.clear1.TabIndex = 22;
            this.clear1.Text = "Clear";
            this.clear1.UseVisualStyleBackColor = false;
            this.clear1.Click += new System.EventHandler(this.clear1_Click);
            // 
            // middleMouse
            // 
            this.middleMouse.Location = new System.Drawing.Point(1067, 299);
            this.middleMouse.Name = "middleMouse";
            this.middleMouse.Size = new System.Drawing.Size(16, 10);
            this.middleMouse.TabIndex = 23;
            this.middleMouse.Text = "Left Mouse";
            this.middleMouse.UseVisualStyleBackColor = true;
            // 
            // volUp
            // 
            this.volUp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("volUp.BackgroundImage")));
            this.volUp.Location = new System.Drawing.Point(43, 272);
            this.volUp.Name = "volUp";
            this.volUp.Size = new System.Drawing.Size(40, 40);
            this.volUp.TabIndex = 24;
            this.volUp.UseVisualStyleBackColor = true;
            this.volUp.Click += new System.EventHandler(this.volUp_Click);
            // 
            // volDown
            // 
            this.volDown.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("volDown.BackgroundImage")));
            this.volDown.Location = new System.Drawing.Point(-1, 273);
            this.volDown.Name = "volDown";
            this.volDown.Size = new System.Drawing.Size(38, 36);
            this.volDown.TabIndex = 25;
            this.volDown.UseVisualStyleBackColor = true;
            this.volDown.Click += new System.EventHandler(this.volDown_Click);
            // 
            // volMute
            // 
            this.volMute.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("volMute.BackgroundImage")));
            this.volMute.Image = ((System.Drawing.Image)(resources.GetObject("volMute.Image")));
            this.volMute.Location = new System.Drawing.Point(24, 318);
            this.volMute.Name = "volMute";
            this.volMute.Size = new System.Drawing.Size(35, 37);
            this.volMute.TabIndex = 26;
            this.volMute.UseVisualStyleBackColor = true;
            this.volMute.Click += new System.EventHandler(this.volMute_Click);
            // 
            // desktopBox
            // 
            this.desktopBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.desktopBox.Location = new System.Drawing.Point(91, 274);
            this.desktopBox.Name = "desktopBox";
            this.desktopBox.Size = new System.Drawing.Size(792, 271);
            this.desktopBox.TabIndex = 27;
            this.desktopBox.TabStop = false;
            // 
            // enterText
            // 
            this.enterText.Location = new System.Drawing.Point(0, 32);
            this.enterText.Name = "enterText";
            this.enterText.Size = new System.Drawing.Size(75, 23);
            this.enterText.TabIndex = 0;
            this.enterText.Text = "Enter Text";
            this.enterText.UseVisualStyleBackColor = true;
            this.enterText.Click += new System.EventHandler(this.enterText_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1124, 593);
            this.Controls.Add(this.enterText);
            this.Controls.Add(this.desktopBox);
            this.Controls.Add(this.volMute);
            this.Controls.Add(this.volDown);
            this.Controls.Add(this.volUp);
            this.Controls.Add(this.middleMouse);
            this.Controls.Add(this.clear1);
            this.Controls.Add(this.clear2);
            this.Controls.Add(this.leftMouse);
            this.Controls.Add(this.rightMouse);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.controlButton);
            this.Controls.Add(this.shiftButton);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "DataEater RAT";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.desktopBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button shiftButton;
        private System.Windows.Forms.Button controlButton;
        private System.Windows.Forms.Button rightMouse;
        private System.Windows.Forms.Button leftMouse;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button clear2;
        private System.Windows.Forms.Button clear1;
        private System.Windows.Forms.Button middleMouse;
        private System.Windows.Forms.Button volUp;
        private System.Windows.Forms.Button volDown;
        private System.Windows.Forms.Button volMute;
        private System.Windows.Forms.PictureBox desktopBox;
        private System.Windows.Forms.Button enterText;
    }
}

