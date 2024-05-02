using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot_for_parameter
{
    internal static class SizeRecommenderFactory
    {
        public static ISizeRecommender CreateRecommender(string category, string filePath)
        {
            switch (category)
            {
                case "MenTopWear":
                    return new MenTopWearSizeRecommender("../../Men_TopWear_SizeChart.json");
                case "WomenTopWear":
                    return new WomenTopWearSizeRecommender("../../Women_TopClothes_SizeChart.json");
                // Добавьте другие категории и соответствующие конструкторы
                default:
                    throw new ArgumentException("Unknown category");
            }
        }
    }
}
