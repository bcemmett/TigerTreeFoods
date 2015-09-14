using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PosTerminal
{
    public partial class PosSession : Form
    {
        private StringBuilder m_barcode = new StringBuilder(16);
        
        public PosSession()
        {
            InitializeComponent();
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
                ProcessNewItem();
                m_barcode.Clear();
            }
        }

        private void ProcessNewItem()
        {
            var db = new DatabaseAccess();
            ShoppingItem newItem = db.GetItemDetails(m_barcode.ToString());
        }
    }
}