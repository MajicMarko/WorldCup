namespace DAL.Interface
{
    public interface IImageRepo
    {
        void SaveImage(string name, string file);
        string LoadImage(string name);
    }
}
