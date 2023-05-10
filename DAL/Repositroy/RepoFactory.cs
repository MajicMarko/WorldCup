using DAL.Interface;

namespace DAL.Repositroy
{
    public static class RepoFactory
    {
        public static IRepo GetRepo() => new FileRepo();
        public static ISettingsRepo GetSettingsRepo() => new FileSettingsRepo();
        public static IImageRepo GetImageRepo() => new FileImageRepo();
    }
}
