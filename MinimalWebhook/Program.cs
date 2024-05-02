//This is an ASP .NET Core Minimal API that receives Webhook POST data
using MinimalWebhook;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//Configure services
builder.Services.AddSingleton<IReceiveWebhook, ConsoleWebhookReceiver>();

var app = builder.Build();

app.UseHttpsRedirection();

//Listen for POST webhooks
app.MapPost("/webhook", async (HttpContext context, IReceiveWebhook receiveWebook) =>
{
    using StreamReader stream = new StreamReader(context.Request.Body);
    return await receiveWebook.ProcessRequest(await stream.ReadToEndAsync());
});

app.Run();