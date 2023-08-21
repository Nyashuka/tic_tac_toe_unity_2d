using System.Collections.Generic;
using System.Linq;

namespace GameLogic.WinCheckerModule
{
    public class DiagonalChecker : IChecker
    {
        public WinData FindWinner(PlayerType[,] gameField)
        {
            Dictionary<PlayerType, int> counters = new Dictionary<PlayerType, int>() { { PlayerType.Cross, 0 }, { PlayerType.Zero, 0 } };

            for (int i = 0; i < gameField.GetLength(0) && i < gameField.GetLength(1); i++)
            {
                if (gameField[i, i] != PlayerType.Empty)
                    counters[gameField[i, i]]++;
            }

            foreach (var counterKey in counters.Keys.ToList())
            {
                if (counters[counterKey] == 3)
                    return new WinData(true, counterKey);

                counters[counterKey] = 0;
            }

            return new WinData(false);
        }
    }
}