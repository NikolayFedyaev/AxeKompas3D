using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using AxeKompas.Model;

namespace Axe3D
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.AxePartLengthTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.AxeWidthTextBox = new System.Windows.Forms.TextBox();
            this.AxePartSecondWidthTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.AxePartFirstWidthTextBox = new System.Windows.Forms.TextBox();
            this.AxePartHeightTextBox = new System.Windows.Forms.TextBox();
            this.AxeHeightTextBox = new System.Windows.Forms.TextBox();
            this.AxeLengthTextBox = new System.Windows.Forms.TextBox();
            this.AxeLengthLabel = new System.Windows.Forms.Label();
            this.ParametersLabel = new System.Windows.Forms.Label();
            this.MaximumButton = new System.Windows.Forms.Button();
            this.AverageButton = new System.Windows.Forms.Button();
            this.MinimumButton = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.BuildButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label14.Location = new System.Drawing.Point(12, 435);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(92, 13);
            this.label14.TabIndex = 37;
            this.label14.Text = "Min - 19, Max - 25";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label13.Location = new System.Drawing.Point(12, 374);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(92, 13);
            this.label13.TabIndex = 36;
            this.label13.Text = "Min - 22, Max - 28";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 396);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Thickness";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label12.Location = new System.Drawing.Point(12, 313);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(104, 13);
            this.label12.TabIndex = 35;
            this.label12.Text = "Min - 135, Max - 165";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 335);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Rounding";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 274);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "Axe Width";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label11.Location = new System.Drawing.Point(12, 252);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(104, 13);
            this.label11.TabIndex = 34;
            this.label11.Text = "Min - 135, Max - 165";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label10.Location = new System.Drawing.Point(12, 191);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(104, 13);
            this.label10.TabIndex = 33;
            this.label10.Text = "Min - 170, Max - 215";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label9.Location = new System.Drawing.Point(12, 127);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 13);
            this.label9.TabIndex = 32;
            this.label9.Text = "Min - 48, Max - 68";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label8.Location = new System.Drawing.Point(12, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 13);
            this.label8.TabIndex = 31;
            this.label8.Text = "Min - 135, Max - 165";
            // 
            // AxePartLengthTextBox
            // 
            this.AxePartLengthTextBox.Location = new System.Drawing.Point(15, 104);
            this.AxePartLengthTextBox.Name = "AxePartLengthTextBox";
            this.AxePartLengthTextBox.Size = new System.Drawing.Size(258, 20);
            this.AxePartLengthTextBox.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Axe Part Height";
            // 
            // AxeWidthTextBox
            // 
            this.AxeWidthTextBox.Location = new System.Drawing.Point(16, 290);
            this.AxeWidthTextBox.Name = "AxeWidthTextBox";
            this.AxeWidthTextBox.Size = new System.Drawing.Size(258, 20);
            this.AxeWidthTextBox.TabIndex = 29;
            // 
            // AxePartSecondWidthTextBox
            // 
            this.AxePartSecondWidthTextBox.Location = new System.Drawing.Point(15, 412);
            this.AxePartSecondWidthTextBox.Name = "AxePartSecondWidthTextBox";
            this.AxePartSecondWidthTextBox.Size = new System.Drawing.Size(258, 20);
            this.AxePartSecondWidthTextBox.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Axe Height";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Axe Part Length";
            // 
            // AxePartFirstWidthTextBox
            // 
            this.AxePartFirstWidthTextBox.Location = new System.Drawing.Point(15, 351);
            this.AxePartFirstWidthTextBox.Name = "AxePartFirstWidthTextBox";
            this.AxePartFirstWidthTextBox.Size = new System.Drawing.Size(258, 20);
            this.AxePartFirstWidthTextBox.TabIndex = 25;
            // 
            // AxePartHeightTextBox
            // 
            this.AxePartHeightTextBox.Location = new System.Drawing.Point(15, 229);
            this.AxePartHeightTextBox.Name = "AxePartHeightTextBox";
            this.AxePartHeightTextBox.Size = new System.Drawing.Size(258, 20);
            this.AxePartHeightTextBox.TabIndex = 22;
            // 
            // AxeHeightTextBox
            // 
            this.AxeHeightTextBox.Location = new System.Drawing.Point(15, 168);
            this.AxeHeightTextBox.Name = "AxeHeightTextBox";
            this.AxeHeightTextBox.Size = new System.Drawing.Size(255, 20);
            this.AxeHeightTextBox.TabIndex = 20;
            // 
            // AxeLengthTextBox
            // 
            this.AxeLengthTextBox.BackColor = System.Drawing.Color.White;
            this.AxeLengthTextBox.Location = new System.Drawing.Point(15, 41);
            this.AxeLengthTextBox.Name = "AxeLengthTextBox";
            this.AxeLengthTextBox.Size = new System.Drawing.Size(258, 20);
            this.AxeLengthTextBox.TabIndex = 18;
            // 
            // AxeLengthLabel
            // 
            this.AxeLengthLabel.AutoSize = true;
            this.AxeLengthLabel.Location = new System.Drawing.Point(12, 25);
            this.AxeLengthLabel.Name = "AxeLengthLabel";
            this.AxeLengthLabel.Size = new System.Drawing.Size(61, 13);
            this.AxeLengthLabel.TabIndex = 17;
            this.AxeLengthLabel.Text = "Axe Length";
            // 
            // ParametersLabel
            // 
            this.ParametersLabel.AutoSize = true;
            this.ParametersLabel.Location = new System.Drawing.Point(13, 0);
            this.ParametersLabel.Name = "ParametersLabel";
            this.ParametersLabel.Size = new System.Drawing.Size(60, 13);
            this.ParametersLabel.TabIndex = 16;
            this.ParametersLabel.Text = "Parameters";
            // 
            // MaximumButton
            // 
            this.MaximumButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.MaximumButton.Location = new System.Drawing.Point(171, 473);
            this.MaximumButton.Name = "MaximumButton";
            this.MaximumButton.Size = new System.Drawing.Size(75, 23);
            this.MaximumButton.TabIndex = 40;
            this.MaximumButton.Text = "Maximum";
            this.MaximumButton.UseVisualStyleBackColor = true;
            this.MaximumButton.Click += new System.EventHandler(this.MaximumButton_Click);
            // 
            // AverageButton
            // 
            this.AverageButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.AverageButton.Location = new System.Drawing.Point(90, 473);
            this.AverageButton.Name = "AverageButton";
            this.AverageButton.Size = new System.Drawing.Size(75, 23);
            this.AverageButton.TabIndex = 39;
            this.AverageButton.Text = "Average";
            this.AverageButton.UseVisualStyleBackColor = true;
            this.AverageButton.Click += new System.EventHandler(this.AverageButton_Click);
            // 
            // MinimumButton
            // 
            this.MinimumButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.MinimumButton.Location = new System.Drawing.Point(9, 473);
            this.MinimumButton.Name = "MinimumButton";
            this.MinimumButton.Size = new System.Drawing.Size(75, 23);
            this.MinimumButton.TabIndex = 38;
            this.MinimumButton.Text = "Minimum";
            this.MinimumButton.UseVisualStyleBackColor = true;
            this.MinimumButton.Click += new System.EventHandler(this.MinimumButton_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // BuildButton
            // 
            this.BuildButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BuildButton.Location = new System.Drawing.Point(303, 473);
            this.BuildButton.Name = "BuildButton";
            this.BuildButton.Size = new System.Drawing.Size(75, 23);
            this.BuildButton.TabIndex = 41;
            this.BuildButton.Text = "Build";
            this.BuildButton.UseVisualStyleBackColor = true;
            this.BuildButton.Click += new System.EventHandler(this.BuildButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(406, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(409, 455);
            this.pictureBox1.TabIndex = 42;
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 508);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.BuildButton);
            this.Controls.Add(this.MaximumButton);
            this.Controls.Add(this.AverageButton);
            this.Controls.Add(this.MinimumButton);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.AxePartLengthTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.AxeWidthTextBox);
            this.Controls.Add(this.AxePartSecondWidthTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.AxePartFirstWidthTextBox);
            this.Controls.Add(this.AxePartHeightTextBox);
            this.Controls.Add(this.AxeHeightTextBox);
            this.Controls.Add(this.AxeLengthTextBox);
            this.Controls.Add(this.AxeLengthLabel);
            this.Controls.Add(this.ParametersLabel);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label14;
        private Label label13;
        private Label label5;
        private Label label12;
        private Label label2;
        private Label label7;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private TextBox AxePartLengthTextBox;
        private Label label4;
        private TextBox AxeWidthTextBox;
        private TextBox AxePartSecondWidthTextBox;
        private Label label3;
        private Label label6;
        private TextBox AxePartFirstWidthTextBox;
        private TextBox AxePartHeightTextBox;
        private TextBox AxeHeightTextBox;
        private TextBox AxeLengthTextBox;
        private Label AxeLengthLabel;
        private Label ParametersLabel;
        private Button MaximumButton;
        private Button AverageButton;
        private Button MinimumButton;
        private ErrorProvider errorProvider;
        private Button BuildButton;
        private PictureBox pictureBox1;
    }
}

