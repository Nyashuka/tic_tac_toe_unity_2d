using System.Collections.Generic;
using System.Linq;

namespace GameLogic.WinCheckerModule
{
    public class VerticalChecker : IChecker
    {
        public WinnerData FindWinner(GameField gameField)
        {
            Dictionary<PlayerType, int> counters = new Dictionary<PlayerType, int>() { { PlayerType.Cross, 0 }, { PlayerType.Zero, 0 } };
            
            for (int i = 0; i < gameField.FieldSize; i++)
            {
                for (int j = 0; j < gameField.FieldSize; j++)
                {
                    if(!gameField.IsEmpty(j,i))
                        counters[gameField[j, i]]++;
                }

                foreach (var counterKey in counters.Keys.ToList())
                {
                    if(counters[counterKey] == 3)
                        return new WinnerData(true, counterKey);
                    
                    counters[counterKey] = 0;
                }
            }

            return new WinnerData(false);
        }
    }
}