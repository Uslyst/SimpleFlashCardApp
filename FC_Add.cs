using System;
using System.Collections.Generic;
using static FlashCardApp.FileOperation;
using static FlashCardApp.FlashCardIdOperation;
using static FlashCardApp.FlashCard;

namespace FlashCardApp
{
    public static class FC_Add
    {
        public static void Add()
        {
            Console.Clear();
            Coloring.Title("Adding Flashcard\n");
            while (true)
            {
                QuestionAndAnswerInput(flashCardsDictionary);

                bool userConfirmation = DisplayAndGetInformation.RequestConfirmation("Do you want to add more Q&A? Y/N\n");

                if (userConfirmation != true)
                {
                    Console.Clear();
                    break;
                }
            }
            
        }
        static void QuestionAndAnswerInput(Dictionary<int, FlashCard> flashCardDictionary)
        {

            Console.Write("\nAdd the question:");
            string question = Console.ReadLine();
            Console.Write("\nAdd its answer:");
            string answer = Console.ReadLine();

            if (string.IsNullOrEmpty(question) || string.IsNullOrEmpty(answer))
            {
                throw new EmptyFieldException();
            }
            int id = GetAvaliableIds();

            FlashCard flashCard = CreateFlashCardItem(question, answer, id);    

            AddFlashCard(flashCardDictionary, id, flashCard);

            Coloring.FeedBack($"\nQuestion and Answer added successfully");
            Console.WriteLine($"Flashcard ID:[{id}]\n");
        }             


        static void AddFlashCard(Dictionary<int, FlashCard> flashCardDictionary, int newId, FlashCard newQaItem)
        {
            flashCardDictionary.Add(newId, newQaItem);
            
            SaveToFile(flashCardsDictionary, dataPath);
        }
    }
}
