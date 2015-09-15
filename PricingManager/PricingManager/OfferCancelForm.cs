using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PricingManager
{
    public partial class OfferCancelForm : Form
    {
        SqlConnection m_conn;
        SqlCommand m_cmd;
        SqlTransaction m_transaction;

        public OfferCancelForm()
        {
            InitializeComponent();
        }

        public void CancelOffers()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["LiveDb"].ConnectionString;
            m_conn = new SqlConnection(connectionString);
            m_conn.Open();
            m_transaction = m_conn.BeginTransaction("Cancel");
            m_cmd = new SqlCommand();
            m_cmd.Connection = m_conn;
            m_cmd.Transaction = m_transaction;
            m_cmd.CommandText = "UPDATE CurrentPrices SET OfferPrice = null";
            m_cmd.ExecuteNonQuery();
        }

        private void buttonConfirm_Click(object sender, System.EventArgs e)
        {
            m_transaction.Commit();
            Cleanup(false);
        }

        private void buttonCancel_Click(object sender, System.EventArgs e)
        {
            m_transaction.Rollback();
            Cleanup(false);
        }

        private void OfferCancelForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cleanup(true);
        }

        private void Cleanup(bool formClosing)
        {
            m_conn.Dispose();
            m_cmd.Dispose();
            m_transaction.Dispose();
            if (!formClosing)
            {
                Close();
            }
        }
    }
}