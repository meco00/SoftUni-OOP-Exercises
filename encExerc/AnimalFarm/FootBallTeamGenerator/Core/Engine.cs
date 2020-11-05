using FootBallTeamGenerator.Common;
using FootBallTeamGenerator.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;

namespace FootBallTeamGenerator.Core
{
    public class Engine
    {
        private readonly ICollection<Team> teams;


        public Engine()
        {
            this.teams = new List<Team>();
        }

        public void Run()
        {


            string command = Console.ReadLine();
            while (command != "END")
            {
                try
                {
                    var input = command.Split(";", StringSplitOptions.RemoveEmptyEntries).ToArray();

                    if (input[0] == "Team")
                    {
                        string teamName = input[1];

                        this.teams.Add(new Team(teamName));

                    }
                    else if (input[0] == "Add")
                    {
                        string teamName = input[1];
                        IsContainsSuchATeam(teamName);

                        string playerName = input[2];
                        var statInput = input.Skip(3).Select(int.Parse).ToArray();

                        Stats stat = new Stats(statInput[0], statInput[1], statInput[2], statInput[3], statInput[4]);
                        Player player = new Player(playerName, stat);

                        var current = teams.FirstOrDefault(x => x.Name == teamName);
                        current.AddPlayer(player);



                    }
                    else if (input[0] == "Remove")
                    {
                        string teamName = input[1];
                        IsContainsSuchATeam(teamName);

                        string playerName = input[2];

                        var currrentTeam = GetCurrentTeam(teamName);

                        currrentTeam.RemovePlayer(playerName);

                    }
                    else if (input[0] == "Rating")
                    {
                        string teamName = input[1];
                        IsContainsSuchATeam(teamName);

                        var currrentTeam = GetCurrentTeam(teamName);


                        Console.WriteLine(currrentTeam.ToString());
                    }

                }
                catch (Exception ae)
                {

                    Console.WriteLine(ae.Message);
                }
               







                command = Console.ReadLine();
            }
        }





        public void AddTeam(string name)
        {
            teams.Add(new Team(name));
        }

        public void ShowStats(string teamName)
        {
            var current = teams.FirstOrDefault(x => x.Name == teamName);

            if (current == null)
            {
                throw new Exception(String.Format(CommonGeneral.MISSING_TEAM_MSG, teamName));

            }

            Console.WriteLine(current.ToString());

        }


        public void IsContainsSuchATeam(string teamName)
        {
            var currentTeam = teams.FirstOrDefault(x => x.Name == teamName);

            if (currentTeam == null)
            {
                throw new Exception(String.Format(CommonGeneral.MISSING_TEAM_MSG, teamName));

            }

        }

        public Team GetCurrentTeam(string input) => this.teams.First(x => x.Name == input);




    }








}




     
    

