namespace RevoGlmViewer
{
    partial class GlmViewerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GlmViewerForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkLock = new System.Windows.Forms.CheckBox();
            this.textAddr = new System.Windows.Forms.TextBox();
            this.groupGlm = new System.Windows.Forms.GroupBox();
            this.glmZ = new System.Windows.Forms.Label();
            this.glmY = new System.Windows.Forms.Label();
            this.glmX = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupGlm.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkLock);
            this.groupBox1.Controls.Add(this.textAddr);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(269, 49);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DsgVar_3 Address";
            // 
            // checkLock
            // 
            this.checkLock.AutoSize = true;
            this.checkLock.Location = new System.Drawing.Point(213, 22);
            this.checkLock.Name = "checkLock";
            this.checkLock.Size = new System.Drawing.Size(50, 17);
            this.checkLock.TabIndex = 1;
            this.checkLock.Text = "Lock";
            this.checkLock.UseVisualStyleBackColor = true;
            this.checkLock.CheckedChanged += new System.EventHandler(this.checkLock_CheckedChanged);
            // 
            // textAddr
            // 
            this.textAddr.Location = new System.Drawing.Point(7, 20);
            this.textAddr.Name = "textAddr";
            this.textAddr.Size = new System.Drawing.Size(200, 20);
            this.textAddr.TabIndex = 0;
            // 
            // groupGlm
            // 
            this.groupGlm.Controls.Add(this.glmZ);
            this.groupGlm.Controls.Add(this.glmY);
            this.groupGlm.Controls.Add(this.glmX);
            this.groupGlm.Controls.Add(this.label3);
            this.groupGlm.Controls.Add(this.label2);
            this.groupGlm.Controls.Add(this.label1);
            this.groupGlm.Enabled = false;
            this.groupGlm.Location = new System.Drawing.Point(13, 69);
            this.groupGlm.Name = "groupGlm";
            this.groupGlm.Size = new System.Drawing.Size(269, 80);
            this.groupGlm.TabIndex = 1;
            this.groupGlm.TabStop = false;
            this.groupGlm.Text = "GLM";
            // 
            // glmZ
            // 
            this.glmZ.AutoSize = true;
            this.glmZ.Location = new System.Drawing.Point(39, 57);
            this.glmZ.Name = "glmZ";
            this.glmZ.Size = new System.Drawing.Size(13, 13);
            this.glmZ.TabIndex = 5;
            this.glmZ.Text = "0";
            // 
            // glmY
            // 
            this.glmY.AutoSize = true;
            this.glmY.Location = new System.Drawing.Point(39, 38);
            this.glmY.Name = "glmY";
            this.glmY.Size = new System.Drawing.Size(13, 13);
            this.glmY.TabIndex = 4;
            this.glmY.Text = "0";
            // 
            // glmX
            // 
            this.glmX.AutoSize = true;
            this.glmX.Location = new System.Drawing.Point(39, 19);
            this.glmX.Name = "glmX";
            this.glmX.Size = new System.Drawing.Size(13, 13);
            this.glmX.TabIndex = 3;
            this.glmX.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 57);
            this.label3.Margin = new System.Windows.Forms.Padding(8, 3, 8, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Z:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 38);
            this.label2.Margin = new System.Windows.Forms.Padding(8, 3, 8, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Y:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 3, 8, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "X:";
            // 
            // GlmViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 161);
            this.Controls.Add(this.groupGlm);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "GlmViewerForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "RevoGlmViewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupGlm.ResumeLayout(false);
            this.groupGlm.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkLock;
        private System.Windows.Forms.TextBox textAddr;
        private System.Windows.Forms.GroupBox groupGlm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label glmZ;
        private System.Windows.Forms.Label glmY;
        private System.Windows.Forms.Label glmX;
    }
}

