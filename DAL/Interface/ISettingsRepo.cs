using DAL.Model;

namespace DAL.Interface
{
    public interface ISettingsRepo
    {
        Settings LoadSettings();
        void SaveSettings(Settings settings);
        void SaveFavoritePlayers(Settings settings);
        bool ExistingSettings();
    }
}
