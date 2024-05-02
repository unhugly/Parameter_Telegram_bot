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
        public Action<long> OnComplete; // Делегат для сброса команды в обработчике

        public TopWearFindOutCommand(ITelegramBotClient botClient) : base(botClient) { }

        public override async Task ExecuteAsync(long chatId)
        {
            await _client.SendTextMessageAsync(chatId, "Введите обхват груди, талии, бёдер, длину рукавов");
            State = CommandState.AwaitingInput;
        }

        public override async Task<bool> ContinueExecuteAsync(string message, long chatId)
        {
            if (State != CommandState.AwaitingInput) return false;

            var inputs = message.Split(' ');
            if (inputs.Length != 4)
            {
                await _client.SendTextMessageAsync(chatId, "Пожалуйста, введите ровно четыре числа.");
                return true;
            }

            try
            {
                int chest = int.Parse(inputs[0]);
                int waist = int.Parse(inputs[1]);
                int hip = int.Parse(inputs[2]);
                int sleeveLength = int.Parse(inputs[3]);

                ISizeRecommender recommender = new WomenTopWearSizeRecommender("../Women_TopWear_SizeChart.json");
                var recommendedSize = recommender.RecommendSize(chest, waist, hip, sleeveLength);

                await _client.SendTextMessageAsync(chatId, $"Рекомендуемый размер: {recommendedSize}");
                //OnComplete?.Invoke(chatId); // Уведомляем обработчик о завершении
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
