namespace WheelzyTechnicalAssessment.Test
{
    public class KnightPossibleMovesTest
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(3, 3)]
        [InlineData(2, 3)]
        [InlineData(0, 1)]
        [InlineData(0, 6)]
        [InlineData(1, 0)]
        [InlineData(1, 7)]
        [InlineData(6, 0)]
        [InlineData(6, 7)]
        [InlineData(7, 1)]
        [InlineData(7, 6)]
        public void GetPossibleMoves_ReturnsCorrectMoves(int currentRow, int currentCol)
        {
            //Prepare
            var knightMoves = new List<Tuple<int, int>>
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

            //Act
            var actualMoves = WheelzyTechnicalAssessment.ConsoleApp.KnightPossibleMoves.KnightPossibleMoves.GetPossibleMoves(currentRow, currentCol);

            //Assert
            foreach (var move in actualMoves)
                if (!IsValidBoardMove(move.Item1, move.Item2) || !IsValidKnightMove(move.Item1, move.Item2, currentRow, currentCol, knightMoves))
                    Assert.Fail("Wrong Move Returned");
        }

        [Fact]
        public void GetPossibleMoves_ArgumentExceptionWrongCurrentPosition()
        {
            //Prepare
            int currentRow = -1, currentCol = -1;

            //Act
            try
            {
                WheelzyTechnicalAssessment.ConsoleApp.KnightPossibleMoves.KnightPossibleMoves.GetPossibleMoves(currentRow, currentCol);
            }
            catch (ArgumentException ex)
            {
                return;
            }

            //Assert
            Assert.Fail("Wrong Position Accepted");
        }

        private bool IsValidKnightMove(int newRow, int newCol, int currentRow, int currentCol, List<Tuple<int, int>> knightOffsets)
        {
            foreach (var move in knightOffsets)
                if (currentRow + move.Item1 == newRow && currentCol + move.Item2 == newCol)
                    return true;

            return false;
        }

        private static bool IsValidBoardMove(int newRow, int newCol)
        {
            return (newRow >= 0 && newRow < 8) && (newCol >= 0 && newCol < 8);
        }
    }
}
