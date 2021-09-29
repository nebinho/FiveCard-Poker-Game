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
        /// <summary>
        /// Selects the first view for the game. PlayerDb is linked to StartView in App.xaml
        /// </summary>
        public PlayerDb CurrentViewModel { get; set; } = new PlayerDb();
        
    }
}
