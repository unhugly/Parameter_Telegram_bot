using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using TelegramBot_for_parameter.Commands;

namespace TelegramBot_for_parameter
{
    internal class CommandHandler
    {
        private readonly ITelegramBotClient client;
        private readonly Dictionary<string, ICommand> commands;
        private readonly Dictionary<long, ICommand> activeCommands;

        public CommandHandler(ITelegramBotClient botClient)
        {
            client = botClient;
            commands = new Dictionary<string, ICommand>
        {
            { "/start", new StartCommand(botClient) },
            { "/help", new HelpCommand(botClient) },
            { "/findout", new TopWearFindOutCommand(botClient) },
            // добавить ещё
        };
            activeCommands = new Dictionary<long, ICommand>();
        }

        public async Task HandleCommandAsync(string message, long chatId)
        {
            if (commands.TryGetValue(message, out var commandHandler))
            {
                activeCommands[chatId] = commandHandler; // Устанавливаем команду как активную
                await commandHandler.ExecuteAsync(chatId);
            }
            else if (activeCommands.TryGetValue(chatId, out var activeCommand))
            {
                if (!await activeCommand.ContinueExecuteAsync(message, chatId))
                {
                    activeCommands.Remove(chatId); // Сброс активной команды, если она завершена
                }
            }
            else
            {
                await client.SendTextMessageAsync(chatId, "Неизвестная команда, используйте /help для вызова списка команд.");
            }
        }
    }

}
