using System.Windows.Forms;

namespace PosTerminal
{
    public partial class PosSession : Form
    {
        private string m_barcode;
        
        public PosSession()
        {
            InitializeComponent();
        }

        private void PosSession_KeyPress(object sender, KeyPressEventArgs e)
        {
            m_barcode += e.KeyChar.ToString();
            richTextBoxLastScanned.Text = m_barcode;
        }
    }
}
