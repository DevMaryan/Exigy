using Exigy.ErrorHandler;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace Exigy.Data
{
    public class Players
    {
        public Players()
        {
            PlayersList = new List<Player>();
        }

        public List<Player> PlayersList { get; set; }

        public void AddNew(Player newPlayer)
        {
            PlayersList.Add(newPlayer);
        }

        public void WriteToFile()
        {
            try
            {
                var filePath = @"C:\Results.json";
                var jsonData = JsonConvert.SerializeObject(PlayersList);
                File.AppendAllText(filePath, jsonData);
            }
            catch(FileException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }
    }

}
