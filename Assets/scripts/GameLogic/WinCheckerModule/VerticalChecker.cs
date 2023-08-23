using System.Collections.Generic;
using System.Linq;

namespace GameLogic.WinCheckerModule
{
    public class VerticalChecker : IChecker
    {
        public WinnerData FindWinner(GameField gameField)
        {
            Dictionary<PlayerType, int> counters = new Dictionary<PlayerType, int>();
            
            for (int i = 0; i < gameField.FieldSize; i++)
            {
                counters[PlayerType.Cross] = 0;
                counters[PlayerType.Zero] = 0;
                for (int j = 0; j < gameField.FieldSize; j++)
                {
                    if(!gameField.IsEmpty(j,i))
                        counters[gameField[j, i]]++;
                }

                foreach (var counterKey in counters.Keys.ToList())
                {
                    if(counters[counterKey] == 3)
                        return new WinnerData(true, counterKey);
                }
            }

            return new WinnerData(false);
        }
    }
}