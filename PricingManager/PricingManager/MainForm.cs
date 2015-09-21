using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PricingManager
{
    public partial class MainForm : Form
    {
        private List<ShoppingItem> m_currentPrices = new List<ShoppingItem>();
        private delegate void AddCompetitorItemToTableCallback(CompetitorItem item);
        private CancellationTokenSource m_competitorLookupCancellationToken;

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
            m_currentPrices.Clear();
            var connectionString = ConfigurationManager.ConnectionStrings["LiveDb"].ConnectionString;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT ProductId, TillDescription, RegularPrice, OfferPrice, Barcode FROM Products";
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var item = new ShoppingItem
                        {
                            ProductId = (int)reader["ProductId"],
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
                : m_currentPrices.Where(p => p.TillDescription.ToLower().Contains(filter)).Take(itemsToDisplay).ToList();
            tableLayoutPanelCurrentPricing.SuspendLayout();
            ResetTable(tableLayoutPanelCurrentPricing);
            AddCurrentPricingHeaders();
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


        private void AddCurrentPricingHeaders()
        {
            tableLayoutPanelCurrentPricing.SuspendLayout();

            RichTextBox description = GetRichTextBoxForItemList(true);
            description.Text = "Description";

            RichTextBox regularPrice = GetRichTextBoxForItemList(true);
            regularPrice.Text = "Regular price";

            RichTextBox offerPrice = GetRichTextBoxForItemList(true);
            offerPrice.Text = "Offer price";
            
            tableLayoutPanelCurrentPricing.RowCount++;
            int nextRow = tableLayoutPanelCurrentPricing.RowCount - 1;
            tableLayoutPanelCurrentPricing.Controls.Add(description, 0, nextRow);
            tableLayoutPanelCurrentPricing.Controls.Add(regularPrice, 1, nextRow);
            tableLayoutPanelCurrentPricing.Controls.Add(offerPrice, 2, nextRow);
            
            tableLayoutPanelCurrentPricing.ResumeLayout();
        }

        private void AddItemToCurrentPricingTable(ShoppingItem item)
        {
            RichTextBox description = GetRichTextBoxForItemList(false);
            description.Text = item.TillDescription;

            RichTextBox regularPrice = GetRichTextBoxForItemList(false);
            regularPrice.Text = item.RegularPrice.ToString("C");

            RichTextBox offerPrice = GetRichTextBoxForItemList(false);
            offerPrice.Text = item.OfferPrice.HasValue ? item.OfferPrice.Value.ToString("C") : String.Empty;

            RichTextBox barcode = GetRichTextBoxForItemList(false);
            barcode.Text = item.Barcode;

            Button updatePrice = new Button
            {
                Text = "Edit",
                Width = 60
            };

            tableLayoutPanelCurrentPricing.RowCount++;
            int nextRow = tableLayoutPanelCurrentPricing.RowCount - 1;
            tableLayoutPanelCurrentPricing.Controls.Add(description, 0, nextRow);
            tableLayoutPanelCurrentPricing.Controls.Add(regularPrice, 1, nextRow);
            tableLayoutPanelCurrentPricing.Controls.Add(offerPrice, 2, nextRow);
            tableLayoutPanelCurrentPricing.Controls.Add(updatePrice, 3, nextRow);
        }

        private RichTextBox GetRichTextBoxForItemList(bool bold)
        {
            var rtb = new RichTextBox
            {
                ForeColor = Color.Black,
                BackColor = SystemColors.Window,
                Margin = new Padding(0),
                Height = 20,
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.None,
                ReadOnly = true
            };
            if (bold)
            {
                rtb.Font = (new Font("Microsoft San Serif", 10, FontStyle.Bold));
            }
            else
            {
                rtb.Font = (new Font("Microsoft San Serif", 10));
            }
            return rtb;
        }

        private void textBoxFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            UpdateCurrentPricesGrid();
        }

        private void buttonFetchCompetitorPricing_Click(object sender, EventArgs e)
        {
            ResetTable(tableLayoutPanelCompetitorPricing);
            AddCompetitorPricingHeaders();
            m_competitorLookupCancellationToken = new CancellationTokenSource();
            var token = m_competitorLookupCancellationToken.Token;
            buttonFetchCompetitorPricing.Enabled = false;
            buttonCancelCompetitorLookup.Enabled = true;
            Task.Run(() => PopulateCompetitorPricing(), token);
        }

        private void AddCompetitorPricingHeaders()
        {
            tableLayoutPanelCompetitorPricing.SuspendLayout();
            
            RichTextBox description = GetRichTextBoxForItemList(true);
            description.Text = "Description";

            RichTextBox regularPrice = GetRichTextBoxForItemList(true);
            regularPrice.Text = "Regular price";

            RichTextBox offerPrice = GetRichTextBoxForItemList(true);
            offerPrice.Text = "Offer price";

            RichTextBox competitorPrice = GetRichTextBoxForItemList(true);
            competitorPrice.Text = "Competitor price";

            tableLayoutPanelCompetitorPricing.RowCount++;
            int nextRow = tableLayoutPanelCompetitorPricing.RowCount - 1;
            tableLayoutPanelCompetitorPricing.Controls.Add(description, 0, nextRow);
            tableLayoutPanelCompetitorPricing.Controls.Add(regularPrice, 1, nextRow);
            tableLayoutPanelCompetitorPricing.Controls.Add(offerPrice, 2, nextRow);
            tableLayoutPanelCompetitorPricing.Controls.Add(competitorPrice, 3, nextRow);

            tableLayoutPanelCompetitorPricing.ResumeLayout();
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
                    cmd.CommandText = "SELECT ProductId, TillDescription, RegularPrice, OfferPrice, Barcode, Image FROM Products WHERE OfferPrice IS NOT NULL";
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (m_competitorLookupCancellationToken.IsCancellationRequested)
                        {
                            return;
                        }
                        var item = new CompetitorItem
                        {
                            ProductId = (int)reader["ProductId"],
                            Barcode = (string)reader["Barcode"],
                            RegularPrice = (Decimal)reader["RegularPrice"],
                            OfferPrice = (Decimal?)reader["OfferPrice"],
                            TillDescription = (string)reader["TillDescription"]
                        };
                        item.CompetitorPrice = CompetitorLookup.LookupCompetitorPrice(item.TillDescription, item.OfferPrice);

                        AddCompetitorItemToTableCallback update = new AddCompetitorItemToTableCallback(AddCompetitorItemToTable);
                        this.Invoke(update, new object[] {item});
                    }
                }
            }
        }

        private void AddCompetitorItemToTable(CompetitorItem item)
        {
            tableLayoutPanelCompetitorPricing.SuspendLayout();
            RichTextBox description = GetRichTextBoxForItemList(false);
            description.Text = item.TillDescription;

            RichTextBox regularPrice = GetRichTextBoxForItemList(false);
            regularPrice.Text = item.RegularPrice.ToString("C");

            RichTextBox offerPrice = GetRichTextBoxForItemList(false);
            offerPrice.Text = item.OfferPrice.HasValue ? item.OfferPrice.Value.ToString("C") : String.Empty;

            RichTextBox competitorPrice = GetRichTextBoxForItemList(false);
            competitorPrice.Text = "█ " + (item.CompetitorPrice.HasValue ? item.CompetitorPrice.Value.ToString("C") : "NO MATCH");

            if (item.CompetitorPrice > item.OfferPrice)
            {
                competitorPrice.ForeColor = Color.Green;
            }
            else
            {
                competitorPrice.ForeColor = Color.Red;
            }

            tableLayoutPanelCompetitorPricing.RowCount++;
            int nextRow = tableLayoutPanelCompetitorPricing.RowCount - 1;
            tableLayoutPanelCompetitorPricing.Controls.Add(description, 0, nextRow);
            tableLayoutPanelCompetitorPricing.Controls.Add(regularPrice, 1, nextRow);
            tableLayoutPanelCompetitorPricing.Controls.Add(offerPrice, 2, nextRow);
            tableLayoutPanelCompetitorPricing.Controls.Add(competitorPrice, 3, nextRow);
            tableLayoutPanelCompetitorPricing.ResumeLayout();
        }

        private void buttonCancelCompetitorLookup_Click(object sender, EventArgs e)
        {
            if (m_competitorLookupCancellationToken != null)
            {
                m_competitorLookupCancellationToken.Cancel();
                buttonFetchCompetitorPricing.Enabled = true;
                buttonCancelCompetitorLookup.Enabled = false;
            }
        }
    }
}