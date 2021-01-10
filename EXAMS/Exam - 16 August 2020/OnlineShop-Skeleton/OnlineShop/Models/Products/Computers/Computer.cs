using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product,IComputer
    {
        private List<IComponent> components;
        private List<IPeripheral> peripherals;

        public Computer(int id, string manufacturer, string model, decimal price, double overallPerformance) 
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherals= new List<IPeripheral>();

        }

        public override double OverallPerformance
        {
            get
            {
                if (this.components.Count==0)
                {
                    return base.OverallPerformance;
                }

                //TODO: IF OUTPUT IS WRONG CHANGE IT TO SUM
                return base.OverallPerformance + this.components.Average(x => x.OverallPerformance);
                
            }   

        }

        public override decimal Price
        {
            get
            {
                if (this.components.Count==0&&this.peripherals.Count==0)
                {
                    return base.Price;
                }
                else if (this.components.Count == 0)
                {
                    return base.Price + this.peripherals.Sum(x => x.Price);
                }
                else if (this.peripherals.Count == 0)
                {
                    return base.Price + this.components.Sum(x => x.Price);
                }

                return base.Price + this.components.Sum(x => x.Price) + this.peripherals.Sum(x => x.Price);
            }
        }


        public IReadOnlyCollection<IComponent> Components => this.components.AsReadOnly();

        public IReadOnlyCollection<IPeripheral> Peripherals => this.peripherals.AsReadOnly();

        public void AddComponent(IComponent component)
        {
            var currentComponent = this.components.FirstOrDefault(x => x.GetType().Name == component.GetType().Name);
            if (!(currentComponent is null))
            {
                //TODO IF WRONG INPUT CHECK HERE
                throw new ArgumentException(
                    string.Format(ExceptionMessages.ExistingComponent, currentComponent.GetType().Name, this.GetType().Name, this.Id));
            }

            this.components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            var currentPeripheral = this.peripherals.FirstOrDefault(x => x.GetType().Name == peripheral.GetType().Name);
            if (!(currentPeripheral is null))
            {
                //TODO IF WRONG INPUT CHECK HERE
                throw new ArgumentException(
                    string.Format(ExceptionMessages.ExistingPeripheral, currentPeripheral.GetType().Name, this.GetType().Name, this.Id));
            }

            this.peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            var currentComponent = this.components.FirstOrDefault(x => x.GetType().Name == componentType);
            if (this.components.Count==0||currentComponent is null)
            {
                
                throw new ArgumentException(
                    string.Format(ExceptionMessages.NotExistingComponent, componentType, this.GetType().Name, this.Id));
            }

            this.components.Remove(currentComponent);

            return currentComponent;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            var currentPeripheral = this.peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);
            if (this.peripherals.Count == 0 || currentPeripheral is null)
            {

                throw new ArgumentException(
                    string.Format(ExceptionMessages.NotExistingPeripheral, peripheralType, this.GetType().Name, this.Id));
            }

            this.peripherals.Remove(currentPeripheral);

            return currentPeripheral;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($" Components ({this.components.Count}):");

            foreach (var item in components)
            {
                sb.AppendLine($"  {item.ToString()}");
            }

            if (this.peripherals.Count>0)
            {
                sb.AppendLine($" Peripherals ({this.peripherals.Count}); Average Overall Performance ({this.peripherals.Average(x => x.OverallPerformance):f2}):");

                foreach (var item in peripherals)
                {
                    sb.AppendLine($"  {item.ToString()}");
                }
            }
            else
            {
                sb.AppendLine($" Peripherals ({this.peripherals.Count}); Average Overall Performance ({0.00}):");

            }



            //TODO:CHANGE HERE IF NOT GIVE MAX POINTS
            return sb.ToString().Trim();
        }
    }
}
