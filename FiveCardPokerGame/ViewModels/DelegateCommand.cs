using System;

namespace FiveCardPokerGame.ViewModels
{
    internal class DelegateCommand
    {
        private readonly Func<bool> enableButton;

        public DelegateCommand(Func<bool> enableButton)
        {
            this.enableButton = enableButton;
        }
    }
}