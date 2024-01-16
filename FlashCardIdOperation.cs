using System;
using System.Collections.Generic;
using static FlashCardApp.Coloring;
using static FlashCardApp.FileOperation;
using static FlashCardApp.FC_Edit;
using static FlashCardApp.FC_Remove;
using static FlashCardApp.FC_GetAnswer;
using System.Linq;
using System.IO;

namespace FlashCardApp
{
    public static class FlashCardIdOperation
    {
        public static void GetFlashCardById(Dictionary<int, FlashCard> flashCardsDictionary, out FlashCard flashCard, out int FlashCardID)
        {
            flashCard = null;
            Title("Enter an ID from the list above:");
            
            if (!int.TryParse(Console.ReadLine(), out FlashCardID))
            {
                throw new FormatException();
            }

            if (!flashCardsDictionary.TryGetValue(FlashCardID, out flashCard))
            {
                throw new NonExistentIdException();
            }



        }

        public static int GetAvaliableIds()
        {
            List<int> idsFound = new List<int>();
            int maxIdRange = 100;


            if (File.Exists(dataPath))
            {
                string[] lines = File.ReadAllLines(dataPath);

                foreach (string line in lines)
                {
                    string[] lineParts = line.Split('§');
                    idsFound.Add(int.Parse(lineParts[0]));
                }

                List<int> allId = Enumerable.Range(1, maxIdRange).ToList();

                int avaliableId = allId.Except(idsFound).Min();
                return avaliableId;
            }
            else
            {

                return 1;
            }
     
        }

        public static bool CheckFlashCardsExistence(bool suppressException)
        {
            string[] lines = File.ReadAllLines(dataPath);
            
            if (lines.Length == 0)
            {
                if (suppressException == true)
                {
                    return true;
                }
                else
                {
                    throw new NoFlashcardsException();

                }
                
            }

            return false;


        }
    }
}
