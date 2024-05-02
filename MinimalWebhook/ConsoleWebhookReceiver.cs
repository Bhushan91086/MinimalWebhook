namespace MinimalWebhook
{
    /// <summary>
    /// An implementation for IReceiveWebhook that writes to the console
    /// </summary>
    public class ConsoleWebhookReceiver : IReceiveWebhook
    {
        /// <summary>
        /// Writes the POST request body to the console and returns JSON
        /// </summary>
        public async Task<string> ProcessRequest(string requestBody)
        {
            //This is where you would put your actual business logic for receiving webhooks
            Console.WriteLine($"Request Body: {requestBody}");
            return "{\"message\" : \"Thanks! We got your webhook\"}";
        }
    }
}
