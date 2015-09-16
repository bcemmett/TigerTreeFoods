using System.Windows.Forms;

namespace PosTerminal
{
    partial class PosSession
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
            this.tableLayoutPanelShoppingItems = new System.Windows.Forms.TableLayoutPanel();
            this.buttonPayNow = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelTotalLabel = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // richTextBoxLastScanned
            // 
            this.richTextBoxLastScanned.Enabled = false;
            this.richTextBoxLastScanned.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxLastScanned.ForeColor = System.Drawing.Color.Teal;
            this.richTextBoxLastScanned.Location = new System.Drawing.Point(386, 13);
            this.richTextBoxLastScanned.Name = "richTextBoxLastScanned";
            this.richTextBoxLastScanned.Size = new System.Drawing.Size(325, 156);
            this.richTextBoxLastScanned.TabIndex = 1;
            this.richTextBoxLastScanned.Text = "";
            // 
            // tableLayoutPanelShoppingItems
            // 
            this.tableLayoutPanelShoppingItems.AutoScroll = true;
            this.tableLayoutPanelShoppingItems.AutoScrollMargin = new System.Drawing.Size(10, 0);
            this.tableLayoutPanelShoppingItems.AutoSize = true;
            this.tableLayoutPanelShoppingItems.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanelShoppingItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tableLayoutPanelShoppingItems.ColumnCount = 2;
            this.tableLayoutPanelShoppingItems.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableLayoutPanelShoppingItems.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.tableLayoutPanelShoppingItems.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanelShoppingItems.MaximumSize = new System.Drawing.Size(369, 324);
            this.tableLayoutPanelShoppingItems.Name = "tableLayoutPanelShoppingItems";
            this.tableLayoutPanelShoppingItems.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.tableLayoutPanelShoppingItems.RowCount = 1;
            this.tableLayoutPanelShoppingItems.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 320F));
            this.tableLayoutPanelShoppingItems.Size = new System.Drawing.Size(369, 324);
            this.tableLayoutPanelShoppingItems.TabIndex = 2;
            // 
            // buttonPayNow
            // 
            this.buttonPayNow.Font = new System.Drawing.Font("Forte", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPayNow.ForeColor = System.Drawing.Color.DarkGreen;
            this.buttonPayNow.Location = new System.Drawing.Point(550, 175);
            this.buttonPayNow.Name = "buttonPayNow";
            this.buttonPayNow.Size = new System.Drawing.Size(162, 161);
            this.buttonPayNow.TabIndex = 3;
            this.buttonPayNow.Text = "Pay Now";
            this.buttonPayNow.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Forte", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.ForeColor = System.Drawing.Color.Firebrick;
            this.buttonCancel.Location = new System.Drawing.Point(387, 275);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(157, 61);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
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
            this.labelTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotal.ForeColor = System.Drawing.Color.Teal;
            this.labelTotal.Location = new System.Drawing.Point(388, 213);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(0, 31);
            this.labelTotal.TabIndex = 6;
            // 
            // PosSession
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 348);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.labelTotalLabel);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonPayNow);
            this.Controls.Add(this.tableLayoutPanelShoppingItems);
            this.Controls.Add(this.richTextBoxLastScanned);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "PosSession";
            this.Text = "Welcome to Tiger Tree Foods!";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PosSession_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxLastScanned;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelShoppingItems;
        private System.Windows.Forms.Button buttonPayNow;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelTotalLabel;
        private System.Windows.Forms.Label labelTotal;

    }
}

