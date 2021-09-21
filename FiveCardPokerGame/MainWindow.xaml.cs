using FiveCardPokerGame.Data;
using FiveCardPokerGame.ViewModels;
using FiveCardPokerGame.Views;
using System.Windows;

namespace FiveCardPokerGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            
            InitializeComponent();
            DataContext = new MainViewModel();
            DeckOfCards deckOfCards = new DeckOfCards();
            EvaluateHand evaluateHand = new EvaluateHand();
            GameViewModel game = new GameViewModel();
            PlayerDb playerDb = new PlayerDb();
            StartView startView = new StartView();
        }
        
    }
}
