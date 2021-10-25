namespace RssReader
{
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.btRead = new System.Windows.Forms.Button();
            this.txtXML = new System.Windows.Forms.TextBox();
            // 
            // txtUrl
            // 
            this.txtUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUrl.Location = new System.Drawing.Point(8, 11);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(593, 23);
            this.txtUrl.TabIndex = 0;
            this.txtUrl.Text = "http://www.antoniopelleriti.it/rss";
            // 
            // btRead
            // 
            this.btRead.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btRead.Location = new System.Drawing.Point(607, 11);
            this.btRead.Name = "btRead";
            this.btRead.Size = new System.Drawing.Size(86, 23);
            this.btRead.TabIndex = 1;
            this.btRead.Text = "Leggi";
            this.btRead.UseVisualStyleBackColor = true;
            this.btRead.Click += new System.EventHandler(this.btRead_Click);
            // 
            // txtXML
            // 
            this.txtXML.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtXML.Location = new System.Drawing.Point(8, 40);
            this.txtXML.Multiline = true;
            this.txtXML.Name = "txtXML";
            this.txtXML.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtXML.Size = new System.Drawing.Size(685, 354);
            this.txtXML.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 409);
            this.Controls.Add(this.txtXML);
            this.Controls.Add(this.btRead);
            this.Controls.Add(this.txtUrl);
            this.Name = "Form1";
            this.Text = "RssReader";

        }

        #endregion

        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Button btRead;
        private System.Windows.Forms.TextBox txtXML;
    }
}

