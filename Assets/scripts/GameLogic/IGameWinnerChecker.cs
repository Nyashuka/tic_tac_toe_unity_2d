namespace GameLogic
{
    public interface IGameWinnerChecker
    {
        bool IsWinner(PlayerType[,] gameField, PlayerType player);
        void IsDraw(PlayerType[,] gameField, PlayerType player);
    }
}