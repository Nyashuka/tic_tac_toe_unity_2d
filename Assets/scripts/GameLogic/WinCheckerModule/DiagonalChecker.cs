using System.Collections.Generic;

namespace GameLogic.WinCheckerModule
{
    public class DiagonalChecker : IChecker
    {
        public WinnerData FindWinner(GameField gameField)
        {
            Dictionary<PlayerType, int> counters = new Dictionary<PlayerType, int>() { { PlayerType.Cross, 0 }, { PlayerType.Zero, 0 } };
            
            for (int i = 0; i < gameField.FieldSize; i++)
            {
                if (!gameField.IsEmpty(i,i))
                    counters[gameField[i, i]]++;
            }

            foreach (var counterKey in counters.Keys)
            {
                if (counters[counterKey] == 3)
                    return new WinnerData(true, counterKey);
            }

            return new WinnerData(false);
        }
    }
}