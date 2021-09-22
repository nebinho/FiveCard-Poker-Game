using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveCardPokerGame.ViewModels
{
   public class EndOfGameViewModel : BaseViewModel
    {
        public string EndScore { get; set; }

        public EndOfGameViewModel()
        {
            EndScore = Global.EndScore.ToString();
        }
    }
}
