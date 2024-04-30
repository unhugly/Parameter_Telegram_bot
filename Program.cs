using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Polling;

namespace TelegramBot_for_parameter
{
    class Program
    {
        private static readonly string BotToken = Environment.GetEnvironmentVariable("TELEGRAM_BERTILLON_BOT_TOKEN");

        static void Main(string[] args) => BotStarter.StartBot(new TelegramBotClient(BotToken));
    }
}
