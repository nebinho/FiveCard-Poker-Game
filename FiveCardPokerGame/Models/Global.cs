using FiveCardPokerGame.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;


namespace FiveCardPokerGame.ViewModels
{
    internal class Global
    {
        public static Player MyPlayer { get; set; }
        public static int Difficulty { get; set; }
        public static int EndScore { get; set; }
        public static string EndHand { get; set; }
        public static string ConnectionString { get; } = "Server = studentpsql.miun.se; Port=5432; Database=sup_db2; User ID = sup_g2; Password=spelmarker; Trust Server Certificate = true; sslmode = Require";
        public static ObservableCollection<CardView> FinalHand { get; set; }



        /// <summary>
        /// Diffrent methods for playing specific sounds. Can be used everywhere in the game.
        /// </summary>
        #region Sounds
        public static void PlayDrawCardSound()
        {
            SoundPlayer player = new(Resources.Sounds.GameSounds.Swoosh1);
            player.Play();
        }

        public static void PlayDragAndDropSound()
        {
            SoundPlayer player = new(Resources.Sounds.GameSounds.DragAndDrop1);
            player.Play();
        }

        public static void PlayClickSound()
        {
            SoundPlayer player = new(Resources.Sounds.GameSounds.Click);
            player.Play();
        }

        public static void PlayNoPointsSound()
        {
            SoundPlayer player = new(Resources.Sounds.GameSounds.NoPoints);
            player.Play();
        }

        public static void PlayPointsSound()
        {
            SoundPlayer player = new(Resources.Sounds.GameSounds.Points);
            player.Play();
        }

        public static void PlayHighScoreSound()
        {
            SoundPlayer player = new(Resources.Sounds.GameSounds.HighScore);
            player.Play();
        }

        #endregion

    }
}
