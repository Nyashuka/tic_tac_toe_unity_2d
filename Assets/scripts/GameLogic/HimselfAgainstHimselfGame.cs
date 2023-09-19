using GameFieldRendererModule;
using Infrastructure.ServiceLocatorModule;
using Services;
using UnityEngine;

namespace GameLogic
{
    public class HimselfAgainstHimselfGame : IGameType
    {
        private readonly GameFieldRenderer _gameFieldRenderer;
        private readonly TicTacToe _ticTacToe;

       public HimselfAgainstHimselfGame()
        {
            _ticTacToe = new TicTacToe(3, PlayerType.Cross);

            _gameFieldRenderer = Object.Instantiate(ServiceLocator.Instance.GetService<AssetsProvider>().GameAssets.GameFieldRenderer);
            _gameFieldRenderer.Init(ServiceLocator.Instance.GetService<AssetsProvider>().GameAssets.GameFieldViewConfigSo.GameFieldViewConfig);
            _gameFieldRenderer.CellClicked += OnCellClicked;
            _gameFieldRenderer.Render();
        }

       private void OnCellClicked(CellCoordinate coordinate)
        {
            PlayerType player = _ticTacToe.CurrentPlayer;
            if (_ticTacToe.TryMakeStep(coordinate.Row, coordinate.Column))
            {
                _gameFieldRenderer.RenderSymbolInto(coordinate.Row, coordinate.Column, player);
            }
        }
    }
}