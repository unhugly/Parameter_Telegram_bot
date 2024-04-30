using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot_for_parameter;

internal class TelegramMessageHandler
{
    private CommandHandler commandHandler;

    public TelegramMessageHandler(ITelegramBotClient botClient)
    {
        this.commandHandler = new CommandHandler(botClient); // Создаем экземпляр CommandHandler
    }

    public async Task HandleUpdateAsync(ITelegramBotClient client, Update update, CancellationToken cancellationToken)
    {
        if (update.Message?.Text == null) return;

        var chatId = update.Message.Chat.Id;
        var text = update.Message.Text; // Получаем текст сообщения

        Console.WriteLine($"Received message in chat {chatId}: {text}");

        // Передаем текст и chatId в CommandHandler для обработки
        await commandHandler.HandleCommandAsync(text, chatId);
    }

    public Task HandleErrorAsync(ITelegramBotClient client, Exception exception, CancellationToken cancellationToken)
    {
        Console.WriteLine("An error occurred: " + exception.ToString());
        return Task.CompletedTask;
    }
}
