using System;
using System.Diagnostics;
using System.IO;
using System.Text.Json;

namespace Proect_Tracker
{
    internal class SaveLoad
    {
        private static readonly string FilePath = "saveFile.json";

       

        public static List<Category> Load()
        {
            if (!File.Exists(FilePath))
            {
                return null;
            }

            string jsonString = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<List<Category>>(jsonString);
        }

        public static void SaveTest(List<Category> categories)
        {
            string jsonString = JsonSerializer.Serialize(categories);
            File.WriteAllText(FilePath, jsonString);
            Debug.WriteLine("SAVED");
        }









    }
   
}