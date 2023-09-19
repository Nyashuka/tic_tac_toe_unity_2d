using System;
using Data.AssetsReferences;
using GameLogic;
using UnityEngine;

namespace GameFieldRendererModule
{
    public class GameFieldRenderer : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer background;

        private GameFieldViewConfig _config;
        private CellView[,] _cells;
        private SpriteRenderer[] _verticalBorders;
        private SpriteRenderer[] _horizontalBorders;

        public event Action<CellCoordinate> CellClicked;

        private const int SquareSidesCount = 4;

        public void Init(GameFieldViewConfig config)
        {
            _config = config;

            background.sprite = null;
            background.size = new Vector2(_config.Size, _config.Size);
        }

        private void InitializeBorders()
        {
            int bordersCount = (_config.CellsCount + 1) * _config.CellsCount;
            _verticalBorders = new SpriteRenderer[bordersCount];
            _horizontalBorders = new SpriteRenderer[bordersCount];
        }

        public void Render()
        {
            //InitializeBorders();
            //GenerateGameField();
            RenderCells();
            RenderOutlines();
        }

        private float CalculateCellSize()
        {
            //return (_config.Size - _config.BorderThickness * (_config.CellsCount + 1)) / _config.CellsCount;
            return _config.Size / _config.CellsCount - _config.BorderThickness * (_config.CellsCount - 1);
        }

        private void GenerateGameField()
        {
            background.size = new Vector2(_config.Size, _config.Size);

            float cellSize = CalculateCellSize();
            float cellSizeHalf = cellSize / 2.0f;

            Bounds gameFieldLocalBounds = background.localBounds;
            float startX = gameFieldLocalBounds.min.x + cellSizeHalf + _config.BorderThickness;
            Vector2 currentPosition = new Vector2(startX,
                gameFieldLocalBounds.min.y * -1 - cellSizeHalf - _config.BorderThickness);

            _cells = new CellView[_config.CellsCount, _config.CellsCount];

            int currentIndex = 0;
            for (int i = 0; i < _config.CellsCount; i++)
            {
                int j;
                for (j = 0; j < _config.CellsCount; j++)
                {
                    currentIndex = i * j + i;

                    _verticalBorders[currentIndex] = RenderVerticalBorder(
                        currentPosition.x - cellSizeHalf - _config.BorderThickness / 2.0f, currentPosition.y, cellSize);
                    _horizontalBorders[currentIndex] = RenderHorizontalBorder(currentPosition.x,
                        currentPosition.y + cellSizeHalf + _config.BorderThickness / 2.0f, cellSize);

                    if (i == _config.CellsCount - 1)
                        _horizontalBorders[currentIndex + 1] = RenderHorizontalBorder(currentPosition.x,
                            currentPosition.y - cellSizeHalf - _config.BorderThickness / 2.0f, cellSize);

                    RenderCell(i, j, currentPosition, cellSize);
                    currentPosition.x += cellSize + _config.BorderThickness;
                }

                if (j == _config.CellsCount)
                    _verticalBorders[currentIndex + j] = RenderVerticalBorder(
                        currentPosition.x - cellSizeHalf - _config.BorderThickness / 2.0f, currentPosition.y, cellSize);

                currentPosition.x = startX;
                currentPosition.y -= cellSize + _config.BorderThickness;
            }
        }

        private void RenderCells()
        {
            float innerSpaces = _config.BorderThickness;
            float cellSize = CalculateCellSize();
            float startX = (-_config.Size / 2) + cellSize / 2.0f;
            float startY = -startX;

            Vector2 currentPoint = new Vector2(startX, startY);


            _cells = new CellView[_config.CellsCount, _config.CellsCount];
            for (int i = 0; i < _config.CellsCount; i++)
            {
                for (int j = 0; j < _config.CellsCount; j++)
                {
                    RenderCell(i, j, currentPoint, cellSize);

                    currentPoint.x += cellSize + innerSpaces;
                }

                currentPoint.x = startX;
                currentPoint.y -= cellSize + innerSpaces;
            }
        }

        private void RenderOutlines()
        {
            float spaces = _config.BorderThickness;
            
            float cellSize = CalculateCellSize();
            float fieldStartX = -_config.Size / 2;
            float fieldStartY = -fieldStartX;

            float horizontalX = fieldStartX + cellSize / 2;
            float horizontalY = fieldStartY + _config.BorderThickness / 2;

            float verticalX = fieldStartX - _config.BorderThickness / 2 ;
            float verticalY = fieldStartY - cellSize / 2;


            for (int j = 0; j < _config.CellsCount; j++)
            {
                RenderLine(new Vector2(horizontalX, horizontalY), cellSize, _config.BorderThickness);
                RenderLine(new Vector2(horizontalX, -horizontalY), cellSize, _config.BorderThickness);
                horizontalX += cellSize + spaces;
            }

            for (int j = 0; j < _config.CellsCount; j++)
            {
                RenderLine(new Vector2(verticalX, verticalY), _config.BorderThickness, cellSize);
                RenderLine(new Vector2(-verticalX, verticalY), _config.BorderThickness, cellSize);
                verticalY -= cellSize + spaces;
            }
        }

        private SpriteRenderer RenderLine(Vector2 currentPoint, float width, float height)
        {
            SpriteRenderer line = Instantiate(_config.BorderSprite, transform);

            line.transform.localPosition = currentPoint;
            line.size = new Vector2(width, height);
            return line;
        }


        private void RenderInnerLines()
        {
            for (int i = 0; i < _config.CellsCount - 1; i++)
            {
                
            }
        }

        private SpriteRenderer RenderVerticalBorder(float x, float y, float cellSize)
        {
            SpriteRenderer border = Instantiate(_config.BorderSprite, transform);
            border.transform.localPosition = new Vector2(x, y);
            border.size = new Vector2(_config.BorderThickness, cellSize);

            return border;
        }

        private SpriteRenderer RenderHorizontalBorder(float x, float y, float cellSize)
        {
            SpriteRenderer border = Instantiate(_config.BorderSprite, transform);
            border.transform.localPosition = new Vector2(x, y);
            border.size = new Vector2(cellSize, _config.BorderThickness);

            return border;
        }

        private void RenderCell(int row, int col, Vector2 position, float cellSize)
        {
            CellView cellView = Instantiate(_config.CellViewPrefab, transform);

            cellView.transform.localPosition = position;
            cellView.Init(row, col, cellSize - _config.CellSizeOffset, cellSize - _config.CellSizeOffset);
            cellView.Clicked += OnCellClicked;

            _cells[row, col] = cellView;
        }

        private void OnCellClicked(CellCoordinate coordinate)
        {
            CellClicked?.Invoke(coordinate);
        }

        public void RenderSymbolInto(int row, int column, PlayerType player)
        {
            _cells[row, column].SetSprite(player == PlayerType.Cross ? _config.CrossSprite : _config.ZeroSprite);
        }
    }
}