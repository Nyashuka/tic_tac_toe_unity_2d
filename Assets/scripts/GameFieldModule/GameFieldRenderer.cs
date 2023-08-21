using System;
using GameLogic;
using UnityEngine;

namespace GameFieldModule
{
    public class GameFieldRenderer : MonoBehaviour
    {
        [SerializeField] private float size;
        [SerializeField] private float sizeOffset;
        [SerializeField] private SpriteRenderer background;
        [Range(3, 5)] [SerializeField] private int cellsCount;

        [SerializeField] private Cell cellPrefab;

        [SerializeField] private float borderThickness;
        [SerializeField] private SpriteRenderer borderSprite;

        [SerializeField] private Sprite crossSprite;
        [SerializeField] private Sprite zeroSprite;

        private Cell[,] _cells;
        private SpriteRenderer[] _verticalBorders;
        private SpriteRenderer[] _horizontalBorders;

        public event Action<CellCoordinate> CellClicked;

        private void Start()
        {
            GenerateGameField();
        }

        private void GenerateGameField()
        {
            background.size = new Vector2(size, size);

            float cellSize = (size - borderThickness * (cellsCount + 1)) / cellsCount;
            float cellSizeHalf = cellSize / 2.0f;

            Bounds gameFieldLocalBounds = background.localBounds;
            float startX = gameFieldLocalBounds.min.x + cellSizeHalf + borderThickness;
            Vector2 currentPosition = new Vector2(startX, gameFieldLocalBounds.min.y * -1 - cellSizeHalf - borderThickness);

            _cells = new Cell[cellsCount, cellsCount];
            
            int bordersCount = (cellsCount + 1) * cellsCount;
            _verticalBorders = new SpriteRenderer[bordersCount];
            _horizontalBorders = new SpriteRenderer[bordersCount];

            int currentIndex = 0;
            for (int i = 0; i < cellsCount; i++)
            {
                int j;
                for (j = 0; j < cellsCount; j++)
                {
                    currentIndex = i * j + i;

                    RenderVerticalBorder(currentIndex, currentPosition.x - cellSizeHalf - borderThickness / 2.0f, currentPosition.y, cellSize);
                    RenderHorizontalBorder(currentIndex, currentPosition.x, currentPosition.y + cellSizeHalf + borderThickness / 2.0f, cellSize);

                    if (i == cellsCount - 1)
                        RenderHorizontalBorder(currentIndex, currentPosition.x, currentPosition.y - cellSizeHalf - borderThickness / 2.0f, cellSize);

                    RenderCell(i, j, currentPosition, cellSize);
                    currentPosition.x += cellSize + borderThickness;
                }

                if (j == cellsCount)
                    RenderVerticalBorder(currentIndex + j, currentPosition.x - cellSizeHalf - borderThickness / 2.0f,  currentPosition.y, cellSize);

                currentPosition.x = startX;
                currentPosition.y -= cellSize + borderThickness;
            }
        }

        private void RenderVerticalBorder(int index, float x, float y, float cellSize)
        {
            _verticalBorders[index] = Instantiate(borderSprite, transform);
            _verticalBorders[index].transform.localPosition =
                new Vector2(x, y);
            _verticalBorders[index].size = new Vector2(borderThickness, cellSize);
        }

        private void RenderHorizontalBorder(int index, float x, float y, float cellSize)
        {
            _horizontalBorders[index] = Instantiate(borderSprite, transform);
            _horizontalBorders[index].transform.localPosition = new Vector2(x,y);
            _horizontalBorders[index].size = new Vector2(cellSize, borderThickness);
        }

        private void RenderCell(int row, int col, Vector2 position, float cellSize)
        {
            _cells[row, col] = Instantiate(cellPrefab, transform);
            _cells[row, col].transform.localPosition = position;
            _cells[row, col].Init(row, col,cellSize - sizeOffset, cellSize);
            _cells[row, col].Clicked += OnCellClicked;
        }

        private void OnCellClicked(CellCoordinate coordinate)
        {
            CellClicked?.Invoke(coordinate);
        }

        public void RenderSymbolInto(int row, int column, PlayerType player)
        {
            _cells[row, column].SetSprite(player == PlayerType.Cross ? crossSprite : zeroSprite);
        }
    }
}