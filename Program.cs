using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Extensions;
using Telegram.Bot.Types;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;

class Program
{
    private static readonly string Token = Environment.GetEnvironmentVariable("TELEGRAM_BERTILLON_BOT_TOKEN");

    static void Main(string[] args)
    {
        var botClient = new TelegramBotClient(Token);
        var cts = new CancellationTokenSource();
        var receiverOptions = new ReceiverOptions
        {
            AllowedUpdates = { } 
        };

        botClient.StartReceiving(
            HandleUpdateAsync,
            HandleErrorAsync,
            receiverOptions,
            cancellationToken: cts.Token);

        Console.WriteLine($"Бот запущен. Нажмите любую клавишу для выхода");
        Console.ReadKey();

        cts.Cancel();
    }

    static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        if (update.Message == null || update.Message.Text == null) return;

        var chatId = update.Message.Chat.Id;
        Console.WriteLine($"Получено сообщение в чате {chatId}.");

        await botClient.SendTextMessageAsync(chatId, "Вы сказали: " + update.Message.Text, cancellationToken: cancellationToken);
    }

    static Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        var ErrorMessage = "Произошла ошибка: " + exception.ToString();
        Console.WriteLine(ErrorMessage);
        return Task.CompletedTask;
    }
}