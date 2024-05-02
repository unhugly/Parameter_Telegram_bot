using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using TelegramBot_for_parameter.Commands;

namespace TelegramBot_for_parameter
{
    internal class UnknownCommand : Command, ICommand
    {
        public UnknownCommand(ITelegramBotClient botClient) : base(botClient) { }

        public override async Task<bool> ContinueExecuteAsync(string message, long chatId)
        {
            await Task.CompletedTask;
            return false;
        }

        public override async Task ExecuteAsync(long chatId)
        {
            await _client.SendTextMessageAsync(chatId, "Неизвестная команда, выберите команду /help для вызова списка доступных команд");
        }
    }
}
