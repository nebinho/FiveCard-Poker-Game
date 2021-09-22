using FiveCardPokerGame.ViewModels;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveCardPokerGame.Data
{
    public class HighScoreDb : BaseViewModel
    {

        private static readonly string connectionString = "Server = studentpsql.miun.se; Port=5432; Database=sup_db2; User ID = sup_g2; Password=spelmarker; Trust Server Certificate = true; sslmode = Require";

        public ObservableCollection<Highscore> Highscores { get; set; }


        #region Create
        public void SetHighscore(Highscore highscore, Player player)
        {
            string stmt = $"INSERT INTO highscore(score, player_id, difficulty) VALUES ({highscore.Score}, {player.PlayerId}, {highscore.Difficulty})";


            try
            {
                using var conn = new NpgsqlConnection(connectionString);
                conn.Open();
                using var command = new NpgsqlCommand(stmt, conn);
                command.Parameters.AddWithValue("@score", highscore.Score);
                command.Parameters.AddWithValue("@player_id", player.PlayerId);
                command.Parameters.AddWithValue("@difficulty", highscore.Difficulty);

                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    highscore.HighscoreId = (int)reader["id"];
                }

            }
            catch (PostgresException ex)
            {
                string errorcode = ex.SqlState;
                throw new Exception("Couldn´t add highscore", ex);
            }

        }

        #endregion

        #region Read

        #endregion

        #region Update
        public void UpdateHighScore(Player player, Highscore highscore)
        {
            string stmt = $"UPDATE highscore SET score = {highscore.Score} WHERE id = {player.PlayerId}";

            try
            {
                using var conn = new NpgsqlConnection(connectionString);
                conn.Open();
                using var command = new NpgsqlCommand(stmt, conn);

                command.Parameters.AddWithValue("@score", highscore.Score);

                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    highscore.HighscoreId = (int)reader["id"];
                }



            }
            catch (PostgresException ex)
            {
                string errorcode = ex.SqlState;
                throw new Exception("FFELLL", ex);
            }
        }
        #endregion

    }
}
