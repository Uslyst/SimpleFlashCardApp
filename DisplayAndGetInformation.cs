using System;
using static FlashCardApp.Coloring;
using static FlashCardApp.FileOperation;
using static FlashCardApp.FC_GetAnswer;
using static FlashCardApp.FC_Add;
using static FlashCardApp.FC_Edit;
using static FlashCardApp.FC_Remove;
using static FlashCardApp.FlashCardIdOperation;
using System.IO;

namespace FlashCardApp
{
    public static class DisplayAndGetInformation
    {
        public static void DisplayMain()
        {
            bool leave = false;
            while (!leave)
            {
                flashCardsDictionary = LoadFlashCardsFromFile(dataPath);


                Title("\tFlashCard Maker\t\n");
                Console.WriteLine("Choose an option" +
                                  "\n0-Clear Console" +
                                  "\n1-Add FlashCard" +
                                  "\n2-Receive Answer" +
                                  "\n3-Edit" +
                                  "\n4-Remove" +
                                  "\n5-Leave");

                string message = "Choose a valid option"; 
                char input = Console.ReadKey(true).KeyChar;
                if (int.TryParse(Convert.ToString(input), out int opcao))
                {
                    try
                    {
                        switch (opcao)
                        {
                            case 0:
                                Console.Clear();
                                break;
                            case 1:
                                Add();
                                break;
                            case 2:
                                CheckFileExistence();
                                CheckFlashCardsExistence(false);                               
                                GetAnswer();
                                break;
                            case 3:
                                CheckFileExistence();
                                CheckFlashCardsExistence(false);                         
                                Edit();
                                //edit()
                                break;
                            case 4:
                                CheckFileExistence();
                                CheckFlashCardsExistence(false);                                
                                Remove();
                                break;
                            case 5:
                                leave = true;
                                break;
                            default:
                                Error(message);
                                break;

                        }
                    }
                    catch (DirectoryNotFoundException)
                    {
                        Error($"Unable to proceed as the file does not exist.");
                    }
                    catch (FormatException)
                    {
                        Error("Enter a valid number");
                    }
                    catch (NonExistentIdException ex)
                    {
                        Error(ex.Message);
                    }
                    catch (EmptyFieldException ex)
                    {
                        Error(ex.Message);
                    }
                    catch (NoFlashcardsException ex)
                    {
                        Error(ex.Message);
                    
                    }

                }
                else
                {
                    Error(message);
                }

            }

        }
    

          // fazer um menu builder depois
        public static void BuildSimpleMenu(string optionMessage1, string optionMessage2, string errorMessage, out bool SimpleMenuFeedBack, out int userChoice)
        {
            Console.WriteLine("Choose an option:" +
                    $"\n[1]-{optionMessage1}" +
                    $"\n[2]-{optionMessage2}" +
                    "\n[3]-Comeback");
          
            char userInput = Console.ReadKey(true).KeyChar;
            if(!int.TryParse(Convert.ToString(userInput), out userChoice))
            {
                SimpleMenuFeedBack = false;
                Error(errorMessage);

            }
            else
            {
                SimpleMenuFeedBack = true;
            }
          
        }

        public static bool RequestConfirmation(string message)
        {
            Title(message);
            char letter = char.ToUpper(Console.ReadKey(true).KeyChar);
            if (letter == 'Y')
            {
                return true;
            }
            else
            {
                Console.Clear();
                return false;
            }
            
        }
    }
}
