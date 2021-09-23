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

        public static string dif { get; set; }

        public static void GetDifficulty(int difficulty)
        {
            if (Global.Difficulty == 1)
            {
                dif = "hard";
            }
            else if (Global.Difficulty == 2)
            {
                dif = "medium";
            }
            else if (Global.Difficulty == 3)
            {
                dif = "easy";
            }


        }

        #region Create
        public void SetHighscore()
        {
            GetDifficulty(Global.Difficulty);

            string stmt = $"INSERT INTO highscore(score, player_id, difficulty) VALUES (@score, @player_id, @difficulty)";

            try
            {
                using var conn = new NpgsqlConnection(Global.ConnectionString);
                conn.Open();
                using var command = new NpgsqlCommand(stmt, conn);
                command.Parameters.AddWithValue("@score", Global.EndScore);
                command.Parameters.AddWithValue("@player_id", Global.MyPlayer.PlayerId);
                command.Parameters.AddWithValue("@difficulty", dif);

                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                     Global.EndScore = (int)reader["score"];
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
            string stmt = $"SELECT * FROM highscore WHERE highscore.difficulty = '{dif}' ORDER BY score DESC";

            try
            {
                using var conn = new NpgsqlConnection(Global.ConnectionString);
                conn.Open();
                using var command = new NpgsqlCommand(stmt, conn);
                using var reader = command.ExecuteReader();


                Global.HighscoreList = new ObservableCollection<Highscore>();
                Highscore highscore = new Highscore();
                while (reader.Read())
                {
                    //highscore = null;
                    highscore = new Highscore
                    {
                        HighscoreId = (int)reader["highscore_id"],
                        Score = (int)reader["score"],
                        Difficulty = (string)reader["difficulty"],
                        PlayerId = (int)reader["player_id"]

                    }; 
                    Global.HighscoreList.Add(highscore);

                }

                return Global.HighscoreList;                

            }
            catch (PostgresException ex)
            {
                string errorcode = ex.SqlState;
                throw new Exception("Couldn´t retrieve Highscore list", ex);
            }

        }

        #endregion

        #region Update
        //public void UpdateHighScore()
        //{
        //    string stmt = $"UPDATE highscore SET score = {Global.MyHighscore.Score} WHERE id = {Global.MyPlayer.PlayerId}";

        //    try
        //    {
        //        using var conn = new NpgsqlConnection(Global.ConnectionString);
        //        conn.Open();
        //        using var command = new NpgsqlCommand(stmt, conn);

        //        command.Parameters.AddWithValue("@score", Global.MyHighscore.Score);

        //        using var reader = command.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            Global.MyHighscore.HighscoreId = (int)reader["id"];
        //        }



        //    }
        //    catch (PostgresException ex)
        //    {
        //        string errorcode = ex.SqlState;
        //        throw new Exception("FFELLL", ex);
        //    }
        //}
        #endregion

    }
}
