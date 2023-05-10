using DAL.Interface;
using DAL.Model;
using System.Globalization;
using System.Text.RegularExpressions;
using WorldCup.Controls;

namespace WorldCup
{
    public partial class FavoritePlayers : Form
    {
        private static IRepo repo;
        private static Settings settings;
        private static IImageRepo images;
        private IList<Player> allPlayers;
        private IList<UCFavoritePlayer> favoritePlayers = new List<UCFavoritePlayer>();
        private FlowLayoutPanel parent;
        private IList<Team> teams;


        public FavoritePlayers(IRepo repository, Settings mainSettings, IImageRepo imagesRepo)
        {

            repo = repository;
            settings = mainSettings;
            images = imagesRepo;
            CultureInfo culture = new CultureInfo(settings.Language.ToString());
            Thread.CurrentThread.CurrentUICulture = culture;
            InitializeComponent();
            PrepareDataForDropDownMenu();
            checkSetting();
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void checkSetting()
        {
            if (settings.Exists())
            {
                PrepareDataForPanel();

            }
        }
        private async Task PrepareDataForDropDownMenu()
        {
            lblError.Text = (settings.Language.ToString() == "en") ? "Loading data..." : "Učitavanje podataka...";

            lblError.Visible = true;


            try
            {

                teams = await repo.LoadTeams(settings);
                teams.ToList().Sort();
                teams.ToList().ForEach(t => ddlRepresentation.Items.Add(t.ToString()));
                //ddlRepresentation.SelectedIndex = 0;
                lblError.Visible = false;
            }
            catch (Exception ex)
            {
                lblError.Text = (settings.Language.ToString() == "en") ? "Error" : "Greška";
                btnNext.Enabled = false;
                lblError.Show();
            }
            lblError.Visible = false;


        }
        private async void PrepareDataForPanel()
        {
            lblError.Text = (settings.Language.ToString() == "en") ? "Loading data..." : "Učitavanje podataka...";
            lblError.Visible = true;
            try
            {
                allPlayers = await repo.LoadPlayers(settings.FavoreteRepresentation.FifaCode);
                ShowUsers(allPlayers);
            }
            catch (Exception)
            {
                lblError.Text = (settings.Language.ToString() == "en") ? "Error" : "Greška";
                lblError.Visible = true;
            }
            lblError.Visible = false;
        }
        private void ShowUsers(IList<Player> players)
        {
            pnlAllPlayers.Controls.Clear();
            foreach (Player player in players)
            {
                UCFavoritePlayer playerSelection = new UCFavoritePlayer(images)
                {
                    Name = player.Name,
                    ContextMenuStrip = playerContextMenuStrip
                };
                playerSelection.LoadData(player.Name, player.ShirtNumber, player.Position, player.Captain);
                playerSelection.MouseDown += PlayerSelection_MouseDown;

                pnlAllPlayers.Controls.Add(playerSelection);
                if (settings.FavoretePlayers != null)
                {
                    foreach (var item in settings.FavoretePlayers)
                    {
                        if (player.Name == item.Name)
                        {
                            playerSelection.SetFav();
                            pnlFavoretePlayers.Controls.Add(playerSelection);
                        }
                    }
                }



            }
        }
        private void ddlRepresentation_SelectedIndexChanged(object sender, EventArgs e)
        {

            pnlAllPlayers.Controls.Clear();
            pnlFavoretePlayers.Controls.Clear();

            if (ddlRepresentation.SelectedItem == null)
            {
                lblError.Text = (settings.Language.ToString() == "en") ? "Representation must be selected" : "Odaberite reprezentaciju";
                return;
            }

            string selectedText = ddlRepresentation.SelectedItem.ToString();
            string countryCode = Regex.Match(selectedText, @"\((.*?)\)").Groups[1].Value;
            Team selectedTeam = teams.FirstOrDefault(t => t.FifaCode == countryCode);
            settings.FavoreteRepresentation = selectedTeam;
            PrepareDataForPanel();

        }



        private void btnNext_Click(object sender, EventArgs e)
        {
            if (pnlFavoretePlayers.Controls.Count != 3)
            {
                lblError.Text = (settings.Language.ToString() == "en") ? "Select 3 players" : "Odaberi 3 igrača";
                lblError.Visible = true;
                return;
            }
            IList<Player> favoretes = new List<Player>();
            foreach (UCFavoritePlayer favourete in pnlFavoretePlayers.Controls)
            {
                favoretes.Add(favourete.GetPlayer());
            }
            settings.FavoretePlayers = favoretes;
            settings.Save(settings);
            settings.SavePlayers(settings);

            OpenNextForm(settings);
        }

        private void OpenNextForm(Settings settings)
        {

            RangList rangList = new RangList(repo, settings, images);
            rangList.Show();
            this.Hide();
        }
        private void PlayerSelection_MouseDown(object sender, MouseEventArgs e)
        {
            UCFavoritePlayer selectedPlayer = sender as UCFavoritePlayer;
            selectedPlayer.BackColor = Color.LightGray;
            favoritePlayers.Add(selectedPlayer);


            parent = (FlowLayoutPanel)selectedPlayer.Parent;
            if (favoritePlayers.Count < 1) { return; }
            selectedPlayer.DoDragDrop(selectedPlayer, DragDropEffects.Move);
        }
        private void pnlPlayers_DragEnter(object sender, DragEventArgs e)
        {
            FlowLayoutPanel starter = sender as FlowLayoutPanel;

            if (starter == parent)
            {
                return;
            }

            e.Effect = DragDropEffects.Move;
        }
        private void pnlPlayers_DragDrop(object sender, DragEventArgs e)
        {
            MovePlayers();
        }
        private void playerContextMenuStrip_Opened(object sender, EventArgs e)
        {
            ContextMenuStrip contextMenu = sender as ContextMenuStrip;
            UCFavoritePlayer playerSelectionUC = contextMenu.SourceControl as UCFavoritePlayer;
            if (playerSelectionUC == null)
            {
                return;
            }

            parent = (FlowLayoutPanel)playerSelectionUC.Parent;
            playerSelectionUC.BackColor = Color.LightGray;
            favoritePlayers.Add(playerSelectionUC);
        }
        private void moveToOtherList_Click(object sender, EventArgs e)
        {
            MovePlayers();
        }
        private void MovePlayers()
        {
            if (parent == pnlAllPlayers)
            {
                favoritePlayers.ToList().ForEach(player => player.SetFav());
                favoritePlayers.ToList().ForEach(player => pnlFavoretePlayers.Controls.Add(player));
                favoritePlayers.ToList().ForEach(player => pnlAllPlayers.Controls.Remove(player));
            }
            if (parent == pnlFavoretePlayers)
            {
                favoritePlayers.ToList().ForEach(player => player.SetNotFav());
                favoritePlayers.ToList().ForEach(player => pnlAllPlayers.Controls.Add(player));
                favoritePlayers.ToList().ForEach(player => pnlFavoretePlayers.Controls.Remove(player));
            }
            favoritePlayers.ToList().ForEach(player => player.BackColor = Color.DarkGray);
            favoritePlayers.Clear();
        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            Exit exitForm = new Exit();

            DialogResult result = exitForm.ShowDialog();

            DialogResult exitResult = exitForm.ExitResult;

            if (exitResult == DialogResult.Yes)
            {
                exitForm.Dispose();
                Application.Exit();
            }
            else if (exitResult == DialogResult.No)
            {
                exitForm.Dispose();
            }
        }
    }
}
