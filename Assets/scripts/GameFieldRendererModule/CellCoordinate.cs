namespace GameFieldRendererModule
{
    public struct CellCoordinate
    {
        public int Row { get; }
        public int Column { get; }
        
        public CellCoordinate(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}