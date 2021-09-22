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


        public ObservableCollection<Highscore> Highscores { get; set; }


        public void GetDifficulty()
        {
            if (Global.Difficulty == 1)
            {
                Global.MyHighscore.Difficulty = "hard";
            }
            else if (Global.Difficulty == 2)
            {
                Global.MyHighscore.Difficulty = "medium";
            }
            else if (Global.Difficulty == 3)
            {
                Global.MyHighscore.Difficulty = "easy";
            }


        }

        #region Create
        public void SetHighscore(Highscore highscore)
        {
            string stmt = $"INSERT INTO highscore(score, player_id, difficulty) VALUES ({highscore.Score}, {Global.MyPlayer}, {highscore.Difficulty})";


            try
            {
                using var conn = new NpgsqlConnection(Global.ConnectionString);
                conn.Open();
                using var command = new NpgsqlCommand(stmt, conn);
                command.Parameters.AddWithValue("@score", highscore.Score);
                command.Parameters.AddWithValue("@player_id", Global.MyPlayer.PlayerId);
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

        public ObservableCollection<Highscore> GetHighscores()
        {
            string stmt = $"SELECT * FROM highscore WHERE difficulty = {Global.MyHighscore.Difficulty} ORDER BY score dsc";

            try
            {
                using var conn = new NpgsqlConnection(Global.ConnectionString);
                conn.Open();
                using var command = new NpgsqlCommand(stmt, conn);
                using var reader = command.ExecuteReader();

                Highscore highscore = null;

                var highscores = new ObservableCollection<Highscore>();

                while (reader.Read())
                {
                    highscore = new Highscore
                    {

                        Score = (int)reader["score"],
                        Difficulty = (string)reader["difficulty"]

                    };
                    highscores.Add(highscore);

                }

                return highscores;

            }
            catch (PostgresException ex)
            {
                string errorcode = ex.SqlState;
                throw new Exception("Couldn´t retrieve Highscore list", ex);
            }
        }

        #endregion

        #region Update
        public void UpdateHighScore()
        {
            string stmt = $"UPDATE highscore SET score = {Global.MyHighscore.Score} WHERE id = {Global.MyPlayer.PlayerId}";

            try
            {
                using var conn = new NpgsqlConnection(Global.ConnectionString);
                conn.Open();
                using var command = new NpgsqlCommand(stmt, conn);

                command.Parameters.AddWithValue("@score", Global.MyHighscore.Score);

                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Global.MyHighscore.HighscoreId = (int)reader["id"];
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
