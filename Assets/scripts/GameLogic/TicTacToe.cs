using System;
using GameLogic.WinCheckerModule;
using UnityEngine;

namespace GameLogic
{
    public class TicTacToe
    {
        private readonly PlayerType[,] _gameField;
        private readonly WinnerChecker _winnerChecker;
        private PlayerType _currentPlayer;
        private int _stepsCount;
        private bool _isGameOver;

        public PlayerType CurrentPlayer => _currentPlayer;

        public event Action<WinData> GameOver;
        
        public TicTacToe(int fieldSize, PlayerType firstPlayer)
        {
            _gameField = new PlayerType[fieldSize, fieldSize];
            for (int i = 0; i < fieldSize; i++)
            {
                for (int j = 0; j < fieldSize; j++)
                {
                    _gameField[i, j] = PlayerType.Empty;
                }
            }

            _stepsCount = fieldSize * fieldSize;
            _currentPlayer = firstPlayer;
            _winnerChecker = new WinnerChecker();
            _isGameOver = false;
        }


        public bool TryMakeStep(int row, int col)
        {
            if (_isGameOver || _gameField[row, col] != PlayerType.Empty)
                return false;
                
            _gameField[row, col] = _currentPlayer == PlayerType.Cross ? PlayerType.Cross : PlayerType.Zero;
            _stepsCount--;
            
            WinData winData = _winnerChecker.FindWinner(_gameField);
            if (winData.WinnerFound)
            {
                Debug.Log(winData.Winner);
                GameOver?.Invoke(winData);
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