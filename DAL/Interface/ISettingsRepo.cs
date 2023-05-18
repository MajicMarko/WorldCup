using DAL.Model;

namespace DAL.Interface
{
    public interface ISettingsRepo
    {
        Settings LoadSettings();
        Settings LoadFavoritePlayers();
        void SaveSettings(Settings settings);
        void SaveFavoritePlayers(Settings settings);
        bool ExistingSettings();
        bool ExistingPlayers();
    }
}
