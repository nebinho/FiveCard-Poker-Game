using FiveCardPokerGame.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FiveCardPokerGame.Views
{
    /// <summary>
    /// Interaction logic for GameView.xaml
    /// </summary>
    public partial class GameView : UserControl
    {
        public GameView()
        {
            InitializeComponent();
        }

        private void card_DragOver(object sender, DragEventArgs e)
        {            
            object data = e.Data.GetData(DataFormats.Serializable);
            if (data is CardView cardView)
            {
                Point dropPosition = e.GetPosition(dropZone);            
                if (!dropZone.Children.Contains(cardView))
                {
                    GameViewModel gameViewModel = (GameViewModel)DataContext;
                    gameViewModel.RemoveCardCommand.Execute(this);
                    dropZone.Children.Add(cardView);
                }
               
            }
        }

    }
}
