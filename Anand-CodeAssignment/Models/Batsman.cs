using System.Collections.Generic;

namespace CodeAssignment.Models
{
    public class PlayersList
    {
        public string PlayerName { get; set; }
        public int IsRetired { get; set; }
    }

    public class Batsman
    {
        public string Batsmanname { get; set; }
        public int RunsScored { get; set; }
        public float StrikeRate { get; set; }
    }

    public class TeamDetails
    {
        public string Name_Full { get; set; }
        public string Name_Short { get; set; }
        public object Players { get; set; }
    }

    public class PlayerDetails
    {
        public string Position { get; set; }
        public string Name_Full { get; set; }
        public bool IsCaptain { get; set; }
    }


    public class Players
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
    }

    public class Playerswicket
    {
        public int PlayerId { get; set; }
        public int Wickets { get; set; }
    }

    public class PlayerswicketData
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public int Wickets { get; set; }
    }





}
