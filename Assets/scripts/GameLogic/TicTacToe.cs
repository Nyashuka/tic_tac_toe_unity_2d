using System;
using GameLogic.WinCheckerModule;

namespace GameLogic
{
    public class TicTacToe
    {
        private readonly GameField _gameField;
        private readonly WinnerChecker _winnerChecker;
        private readonly int _fieldSize;
        
        private PlayerType _currentPlayer;
        private int _stepsCount;
        private bool _isGameOver;

        public PlayerType CurrentPlayer => _currentPlayer;

        public event Action<WinnerData> GameOver;
        
        public TicTacToe(int fieldSize, PlayerType firstPlayer)
        {
            _gameField = new GameField(fieldSize);
            _stepsCount = fieldSize * fieldSize;
            _currentPlayer = firstPlayer;
            _winnerChecker = new WinnerChecker();
            _isGameOver = false;
        }
        
        public bool TryMakeStep(int row, int col)
        {
            if (_isGameOver || !_gameField.IsEmpty(row, col))
                return false;

            _gameField[row, col] = _currentPlayer;
            _stepsCount--;
            
            WinnerData winnerData = _winnerChecker.FindWinner(_gameField);
            if (winnerData.WinnerFound || (winnerData.WinnerFound && _stepsCount == 0))
            {
                GameOver?.Invoke(winnerData);
                _isGameOver = true;
                return true;
            }

            ChangePlayer();
            return true;
        }

        private void ChangePlayer()
        {
            _currentPlayer = _currentPlayer == PlayerType.Cross ? PlayerType.Zero : PlayerType.Cross;
        }
    }
}