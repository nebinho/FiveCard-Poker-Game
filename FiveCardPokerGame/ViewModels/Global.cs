using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FiveCardPokerGame.ViewModels.PlayerViewModel;

namespace FiveCardPokerGame.ViewModels
{
    internal class Global
    {
        public static Player MyPlayer { get; set; }
        public static Highscore MyHighscore { get; set; }
        public static int Difficulty { get; set; }
        public static int EndScore { get; set; }
        public static string ConnectionString { get; } = "Server = studentpsql.miun.se; Port=5432; Database=sup_db2; User ID = sup_g2; Password=spelmarker; Trust Server Certificate = true; sslmode = Require";

    }
}
