using FiveCardPokerGame.Data;
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
    /// Interaction logic for StartView.xaml
    /// </summary>
    public partial class StartView : MasterGameView
    {
        //public readonly PlayerDb PlayerDb;
        public StartView()
        {
            InitializeComponent();
            

        }

        private void getplayers_Click(object sender, RoutedEventArgs e)
        {
            

                //MessageBox.Show($"{PlayerDb.SelectedPlayer}");
            
        }

        //private void playerlist_DropDownOpened(object sender, EventArgs e)
        //{
        //    playerlist.ItemsSource = null;
        //    playerlist.ItemsSource = PlayerDb.GetPlayers();
        //    playerlist.UpdateLayout();
        //}
    }
}
