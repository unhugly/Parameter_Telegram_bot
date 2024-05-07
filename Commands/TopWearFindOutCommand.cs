using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using TelegramBot_for_parameter.Commands;
using TeleSharp.TL.Updates;

namespace TelegramBot_for_parameter
{
    internal class TopWearFindOutCommand : Command, ICommand
    {
        public TopWearFindOutCommand(ITelegramBotClient botClient) : base(botClient) { }

        public override async Task ExecuteAsync(long chatId)
        {
            await _client.SendTextMessageAsync(chatId, "Введите обхват груди, талии, бёдер\nПример: 90 60 90");
            State = CommandState.AwaitingInput;
        }

        public override async Task<bool> ContinueExecuteAsync(string message, long chatId)
        {
            if (State != CommandState.AwaitingInput) return false;

            var inputs = message.Split(' ');
            if (inputs.Length != 3)
            {
                await _client.SendTextMessageAsync(chatId, "Пожалуйста, введите ровно три числа.");
                return true;
            }

            try
            {
                int chest = int.Parse(inputs[0]);
                int waist = int.Parse(inputs[1]);
                int hip = int.Parse(inputs[2]);

                await _client.SendTextMessageAsync(chatId, $"Рекомендуемый размер: {WomenTopWearSizeRecommender.RecommendSize(chest, waist, hip)}");
                Reset();
                return false;
            }
            catch (FormatException)
            {
                await _client.SendTextMessageAsync(chatId, "Пожалуйста, убедитесь, что вводите только числа.");
                return true;
            }
            catch (Exception ex)
            {
                await _client.SendTextMessageAsync(chatId, $"Произошла ошибка при обработке вашего запроса. {ex.Message}");
                return false;
            }
        }
    }

}
