using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace TelegramBot_for_parameter
{
    internal class CommandHandler
    {
        private readonly ITelegramBotClient client;
        private readonly Dictionary<string, ICommand> commands;

        public CommandHandler(ITelegramBotClient botClient)
        {
            client = botClient;
            commands = new Dictionary<string, ICommand>
            {
                { "/start", new StartCommand(botClient) },
                { "/help", new HelpCommand(botClient) },
                // добавить ещё
            };
        }

        public async Task HandleCommandAsync(string command, long chatId)
        {
            if (commands.TryGetValue(command, out var commandHandler))
            {
                await commandHandler.ExecuteAsync(chatId);
            }
            else
            {
                var unknownCommandHandler = new UnknownCommand(client);
                await unknownCommandHandler.ExecuteAsync(chatId);
            }
        }
    }
}
