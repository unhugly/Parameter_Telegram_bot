using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace TelegramBot_for_parameter.Commands
{
    internal abstract class Command
    {
        protected readonly ITelegramBotClient _client;

        public Command(ITelegramBotClient botClient) {
            _client = botClient;
        }
    }
}
