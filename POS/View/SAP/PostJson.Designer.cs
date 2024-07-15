
namespace POS
{
    partial class PostJson
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PostJson));
            this.Lable1 = new System.Windows.Forms.Label();
            this.txtJson = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.lblAPIName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Lable1
            // 
            this.Lable1.AutoSize = true;
            this.Lable1.Location = new System.Drawing.Point(12, 29);
            this.Lable1.Name = "Lable1";
            this.Lable1.Size = new System.Drawing.Size(61, 13);
            this.Lable1.TabIndex = 23;
            this.Lable1.Text = "API Name: ";
            // 
            // txtJson
            // 
            this.txtJson.Location = new System.Drawing.Point(30, 57);
            this.txtJson.Multiline = true;
            this.txtJson.Name = "txtJson";
            this.txtJson.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtJson.Size = new System.Drawing.Size(429, 353);
            this.txtJson.TabIndex = 25;
            // 
            // btnSave
            // 
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Image = global::POS.Properties.Resources.save_big;
            this.btnSave.Location = new System.Drawing.Point(178, 425);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(113, 46);
            this.btnSave.TabIndex = 26;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "txt";
            this.saveFileDialog1.Filter = "\"txt files (*.txt)|*.txt|All files (*.*)|*.*\";  ";
            this.saveFileDialog1.InitialDirectory = " @\"C:\\\"";
            this.saveFileDialog1.RestoreDirectory = true;
            this.saveFileDialog1.Title = "Save Json To A Text File";
            // 
            // lblAPIName
            // 
            this.lblAPIName.AutoSize = true;
            this.lblAPIName.Location = new System.Drawing.Point(73, 29);
            this.lblAPIName.Name = "lblAPIName";
            this.lblAPIName.Size = new System.Drawing.Size(0, 13);
            this.lblAPIName.TabIndex = 27;
            // 
            // PostJson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(202)))), ((int)(((byte)(125)))));
            this.ClientSize = new System.Drawing.Size(483, 511);
            this.Controls.Add(this.lblAPIName);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtJson);
            this.Controls.Add(this.Lable1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PostJson";
            this.Text = "Post Json";
            this.Load += new System.EventHandler(this.PostJson_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lable1;
        private System.Windows.Forms.TextBox txtJson;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label lblAPIName;
    }
}