using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCardApp
{
    public class FlashCard
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public int Id { get; set; }


        public static FlashCard CreateFlashCardItem(string newQuestion, string newAnswer, int newId)
        {
            return new FlashCard()
            {
                Question = newQuestion,
                Answer = newAnswer,
                Id = newId
            };
        }
    }
    
}
