﻿
namespace Procesamiento_de_Imagenes
{
    partial class Form2
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jpgToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jPEGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bMPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filtersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bWToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blackWhiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.coolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.greyScaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.higlightsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.negativeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sepiaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.warmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gaussianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noiseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.despeckleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.button5 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.filtersToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1094, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newProjectToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveAllToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.fileToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newProjectToolStripMenuItem
            // 
            this.newProjectToolStripMenuItem.Name = "newProjectToolStripMenuItem";
            this.newProjectToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.newProjectToolStripMenuItem.Text = "New Project";
            this.newProjectToolStripMenuItem.Click += new System.EventHandler(this.newProjectToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveAllToolStripMenuItem
            // 
            this.saveAllToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jpgToolStripMenuItem,
            this.jPEGToolStripMenuItem,
            this.pngToolStripMenuItem,
            this.bMPToolStripMenuItem});
            this.saveAllToolStripMenuItem.Name = "saveAllToolStripMenuItem";
            this.saveAllToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.saveAllToolStripMenuItem.Text = "Export as";
            // 
            // jpgToolStripMenuItem
            // 
            this.jpgToolStripMenuItem.Name = "jpgToolStripMenuItem";
            this.jpgToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.jpgToolStripMenuItem.Text = "JPG";
            this.jpgToolStripMenuItem.Click += new System.EventHandler(this.jpgToolStripMenuItem_Click);
            // 
            // jPEGToolStripMenuItem
            // 
            this.jPEGToolStripMenuItem.Name = "jPEGToolStripMenuItem";
            this.jPEGToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.jPEGToolStripMenuItem.Text = "JPEG";
            this.jPEGToolStripMenuItem.Click += new System.EventHandler(this.jPEGToolStripMenuItem_Click);
            // 
            // pngToolStripMenuItem
            // 
            this.pngToolStripMenuItem.Name = "pngToolStripMenuItem";
            this.pngToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.pngToolStripMenuItem.Text = "PNG";
            this.pngToolStripMenuItem.Click += new System.EventHandler(this.pngToolStripMenuItem_Click);
            // 
            // bMPToolStripMenuItem
            // 
            this.bMPToolStripMenuItem.Name = "bMPToolStripMenuItem";
            this.bMPToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.bMPToolStripMenuItem.Text = "BMP";
            this.bMPToolStripMenuItem.Click += new System.EventHandler(this.bMPToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // filtersToolStripMenuItem
            // 
            this.filtersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bWToolStripMenuItem,
            this.blurToolStripMenuItem,
            this.noiseToolStripMenuItem});
            this.filtersToolStripMenuItem.Name = "filtersToolStripMenuItem";
            this.filtersToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.filtersToolStripMenuItem.Text = "Filters";
            // 
            // bWToolStripMenuItem
            // 
            this.bWToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blackWhiteToolStripMenuItem,
            this.coolToolStripMenuItem,
            this.greyScaleToolStripMenuItem,
            this.higlightsToolStripMenuItem,
            this.negativeToolStripMenuItem,
            this.sepiaToolStripMenuItem,
            this.warmToolStripMenuItem});
            this.bWToolStripMenuItem.Name = "bWToolStripMenuItem";
            this.bWToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.bWToolStripMenuItem.Text = "Colors";
            // 
            // blackWhiteToolStripMenuItem
            // 
            this.blackWhiteToolStripMenuItem.Name = "blackWhiteToolStripMenuItem";
            this.blackWhiteToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.blackWhiteToolStripMenuItem.Text = "Black and White";
            // 
            // coolToolStripMenuItem
            // 
            this.coolToolStripMenuItem.Name = "coolToolStripMenuItem";
            this.coolToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.coolToolStripMenuItem.Text = "Cool";
            // 
            // greyScaleToolStripMenuItem
            // 
            this.greyScaleToolStripMenuItem.Name = "greyScaleToolStripMenuItem";
            this.greyScaleToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.greyScaleToolStripMenuItem.Text = "Grey Scale";
            // 
            // higlightsToolStripMenuItem
            // 
            this.higlightsToolStripMenuItem.Name = "higlightsToolStripMenuItem";
            this.higlightsToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.higlightsToolStripMenuItem.Text = "Higlights";
            // 
            // negativeToolStripMenuItem
            // 
            this.negativeToolStripMenuItem.Name = "negativeToolStripMenuItem";
            this.negativeToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.negativeToolStripMenuItem.Text = "Negative";
            // 
            // sepiaToolStripMenuItem
            // 
            this.sepiaToolStripMenuItem.Name = "sepiaToolStripMenuItem";
            this.sepiaToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.sepiaToolStripMenuItem.Text = "Sepia";
            // 
            // warmToolStripMenuItem
            // 
            this.warmToolStripMenuItem.Name = "warmToolStripMenuItem";
            this.warmToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.warmToolStripMenuItem.Text = "Warm";
            // 
            // blurToolStripMenuItem
            // 
            this.blurToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gaussianToolStripMenuItem});
            this.blurToolStripMenuItem.Name = "blurToolStripMenuItem";
            this.blurToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.blurToolStripMenuItem.Text = "Blur";
            // 
            // gaussianToolStripMenuItem
            // 
            this.gaussianToolStripMenuItem.Name = "gaussianToolStripMenuItem";
            this.gaussianToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.gaussianToolStripMenuItem.Text = "Gaussian";
            // 
            // noiseToolStripMenuItem
            // 
            this.noiseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.despeckleToolStripMenuItem});
            this.noiseToolStripMenuItem.Name = "noiseToolStripMenuItem";
            this.noiseToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.noiseToolStripMenuItem.Text = "Noise";
            // 
            // despeckleToolStripMenuItem
            // 
            this.despeckleToolStripMenuItem.Name = "despeckleToolStripMenuItem";
            this.despeckleToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.despeckleToolStripMenuItem.Text = "Despeckle";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(15)))), ((int)(((byte)(13)))));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button3.Location = new System.Drawing.Point(1005, 459);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(77, 27);
            this.button3.TabIndex = 12;
            this.button3.Text = "Save";
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(15)))), ((int)(((byte)(13)))));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(12, 459);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 27);
            this.button1.TabIndex = 13;
            this.button1.Text = "Upload";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(15)))), ((int)(((byte)(13)))));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(300, 459);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(77, 27);
            this.button2.TabIndex = 14;
            this.button2.Text = "Webcam";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(15)))), ((int)(((byte)(13)))));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(381, 459);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(77, 27);
            this.button4.TabIndex = 15;
            this.button4.Text = "Capture";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(95, 462);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(161, 20);
            this.textBox1.TabIndex = 16;
            this.textBox1.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::Procesamiento_de_Imagenes.Properties.Resources._8;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(552, 36);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(530, 415);
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Procesamiento_de_Imagenes.Properties.Resources._7;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(11, 36);
            this.pictureBox1.MaximumSize = new System.Drawing.Size(630, 616);
            this.pictureBox1.MinimumSize = new System.Drawing.Size(500, 400);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(530, 415);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "JPG (*.jpg)|*.jpg|JPEG (*.jpeg)|*.jpeg|PNG (*.png)|*.png|BMP (*.bmp)|*.bmp|All Fi" +
    "les(*.*)|*.*";
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(15)))), ((int)(((byte)(13)))));
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(464, 459);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(77, 27);
            this.button5.TabIndex = 17;
            this.button5.Text = "Stop";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Form2
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(15)))), ((int)(((byte)(13)))));
            this.ClientSize = new System.Drawing.Size(1094, 520);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1110, 536);
            this.Name = "Form2";
            this.Text = "Editor";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jpgToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filtersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bWToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blackWhiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem coolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem greyScaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem higlightsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem negativeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sepiaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem warmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blurToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gaussianToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noiseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem despeckleToolStripMenuItem;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripMenuItem bMPToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem jPEGToolStripMenuItem;
        private System.Windows.Forms.Button button5;
    }
}