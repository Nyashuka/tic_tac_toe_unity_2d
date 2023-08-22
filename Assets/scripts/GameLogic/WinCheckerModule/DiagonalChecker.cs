using System.Collections.Generic;
using System.Linq;

namespace GameLogic.WinCheckerModule
{
    public class DiagonalChecker : IChecker
    {
        public WinnerData FindWinner(GameField gameField)
        {
            Dictionary<PlayerType, int> counters = new Dictionary<PlayerType, int>() { { PlayerType.Cross, 0 }, { PlayerType.Zero, 0 } };

            for (int i = 0; i < gameField.FieldSize && i < gameField.FieldSize; i++)
            {
                if (!gameField.IsEmpty(i,i))
                    counters[gameField[i, i]]++;
            }

            foreach (var counterKey in counters.Keys.ToList())
            {
                if (counters[counterKey] == 3)
                    return new WinnerData(true, counterKey);

                counters[counterKey] = 0;
            }

            return new WinnerData(false);
        }
    }
}