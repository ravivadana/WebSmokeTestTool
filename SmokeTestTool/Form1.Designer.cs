namespace SmokeTestTool
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
            this.txtSourceUrl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDestUrl = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.Result1 = new System.Windows.Forms.TreeView();
            this.Result2 = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // txtSourceUrl
            // 
            this.txtSourceUrl.Location = new System.Drawing.Point(115, 23);
            this.txtSourceUrl.Name = "txtSourceUrl";
            this.txtSourceUrl.Size = new System.Drawing.Size(341, 20);
            this.txtSourceUrl.TabIndex = 0;
            this.txtSourceUrl.Text = "http://localhost:22507/";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sorce URL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(694, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Destination URL";
            // 
            // txtDestUrl
            // 
            this.txtDestUrl.Location = new System.Drawing.Point(785, 28);
            this.txtDestUrl.Name = "txtDestUrl";
            this.txtDestUrl.Size = new System.Drawing.Size(341, 20);
            this.txtDestUrl.TabIndex = 2;
            this.txtDestUrl.Text = "http://localhost:22507/";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(1155, 27);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 6;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // Result1
            // 
            this.Result1.Location = new System.Drawing.Point(52, 74);
            this.Result1.Name = "Result1";
            this.Result1.Size = new System.Drawing.Size(509, 411);
            this.Result1.TabIndex = 7;
            // 
            // Result2
            // 
            this.Result2.Location = new System.Drawing.Point(617, 74);
            this.Result2.Name = "Result2";
            this.Result2.Size = new System.Drawing.Size(509, 411);
            this.Result2.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 605);
            this.Controls.Add(this.Result2);
            this.Controls.Add(this.Result1);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDestUrl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSourceUrl);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSourceUrl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDestUrl;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TreeView Result1;
        private System.Windows.Forms.TreeView Result2;
    }
}

