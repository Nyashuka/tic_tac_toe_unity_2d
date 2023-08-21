using System.Collections.Generic;

namespace GameLogic.WinCheckerModule
{
    public class WinnerChecker
    {
        private readonly List<IChecker> _checkers;

        public WinnerChecker()
        {
            _checkers = new List<IChecker>()
            {
                new VerticalChecker(),
                new HorizontalChecker(),
                new DiagonalChecker(),
                new OppositeDiagonalChecker()
            };
        }

        public WinData FindWinner(PlayerType[,] gameField)
        {
            foreach (var checker in _checkers)
            {
                WinData winData = checker.FindWinner(gameField);
                if (winData.WinnerFound)
                    return winData;
            }

            return new WinData(false);
        }
    }
}