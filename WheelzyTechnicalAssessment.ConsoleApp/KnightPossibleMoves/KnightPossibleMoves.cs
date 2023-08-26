namespace WheelzyTechnicalAssessment.ConsoleApp.KnightPossibleMoves
{
    public class KnightPossibleMoves
    {
        public static List<Tuple<int, int>> GetPossibleMoves(int row, int col)
        {
            if (row < 0 || col < 0) throw new ArgumentException($"Invalid Current Position {row} - {col}");

            var moves = new List<Tuple<int, int>>();
            var offsets = new List<Tuple<int, int>>()
            {
                Tuple.Create(-2, -1),
                Tuple.Create(-2, 1),
                Tuple.Create(-1, -2),
                Tuple.Create(-1, 2),
                Tuple.Create(1, -2),
                Tuple.Create(1, 2),
                Tuple.Create(2, -1),
                Tuple.Create(2, 1)
            };

            foreach (var offset in offsets)
            {
                var newRow = row + offset.Item1;
                var newCol = col + offset.Item2;

                if (IsValidMove(newRow, newCol))
                {
                    moves.Add(Tuple.Create(newRow, newCol));
                }
            }

            return moves;
        }
        private static bool IsValidMove(int newRow, int newCol)
        {
            return (newRow >= 0 && newRow < 8) && (newCol >= 0 && newCol < 8);
        }
    }
}
