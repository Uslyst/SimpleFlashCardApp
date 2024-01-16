using System;
using System.Collections.Generic;
using System.IO;
using static FlashCardApp.Coloring;
using static FlashCardApp.DisplayAndGetInformation;
namespace FlashCardApp
{
    public static class FileOperation
    {
        public static Dictionary<int, FlashCard> flashCardsDictionary;

        public static string dataPath = "data.txt";
        public static void SaveToFile(Dictionary<int, FlashCard> flashCardsDictionary, string dataPath)
        {
            List<string> lines = new List<string>();

            foreach (var kpv in flashCardsDictionary)
            {
                lines.Add($"{kpv.Key}§{kpv.Value.Question}§{kpv.Value.Answer}");
            }

            File.WriteAllLines(dataPath, lines);
        }

        public static void ShowFlashCards(string dataPath, string title, bool isModifying)
        {                        
            string[] lines = File.ReadAllLines(dataPath);
            string[] lineParts;

            Console.Clear();

            Title(title);
            foreach (string line in lines)
            {
                lineParts = line.Split('§');

                if (isModifying)
                {
                    Console.WriteLine($"\nID: [{lineParts[0]}]=-------------------------------------=>" +
                                    $"\n\nQuestion: {lineParts[1]}" +
                                    $"\n\nAnswer: {lineParts[2]}");
                }
                else
                {
                    Console.WriteLine($"\nID: [{lineParts[0]}]=-------------------------------------=>" +
                         $"\n\nQuestion: {lineParts[1]}");

                }
            }
        }
        public static Dictionary<int, FlashCard> LoadFlashCardsFromFile(string dataPath)
        {
            Dictionary<int, FlashCard> flashCardsDictionary = new Dictionary<int, FlashCard>();

            string[] lineParts;

            if (File.Exists(dataPath))
            {
                string[] lines = File.ReadAllLines(dataPath);

                foreach (string line in lines)
                {
                    lineParts = line.Split('§');

                    
                    int id = int.Parse(lineParts[0]);

                    FlashCard flashcard = FlashCard.CreateFlashCardItem(lineParts[1], lineParts[2], id);

                    flashCardsDictionary.Add(id, flashcard);
                    
                }
            }
            
        return flashCardsDictionary;
        }

        public static bool CheckFileExistence()
        {         
            if (!File.Exists(FileOperation.dataPath))
            {
                throw new DirectoryNotFoundException();
            }
            return true;
        }              
    }
}
