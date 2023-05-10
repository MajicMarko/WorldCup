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
    }
}
