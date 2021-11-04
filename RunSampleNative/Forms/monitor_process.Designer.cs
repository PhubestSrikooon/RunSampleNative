
namespace RunSampleNative.Forms
{
    partial class monitor_process
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
            this.descriptstion = new System.Windows.Forms.Label();
            this.save = new System.Windows.Forms.Button();
            this.add_process = new System.Windows.Forms.Button();
            this.all_process = new System.Windows.Forms.Panel();
            this.refresh = new System.Windows.Forms.Button();
            this.search = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // descriptstion
            // 
            this.descriptstion.AutoSize = true;
            this.descriptstion.Location = new System.Drawing.Point(12, 9);
            this.descriptstion.Name = "descriptstion";
            this.descriptstion.Size = new System.Drawing.Size(229, 13);
            this.descriptstion.TabIndex = 0;
            this.descriptstion.Text = "This will monitor selected process cpu and ram.";
            // 
            // save
            // 
            this.save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.save.Location = new System.Drawing.Point(455, 247);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 33);
            this.save.TabIndex = 2;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // add_process
            // 
            this.add_process.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.add_process.Location = new System.Drawing.Point(374, 247);
            this.add_process.Name = "add_process";
            this.add_process.Size = new System.Drawing.Size(75, 33);
            this.add_process.TabIndex = 3;
            this.add_process.Text = "Add";
            this.add_process.UseVisualStyleBackColor = true;
            // 
            // all_process
            // 
            this.all_process.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.all_process.AutoScroll = true;
            this.all_process.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.all_process.Location = new System.Drawing.Point(15, 25);
            this.all_process.Name = "all_process";
            this.all_process.Size = new System.Drawing.Size(515, 216);
            this.all_process.TabIndex = 4;
            // 
            // refresh
            // 
            this.refresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.refresh.Location = new System.Drawing.Point(15, 247);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(75, 33);
            this.refresh.TabIndex = 5;
            this.refresh.Text = "Refresh";
            this.refresh.UseVisualStyleBackColor = true;
            // 
            // search
            // 
            this.search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.search.Location = new System.Drawing.Point(96, 247);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(75, 33);
            this.search.TabIndex = 6;
            this.search.Text = "Search";
            this.search.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(177, 254);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(191, 20);
            this.textBox1.TabIndex = 7;
            // 
            // monitor_process
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 285);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.search);
            this.Controls.Add(this.refresh);
            this.Controls.Add(this.all_process);
            this.Controls.Add(this.add_process);
            this.Controls.Add(this.save);
            this.Controls.Add(this.descriptstion);
            this.Name = "monitor_process";
            this.Text = "Monitor Process";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label descriptstion;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button add_process;
        private System.Windows.Forms.Panel all_process;
        private System.Windows.Forms.Button refresh;
        private System.Windows.Forms.Button search;
        private System.Windows.Forms.TextBox textBox1;
    }
}