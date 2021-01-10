using OnlineShop.Common.Constants;
using OnlineShop.Common.Enums;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private List<IComputer> computers;
        private List<IPeripheral> peripherals;

        public Controller()
        {
            this.computers = new List<IComputer>();
            this.peripherals = new List<IPeripheral>();
        }


        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {

            IComputer currentComputer = this.computers.FirstOrDefault(x => x.Id == computerId);

            if (currentComputer is null)
            {
                throw new ArgumentException("Computer with this id does not exist.");

            }

            var currentComponent = currentComputer.Components.FirstOrDefault(x => x.Id == id);

            if (!(currentComponent is null))
            {
                throw new ArgumentException($"Component with this id already exists.");
            }

            currentComponent = ComponentFactory(id, componentType, manufacturer, model, price, overallPerformance, generation);




            if (currentComponent is null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }

            currentComputer.AddComponent(currentComponent);

            return $"Component {componentType} with id {id} added successfully in computer with id {computerId}.";



        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            IComputer currentComputer = this.computers.FirstOrDefault(x => x.Id == id);
            if (!(currentComputer is null))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }

            currentComputer = ComputerFactory( computerType,  id,  manufacturer,  model,  price);
            
   
            if(currentComputer is null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidComputerType);
            }

            this.computers.Add(currentComputer);

            return $"Computer with id {id} added successfully.";




        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
           

            var currentPeripheral = this.peripherals.FirstOrDefault(x => x.Id == id);

            if (!(currentPeripheral is null))
            {
                throw new ArgumentException($"Peripheral with this id already exists.");
            }

            IComputer currentComputer = this.computers.FirstOrDefault(x => x.Id == computerId);

            if (currentComputer is null)
            {
                throw new ArgumentException("Computer with this id does not exist.");

            }

            currentPeripheral = PeripheralFactory(id, peripheralType, manufacturer, model, price, overallPerformance, connectionType);

           
            if(currentPeripheral is null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidPeripheralType);
            }

            currentComputer.AddPeripheral(currentPeripheral);

            this.peripherals.Add(currentPeripheral);

            return $"Peripheral {peripheralType} with id {id} added successfully in computer with id {computerId}.";





        }

        public string BuyBest(decimal budget)
        {
           var bestOne= this.computers.OrderByDescending(x=>x.OverallPerformance).FirstOrDefault(x=>x.Price<=budget);
            if (bestOne is null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CanNotBuyComputer, budget));

            }

            this.computers.Remove(bestOne);

            return bestOne.ToString();

        }

        public string BuyComputer(int id)
        {
            var removeComputer = this.computers.FirstOrDefault(x => x.Id == id);

            if (removeComputer is null)
            {
                throw new ArgumentException("Computer with this id does not exist.");

            }

            this.computers.Remove(removeComputer);

            return removeComputer.ToString();


        }

        public string GetComputerData(int id)
        {
            var getComputer = this.computers.FirstOrDefault(x => x.Id == id);
            if (getComputer is null)
            {
                throw new ArgumentException("Computer with this id does not exist.");

            }

            return getComputer.ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            IComputer currentComputer = this.computers.FirstOrDefault(x => x.Id == computerId);

            if (currentComputer is null)
            {
                throw new ArgumentException("Computer with this id does not exist.");

            }

            var component =currentComputer.RemoveComponent(componentType);

            return $"Successfully removed {componentType} with id {component.Id}.";
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            IComputer currentComputer = this.computers.FirstOrDefault(x => x.Id == computerId);
            if (currentComputer is null)
            {
                throw new ArgumentException("Computer with this id does not exist.");

            }

            var peripheral = currentComputer.RemovePeripheral(peripheralType);

            this.peripherals.Remove(peripheral);

            return $"Successfully removed {peripheralType} with id {peripheral.Id}.";
        }

        private static IPeripheral PeripheralFactory(
            int id, 
            string peripheralType, string manufacturer, 
            string model, decimal price, double overallPerformance,
            string connectionType)
        {
            Enum.TryParse(peripheralType, out PeripheralType type);

            IPeripheral peripheral = type switch
            {
                PeripheralType.Headset=> new Headset(id, manufacturer, model, price, overallPerformance, connectionType),
                PeripheralType.Keyboard=> new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType),
                PeripheralType.Monitor=> new Monitor(id, manufacturer, model, price, overallPerformance, connectionType),
                PeripheralType.Mouse=> new Mouse(id, manufacturer, model, price, overallPerformance, connectionType),
                _ =>null


            };

            return peripheral;

        }


        private static IComputer ComputerFactory(
            string computerType, int id, string manufacturer, string model, decimal price)
        {
            Enum.TryParse(computerType, out ComputerType type);

            IComputer computer = type switch
            {
                ComputerType.DesktopComputer => new DesktopComputer(id, manufacturer, model, price),
                ComputerType.Laptop => new Laptop(id, manufacturer, model, price),
              _ =>null


            };

            return computer;
        }

        private static IComponent ComponentFactory(
            int id,string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            Enum.TryParse(componentType, out ComponentType type);

          IComponent component = type switch
            {
                ComponentType.CentralProcessingUnit=> new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.Motherboard=>new Motherboard(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.PowerSupply=>new PowerSupply(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.RandomAccessMemory=>new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.SolidStateDrive=>new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.VideoCard=>new VideoCard(id, manufacturer, model, price, overallPerformance, generation),
                _ =>null
            };


            return component;
        }
    }
}
