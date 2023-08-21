namespace GameLogic.WinCheckerModule
{
    public class WinData
    {
        public bool WinnerFound { get; }
        public PlayerType Winner { get; }
        public int[,] WinPath { get; }
        
        public WinData(bool winnerFound, PlayerType winner = PlayerType.Empty, int[,] winPath = null)
        {
            WinnerFound = winnerFound;
            Winner = winner;
            WinPath = winPath;
        }
    }
}