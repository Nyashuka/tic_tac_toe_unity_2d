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

        public WinnerData FindWinner(GameField gameField)
        {
            foreach (var checker in _checkers)
            {
                WinnerData winnerData = checker.FindWinner(gameField);
                if (winnerData.WinnerFound)
                    return winnerData;
            }

            return new WinnerData(false);
        }
    }
}