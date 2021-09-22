using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FiveCardPokerGame.ViewModels.PlayerViewModel;

namespace FiveCardPokerGame.ViewModels
{
    internal class Global
    {
        public static Player MyPlayer { get; set; }
        public static int Difficulty { get; set; }
        public static int EndScore { get; set; }
    }
}
