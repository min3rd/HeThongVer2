namespace HT4
{
    partial class ImportDataFromExelToNganh
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
            this.listSV = new System.Windows.Forms.ListView();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listSV
            // 
            this.listSV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listSV.Location = new System.Drawing.Point(-3, 0);
            this.listSV.MultiSelect = false;
            this.listSV.Name = "listSV";
            this.listSV.Size = new System.Drawing.Size(589, 523);
            this.listSV.TabIndex = 0;
            this.listSV.UseCompatibleStateImageBehavior = false;
            this.listSV.View = System.Windows.Forms.View.Details;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(100)))));
            this.btnThem.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnThem.Location = new System.Drawing.Point(497, 526);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 1;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnHuy.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnHuy.Location = new System.Drawing.Point(416, 525);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 23);
            this.btnHuy.TabIndex = 2;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // ImportDataFromExelToNganh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.listSV);
            this.Name = "ImportDataFromExelToNganh";
            this.Text = "Xem dữ liệu";
            this.Load += new System.EventHandler(this.ImportDataFromExel_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listSV;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnHuy;
    }
}