namespace FiveCardPokerGame.ViewModels
{
    public partial class PlayerViewModel
    {
        public class Player : PlayerViewModel
        {
            public string Name { get; set; }
            public int PlayerId { get; set; }
            public int HighScore { get; set; }
            public int HighScoreID { get; set; }
            public Player()
            {
                Name = "kevin";
                HighScore = 50;
                //PlayerId = 1;
            }

            

        }
        
    }
}
