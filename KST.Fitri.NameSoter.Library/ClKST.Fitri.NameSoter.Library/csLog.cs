using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KST.Fitri.NameSorter.Library
{
    public class csLog
    {
        /// <summary>Read Log</summary>
        /// <author>Fitri Kushandayani</author><date>December 24, 2019</date>
        /// <returns></returns>
        public static List<string> Read(string filePath)
        {
            List<string> result = new List<string>();
            if (File.Exists(filePath))
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        result.Add(line);
                    }
                }
            }
            return result;
        }

        /// <summary>Save Log</summary>
        /// <author>Fitri Kushandayani</author><date>December 24, 2019</date>
        /// <returns></returns>
        public static void Save(string Message, string filename, string directory)
        {

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            string filepath = directory + "\\" + filename;
            if (!File.Exists(filepath))
            {
                FileStream fs = File.Create(filepath);
                fs.Flush();
                fs.Close();
            }
            File.WriteAllText(filepath, Message);
        }


        /// <summary>UpdateSortList</summary>
        /// <author>Fitri Kushandayani</author><date>December 24, 2019</date>
        /// <returns></returns>
        public static void UpdateSortList(string filename, string directory, string msg)
        {
            string result = "";
            if (!string.IsNullOrEmpty(msg))
            {                
                string[] word = msg.Split(',');
                if (word != null && word.Count() > 0)
                {
                    foreach (var item in word)
                    {
                        result += item + Environment.NewLine;
                    }
                }
            }
            Save(result, filename, directory);
        }

        /// <summary>GetFileNames</summary>
        /// <author>Fitri Kushandayani</author><date>December 24, 2019</date>
        /// <returns>string[]</returns>
        public static List<string> GetFileNames(string directory, string filter)
        {
            if (Directory.Exists(directory))
            {
                string[] files = Directory.GetFiles(directory, filter);
                for (int i = 0; i < files.Length; i++)
                    files[i] = Path.GetFileName(files[i]);
                return files.ToList();
            }
            return null;
        }
    }
}
