using System;

namespace FiveCardPokerGame.ViewModels
{
    internal class DelegateCommand
    {
        private Func<bool> enableButton;

        public DelegateCommand(Func<bool> enableButton)
        {
            this.enableButton = enableButton;
        }
    }
}