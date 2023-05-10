using DAL.Interface;
using DAL.Model;
using System.Globalization;

namespace WorldCup
{
    public partial class Menu : Form
    {
        private static IRepo repo;
        private static Settings settings;
        private static IImageRepo images;
        private Settings.LanguageE language;


        public Menu(IRepo repository)
        {
            repo = repository;
            language = Settings.LanguageE.en;
            SetCulture();
        }

        private void SetCulture()
        {
            CultureInfo culture = new CultureInfo(language.ToString());

            Thread.CurrentThread.CurrentUICulture = culture;

            this.Controls.Clear();
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        internal void SettingsLoad(Settings mainSettings, IImageRepo imagesRepo)
        {
            images = imagesRepo;
            settings = mainSettings;
            repo.Settings(settings);
        }
        private void OpenNextForm(Settings settings)
        {
            settings.Save(settings);
            FavoritePlayers favoritePlayers = new FavoritePlayers(repo, settings, images);
            favoritePlayers.Show();
            this.Hide();
        }


        private void btnLanguage_Click(object sender, EventArgs e)
        {
            if (Thread.CurrentThread.CurrentUICulture.Name == Settings.LanguageE.en.ToString())
            {
                language = Settings.LanguageE.hr;
                SetCulture();
            }
            else
            {
                language = Settings.LanguageE.en;
                SetCulture();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            RadioButton selected = gbChampionship.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            if (selected != null)
            {
                settings.Championship = (Settings.ChampionshipE)Enum.Parse(typeof(Settings.ChampionshipE), selected.Name);
            }

            settings.Language = (Settings.LanguageE)Enum.Parse(typeof(Settings.LanguageE), language.ToString());


            string confirmationMessage;

            if (settings.Language.ToString() == "en")
            {
                confirmationMessage = "Are you sure you want to save this setting?";
            }
            else
            {
                confirmationMessage = "Jeste li sigurni da želite spremiti postavke?";
            }

            DialogResult result = MessageBox.Show(confirmationMessage, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                OpenNextForm(settings);
            }
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
