using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using TelegramBot_for_parameter.Commands;

namespace TelegramBot_for_parameter
{
    internal class HelpCommand : Command, ICommand
    {
        public HelpCommand(ITelegramBotClient botClient) : base(botClient) { }

        public override async Task<bool> ContinueExecuteAsync(string message, long chatId)
        {
            await Task.CompletedTask;
            return false;
        }

        public override async Task ExecuteAsync(long chatId)
        {
            string helpMessage = "Список доступных команд:\n/help - список команд\n";
            await _client.SendTextMessageAsync(chatId, helpMessage);
        }
    }


}
