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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PosSession));
            this.richTextBoxLastScanned = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanelShoppingItems = new System.Windows.Forms.TableLayoutPanel();
            this.labelTotal = new System.Windows.Forms.Label();
            this.pictureBoxLoadingSpinny = new System.Windows.Forms.PictureBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonPayNow = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoadingSpinny)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBoxLastScanned
            // 
            this.richTextBoxLastScanned.Enabled = false;
            this.richTextBoxLastScanned.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxLastScanned.ForeColor = System.Drawing.Color.Teal;
            this.richTextBoxLastScanned.Location = new System.Drawing.Point(398, 13);
            this.richTextBoxLastScanned.Name = "richTextBoxLastScanned";
            this.richTextBoxLastScanned.Size = new System.Drawing.Size(343, 123);
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
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotal.ForeColor = System.Drawing.Color.Teal;
            this.labelTotal.Location = new System.Drawing.Point(12, 356);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(82, 31);
            this.labelTotal.TabIndex = 6;
            this.labelTotal.Text = "£0.00";
            // 
            // pictureBoxLoadingSpinny
            // 
            this.pictureBoxLoadingSpinny.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBoxLoadingSpinny.Image = global::PosTerminal.Properties.Resources.ajax_loader;
            this.pictureBoxLoadingSpinny.Location = new System.Drawing.Point(662, 18);
            this.pictureBoxLoadingSpinny.Name = "pictureBoxLoadingSpinny";
            this.pictureBoxLoadingSpinny.Size = new System.Drawing.Size(73, 71);
            this.pictureBoxLoadingSpinny.TabIndex = 10;
            this.pictureBoxLoadingSpinny.TabStop = false;
            this.pictureBoxLoadingSpinny.Visible = false;
            // 
            // button3
            // 
            this.button3.BackgroundImage = global::PosTerminal.Properties.Resources.blue;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Font = new System.Drawing.Font("MV Boli", 14F, System.Drawing.FontStyle.Bold);
            this.button3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button3.Image = global::PosTerminal.Properties.Resources.question;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button3.Location = new System.Drawing.Point(641, 149);
            this.button3.Name = "button3";
            this.button3.Padding = new System.Windows.Forms.Padding(0, 10, 0, 5);
            this.button3.Size = new System.Drawing.Size(100, 100);
            this.button3.TabIndex = 9;
            this.button3.Text = "Help";
            this.button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::PosTerminal.Properties.Resources.blue;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Font = new System.Drawing.Font("MV Boli", 14F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button2.Image = global::PosTerminal.Properties.Resources.loyalty;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button2.Location = new System.Drawing.Point(520, 149);
            this.button2.Name = "button2";
            this.button2.Padding = new System.Windows.Forms.Padding(0, 10, 0, 5);
            this.button2.Size = new System.Drawing.Size(100, 100);
            this.button2.TabIndex = 8;
            this.button2.Text = "Loyalty";
            this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::PosTerminal.Properties.Resources.blue;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Font = new System.Drawing.Font("MV Boli", 14F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button1.Image = global::PosTerminal.Properties.Resources.keypad;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.Location = new System.Drawing.Point(399, 149);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 5);
            this.button1.Size = new System.Drawing.Size(100, 100);
            this.button1.TabIndex = 7;
            this.button1.Text = "Keypad";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackgroundImage = global::PosTerminal.Properties.Resources.red;
            this.buttonCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonCancel.Font = new System.Drawing.Font("MV Boli", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.buttonCancel.Location = new System.Drawing.Point(224, 342);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(157, 50);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonPayNow
            // 
            this.buttonPayNow.BackColor = System.Drawing.Color.Green;
            this.buttonPayNow.BackgroundImage = global::PosTerminal.Properties.Resources.green;
            this.buttonPayNow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonPayNow.Font = new System.Drawing.Font("MV Boli", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPayNow.ForeColor = System.Drawing.Color.Snow;
            this.buttonPayNow.Image = global::PosTerminal.Properties.Resources.money;
            this.buttonPayNow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPayNow.Location = new System.Drawing.Point(399, 266);
            this.buttonPayNow.Name = "buttonPayNow";
            this.buttonPayNow.Padding = new System.Windows.Forms.Padding(30, 0, 20, 0);
            this.buttonPayNow.Size = new System.Drawing.Size(342, 126);
            this.buttonPayNow.TabIndex = 3;
            this.buttonPayNow.Text = "Pay Now";
            this.buttonPayNow.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonPayNow.UseVisualStyleBackColor = false;
            // 
            // PosSession
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 408);
            this.Controls.Add(this.pictureBoxLoadingSpinny);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonPayNow);
            this.Controls.Add(this.tableLayoutPanelShoppingItems);
            this.Controls.Add(this.richTextBoxLastScanned);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "PosSession";
            this.Text = "Welcome to Tiger Tree Foods!";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PosSession_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoadingSpinny)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxLastScanned;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelShoppingItems;
        private System.Windows.Forms.Button buttonPayNow;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelTotal;
        private Button button1;
        private Button button2;
        private Button button3;
        private PictureBox pictureBoxLoadingSpinny;

    }
}

