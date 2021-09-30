using FiveCardPokerGame.ViewModels;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FiveCardPokerGame.Data
{
    public class HighScoreDb : BaseViewModel
    {
        /// <summary>
        /// String prop to display difficulty
        /// </summary>
        public static string Dif { get; set; }

        /// <summary>
        /// Gets the int difficulty and translates to string
        /// </summary>
        /// <param name="difficulty"></param>
        public static void GetDifficulty()
        {
            if (Global.Difficulty == 1)
            {
                Dif = "Hard";
            }
            else if (Global.Difficulty == 2)
            {
                Dif = "Medium";
            }
            else if (Global.Difficulty == 3)
            {
                Dif = "Easy";
            }
        }

        #region Create
        /// <summary>
        /// Sets the highscore in database to a player and chosen difficulty
        /// </summary>
        public static void SetHighscore()
        {
            GetDifficulty();

            string stmt = $"INSERT INTO highscore(score, player_id, difficulty) VALUES (@score, @player_id, @difficulty)";

            try
            {
                using var conn = new NpgsqlConnection(Global.ConnectionString);
                conn.Open();

                using var command = new NpgsqlCommand(stmt, conn);
                command.Parameters.AddWithValue("@score", Global.EndScore);
                command.Parameters.AddWithValue("@player_id", Global.MyPlayer.PlayerId);
                command.Parameters.AddWithValue("@difficulty", Dif);

                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                     Global.EndScore = (int)reader["score"];
                }  
            }
            catch (PostgresException ex)
            {
                
                throw new Exception("Couldn´t add highscore", ex);
            }
        }

        #endregion

        #region Read
        /// <summary>
        /// Gets an observable collection from database for the EndView based on the difficulty the player has played on
        /// </summary>
        /// <returns>ObservableCollection of Highscores</returns>
        public static ObservableCollection<Highscore> GetHighscores()
        {            
            string stmt = $"SELECT player.name, highscore.score, highscore.difficulty, highscore.player_id, DENSE_RANK () OVER ( ORDER BY score DESC ) score_rank FROM player JOIN highscore on player.id=highscore.player_id and highscore.difficulty = '{Dif}' LIMIT 19";

            try
            {
                using var conn = new NpgsqlConnection(Global.ConnectionString);
                conn.Open();

                using var command = new NpgsqlCommand(stmt, conn);
                using var reader = command.ExecuteReader();

                EndOfGameViewModel.HighscoreList = new ObservableCollection<Highscore>();
                Highscore highscore = new();

                while (reader.Read())
                {
                    highscore = new Highscore
                    {
                        Score = (int)reader["score"],                        
                        Difficulty = (string)reader["difficulty"],
                        PlayerId = (int)reader["player_id"],
                        Name = (string)reader["name"],
                        ScoreRank = (long)reader["score_rank"]
                    };
                    EndOfGameViewModel.HighscoreList.Add(highscore);
                    
                }
                return EndOfGameViewModel.HighscoreList;
                
            }
            catch (PostgresException ex)
            {
                
                throw new Exception("Couldn´t retrieve Highscores list", ex);
            }
        }

        /// <summary>
        /// Gets an observable collection from database for the StartView/HighscoreView with highscores on easy difficulty 
        /// </summary>
        /// <returns>ObservableCollection of Highscores on Easy difficulty</returns>
        public static ObservableCollection<Highscore> GetEasyHighScore()
        {
            string stmt = "SELECT player.name, highscore.score, highscore.difficulty, highscore.player_id, DENSE_RANK () OVER ( ORDER BY score DESC ) score_rank FROM player JOIN highscore on player.id=highscore.player_id and highscore.difficulty = 'Easy' LIMIT 19";

            try
            {
                using var conn = new NpgsqlConnection(Global.ConnectionString);
                conn.Open();

                using var command = new NpgsqlCommand(stmt, conn);
                using var reader = command.ExecuteReader();

                ObservableCollection<Highscore> easyList = new();
                Highscore highscore = new();

                while (reader.Read())
                {
                    highscore = new Highscore
                    {
                        Score = (int)reader["score"],
                        Difficulty = (string)reader["difficulty"],
                        PlayerId = (int)reader["player_id"],
                        Name = (string)reader["name"],
                        ScoreRank = (long)reader["score_rank"]

                    };
                    easyList.Add(highscore);
                }
                return easyList;
            }
            catch (PostgresException ex)
            {
                
                throw new Exception("Couldn´t retrieve Highscores list", ex);
            }
        }

        /// <summary>
        /// Gets an observable collection from database for the StartView/HighscoreView with highscores on medium difficulty
        /// </summary>
        /// <returns>ObservableCollection of Highscores on Medium difficulty</returns>
        public static ObservableCollection<Highscore> GetMediumHighScore()
        {
            string stmt = "SELECT player.name, highscore.score, highscore.difficulty, highscore.player_id, DENSE_RANK () OVER ( ORDER BY score DESC ) score_rank FROM player JOIN highscore on player.id=highscore.player_id and highscore.difficulty = 'Medium' LIMIT 19";

            try
            {
                using var conn = new NpgsqlConnection(Global.ConnectionString);
                conn.Open();

                using var command = new NpgsqlCommand(stmt, conn);
                using var reader = command.ExecuteReader();

                ObservableCollection<Highscore> mediumList = new();
                Highscore highscore = new();

                while (reader.Read())
                {
                    highscore = new Highscore
                    {
                        Score = (int)reader["score"],
                        Difficulty = (string)reader["difficulty"],
                        PlayerId = (int)reader["player_id"],
                        Name = (string)reader["name"],
                        ScoreRank = (long)reader["score_rank"]
                    };
                    mediumList.Add(highscore);
                }
                return mediumList;
            }
            catch (PostgresException ex)
            {
                
                throw new Exception("Couldn´t retrieve Highscores list", ex);
            }
        }

        /// <summary>
        ///Gets an observable collection from database for the StartView/HighscoreView with highscores on hard difficulty  
        /// </summary>
        /// <returns>ObservableCollection of Highscores on Hard difficulty</returns>
        public static ObservableCollection<Highscore> GetHardHighScore()
        {
            string stmt = "SELECT player.name, highscore.score, highscore.difficulty, highscore.player_id, DENSE_RANK () OVER ( ORDER BY score DESC ) score_rank FROM player JOIN highscore on player.id=highscore.player_id and highscore.difficulty = 'Hard' LIMIT 19";

            try
            {
                using var conn = new NpgsqlConnection(Global.ConnectionString);
                conn.Open();

                using var command = new NpgsqlCommand(stmt, conn);
                using var reader = command.ExecuteReader();

                ObservableCollection<Highscore> hardList = new();
                Highscore highscore = new();

                while (reader.Read())
                {
                    highscore = new Highscore
                    {
                        Score = (int)reader["score"],
                        Difficulty = (string)reader["difficulty"],
                        PlayerId = (int)reader["player_id"],
                        Name = (string)reader["name"],
                        ScoreRank = (long)reader["score_rank"]
                    };
                    hardList.Add(highscore);
                }
                return hardList;
            }
            catch (PostgresException ex)
            {
                
                throw new Exception("Couldn´t retrieve Highscores list", ex);
            }
        }

        #endregion
    }
}
