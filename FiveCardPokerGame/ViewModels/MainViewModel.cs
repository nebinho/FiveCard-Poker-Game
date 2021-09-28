using FiveCardPokerGame.Commands;
using FiveCardPokerGame.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveCardPokerGame.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public PlayerDb CurrentViewModel { get; set; } = new PlayerDb();
        
    }
}
