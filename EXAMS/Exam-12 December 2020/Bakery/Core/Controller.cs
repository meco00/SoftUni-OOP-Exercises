using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Bakery.Core
{
    public class Controller : IController
    {
       private List<IBakedFood> bakedFoods;
       private List<IDrink> drinks;
       private List<ITable> tables;
        private decimal totalIncome=0;

        public Controller()
        {
            this.bakedFoods = new List<IBakedFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();
        }

      

        public string GetFreeTablesInfo()
        {
            var freeTables = this.tables.Where(x => x.IsReserved == false).ToList();

            StringBuilder sb = new StringBuilder();
            foreach (ITable item in freeTables)
            {
                sb.AppendLine(item.GetFreeTableInfo());

            }

            return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
           

            return $"Total income: {totalIncome:f2}lv";
        }

        public string LeaveTable(int tableNumber)
        {
            var currentTable = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Table: {tableNumber}");
            sb.AppendLine($"Bill: {currentTable.GetBill():f2}");


            totalIncome += currentTable.GetBill();
            currentTable.Clear();


            return sb.ToString().TrimEnd();

        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            var currentTable = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            if (currentTable is null)
            {
                return $"Could not find table {tableNumber}";

            }

            var currentDrink = this.drinks.FirstOrDefault(x => x.Name == drinkName);

            if (currentDrink is null)
            {
                return $"There is no {drinkName} {drinkBrand} available";

            }

            currentTable.OrderDrink(currentDrink);

            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            var currentTable = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            if (currentTable is null)
            {
                return $"Could not find table {tableNumber}";

            }

            var currentFood = this.bakedFoods.FirstOrDefault(x => x.Name == foodName);
            if (currentFood is null)
            {
                return $"No {foodName} in the menu";

            }

            currentTable.OrderFood(currentFood);

            return $"Table {tableNumber} ordered {foodName}";
        }

        public string ReserveTable(int numberOfPeople)
        {
            var currentTable = this.tables.FirstOrDefault(x => x.IsReserved == false&&numberOfPeople<=x.Capacity);

            if (currentTable is null)
            {
                return $"No available table for {numberOfPeople} people";

            }


           
            currentTable.Reserve(numberOfPeople);


            return $"Table {currentTable.TableNumber} has been reserved for {numberOfPeople} people";

        }
        public string AddDrink(string type, string name, int portion, string brand)
        {
        
            Assembly assembly = Assembly.GetExecutingAssembly();

            var currentType = assembly.GetTypes().FirstOrDefault(x => x.Name == type);

            object[] args = { name, portion,brand };
           
            IDrink drink = (IDrink)Activator.CreateInstance(currentType, args);

            if (type == "Tea")
            {
                drink = new Tea(name, portion, brand);
            }
            else if (type == "Water")
            {
                drink = new Water(name, portion, brand);
            }

            this.drinks.Add(drink);

            return $"Added {drink.Name} ({drink.Brand}) to the drink menu";
        }

        public string AddFood(string type, string name, decimal price)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            var currentType = assembly.GetTypes().FirstOrDefault(x => x.Name == type);
           

            object[] args = { name, price };


            var bakedFood =(IBakedFood)Activator.CreateInstance(currentType,args);


            if (type == "Bread")
            {
                bakedFood = new Bread(name, price);
            }
            else if (type == "Cake")
            {
                bakedFood = new Cake(name, price);
            }

            this.bakedFoods.Add(bakedFood);

            return $"Added {bakedFood.Name} ({bakedFood.GetType().Name}) to the menu";

        }

        public string AddTable(string type, int tableNumber, int capacity)
        {

            Assembly assembly = Assembly.GetExecutingAssembly();

            var currentType = assembly.GetTypes().FirstOrDefault(x => x.Name == type);

            object[] args = { tableNumber, capacity  };

            
            var table = (ITable)Activator.CreateInstance(currentType, args);

            if (type == "InsideTable")
            {
                table = new InsideTable(tableNumber, capacity);
            }
            else if (type == "OutsideTable")
            {
                table = new OutsideTable(tableNumber, capacity);
            }

            this.tables.Add(table);

            return $"Added table number {tableNumber} in the bakery";
        }
    }
}
