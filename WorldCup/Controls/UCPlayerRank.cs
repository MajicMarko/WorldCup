using DAL.Interface;
using DAL.Model;

namespace WorldCup.Controls
{
    public partial class UCPlayerRank : UserControl
    {
        private static IImageRepo images;

        public UCPlayerRank(IImageRepo imagesRepo)
        {
            images = imagesRepo;
            InitializeComponent();
        }

        internal void LoadData(string name, int apearences, int scored, int yellowCards, string imgUrl, bool favorete, Settings settings)
        {
            lblName.Text = name;
            lblApearences.Text = apearences.ToString();
            lblGoalsScored.Text = scored.ToString();
            lblYellowCard.Text = yellowCards.ToString();
            if (imgUrl != null)
            {
                imgPlayer.ImageLocation = imgUrl;
            }
            if (favorete)
            {
                BackColor = Color.DarkGoldenrod;
            }
            if (images.LoadImage(name) != null)
            {
                imgPlayer.ImageLocation = images.LoadImage(name);
            }
        }

        internal string GetPlayerName()
        {
            return lblName.Text;
        }
    }
}
