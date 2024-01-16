using System.IO;
using static FlashCardApp.FileOperation;
using static FlashCardApp.FlashCardIdOperation;
using static FlashCardApp.Coloring;
using System;
namespace FlashCardApp
{
    public static class FC_GetAnswer
    {
        public static void GetAnswer()
        {

            bool shouldContinueLoop = true;
            //proceed
            while (shouldContinueLoop)
            {
                
                ShowFlashCards(dataPath, "Getting Answer", false);

                GetFlashCardById(flashCardsDictionary, out FlashCard flashCard, out int _);

                GetFlashCardAnswer(flashCard);

                shouldContinueLoop = DisplayAndGetInformation.RequestConfirmation("Get another answer? Y/N");
            }

            Console.Clear();



        }
        public static void GetFlashCardAnswer(FlashCard flashCard)
        {
            Console.WriteLine($"\nQuestion: {flashCard.Question}");
            FeedBack($"Answer: {flashCard.Answer}\n");
        }           
    }
}
