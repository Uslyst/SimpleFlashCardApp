using System;
using System.Collections.Generic;
using static FlashCardApp.FileOperation;
using static FlashCardApp.FlashCardIdOperation;
using static FlashCardApp.Coloring;
using System.IO;
using static FlashCardApp.DisplayAndGetInformation;

namespace FlashCardApp
{
    public static class FC_Remove
    {

        public static void Remove()
        {
            string title = "Removing flashcard";
            string errorMessage = "This option doesn't exists";
            bool leave = false;
            Console.Clear();
            
            //proceed
            Title(title);
            Console.WriteLine(" ");

            while (!leave)
            {               
                
                BuildSimpleMenu("Remove one FlashCard", "Remove all", errorMessage,
                    out bool SimpleMenuFeedBack, out int userChoice);

                if (SimpleMenuFeedBack == true)
                {
                    switch (userChoice)
                    {
                        case 1:
                            DeleteOneFlashCard(flashCardsDictionary, title);
                            leave = CheckFlashCardsExistence(true);
                            break;
                        case 2:
                            DeleteAllFlashCards(dataPath);
                            leave = true;
                            break;
                        case 3:
                            Console.Clear();
                            leave = true;                        
                            break;
                          
                        default:
                            Console.Clear();
                            Error(errorMessage);                         
                            break;
                    }

                }


            }
            

        }
        public static void DeleteOneFlashCard(Dictionary<int, FlashCard> flashCardsDictionary, string title)
        {      

            ShowFlashCards(dataPath, title, true);
            GetFlashCardById(flashCardsDictionary, out FlashCard flashCard, out int FlashCardID);

            bool userConfirmation = RequestConfirmation($"\nAre you sure you want to remove the flashcard [{FlashCardID}]? Y/N");
            if (userConfirmation == true)
            {              
                flashCardsDictionary.Remove(FlashCardID);
                SaveToFile(flashCardsDictionary, dataPath);
                FeedBack($"\n\nFlashcard [{FlashCardID}] successfully removed\n");                               
            }

            
        }

        public static void DeleteAllFlashCards(string dataPath)
        {           
            bool userConfirmation = RequestConfirmation($"\nAre you sure you want to REMOVE ALL the flashcards? Y/N");
            
            if (userConfirmation == true)
            {
                File.Delete(dataPath);
                Console.Clear();
                FeedBack("All data was successfully deleted");
            }
                
        }
    }
}
