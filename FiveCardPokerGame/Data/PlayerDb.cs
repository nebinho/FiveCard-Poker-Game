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

        /// <summary>
        /// ObservableCollection to store Players from database
        /// </summary>
        public ObservableCollection<Player> Players { get; set; }
        /// <summary>
        /// Prop to store selected player from the StartView
        /// </summary>
        public Player SelectedPlayer { get; set; }
        /// <summary>
        /// Dictionary to translate the int difficulty to a string for show on StartView
        /// </summary>
        public Dictionary<int, string> DifficultyDictionary { get; set; } = new Dictionary<int, string>();
        /// <summary>
        /// Prop to store selected difficulty from StartView
        /// </summary>
        public int SelectedDifficulty { get; set; }
        public BaseViewModel SelectedViewModel { get; set; }
        public ICommand UpdateViewAndSaveDataCommand { get; set; }
        public ICommand CreatePlayerCommand { get; set; }
        /// <summary>
        /// Prop to store new player if a user creates one
        /// </summary>
        public string NewPlayer { get; set; }
        /// <summary>
        /// Prop to display feedback for the user if player and difficulty are not selected
        /// </summary>
        public string FeedbackString { get; set;  }
        public ICommand RulesCommand { get; set; }
        public ICommand HighScoreListsCommand { get; set; }

        #region Read
        /// <summary>
        /// Gets observable collection of created players from database to display in listbox on StartView for user to choose
        /// </summary>
        /// <returns>ObservableCollection of Players</returns>
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

        /// <summary>
        /// Method to get and select new created player from database 
        /// </summary>
        /// <param name="NewPlayer"></param>
        /// <returns>Player</returns>
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
        /// <summary>
        /// Method to create and store new created player in database
        /// </summary>
        /// <param name="NewPlayer"></param>
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
