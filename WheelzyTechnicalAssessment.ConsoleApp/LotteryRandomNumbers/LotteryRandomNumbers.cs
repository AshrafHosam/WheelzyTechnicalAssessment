using Newtonsoft.Json;
using Polly;

namespace WheelzyTechnicalAssessment.ConsoleApp.LotteryRandomNumbers
{
    internal class LotteryRandomNumbers
    {
        protected LotteryRandomNumbers()
        {
        }

        public static async Task GenerateLotteryRequests()
        {
            var httpClient = new HttpClient();
            var tasks = new List<Task>();

            for (int i = 0; i < 10; i++)
            {
                var customerNumber = new Random().Next(1000, 9999);
                var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(new { CustomerNumber = customerNumber }));
                content.Headers.ContentType.MediaType = "application/json";
                tasks.Add(httpClient.PostAsync("https://notrealapi.com/lottery/play", content).ContinueWith(async responseTask =>
                {
                    try
                    {
                        var response = await responseTask;
                        if (response.IsSuccessStatusCode)
                        {
                            var responseContent = await response.Content.ReadAsStringAsync();
                            var lotteryResult = Newtonsoft.Json.JsonConvert.DeserializeObject<int>(responseContent);
                            if (lotteryResult == customerNumber)
                            {
                                Console.WriteLine($"Congratulations! You won with number {customerNumber}!");
                            }
                            else
                            {
                                Console.WriteLine($"Sorry, you lost with number {customerNumber}.");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Error: {response.StatusCode}");
                        }
                    }
                    catch (HttpRequestException ex)
                    {
                        Console.WriteLine($"Http Exception Message: {ex.Message}");
                    }
                }));
            }

            await Task.WhenAll(tasks);
        }
    }
}



