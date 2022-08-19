namespace ETradeUI.Helpers
{
    public class APIHelper
    {
        public HttpClient Initial()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7161/api/");
            return client;
        }
    }
}
