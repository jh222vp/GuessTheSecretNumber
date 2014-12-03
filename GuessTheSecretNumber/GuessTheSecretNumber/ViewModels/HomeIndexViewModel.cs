using GuessTheSecretNumber.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GuessTheSecretNumber.ViewModels
{
    public class HomeIndexViewModel
    {
        public SecretNumber SecretNumber { get; set; }
        [Required]
        //[Range(1, 100)]
        public int? Guess { get; set; }
        public string OutcomeMessage
        {
            get
            {
                switch (SecretNumber.LastGuessedNumber.Outcome)
                {
                    case Outcome.Indefinite: {return "Du har inte gjort någon gissning..";  }
                    case Outcome.Low: { return "Du gissade för lågt";  }
                    case Outcome.High: { return "Du gissade för högt";  }
                    case Outcome.Right: { return "Hurra! Nu har du gissat rätt";  }
                    case Outcome.NoMoreGuesses: { return  "Du har inga gissningar kvar";  }
                    case Outcome.OldGuess: { return "Det här talet har du redan gissat på";  }
                    default: { throw new ArgumentOutOfRangeException(); }
                }
            }
        }
        //Varför går ej detta?
        /* public void OutMessage()
         {
             switch (SecretNumber.LastGuessedNumber.Outcome)
             {
                 case Outcome.Indefinite: {OutcomeMessage = "Du har inte gjort någon gissning.."; break; }
                 case Outcome.Low: { OutcomeMessage = "Du gissade för lågt"; break; }
                 case Outcome.High: { OutcomeMessage = "Du gissade för högt"; break; }
                 case Outcome.Right: { OutcomeMessage = "Hurra! Nu har du gissat rätt"; break; }
                 case Outcome.NoMoreGuesses: { OutcomeMessage = "Du har inga gissningar kvar"; break; }
                 case Outcome.OldGuess: { OutcomeMessage = "Det här talet har du redan gissat på"; break; }
                 default: { break; }
             }
         }*/
    }
}