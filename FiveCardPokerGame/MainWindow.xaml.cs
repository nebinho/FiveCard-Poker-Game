using FiveCardPokerGame.ViewModels;
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
            GameViewModel game = new GameViewModel();
        }
        
    }
}
