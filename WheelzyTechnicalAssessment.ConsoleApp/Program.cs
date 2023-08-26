namespace WheelzyTechnicalAssessment.ConsoleApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await LotteryRandomNumbers.LotteryRandomNumbers.GenerateLotteryRequests();

            var possibleMoves = KnightPossibleMoves.KnightPossibleMoves.GetPossibleMoves(0, 0);
            foreach (var move in possibleMoves)
                Console.WriteLine(move);
        }
    }
}
