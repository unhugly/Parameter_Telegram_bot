using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot.Polling;
using Telegram.Bot;

namespace TelegramBot_for_parameter
{
    internal class BotStarter
    {
        public static void StartBot(TelegramBotClient client)
        {
            var messageHandler = new TelegramMessageHandler(client);
            var receiverOptions = new ReceiverOptions { AllowedUpdates = { } };

            using (var cts = new CancellationTokenSource())
            {
                client.StartReceiving(
                    messageHandler.HandleUpdateAsync,
                    messageHandler.HandleErrorAsync,
                    receiverOptions,
                    cts.Token
                );

                Console.WriteLine($"Бот запущен");
                Console.ReadKey();
                cts.Cancel();
            }
        }
    }
}
