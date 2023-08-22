namespace GameLogic.WinCheckerModule
{
    public class WinnerData
    {
        public bool WinnerFound { get; }
        public PlayerType? Winner { get; }
        public int[,] WinPath { get; }
        
        public WinnerData(bool winnerFound, PlayerType? winner = null, int[,] winPath = null)
        {
            WinnerFound = winnerFound;
            Winner = winner;
            WinPath = winPath;
        }
    }
}