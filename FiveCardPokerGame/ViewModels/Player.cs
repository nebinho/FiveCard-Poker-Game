namespace FiveCardPokerGame.ViewModels
{
    public partial class PlayerViewModel
    {
        public class Player : PlayerViewModel
        {
            public string Name { get; set; }
            public int PlayerId { get; set; }
            public int HighScore { get; set; }

            public override string ToString()
            {
                return $"{Name}";
            }



        }
        
    }
}
