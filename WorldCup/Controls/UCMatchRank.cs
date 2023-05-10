namespace WorldCup.Controls
{
    public partial class UCMatchRank : UserControl
    {
        public UCMatchRank()
        {
            InitializeComponent();
        }

        public void LoadData(string location, long attendents, string homeTeam, string awayTeam)
        {
            lblLocation.Text = location;
            lblAttendance.Text = attendents.ToString();
            lblHomeTeam.Text = homeTeam;
            lblAwayTeam.Text = awayTeam;
        }
    }
}
