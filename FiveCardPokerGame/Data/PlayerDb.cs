using FiveCardPokerGame.Commands;
using FiveCardPokerGame.ViewModels;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Media;
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
            DifficultyDictionary[1] = "Hard - 1 Draw";
            DifficultyDictionary[2] = "Medium - 2 Draws";
            DifficultyDictionary[3] = "Easy - 3 Draws";
            RulesCommand = new RulesCommand(this);
            HighScoreListsCommand = new HighScoreListsCommand(this);
        }
        public ObservableCollection<Player> Players { get; set; }
        public Player SelectedPlayer { get; set; }
        //public ObservableCollection<int> Difficulty { get; set; } = new ObservableCollection<int> { 1,2,3};
        public Dictionary<int, string> DifficultyDictionary { get; set; } = new Dictionary<int, string>();
        public int SelectedDifficulty { get; set; }
        public BaseViewModel SelectedViewModel { get; set; }
        public ICommand UpdateViewAndSaveDataCommand { get; set; }
        public ICommand CreatePlayerCommand { get; set; }
        public string NewPlayer { get; set; }
        public bool BtnEnabler { get; set; }
        public string FeedbackString { get; set;  }
        public ICommand RulesCommand { get; set; }
        public ICommand HighScoreListsCommand { get; set; }

        #region Read
        public ObservableCollection<Player> GetPlayers()
        {
            string stmt = "SELECT * FROM player ORDER BY name ASC";

            try
            {
                Players = new ObservableCollection<Player>();
                using var conn = new NpgsqlConnection(Global.ConnectionString);
                conn.Open();

                using var command = new NpgsqlCommand(stmt, conn);
                using var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Player player = null;
                    player = new Player
                    {
                        Name = (string)reader["name"],
                        PlayerId = (int)reader["id"]
                    };
                    Players.Add(player);
                }
                return Players;
            }
            catch (PostgresException ex)
            {
                string errorcode = ex.SqlState;
                throw new Exception("Couldn´t retrieve Players list", ex);
            }
        }

        public Player SelectPlayer(string NewPlayer)
        {
            Player player = null;
            string stmt = "SELECT * FROM player WHERE name = @name";
            try
            {
                using var conn = new NpgsqlConnection(Global.ConnectionString);
                conn.Open();

                using var command = new NpgsqlCommand(stmt, conn);
                command.Parameters.AddWithValue("@name", NewPlayer);

                using var reader = command.ExecuteReader();
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
                throw new Exception("Player couldn´t be selected", ex);
            }
        }
        #endregion

        #region Create
        public void CreatePlayer(string NewPlayer)
        {
            FeedbackString = null;
            string stmt = $"INSERT INTO player(name) VALUES (@name)";
            if (NewPlayer != null)
            {
                try
                {
                    using var conn = new NpgsqlConnection(Global.ConnectionString);
                    conn.Open();

                    using var command = new NpgsqlCommand(stmt, conn);
                    command.Parameters.AddWithValue("@name", NewPlayer);

                    using var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        NewPlayer = (string)reader["name"];
                    }
                    FeedbackString = $"{NewPlayer} is created and selected!";
                }
                catch (PostgresException ex)
                {
                    string errorcode = ex.SqlState;
                    FeedbackString = "The name already exists, please choose another name";
                }
                var player = SelectPlayer(NewPlayer);
                Global.MyPlayer = player;
                SelectedPlayer = player;
            }
            else
            {
            }
        }
        #endregion

    }
}
