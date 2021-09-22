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
            UpdateViewAndSaveDataCommand = new UpdateViewAndSaveDataCommand(this);
            CreatePlayerCommand = new CreatePlayerCommand(this);
            
        }
        public ObservableCollection<Player> Players { get; set; }
        public Player SelectedPlayer { get; set; }
        public ObservableCollection<int> Difficulty { get; set; } = new ObservableCollection<int> { 1,2,3};
        public int SelectedDifficulty { get; set; }
        public BaseViewModel SelectedViewModel { get; set; }
        public ICommand UpdateViewAndSaveDataCommand { get; set; }

        public ICommand CreatePlayerCommand { get; set; }
        public string NewPlayer { get; set; }
        public bool BtnEnabler { get; set; }
        public string AlrdyExists { get; set;  }
        

        //public bool HasContent() // försöka göra så att knappen är disabled när man inte skrivit in nån ny spelare
        //{
        //    if (NewPlayer == null)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}

        


        #region Read
        public void CreatePlayer(string NewPlayer)
        {
            AlrdyExists = null;
            string stmt = $"insert into player(name) values (@name)";
            if (NewPlayer!= null)
            {
                try
                {
                    using var conn = new NpgsqlConnection(Global.ConnectionString);
                    conn.Open();
                    using var command = new NpgsqlCommand(stmt, conn);
                    //Player p1 = new Player();
                    command.Parameters.AddWithValue("@name", NewPlayer);


                    using var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        NewPlayer = (string)reader["name"];
                        
                    }
                    AlrdyExists = $"{NewPlayer} är skapad";


                }
                catch (PostgresException ex)
                {
                    string errorcode = ex.SqlState;
                    AlrdyExists = "Namnet finns redan, vänligen välj ett annat";
                    //throw new Exception(AlrdyExists = "Namnet finns redan", ex);
                }
                var player = SelectPlayer(NewPlayer);
                Global.MyPlayer = player;
            }
            else
            {
                
                
            }
        }
        public Player SelectPlayer(string NewPlayer)
        {
            Player player = null;
            string stmt = "select * from player where name = @name";
            try
            {
                using var conn = new NpgsqlConnection(Global.ConnectionString);
                
                conn.Open();
                using var command = new NpgsqlCommand(stmt, conn);
                command.Parameters.AddWithValue("@name", NewPlayer);

                using var reader = command.ExecuteReader();
                //Player player = null;

                while (reader.Read())
                {
                    
                    player = new Player
                    {
                        PlayerId = (int)reader["id"],
                        Name = (string)reader["name"],

                    };
                    
                }
                return player;
            }
            
          
            
            catch (PostgresException ex)
            {

                string errorcode = ex.SqlState;
                throw new Exception("fel", ex);
            }


        }
        //public Player UpdateHighScore(Player player)
        //{
        //    string stmt = "update player set highscore = @highscore where id =@id";

        //    try
        //    {
        //        using var conn = new NpgsqlConnection(connectionString);
        //        conn.Open();
        //        using var command = new NpgsqlCommand(stmt, conn);
        //        //Player p1 = new Player();
        //        command.Parameters.AddWithValue("@highscore", player.HighScore);
        //        command.Parameters.AddWithValue("@id", player.PlayerId);


        //        using var reader = command.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            player.HighScore = (int)reader["highscore"];
        //        }

        //        return player;

        //    }
        //    catch (PostgresException ex)
        //    {
        //        string errorcode = ex.SqlState;
        //        throw new Exception("FFELLL", ex);
        //    }
        //}
        #endregion

        public ObservableCollection<Player> GetPlayers()
        {
            string stmt = "select * from player order by name asc";

            try
            {
                Players = new ObservableCollection<Player>();
                using var conn = new NpgsqlConnection(Global.ConnectionString);
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
                        PlayerId = (int)reader["id"]
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
