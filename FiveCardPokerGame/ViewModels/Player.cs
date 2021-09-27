namespace FiveCardPokerGame.ViewModels
{
    
    public class Player : PlayerViewModel
    {
        public string Name { get; set; }
        public int PlayerId { get; set; }

        public override string ToString()
        {
            return $"{Name}";
        }

    }
}
