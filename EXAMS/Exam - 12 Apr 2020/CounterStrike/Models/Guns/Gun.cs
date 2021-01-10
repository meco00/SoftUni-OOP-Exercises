﻿using CounterStrike.Models.Guns.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Models.Guns
{
    public abstract class Gun : IGun
    {
        private string name;
        private int bulletsCount;

        public Gun(string name, int bulletsCount)
        {
            this.Name = name;
            this.BulletsCount = bulletsCount;

        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"Gun cannot be null or empty.");
                }
                this.name = value;
            }
        }

        public int BulletsCount
        {
            get
            {
                return this.bulletsCount;
            }
            
            protected set
            {
                if (value<0)
                {
                    throw new ArgumentException($"Bullets cannot be below 0.");
                }
                this.bulletsCount = value;
            }
        }

        public abstract int FireRate { get; }

        public int Fire()
        {
            if (BulletsCount>=FireRate)
            {
                BulletsCount -= FireRate;
                return FireRate;
            }

            return 0;
        }
       
    }
}
