using DAL.Interface;
using DAL.Model;
using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace WPF
{
    /// <summary>
    /// Interaction logic for UserCoPlayerUCntrol1.xaml
    /// </summary>
    public partial class PlayerUC : UserControl
    {
        private static IImageRepo images;

        public Player Player { get; set; }
        public PlayerUC(IImageRepo imagesRepo)
        {
            images = imagesRepo;
            InitializeComponent();
        }

        internal void LoadData(Player player)
        {
            lblName.Content = player.Name;
            lblNumber.Content = player.ShirtNumber;
            Player = player;
            if (images.LoadImage(player.Name) != null)
            {
                imgPlayer.Source = new BitmapImage(new Uri(images.LoadImage(player.Name)));
            }
        }

        internal Player GetData()
        {
            return Player;
        }
    }
}
