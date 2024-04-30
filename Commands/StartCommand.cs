using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace TelegramBot_for_parameter
{
    internal class StartCommand : Commands.Command, ICommand
    {
        public StartCommand(ITelegramBotClient botClient) : base(botClient) { }

        public async Task ExecuteAsync(long chatId)
        {
            string welcomeMessage = "Добро пожаловать! Пользуясь ботом, вы подтверждаете свое согласие на обработку персональных данных и предоставление их третьим лицам. Выберите команду /help для вызова списка доступных команд.";
            await _client.SendTextMessageAsync(chatId, welcomeMessage);
        }
    }
}
