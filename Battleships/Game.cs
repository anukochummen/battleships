using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    // Imagine a game of battleships.
    //   The player has to guess the location of the opponent's 'ships' on a 10x10 grid
    //   Ships are one unit wide and 2-4 units long, they may be placed vertically or horizontally
    //   The player asks if a given co-ordinate is a hit or a miss
    //   Once all cells representing a ship are hit - that ship is sunk.
    public class Game
    {
        // ships: each string represents a ship in the form first co-ordinate, last co-ordinate
        //   e.g. "3:2,3:5" is a 4 cell ship horizontally across the 4th row from the 3rd to the 6th column
        // guesses: each string represents the co-ordinate of a guess
        //   e.g. "7:0" - misses the ship above, "3:3" hits it.
        // returns: the number of ships sunk by the set of guesses
        public static int Play(string[] ships, string[] guesses)
        {
            //get Ships positions
            Dictionary<string, List<string>> shipsPositions = new Dictionary<string, List<string>>();
            int sunkShipsCount = 0;
            List<string> placedCells;

            for (int i = 0; i < ships.Length; i++)
            {
                placedCells =  GetShipPlacedCells(ships[i]);   
                //---------
                // we can write logic here to check any ship overlapping postions 
                //----------
                shipsPositions.Add($"Ship-{i}", placedCells);                
            }

            //Count sunk ships
            foreach (var shipPositions in shipsPositions)
            {
                if (!shipPositions.Value.Except(guesses).Any())
                {
                    sunkShipsCount++;
                }
            }

            return sunkShipsCount;
        }

        private static List<string> GetShipPlacedCells(string shipCoordinate)
        {
            List<string> placedCells = new List<string>();
            var firstlastCoordinate = shipCoordinate.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            string[] firstPosition = firstlastCoordinate.First().Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            string[] lastPosition = firstlastCoordinate.Last().Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

            int roStart = Convert.ToInt32(firstPosition.First());
            int roEnd = Convert.ToInt32(lastPosition.First());            

            int colStart = Convert.ToInt32(firstPosition.Last());
            int colEnd = Convert.ToInt32(lastPosition.Last());

            //--**Optional logic to manage if ship in reverse position
            int coordinateHolderTemp;
            if(roStart > roEnd)
            {
                coordinateHolderTemp = roStart;
                roStart = roEnd;
                roEnd = coordinateHolderTemp;
            }
            if (colStart > colEnd)
            {
                coordinateHolderTemp = colStart;
                colStart = colEnd;
                colEnd = coordinateHolderTemp;
            }
            //----**

            //Get all cells a ship placed
            for (int ro = roStart; ro <= roEnd; ro++)
            {
                for (int col = colStart; col <= colEnd; col++)
                {
                    placedCells.Add($"{ro}:{col}");
                }
            }

            return placedCells;
        }
        
    }
}
