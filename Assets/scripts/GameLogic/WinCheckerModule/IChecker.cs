namespace GameLogic.WinCheckerModule
{
    public interface IChecker
    {
        WinnerData FindWinner(GameField gameField);
    }
}