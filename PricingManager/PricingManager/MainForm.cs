using System;
using System.Windows.Forms;

namespace PricingManager
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonLoadCurrentPricingData_Click(object sender, EventArgs e)
        {
        }

        private void buttonCancelAllOffers_Click(object sender, EventArgs e)
        {
            var offerCanceller = new OfferCancelForm();
            offerCanceller.Show();
            offerCanceller.CancelOffers();
        }
    }
}