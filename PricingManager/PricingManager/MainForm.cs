using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using PosTerminal;

namespace PricingManager
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            tableLayoutPanelCurrentPricing.RowStyles.Clear();
        }

        private void buttonCancelAllOffers_Click(object sender, EventArgs e)
        {
            var offerCanceller = new OfferCancelForm();
            offerCanceller.Show();
            offerCanceller.CancelOffers();
        }

        private void buttonLoadCurrentPricingData_Click(object sender, EventArgs e)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["LiveDb"].ConnectionString;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT TOP 250 ItemId, TillDescription, RegularPrice, OfferPrice, Barcode FROM CurrentPrices";
                    var reader = cmd.ExecuteReader();
                    tableLayoutPanelCurrentPricing.SuspendLayout();
                    while (reader.Read())
                    {
                        var item = new ShoppingItem
                        {
                            ItemId = (int) reader["ItemId"],
                            Barcode = (string) reader["Barcode"],
                            RegularPrice = (Decimal) reader["RegularPrice"],
                            OfferPrice = reader["OfferPrice"] == DBNull.Value ? null : (Decimal?) reader["OfferPrice"],
                            TillDescription = (string) reader["TillDescription"]
                        };
                        AddItemToTable(item);
                    }
                    tableLayoutPanelCurrentPricing.ResumeLayout();
                }
            }
        }

        private void AddItemToTable(ShoppingItem item)
        {
            RichTextBox description = GetRichTextBoxForItemList();
            description.Text = item.TillDescription;

            RichTextBox regularPrice = GetRichTextBoxForItemList();
            regularPrice.Text = item.RegularPrice.ToString("C");

            RichTextBox offerPrice = GetRichTextBoxForItemList();
            offerPrice.Text = item.OfferPrice.HasValue ? item.OfferPrice.Value.ToString("C") : String.Empty;

            RichTextBox barcode = GetRichTextBoxForItemList();
            barcode.Text = item.Barcode;

            tableLayoutPanelCurrentPricing.RowCount++;
            int nextRow = tableLayoutPanelCurrentPricing.RowCount - 1;
            tableLayoutPanelCurrentPricing.Controls.Add(description, 0, nextRow);
            tableLayoutPanelCurrentPricing.Controls.Add(barcode, 1, nextRow);
            tableLayoutPanelCurrentPricing.Controls.Add(regularPrice, 2, nextRow);
            tableLayoutPanelCurrentPricing.Controls.Add(offerPrice, 3, nextRow);
        }

        private RichTextBox GetRichTextBoxForItemList()
        {
            var rtb = new RichTextBox
            {
                ForeColor = Color.Black,
                BackColor = SystemColors.Window,
                Font = (new Font("Microsoft San Serif", 10)),
                Margin = new Padding(0),
                Height = 18,
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.None,
                ReadOnly = true
            };
            return rtb;
        }
    }
}