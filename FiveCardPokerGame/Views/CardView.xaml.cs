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
using static FiveCardPokerGame.ViewModels.Card;

namespace FiveCardPokerGame.Views
{
    /// <summary>
    /// Interaction logic for CardView.xaml
    /// </summary>
    public partial class CardView : UserControl
    {

        public Card GetCard
        {
            get { return (Card)GetValue(GetCardProperty); }
            set { SetValue(GetCardProperty, value); }
        }


        // Using a DependencyProperty as the backing store for GetSuit.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GetCardProperty =
            DependencyProperty.Register("GetCard", typeof(Card), typeof(CardView), new PropertyMetadata(new Card()));



        //public Card CardHeight
        //{
        //    get { return (Card)GetValue(CardHeightProperty); }
        //    set { SetValue(CardHeightProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for CardHeight.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty CardHeightProperty =
        //    DependencyProperty.Register("CardHeight", typeof(Card), typeof(CardView), new PropertyMetadata(712));



        //public Card CardWidth
        //{
        //    get { return (Card)GetValue(CardWidthProperty); }
        //    set { SetValue(CardWidthProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for CardWidth.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty CardWidthProperty =
        //    DependencyProperty.Register("CardWidth", typeof(Card), typeof(CardView), new PropertyMetadata(512));


        protected void MoveCard(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragDrop.DoDragDrop(this, new DataObject(DataFormats.Serializable, this), DragDropEffects.Move);               
            }
        }

        

        public CardView()
        {
            InitializeComponent();
            
        }
    }
}
