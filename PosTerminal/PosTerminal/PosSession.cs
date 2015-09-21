using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PosTerminal
{
    public partial class PosSession : Form
    {
        private StringBuilder m_barcode = new StringBuilder(16);
        private List<ShoppingItem> m_ShoppingItems = new List<ShoppingItem>();
        private delegate void UpdateWithScannedProductCallback(ShoppingItem item);
        
        public PosSession()
        {
            InitializeComponent();
            tableLayoutPanelShoppingItems.RowStyles.Clear();
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }

            base.WndProc(ref m);
        }

        private void PosSession_KeyPress(object sender, KeyPressEventArgs e)
        {
            char[] validChars = {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
            if (validChars.Contains(e.KeyChar))
            {
                m_barcode.Append(e.KeyChar.ToString());
                return;
            }

            if (e.KeyChar == (char)Keys.Escape)
            {
                m_barcode.Clear();
                return;
            }

            if (e.KeyChar == (char) Keys.LineFeed)
            {
                string barcode = m_barcode.ToString();
                m_barcode.Clear();
                ProcessScannedItem(barcode);
            }
        }

        private void ProcessScannedItem(string barcode)
        {
            pictureBoxLoadingSpinny.Visible = true;
            richTextBoxLastScanned.Text = "Searching for item...";
            Task.Run(() => LookupScannedItem(barcode));
        }

        private void LookupScannedItem(string barcode)
        {
            var db = new DatabaseAccess();
            ShoppingItem newItem = new ShoppingItem();
            try
            {
                newItem = db.GetItemDetails(barcode);
            }
            catch (Exception)
            {
                richTextBoxLastScanned.Text = "Couldn't find item. Seek assistance.";
                return;
            }
            UpdateWithScannedProductCallback update = new UpdateWithScannedProductCallback(UpdateWithScannedProduct);
            this.Invoke(update, new object[] { newItem });
        }

        private void UpdateWithScannedProduct(ShoppingItem item)
        {
            m_ShoppingItems.Add(item);
            UpdateMostRecentItem(item);
            AddShoppingItemToList(item);
            UpdateTotalCost();
            pictureBoxLoadingSpinny.Visible = false;
        }


        private void UpdateTotalCost()
        {
            Decimal total = m_ShoppingItems.Sum(s => s.OfferPrice != null ? Decimal.Round(s.OfferPrice.Value, 2) : Decimal.Round(s.RegularPrice, 2));
            labelTotal.Text = total.ToString("C");
        }

        private void UpdateMostRecentItem(ShoppingItem item)
        {
            richTextBoxLastScanned.Text = item.TillDescription;
            richTextBoxLastScanned.Text += Environment.NewLine;
            Decimal price = item.OfferPrice ?? item.RegularPrice;
            richTextBoxLastScanned.Text += price.ToString("C");
            if (item.OfferPrice != null)
            {
                richTextBoxLastScanned.Text += " (special offer)";
            }
        }

        private void AddShoppingItemToList(ShoppingItem item)
        {
            tableLayoutPanelShoppingItems.SuspendLayout();
            RichTextBox description = GetRichTextBoxForItemList();
            description.Text = item.TillDescription;

            Decimal cost = item.OfferPrice ?? item.RegularPrice;
            RichTextBox price = GetRichTextBoxForItemList();
            price.Text = cost.ToString("C");

            tableLayoutPanelShoppingItems.RowCount++;
            int nextRow = tableLayoutPanelShoppingItems.RowCount - 1;
            tableLayoutPanelShoppingItems.Controls.Add(description, 0, nextRow);
            tableLayoutPanelShoppingItems.Controls.Add(price, 1, nextRow);
            tableLayoutPanelShoppingItems.ResumeLayout();
        }

        private RichTextBox GetRichTextBoxForItemList()
        {
            var rtb = new RichTextBox
            {
                ForeColor = Color.Teal,
                Font = (new Font("Microsoft San Serif", 12)),
                Margin = new Padding(0),
                Dock = DockStyle.Fill,
                Height = 20,
                BorderStyle = BorderStyle.None,
                Enabled = false
            };
            return rtb;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            tableLayoutPanelShoppingItems.Controls.Clear();
            tableLayoutPanelShoppingItems.RowCount = 1;
            labelTotal.Text = "£0.00";
            richTextBoxLastScanned.Text = String.Empty;
            m_ShoppingItems.Clear();
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to close the application?", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}