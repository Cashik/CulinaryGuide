using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CulinaryGuide
{
    public class SettingsClass
    {
        public int windowWidth = 670;
        public int windowHeight = 490;
        public string login;
        public string password;
        string path = @"settings.dat";
        public SettingsClass() { }
        public SettingsClass(int wW,int wH,bool aA)
        {
            windowWidth = wW;
            windowHeight = wH;
        }

        public void Reload()
        {
            // 
            try
            {
                // создаем объект BinaryReader
                using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
                {
                    // считываем каждое значение из файла
                    windowWidth = reader.ReadInt32();
                    windowHeight = reader.ReadInt32();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    

        public void Rewrite()
        {
            try
            {
                // создаем объект BinaryWriter
                using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
                {
                    // записываем в файл значение каждого поля структуры
                    writer.Write(windowWidth);
                    writer.Write(windowHeight);
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
