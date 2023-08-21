namespace GameLogic.WinCheckerModule
{
    public interface IChecker
    {
        WinData FindWinner(PlayerType[,] gameField);
    }
}