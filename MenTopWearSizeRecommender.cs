using System.Collections.Generic;

namespace TelegramBot_for_parameter
{
    internal class MenTopWearSizeRecommender
    {
        private readonly static List<SizeEntry> sizes = FromJSON("../Men_TopWear_SizeChart.json");

        public MenTopWearSizeRecommender() { }

        public static string RecommendSize(int chest, int waist, int hip)
        {
            throw new System.NotImplementedException();
        }
        public static List<SizeEntry> FromJSON(string filePath)
        {
            throw new System.NotImplementedException();
        }
    }
}