using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FlashCardApp.FileOperation;
using static FlashCardApp.FC_Main;
using static FlashCardApp.FlashCardIdOperation;
using static FlashCardApp.Coloring;
using static FlashCardApp.DisplayAndGetInformation;

namespace FlashCardApp
{
    public static class FC_Edit
    {
        public static void Edit()
        {

            //proceed
            

            ShowFlashCards(dataPath, "Editing", true);           
            

            GetFlashCardById(flashCardsDictionary, out FlashCard flashCard, out int FlashCardID);


            EditFlashCard(FlashCardID, flashCard, "This option doesn't exists");

        }

        public static void EditFlashCard(int FlashCardID, FlashCard flashCard, string errorMessage)
        {
            // logica para se for modo editor
            bool leave = false;
            while (!leave)
            {
                Title($"Choose the text to edit within the set identified by ID: [{FlashCardID}]");
                Console.WriteLine(" ");
                BuildSimpleMenu("Question", "Answer", errorMessage, out bool SimpleMenuFeedBack, out int userChoice);
                
                if (SimpleMenuFeedBack == true)
                {
                    switch (userChoice)
                    {
                        case 1:
                            flashCard.Question = EditField("Write a new Question:");
                            break;
                        case 2:
                            flashCard.Answer = EditField("Write a new Answer:");
                            break;
                        case 3:
                            leave = true;
                            break;
                        default:
                            Error(errorMessage);
                            break;
                    }
                }    
                else
                {
                    leave = true;
                }
            }
            SaveToFile(flashCardsDictionary, dataPath);
            Console.Clear();
        }
        static string EditField(string message)
        {
            Title(message);
            string input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                throw new EmptyFieldException();
            }
            else
            {                
                FeedBack("\nText edited successfully\n");
                return input;
            }
            
        }
    }
}
