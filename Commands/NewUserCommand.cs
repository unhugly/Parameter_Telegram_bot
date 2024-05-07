using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace TelegramBot_for_parameter.Commands
{
    internal class NewUserCommand : Command, ICommand
    {
        public NewUserCommand(ITelegramBotClient botClient) : base(botClient) { }

        public override Task<bool> ContinueExecuteAsync(string message, long chatId)
        {
            throw new NotImplementedException();
        }

        public override async Task ExecuteAsync(long chatId)
        {
            await _client.SendTextMessageAsync(chatId, "Какую таблицу размеров одежды будем использовать - женскую или мужскую ?");
            State = CommandState.AwaitingInput;
        }
    }
}
