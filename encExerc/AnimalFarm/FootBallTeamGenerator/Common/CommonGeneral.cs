using System;
using System.Collections.Generic;
using System.Text;

namespace FootBallTeamGenerator.Common
{
   public class CommonGeneral
    {
        public static string INVALID_STAT_INPUT = "{0} should be between {1} and {2}.";
        public static string INVALID_PLAYER_REMOVE = "Player {0} is not in {1} team.";
        public static string MISSING_TEAM_MSG = "Team {0} does not exist.";



        public static void ValidateNames(string input)
        {
            if (String.IsNullOrEmpty(input)||String.IsNullOrWhiteSpace(input))
            {
                throw new Exception("A name should not be empty.");
            }
        }
    }
}
