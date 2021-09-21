using FiveCardPokerGame.Commands;
using FiveCardPokerGame.ViewModels;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using static FiveCardPokerGame.ViewModels.PlayerViewModel;

namespace FiveCardPokerGame.Data
{
    public class PlayerDb : BaseViewModel
    {
        public PlayerDb()
        {
            GetPlayers();
            UpdateViewCommand = new UpdateViewCommand(this);

        }
        public ObservableCollection<Player> Players { get; set; }
        public Player SelectedPlayer { get; set; }
        public ObservableCollection<int> Difficulty { get; set; } = new ObservableCollection<int> { 1,2,3};
        public int SelectedDifficulty { get; set; }
        public BaseViewModel SelectedViewModel { get; set; }
        public ICommand UpdateViewCommand { get; set; }




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

        public ObservableCollection<Player> GetPlayers()
        {
            string stmt = "select * from player order by name asc";

            try
            {
                Players = new ObservableCollection<Player>();
                using var conn = new NpgsqlConnection(connectionString);
                conn.Open();
                using var command = new NpgsqlCommand(stmt, conn);
                using var reader = command.ExecuteReader();
                
                //Player player = null;
                //var Players = new List<Player>();

                
                while (reader.Read())
                {
                    Player asd = null;
                    Player player = null;
                     player = new Player
                    {
                       
                        Name = (string)reader["name"],
                        
                    };
                    asd = player;
                    Players.Add(asd);

                }

                return Players;

            }
            catch (PostgresException ex)
            {
                string errorcode = ex.SqlState;
                throw new Exception("FFELLL", ex);
            }
        }
    }
}
