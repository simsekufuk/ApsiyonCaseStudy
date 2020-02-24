using ApsiyonCaseStudy.Utilies.Abstract;
using System;
using System.IO;

namespace ApsiyonCaseStudy.Utilies
{
    public class FileProcess : IFileProcess
    {
        public void Write(string message)
        {
            string desktopFilePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (!Directory.Exists(desktopFilePath + @"\ApsiyonLog"))
            {
                Directory.CreateDirectory(desktopFilePath + @"\ApsiyonLog");
            }

            string filaPath = desktopFilePath + @"\ApsiyonLog\Log.txt";
            FileStream fs = new FileStream(filaPath, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(message);
            sw.WriteLine("--------");
            sw.Flush();
            sw.Close();
            fs.Close();
        }
    }
}
