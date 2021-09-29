namespace FiveCardPokerGame.ViewModels
{
    
    public class Player : BaseViewModel
    {
        public string Name { get; set; }
        public int PlayerId { get; set; }
        /// <summary>
        /// Returns Name(string) if displaying the object.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Name}";
        }

    }
}
