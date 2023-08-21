using GameFieldModule;
using UnityEngine;

namespace GameLogic
{
    public class HimselfAgainstHimselfGame : MonoBehaviour
    {
        [SerializeField] private GameFieldRenderer gameFieldRenderer;
        private TicTacToe _ticTacToe;

        private void Start()
        {
            _ticTacToe = new TicTacToe(3, PlayerType.Cross);

            gameFieldRenderer.CellClicked += OnCellClicked;
        }

        private void OnCellClicked(CellCoordinate coordinate)
        {
            PlayerType player = _ticTacToe.CurrentPlayer;
            if (_ticTacToe.TryMakeStep(coordinate.Row, coordinate.Column))
            {
                gameFieldRenderer.RenderSymbolInto(coordinate.Row, coordinate.Column, player);
            }
        }
    }
}