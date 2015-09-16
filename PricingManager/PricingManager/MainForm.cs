using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using PosTerminal;

namespace PricingManager
{
    public partial class MainForm : Form
    {
        private List<ShoppingItem> m_currentPrices = new List<ShoppingItem>();
        private delegate void AddCompetitorItemToTableCallback(CompetitorItem item);

        public MainForm()
        {
            InitializeComponent();
            tableLayoutPanelCurrentPricing.RowStyles.Clear();
            tableLayoutPanelCompetitorPricing.RowStyles.Clear();
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
                    cmd.CommandText = "SELECT ItemId, TillDescription, RegularPrice, OfferPrice, Barcode FROM CurrentPrices";
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
            ResetTable(tableLayoutPanelCurrentPricing);
            foreach (var item in items)
            {
                AddItemToCurrentPricingTable(item);
            }
            tableLayoutPanelCurrentPricing.ResumeLayout();
        }

        private void ResetTable(TableLayoutPanel table)
        {
            table.RowStyles.Clear();
            table.Controls.Clear();
            table.RowCount = 1;
        }

        private void AddItemToCurrentPricingTable(ShoppingItem item)
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

        private void buttonFetchCompetitorPricing_Click(object sender, EventArgs e)
        {
            ResetTable(tableLayoutPanelCompetitorPricing);
            Task.Run(() => PopulateCompetitorPricing());
        }

        private void PopulateCompetitorPricing()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["LiveDb"].ConnectionString;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT ItemId, TillDescription, RegularPrice, OfferPrice, Barcode FROM CurrentPrices WHERE OfferPrice IS NOT NULL";
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var item = new CompetitorItem
                        {
                            ItemId = (int)reader["ItemId"],
                            Barcode = (string)reader["Barcode"],
                            RegularPrice = (Decimal)reader["RegularPrice"],
                            OfferPrice = (Decimal?)reader["OfferPrice"],
                            TillDescription = (string)reader["TillDescription"]
                        };
                        item.CompetitorPrice = CompetitorLookup.LookupCompetitorPrice(item.TillDescription);

                        AddCompetitorItemToTableCallback update = new AddCompetitorItemToTableCallback(AddCompetitorItemToTable);
                        this.Invoke(update, new object[] {item});
                        
                        Thread.Sleep(1000);
                    }
                }
            }
        }

        private void AddCompetitorItemToTable(CompetitorItem item)
        {
            RichTextBox description = GetRichTextBoxForItemList();
            description.Text = item.TillDescription;

            RichTextBox regularPrice = GetRichTextBoxForItemList();
            regularPrice.Text = item.RegularPrice.ToString("C");

            RichTextBox offerPrice = GetRichTextBoxForItemList();
            offerPrice.Text = item.OfferPrice.HasValue ? item.OfferPrice.Value.ToString("C") : String.Empty;

            RichTextBox competitorPrice = GetRichTextBoxForItemList();
            competitorPrice.Text = item.CompetitorPrice.HasValue ? item.CompetitorPrice.Value.ToString("C") : "NO MATCH";

            Button updatePrice = new Button
            {
                Text = "Edit",
                Width = 60
            };

            tableLayoutPanelCompetitorPricing.RowCount++;
            int nextRow = tableLayoutPanelCompetitorPricing.RowCount - 1;
            tableLayoutPanelCompetitorPricing.Controls.Add(description, 0, nextRow);
            tableLayoutPanelCompetitorPricing.Controls.Add(regularPrice, 1, nextRow);
            tableLayoutPanelCompetitorPricing.Controls.Add(offerPrice, 2, nextRow);
            tableLayoutPanelCompetitorPricing.Controls.Add(competitorPrice, 3, nextRow);
            tableLayoutPanelCompetitorPricing.Controls.Add(updatePrice, 4, nextRow);
        }
    }
}