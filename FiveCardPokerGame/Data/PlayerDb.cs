using FiveCardPokerGame.ViewModels;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FiveCardPokerGame.ViewModels.PlayerViewModel;

namespace FiveCardPokerGame.Data
{
    public class PlayerDb : BaseViewModel
    {

        private static readonly string connectionString = "Server = studentpsql.miun.se; Port=5432; Database=sup_db2; User ID = sup_g2; Password=spelmarker; Trust Server Certificate = true; sslmode = Require";

        #region Read
        public Player CreatePlayer(Player player)
        {
            string stmt = $"insert into player(name, highscore) values (@name, @highscore) returning id";


            try
            {
                using var conn = new NpgsqlConnection(connectionString);
                conn.Open();
                using var command = new NpgsqlCommand(stmt, conn);
                //Player p1 = new Player();
                command.Parameters.AddWithValue("@name", player.Name);
                command.Parameters.AddWithValue("@highscore", player.HighScore);

                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    player.PlayerId = (int)reader["id"];
                }

                return player;

            }
            catch (PostgresException ex)
            {
                string errorcode = ex.SqlState;
                throw new Exception("FFELLL", ex);
            }
        }

        public Player UpdateHighScore(Player player)
        {
            string stmt = "update player set highscore = @highscore where id =@id";

            try
            {
                using var conn = new NpgsqlConnection(connectionString);
                conn.Open();
                using var command = new NpgsqlCommand(stmt, conn);
                //Player p1 = new Player();
                command.Parameters.AddWithValue("@highscore", player.HighScore);
                command.Parameters.AddWithValue("@id", player.PlayerId);


                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    player.HighScore = (int)reader["highscore"];
                }

                return player;

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
