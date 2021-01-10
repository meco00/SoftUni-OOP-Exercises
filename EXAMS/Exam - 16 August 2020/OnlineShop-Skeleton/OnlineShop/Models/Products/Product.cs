﻿using OnlineShop.Common.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products
{
    public abstract class Product : IProduct
    {
        private int id;
        private string manufacturer;
        private string model;
        private decimal price;
        private double overallPerformance;


        public Product(int id, string manufacturer, string model, decimal price, double overallPerformance)
        {
            this.Id = id;
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Price = price;
            this.OverallPerformance = overallPerformance;

        }


        public int Id
        {
            get { return this.id; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidProductId);

                }
                this.id = value;
            }
        }

        public string Manufacturer
        {
            get { return this.manufacturer; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Manufacturer can not be empty.");

                }
                this.manufacturer = value;
            }
        }


        public string Model
        {
            get { return this.model; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Model can not be empty.");

                }
                this.model = value;
            }
        }

        public virtual decimal Price
        {
            get { return this.price; }

            private set
            {
                if (value<=0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPrice);

                }
                this.price = value;
            }
        }

        public virtual double OverallPerformance
        {
            get { return this.overallPerformance; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidOverallPerformance);

                }
                this.overallPerformance = value;
            }
        }

        public override string ToString()
        {
            return $"Overall Performance: {OverallPerformance:f2}. Price: {Price:f2} - {this.GetType().Name}: {Manufacturer} {Model} (Id: {Id})";
        }
    }
}
