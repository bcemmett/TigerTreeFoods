namespace PricingManager
{
    partial class MainForm
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
            this.tabControlPricing = new System.Windows.Forms.TabControl();
            this.tabPageCurrentPricing = new System.Windows.Forms.TabPage();
            this.labelFilter = new System.Windows.Forms.Label();
            this.textBoxFilter = new System.Windows.Forms.TextBox();
            this.buttonLoadCurrentPricingData = new System.Windows.Forms.Button();
            this.buttonCancelAllOffers = new System.Windows.Forms.Button();
            this.labelCurrentPricing = new System.Windows.Forms.Label();
            this.tableLayoutPanelCurrentPricing = new System.Windows.Forms.TableLayoutPanel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControlPricing.SuspendLayout();
            this.tabPageCurrentPricing.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlPricing
            // 
            this.tabControlPricing.Controls.Add(this.tabPageCurrentPricing);
            this.tabControlPricing.Controls.Add(this.tabPage2);
            this.tabControlPricing.Location = new System.Drawing.Point(12, 12);
            this.tabControlPricing.Name = "tabControlPricing";
            this.tabControlPricing.SelectedIndex = 0;
            this.tabControlPricing.Size = new System.Drawing.Size(781, 432);
            this.tabControlPricing.TabIndex = 0;
            // 
            // tabPageCurrentPricing
            // 
            this.tabPageCurrentPricing.Controls.Add(this.labelFilter);
            this.tabPageCurrentPricing.Controls.Add(this.textBoxFilter);
            this.tabPageCurrentPricing.Controls.Add(this.buttonLoadCurrentPricingData);
            this.tabPageCurrentPricing.Controls.Add(this.buttonCancelAllOffers);
            this.tabPageCurrentPricing.Controls.Add(this.labelCurrentPricing);
            this.tabPageCurrentPricing.Controls.Add(this.tableLayoutPanelCurrentPricing);
            this.tabPageCurrentPricing.Location = new System.Drawing.Point(4, 22);
            this.tabPageCurrentPricing.Name = "tabPageCurrentPricing";
            this.tabPageCurrentPricing.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCurrentPricing.Size = new System.Drawing.Size(773, 406);
            this.tabPageCurrentPricing.TabIndex = 0;
            this.tabPageCurrentPricing.Text = "Current Pricing";
            this.tabPageCurrentPricing.UseVisualStyleBackColor = true;
            // 
            // labelFilter
            // 
            this.labelFilter.AutoSize = true;
            this.labelFilter.Location = new System.Drawing.Point(231, 20);
            this.labelFilter.Name = "labelFilter";
            this.labelFilter.Size = new System.Drawing.Size(32, 13);
            this.labelFilter.TabIndex = 5;
            this.labelFilter.Text = "Filter:";
            // 
            // textBoxFilter
            // 
            this.textBoxFilter.Location = new System.Drawing.Point(269, 15);
            this.textBoxFilter.Multiline = true;
            this.textBoxFilter.Name = "textBoxFilter";
            this.textBoxFilter.Size = new System.Drawing.Size(222, 23);
            this.textBoxFilter.TabIndex = 4;
            this.textBoxFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxFilter_KeyPress);
            // 
            // buttonLoadCurrentPricingData
            // 
            this.buttonLoadCurrentPricingData.BackColor = System.Drawing.Color.Transparent;
            this.buttonLoadCurrentPricingData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLoadCurrentPricingData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLoadCurrentPricingData.ForeColor = System.Drawing.Color.LimeGreen;
            this.buttonLoadCurrentPricingData.Location = new System.Drawing.Point(497, 15);
            this.buttonLoadCurrentPricingData.Name = "buttonLoadCurrentPricingData";
            this.buttonLoadCurrentPricingData.Size = new System.Drawing.Size(132, 23);
            this.buttonLoadCurrentPricingData.TabIndex = 3;
            this.buttonLoadCurrentPricingData.Text = "Refresh data";
            this.buttonLoadCurrentPricingData.UseVisualStyleBackColor = false;
            this.buttonLoadCurrentPricingData.Click += new System.EventHandler(this.buttonLoadCurrentPricingData_Click);
            // 
            // buttonCancelAllOffers
            // 
            this.buttonCancelAllOffers.BackColor = System.Drawing.Color.Transparent;
            this.buttonCancelAllOffers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancelAllOffers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancelAllOffers.ForeColor = System.Drawing.Color.Red;
            this.buttonCancelAllOffers.Location = new System.Drawing.Point(635, 15);
            this.buttonCancelAllOffers.Name = "buttonCancelAllOffers";
            this.buttonCancelAllOffers.Size = new System.Drawing.Size(132, 23);
            this.buttonCancelAllOffers.TabIndex = 2;
            this.buttonCancelAllOffers.Text = "End all offers";
            this.buttonCancelAllOffers.UseVisualStyleBackColor = false;
            this.buttonCancelAllOffers.Click += new System.EventHandler(this.buttonCancelAllOffers_Click);
            // 
            // labelCurrentPricing
            // 
            this.labelCurrentPricing.AutoSize = true;
            this.labelCurrentPricing.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCurrentPricing.Location = new System.Drawing.Point(6, 12);
            this.labelCurrentPricing.Name = "labelCurrentPricing";
            this.labelCurrentPricing.Size = new System.Drawing.Size(150, 24);
            this.labelCurrentPricing.TabIndex = 1;
            this.labelCurrentPricing.Text = "Current Pricing";
            // 
            // tableLayoutPanelCurrentPricing
            // 
            this.tableLayoutPanelCurrentPricing.ColumnCount = 5;
            this.tableLayoutPanelCurrentPricing.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.tableLayoutPanelCurrentPricing.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanelCurrentPricing.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanelCurrentPricing.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanelCurrentPricing.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 121F));
            this.tableLayoutPanelCurrentPricing.Location = new System.Drawing.Point(6, 48);
            this.tableLayoutPanelCurrentPricing.Name = "tableLayoutPanelCurrentPricing";
            this.tableLayoutPanelCurrentPricing.RowCount = 1;
            this.tableLayoutPanelCurrentPricing.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelCurrentPricing.Size = new System.Drawing.Size(761, 352);
            this.tableLayoutPanelCurrentPricing.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(773, 406);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Competitor Price Analysis";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 456);
            this.Controls.Add(this.tabControlPricing);
            this.Name = "MainForm";
            this.Text = "Pricing Manager";
            this.tabControlPricing.ResumeLayout(false);
            this.tabPageCurrentPricing.ResumeLayout(false);
            this.tabPageCurrentPricing.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlPricing;
        private System.Windows.Forms.TabPage tabPageCurrentPricing;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelCurrentPricing;
        private System.Windows.Forms.Button buttonCancelAllOffers;
        private System.Windows.Forms.Label labelCurrentPricing;
        private System.Windows.Forms.Button buttonLoadCurrentPricingData;
        private System.Windows.Forms.Label labelFilter;
        private System.Windows.Forms.TextBox textBoxFilter;
    }
}

