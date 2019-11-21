using System;
using System.Collections.Generic;

namespace StarWars
{
    public class ResupplyCalculator
    {
        public IList<Starships> Calculate(IList<Starships> StarShips, int userInput)
        {
            foreach (var ship in StarShips)
            {
                //Checking the data required to for calculation is valid
                if (ship.consumables == "unknown" || ship.MGLT == "unknown")
                {
                    ship.resupply = "unknown data";
                }
                else
                {
                    var consumables = ConvertConsumablesInHours(ship.consumables);
                    //Calculating how many megalights a starship can travel with consumables,
                    //Then calculating stops required to resupply consumables in given distance.
                    ship.resupply = (userInput / (Int32.Parse(ship.MGLT) * consumables)).ToString();
                }
            }
            return StarShips;
        }

        //Function to convert consumable to per hours
        public int ConvertConsumablesInHours(string consumables)
        {
            var type = consumables.Split(" ");
            var number = Int32.Parse(type[0]);
            switch(type[1])
            {
                case "hours":
                    return number;

                case "days":
                    return number * 24;

                case "week":
                    return number * 168;

                case "weeks":
                    return number * 168;

                case "months":
                    return number * 730;

                case "month":
                    return number * 730;

                case "years":
                    return number * 8760;

                case "year":
                    return number * 8760;

                default:
                    return 0;
            }
        }
    }
}
