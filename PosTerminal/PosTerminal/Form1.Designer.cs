namespace PosTerminal
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
            this.richTextBoxLastScanned = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonPayNow = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelTotalLabel = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // richTextBoxLastScanned
            // 
            this.richTextBoxLastScanned.Enabled = false;
            this.richTextBoxLastScanned.Location = new System.Drawing.Point(387, 13);
            this.richTextBoxLastScanned.Name = "richTextBoxLastScanned";
            this.richTextBoxLastScanned.Size = new System.Drawing.Size(325, 156);
            this.richTextBoxLastScanned.TabIndex = 1;
            this.richTextBoxLastScanned.Text = "";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(369, 324);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // buttonPayNow
            // 
            this.buttonPayNow.Location = new System.Drawing.Point(550, 175);
            this.buttonPayNow.Name = "buttonPayNow";
            this.buttonPayNow.Size = new System.Drawing.Size(162, 161);
            this.buttonPayNow.TabIndex = 3;
            this.buttonPayNow.Text = "Pay Now";
            this.buttonPayNow.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(387, 275);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(157, 61);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // labelTotalLabel
            // 
            this.labelTotalLabel.AutoSize = true;
            this.labelTotalLabel.Location = new System.Drawing.Point(388, 191);
            this.labelTotalLabel.Name = "labelTotalLabel";
            this.labelTotalLabel.Size = new System.Drawing.Size(34, 13);
            this.labelTotalLabel.TabIndex = 5;
            this.labelTotalLabel.Text = "Total:";
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Location = new System.Drawing.Point(388, 213);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(0, 13);
            this.labelTotal.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 348);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.labelTotalLabel);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonPayNow);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.richTextBoxLastScanned);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxLastScanned;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonPayNow;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelTotalLabel;
        private System.Windows.Forms.Label labelTotal;

    }
}

