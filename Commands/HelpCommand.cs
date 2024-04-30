using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace TelegramBot_for_parameter
{
    internal class HelpCommand : Commands.Command, ICommand
    {
        public HelpCommand(ITelegramBotClient botClient) : base(botClient) { }

        public async Task ExecuteAsync(long chatId)
        {
            await _client.SendTextMessageAsync(chatId, "Список доступных команд:\n/help (список команд)\n/advice(случайный совет)");
        }
    }
}
