using GameFieldModule;

namespace GameLogic
{
    public class HimselfAgainstHimselfGame : IGameType
    {
        private GameFieldRenderer _gameFieldRenderer;
        private readonly TicTacToe _ticTacToe;

       public HimselfAgainstHimselfGame()
        {
            _ticTacToe = new TicTacToe(3, PlayerType.Cross);

            _gameFieldRenderer.CellClicked += OnCellClicked;
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