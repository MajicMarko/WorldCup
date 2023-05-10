using DAL.Interface;
using DAL.Model;
using DAL.Repositroy;

namespace WorldCup.Controls
{
    public partial class UCFavoritePlayer : UserControl
    {
        private static IImageRepo? images;

        public UCFavoritePlayer(IImageRepo imagesRepo)
        {
            images = imagesRepo;
            InitializeComponent();
        }

        public void LoadData(string name, long number, Player.PositionE position, bool isCapetan)
        {
            lblPlayerName.Text = name;
            lblPlayerNumber.Text = number.ToString();
            lblPlayerPosition.Text = position.ToString();
            if (isCapetan)
            {
                lblPlayerCapetan.Text = "C";
            }
            else
            {
                lblPlayerCapetan.Text = "";
            }
            if (images.LoadImage(name) != null)
            {
                imgPlayer.ImageLocation = images.LoadImage(name);
            }
        }

        public Player GetPlayer()
        {
            Player player = new Player
            {
                Name = lblPlayerName.Text,
                ShirtNumber = int.Parse(lblPlayerNumber.Text),
                Position = (Player.PositionE)Enum.Parse(typeof(Player.PositionE), lblPlayerPosition.Text),
            };

            if (lblPlayerCapetan.Text == "Yes")
            {
                player.Captain = true;
            }
            else
            {
                player.Captain = false;
            }

            return player;
        }

        public void SetFav()
        {
            imgFavorite.Visible = true;
        }

        public void SetNotFav()
        {
            imgFavorite.Visible = false;
        }



        private void imgPlayer_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Pictures|*.jpg;*.jpeg;*.bmp;*.png|All files|*.*",
                InitialDirectory = Application.StartupPath
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                imgPlayer.ImageLocation = ofd.FileName;
                images.SaveImage(lblPlayerName.Text, ofd.FileName);
            }
        }
    }
}
