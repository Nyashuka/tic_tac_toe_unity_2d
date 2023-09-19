using UnityEngine;

namespace GameFieldRendererModule
{
    public class CellsRenderer
    {
        private float _size;
        private float _cellsCountInRow;
        private Bounds _gameFieldLocalBounds;
        private Transform _cellsParent;
        
        
        
        public void Render()
        {
            float cellSizeHalf = _size / 2.0f;
            float startX = _gameFieldLocalBounds.min.x + cellSizeHalf;
            
            for (int i = 0; i < _cellsCountInRow; i++)
            {
                for (int j = 0; j < _cellsCountInRow; j++)
                {
                    
                }
            }
        }
    }
}