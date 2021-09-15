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



        public string SetScore
        {
            get { return (string)GetValue(SetScoreProperty); }
            set { SetValue(SetScoreProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SetScore.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SetScoreProperty =
            DependencyProperty.Register("SetScore", typeof(string), typeof(GameView), new PropertyMetadata("0"));

        



        public GameView()
        {
            InitializeComponent();
            
        }
    }
}
