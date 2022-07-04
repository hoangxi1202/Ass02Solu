namespace SalesWinApp
{
    partial class frmProductDetail
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
            this.lbProductID = new System.Windows.Forms.Label();
            this.lbCategoryID = new System.Windows.Forms.Label();
            this.lbProductName = new System.Windows.Forms.Label();
            this.lbWeight = new System.Windows.Forms.Label();
            this.lbUnitPrice = new System.Windows.Forms.Label();
            this.lbUnitInStock = new System.Windows.Forms.Label();
            this.txtProductID = new System.Windows.Forms.TextBox();
            this.txtCategoryID = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtUnitPrice = new System.Windows.Forms.MaskedTextBox();
            this.txtUnitInStock = new System.Windows.Forms.MaskedTextBox();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbProductID
            // 
            this.lbProductID.AutoSize = true;
            this.lbProductID.Location = new System.Drawing.Point(38, 35);
            this.lbProductID.Name = "lbProductID";
            this.lbProductID.Size = new System.Drawing.Size(79, 20);
            this.lbProductID.TabIndex = 0;
            this.lbProductID.Text = "Product ID";
            // 
            // lbCategoryID
            // 
            this.lbCategoryID.AutoSize = true;
            this.lbCategoryID.Location = new System.Drawing.Point(38, 70);
            this.lbCategoryID.Name = "lbCategoryID";
            this.lbCategoryID.Size = new System.Drawing.Size(83, 20);
            this.lbCategoryID.TabIndex = 1;
            this.lbCategoryID.Text = "Categoy ID";
            // 
            // lbProductName
            // 
            this.lbProductName.AutoSize = true;
            this.lbProductName.Location = new System.Drawing.Point(38, 107);
            this.lbProductName.Name = "lbProductName";
            this.lbProductName.Size = new System.Drawing.Size(104, 20);
            this.lbProductName.TabIndex = 2;
            this.lbProductName.Text = "Product Name";
            // 
            // lbWeight
            // 
            this.lbWeight.AutoSize = true;
            this.lbWeight.Location = new System.Drawing.Point(38, 145);
            this.lbWeight.Name = "lbWeight";
            this.lbWeight.Size = new System.Drawing.Size(56, 20);
            this.lbWeight.TabIndex = 3;
            this.lbWeight.Text = "Weight";
            // 
            // lbUnitPrice
            // 
            this.lbUnitPrice.AutoSize = true;
            this.lbUnitPrice.Location = new System.Drawing.Point(38, 188);
            this.lbUnitPrice.Name = "lbUnitPrice";
            this.lbUnitPrice.Size = new System.Drawing.Size(72, 20);
            this.lbUnitPrice.TabIndex = 4;
            this.lbUnitPrice.Text = "Unit Price";
            // 
            // lbUnitInStock
            // 
            this.lbUnitInStock.AutoSize = true;
            this.lbUnitInStock.Location = new System.Drawing.Point(38, 227);
            this.lbUnitInStock.Name = "lbUnitInStock";
            this.lbUnitInStock.Size = new System.Drawing.Size(92, 20);
            this.lbUnitInStock.TabIndex = 5;
            this.lbUnitInStock.Text = "Unit In Stock";
            // 
            // txtProductID
            // 
            this.txtProductID.Location = new System.Drawing.Point(150, 32);
            this.txtProductID.Name = "txtProductID";
            this.txtProductID.Size = new System.Drawing.Size(230, 27);
            this.txtProductID.TabIndex = 6;
            // 
            // txtCategoryID
            // 
            this.txtCategoryID.Location = new System.Drawing.Point(150, 70);
            this.txtCategoryID.Name = "txtCategoryID";
            this.txtCategoryID.Size = new System.Drawing.Size(230, 27);
            this.txtCategoryID.TabIndex = 7;
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(150, 107);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(230, 27);
            this.txtProductName.TabIndex = 8;
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(69, 293);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(113, 51);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(232, 293);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(113, 51);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtUnitPrice
            // 
            this.txtUnitPrice.Location = new System.Drawing.Point(151, 188);
            this.txtUnitPrice.Mask = "000000000";
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.Size = new System.Drawing.Size(229, 27);
            this.txtUnitPrice.TabIndex = 15;
            this.txtUnitPrice.Text = "0";
            // 
            // txtUnitInStock
            // 
            this.txtUnitInStock.Location = new System.Drawing.Point(151, 227);
            this.txtUnitInStock.Mask = "00000";
            this.txtUnitInStock.Name = "txtUnitInStock";
            this.txtUnitInStock.Size = new System.Drawing.Size(229, 27);
            this.txtUnitInStock.TabIndex = 16;
            this.txtUnitInStock.Text = "0";
            // 
            // txtWeight
            // 
            this.txtWeight.Location = new System.Drawing.Point(150, 145);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(230, 27);
            this.txtWeight.TabIndex = 17;
            // 
            // frmProductDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 390);
            this.Controls.Add(this.txtWeight);
            this.Controls.Add(this.txtUnitInStock);
            this.Controls.Add(this.txtUnitPrice);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.txtCategoryID);
            this.Controls.Add(this.txtProductID);
            this.Controls.Add(this.lbUnitInStock);
            this.Controls.Add(this.lbUnitPrice);
            this.Controls.Add(this.lbWeight);
            this.Controls.Add(this.lbProductName);
            this.Controls.Add(this.lbCategoryID);
            this.Controls.Add(this.lbProductID);
            this.Name = "frmProductDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Detail";
            this.Load += new System.EventHandler(this.frmProductDetail_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lbProductID;
        private Label lbCategoryID;
        private Label lbProductName;
        private Label lbWeight;
        private Label lbUnitPrice;
        private Label lbUnitInStock;
        private TextBox txtProductID;
        private TextBox txtCategoryID;
        private TextBox txtProductName;
        private Button btnSave;
        private Button btnCancel;
        private MaskedTextBox txtUnitPrice;
        private MaskedTextBox txtUnitInStock;
        private TextBox txtWeight;
    }
}