using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PosTerminal;

namespace PricingManager
{
    public partial class MainForm : Form
    {
        private List<ShoppingItem> m_currentPrices = new List<ShoppingItem>();

        public MainForm()
        {
            InitializeComponent();
            tableLayoutPanelCurrentPricing.RowStyles.Clear();
            UpdateCurrentPricesGridFromDatabase();
        }

        private void buttonCancelAllOffers_Click(object sender, EventArgs e)
        {
            var offerCanceller = new OfferCancelForm();
            offerCanceller.Show();
            offerCanceller.CancelOffers();
        }

        private void buttonLoadCurrentPricingData_Click(object sender, EventArgs e)
        {
            UpdateCurrentPricesGridFromDatabase();
        }

        private void UpdateCurrentPricesGridFromDatabase()
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
                    while (reader.Read())
                    {
                        var item = new ShoppingItem
                        {
                            ItemId = (int)reader["ItemId"],
                            Barcode = (string)reader["Barcode"],
                            RegularPrice = (Decimal)reader["RegularPrice"],
                            OfferPrice = reader["OfferPrice"] == DBNull.Value ? null : (Decimal?)reader["OfferPrice"],
                            TillDescription = (string)reader["TillDescription"]
                        };
                        m_currentPrices.Add(item);
                    }
                    UpdateCurrentPricesGrid();
                }
            }
        }

        private void UpdateCurrentPricesGrid()
        {
            int itemsToDisplay = 100;
            string filter = textBoxFilter.Text;
            List<ShoppingItem> items = String.IsNullOrWhiteSpace(filter)
                ? m_currentPrices.Take(itemsToDisplay).ToList()
                : m_currentPrices.Where(p => p.TillDescription.Contains(filter)).Take(itemsToDisplay).ToList();
            tableLayoutPanelCurrentPricing.SuspendLayout();
            ResetTable();
            foreach (var item in items)
            {
                AddItemToTable(item);
            }
            tableLayoutPanelCurrentPricing.ResumeLayout();
        }

        private void ResetTable()
        {
            tableLayoutPanelCurrentPricing.RowStyles.Clear();
            tableLayoutPanelCurrentPricing.Controls.Clear();
            tableLayoutPanelCurrentPricing.RowCount = 1;
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

            Button updatePrice = new Button
            {
                Text = "Edit",
                Width = 60
            };

            tableLayoutPanelCurrentPricing.RowCount++;
            int nextRow = tableLayoutPanelCurrentPricing.RowCount - 1;
            tableLayoutPanelCurrentPricing.Controls.Add(description, 0, nextRow);
            tableLayoutPanelCurrentPricing.Controls.Add(barcode, 1, nextRow);
            tableLayoutPanelCurrentPricing.Controls.Add(regularPrice, 2, nextRow);
            tableLayoutPanelCurrentPricing.Controls.Add(offerPrice, 3, nextRow);
            tableLayoutPanelCurrentPricing.Controls.Add(updatePrice, 4, nextRow);
        }

        private RichTextBox GetRichTextBoxForItemList()
        {
            var rtb = new RichTextBox
            {
                ForeColor = Color.Black,
                BackColor = SystemColors.Window,
                Font = (new Font("Microsoft San Serif", 10)),
                Margin = new Padding(0),
                Height = 20,
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.None,
                ReadOnly = true
            };
            return rtb;
        }

        private void textBoxFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            UpdateCurrentPricesGrid();
        }
    }
}