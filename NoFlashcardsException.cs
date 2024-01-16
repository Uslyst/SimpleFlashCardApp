using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCardApp
{
    public  class NoFlashcardsException : Exception 
    {      
        public NoFlashcardsException() : base("The file is created but there are no flashcards in it")    
        { 
        
        }     
    }
    public class EmptyFieldException : Exception
    {
        public EmptyFieldException() : base("A field cannot be empty")
        {

        }
    }
    
    public class NonExistentIdException : Exception
    {
        public NonExistentIdException() : base("This ID doesn't exists")
        {

        }
    }

}
