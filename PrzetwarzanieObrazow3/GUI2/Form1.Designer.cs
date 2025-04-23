namespace GUI2;

partial class Form1
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
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        button1 = new System.Windows.Forms.Button();
        button2 = new System.Windows.Forms.Button();
        pictureBoxOriginal = new System.Windows.Forms.PictureBox();
        pictureBoxResult1 = new System.Windows.Forms.PictureBox();
        pictureBoxResult2 = new System.Windows.Forms.PictureBox();
        pictureBoxResult3 = new System.Windows.Forms.PictureBox();
        pictureBoxResult4 = new System.Windows.Forms.PictureBox();
        ((System.ComponentModel.ISupportInitialize)pictureBoxOriginal).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pictureBoxResult1).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pictureBoxResult2).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pictureBoxResult3).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pictureBoxResult4).BeginInit();
        SuspendLayout();
        // 
        // button1
        // 
        button1.Location = new System.Drawing.Point(292, 644);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(132, 64);
        button1.TabIndex = 0;
        button1.Text = "Load Img";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // button2
        // 
        button2.Location = new System.Drawing.Point(500, 645);
        button2.Name = "button2";
        button2.Size = new System.Drawing.Size(126, 63);
        button2.TabIndex = 1;
        button2.Text = "Process";
        button2.UseVisualStyleBackColor = true;
        button2.Click += button2_Click;
        // 
        // pictureBoxOriginal
        // 
        pictureBoxOriginal.Location = new System.Drawing.Point(24, 125);
        pictureBoxOriginal.Name = "pictureBoxOriginal";
        pictureBoxOriginal.Size = new System.Drawing.Size(400, 400);
        pictureBoxOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        pictureBoxOriginal.TabIndex = 2;
        pictureBoxOriginal.TabStop = false;
        // 
        // pictureBoxResult1
        // 
        pictureBoxResult1.Location = new System.Drawing.Point(500, 98);
        pictureBoxResult1.Name = "pictureBoxResult1";
        pictureBoxResult1.Size = new System.Drawing.Size(211, 225);
        pictureBoxResult1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
        pictureBoxResult1.TabIndex = 3;
        pictureBoxResult1.TabStop = false;
        // 
        // pictureBoxResult2
        // 
        pictureBoxResult2.Location = new System.Drawing.Point(730, 98);
        pictureBoxResult2.Name = "pictureBoxResult2";
        pictureBoxResult2.Size = new System.Drawing.Size(211, 225);
        pictureBoxResult2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
        pictureBoxResult2.TabIndex = 4;
        pictureBoxResult2.TabStop = false;
        // 
        // pictureBoxResult3
        // 
        pictureBoxResult3.Location = new System.Drawing.Point(500, 342);
        pictureBoxResult3.Name = "pictureBoxResult3";
        pictureBoxResult3.Size = new System.Drawing.Size(211, 225);
        pictureBoxResult3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
        pictureBoxResult3.TabIndex = 5;
        pictureBoxResult3.TabStop = false;
        // 
        // pictureBoxResult4
        // 
        pictureBoxResult4.Location = new System.Drawing.Point(730, 342);
        pictureBoxResult4.Name = "pictureBoxResult4";
        pictureBoxResult4.Size = new System.Drawing.Size(214, 225);
        pictureBoxResult4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
        pictureBoxResult4.TabIndex = 6;
        pictureBoxResult4.TabStop = false;
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(1184, 961);
        Controls.Add(pictureBoxResult4);
        Controls.Add(pictureBoxResult3);
        Controls.Add(pictureBoxResult2);
        Controls.Add(pictureBoxResult1);
        Controls.Add(pictureBoxOriginal);
        Controls.Add(button2);
        Controls.Add(button1);
        Text = "Form1";
        ((System.ComponentModel.ISupportInitialize)pictureBoxOriginal).EndInit();
        ((System.ComponentModel.ISupportInitialize)pictureBoxResult1).EndInit();
        ((System.ComponentModel.ISupportInitialize)pictureBoxResult2).EndInit();
        ((System.ComponentModel.ISupportInitialize)pictureBoxResult3).EndInit();
        ((System.ComponentModel.ISupportInitialize)pictureBoxResult4).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.PictureBox pictureBoxOriginal;
    private System.Windows.Forms.PictureBox pictureBoxResult1;
    private System.Windows.Forms.PictureBox pictureBoxResult2;
    private System.Windows.Forms.PictureBox pictureBoxResult3;
    private System.Windows.Forms.PictureBox pictureBoxResult4;

    #endregion
}