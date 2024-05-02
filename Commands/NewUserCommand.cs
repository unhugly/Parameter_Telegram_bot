using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace TelegramBot_for_parameter
{
    internal class NewUserCommand : Commands.Command, ICommand
    {
        public NewUserCommand(ITelegramBotClient botClient) : base(botClient) { }

        public async Task ExecuteAsync(long chatId)
        {
            await _client.SendTextMessageAsync(chatId, "Введите обхват груди, талии, бёдер, длину рукавов");
            // Допустим, этот метод вызывается в ответ на следующее сообщение пользователя
            var userInput = "90 70 95 60"; // Предположим, что это ввод пользователя

            // Разделяем введенную строку на компоненты
            var inputs = userInput.Split(' ');
            if (inputs.Length != 4)
            {
                await _client.SendTextMessageAsync(chatId, "Пожалуйста, введите ровно четыре числа.");
                return;
            }

            try
            {
                // Парсим введенные числа
                int chest = int.Parse(inputs[0]);
                int waist = int.Parse(inputs[1]);
                int hip = int.Parse(inputs[2]);
                int sleeveLength = int.Parse(inputs[3]);

                // Вызываем метод для рекомендации размера
                ISizeRecommender recommender = new WomenTopWearSizeRecommender("../Women_TopWear_SizeChart.json");
                var recommendedSize = recommender.RecommendSize(chest, waist, hip, sleeveLength);

                await _client.SendTextMessageAsync(chatId, $"Рекомендуемый размер: {recommendedSize}");
            }
            catch (FormatException)
            {
                await _client.SendTextMessageAsync(chatId, "Пожалуйста, убедитесь, что вводите только числа.");
            }
            catch (Exception ex)
            {
                await _client.SendTextMessageAsync(chatId, $"Произошла ошибка при обработке вашего запроса. {ex.Message}");
            }
        }
    }
}
