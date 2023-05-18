using DAL.Interface;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DAL.Repositroy
{
    public class FileImageRepo : IImageRepo
    {
        private static readonly string DIR = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName + "\\WorldCup\\temp";
        private static readonly string PATH = DIR + "\\images.txt";
        private static readonly char DEL = '|';

        private void CreateFilesIfNonExistent()
        {
            Directory.CreateDirectory(DIR);
            if (!File.Exists(PATH))
            {
                File.Create(PATH).Close();
            }
        }

        public FileImageRepo()
        {
            CreateFilesIfNonExistent();
        }

        public string LoadImage(string name)
        {
            string[] lines = File.ReadAllLines(PATH);
            foreach (string line in lines)
            {
                if (line.Split(DEL).First() == name)
                {
                    return line.Split(DEL).Last();
                }
            }

            return null;
        }

        public void SaveImage(string name, string file)
        {
            IList<string> lines = new List<string>();
            string[] fileLines = File.ReadAllLines(PATH);
            fileLines.ToList().ForEach(l => lines.Add(l));
            string line = name + DEL + file;
            lines.Add(line);
            File.WriteAllLines(PATH, lines);
        }
    }
}

