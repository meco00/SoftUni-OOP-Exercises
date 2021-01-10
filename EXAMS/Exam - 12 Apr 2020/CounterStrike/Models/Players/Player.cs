using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string username;
        private int health;
        private int armor;
        private IGun gun;

        public Player(string username, int health, int armor, IGun gun)
        {
            this.Username = username;
            this.Health = health;
            this.Armor = armor;
            this.Gun = gun;

        }

        public string Username
        {
            get
            {
                return this.username;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"Username cannot be null or empty.");
                }
                this.username = value;
            }
        }
        public int Health
        {
            get
            {
                return this.health;
            }
           
            private set
            {
                //TODO:CHANGE TO BELOW ONLY IF FAIL
                if (value < 0)
                {
                    throw new ArgumentException($"Player health cannot be below or equal to 0.");
                }
                this.health = value;
            }
        }

        public int Armor
        {
            get
            {
                return this.armor;
            }
            
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"Player armor cannot be below 0.");
                }
                this.armor = value;
            }
        }

        public IGun Gun
        {
            get { return this.gun; }
            private set
            {
                if (value is null)
                {
                    throw new ArgumentException("Gun cannot be null or empty.");

                }
                this.gun = value;
            }
        }

        public bool IsAlive => this.Health>0;

        public void TakeDamage(int points)
        {
            if (this.Armor-points>=0)
            {
                this.Armor -= points;
                return;

            }
            else if (this.Armor>0)
            {
                points -= this.Armor;
                this.Armor = 0;

            }

            this.health -= points;
            if (this.health<0)
            {
                this.health = 0;

            }


        }

        public override string ToString()
        {
           


            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.GetType().Name}: { this.Username}");
            sb.AppendLine($"--Health: { this.Health}");
            sb.AppendLine($"--Armor: { this.Armor}");
            sb.AppendLine($"--Gun: {this.Gun.Name}");

            return sb.ToString().TrimEnd();
        }


    }
    }

