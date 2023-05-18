using DAL.Interface;
using DAL.Model;
using System.Data;
using System.Drawing.Drawing2D;
using System.Globalization;
using Match = DAL.Model.Match;
using WorldCup.Controls;
using System.Drawing.Printing;

namespace WorldCup
{
    public partial class RangList : Form
    {
        private static IRepo repo;
        private static Settings settings;
        private static IImageRepo images;
        private IList<Match> matches;
        private IList<Match> sortedMatches;
        private IList<Player> players;
        private IList<Player> sortedPlayers;
        private bool openNewFormWithoutConfirmation = false;


        public RangList(IRepo repository, Settings mainSettings, IImageRepo imagesRepo)
        {
            repo = repository;
            settings = mainSettings;
            images = imagesRepo;
            CultureInfo culture = new CultureInfo(settings.Language.ToString());
            Thread.CurrentThread.CurrentUICulture = culture;
            InitializeComponent();
            LoadData();

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        internal async Task LoadData()
        {
            lblError.Text = (settings.Language.ToString() == "en") ? "Loading data..." : "Učitavanje podataka...";
            lblError.Visible = true;
            string fifaCode = settings.FavoriteRepresentation.FifaCode;
            try
            {
                matches = await repo.LoadTeamRankings(fifaCode);
                players = await repo.LoadPlayerRankings(fifaCode);
                foreach (Player player in players)
                {
                    if (settings.FavoritePlayers.FirstOrDefault(p => player.Name == p.Name) != null)
                    {
                        player.Favorete = true;
                    }
                }
                //LoadDdls();
                lblError.Visible = false;
            }
            catch (Exception)
            {
                lblError.Text = (settings.Language.ToString() == "en") ? "Error" : "Greška";
                lblError.Visible = true;
            }
        }
        private void LoadMatches(IList<Match> sortedMatches)
        {
            foreach (Match match in sortedMatches)
            {
                UCMatchRank matchRang = new UCMatchRank();
                matchRang.LoadData(match.Location, match.Attendance, match.HomeTeamCountry, match.AwayTeamCountry);
                pnlMatches.Controls.Add(matchRang);
            }
        }
        private void LoadPlayers(IList<Player> sortedPlayers)
        {
            foreach (Player player in sortedPlayers)
            {
                UCPlayerRank playerRang = new UCPlayerRank(images);
                playerRang.LoadData(player.Name, player.Apearences, player.Scored, player.YellowCards, player.ImgUrl, player.Favorete, settings);
                pnlPlayers.Controls.Add(playerRang);
            }
        }


        private void btnSortMatches_Click(object sender, EventArgs e)
        {
            if (sortedMatches != null)
            {
                sortedMatches.Clear();
            }
            pnlMatches.Controls.Clear();


            if (rbAppAsc.Checked)
            {
                sortedMatches = matches.OrderBy(match => match.Attendance).ToList();
                pnlMatches.Controls.Clear();
            }
            else if (rbAppDesc.Checked)
            {
                sortedMatches = matches.OrderByDescending(match => match.Attendance).ToList();
                pnlMatches.Controls.Clear();

            }
            LoadMatches(sortedMatches);
        }

        private void btnSortPlayers_Click(object sender, EventArgs e)
        {
            if (sortedPlayers != null)
            {
                sortedPlayers.Clear();
            }
            pnlPlayers.Controls.Clear();


            if (rbGoalAsc.Checked)
            {
                sortedPlayers = players.OrderBy(player => player.Scored).ToList();
                pnlPlayers.Controls.Clear();
            }
            else if (rbGoalDesc.Checked)
            {
                sortedPlayers = players.OrderByDescending(player => player.Scored).ToList();
                pnlPlayers.Controls.Clear();
            }
            else if (rbCardAsc.Checked)
            {
                sortedPlayers = players.OrderBy(player => player.YellowCards).ToList();
                pnlPlayers.Controls.Clear();
            }
            else if (rbCardDesc.Checked)
            {
                sortedPlayers = players.OrderByDescending(player => player.YellowCards).ToList();
                pnlPlayers.Controls.Clear();

            }
            LoadPlayers(sortedPlayers);
        }


        private void btnPrintPlayers_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += (s, e) =>
            {
                Rectangle pagearea = e.PageBounds;
                Bitmap print;
                int height;
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                height = pnlPlayers.Height;
                pnlPlayers.Height = 1800;
                print = new Bitmap(pnlPlayers.Width, pnlPlayers.Height);
                pnlPlayers.DrawToBitmap(print, new Rectangle(0, 0, pnlPlayers.Width, pnlPlayers.Height));
                e.Graphics.DrawImage(print, (pagearea.Width / 2) - (pnlPlayers.Width / 2), 20f);
            };

            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }

        private void btnPrintMatchs_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += (s, e) =>
            {
                Rectangle pagearea = e.PageBounds;
                Bitmap print;
                int height;
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                height = pnlMatches.Height;
                pnlMatches.Height = 1800;
                print = new Bitmap(pnlMatches.Width, pnlMatches.Height);
                pnlMatches.DrawToBitmap(print, new Rectangle(0, 0, pnlMatches.Width, pnlMatches.Height));
                e.Graphics.DrawImage(print, (pagearea.Width / 2) - (pnlMatches.Width / 2), 20f);
            };

            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }


        private void btnChangeSettings_Click(object sender, EventArgs e)
        {

            openNewFormWithoutConfirmation = true;
            Menu settingsDefault = new Menu(repo);
            settingsDefault.SettingsLoad(settings, images);
            settingsDefault.Show();
            this.Hide();
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
