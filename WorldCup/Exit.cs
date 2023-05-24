using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Windows.Forms;

namespace WorldCup
{
    public partial class Exit : Form
    {
        public DialogResult ExitResult { get; private set; }

        public Exit()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            ExitResult = DialogResult.No;
            Close();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            ExitResult = DialogResult.Yes;
            Close();
        }

        private void Exit_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true; // Enable receiving key events by the form
        }

        private void Exit_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnYes_Click(sender, e);
            }
            if (e.KeyCode == Keys.Escape)
            {
                btnNo_Click(sender, e);
            }
        }
    }
}
