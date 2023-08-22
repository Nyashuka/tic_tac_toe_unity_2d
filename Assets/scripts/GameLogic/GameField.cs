using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameLogic
{
    public class GameField
    {
        private readonly Dictionary<Vector2Int, PlayerType> _cells;
        public int FieldSize { get; }
        
        public GameField(int fieldSize)
        {
            _cells = new Dictionary<Vector2Int, PlayerType>(fieldSize);
            FieldSize = fieldSize;
        }
        
        public PlayerType this[int row, int col]
        {
            get => _cells[new Vector2Int(row, col)];
            set => _cells[new Vector2Int(row, col)] = value;
        }

        public bool IsEmpty(int row, int col)
        {
            return !_cells.ContainsKey(new Vector2Int(row, col));
        }
    }
}