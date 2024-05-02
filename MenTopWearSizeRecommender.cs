using System.Collections.Generic;

namespace TelegramBot_for_parameter
{
    internal class MenTopWearSizeRecommender : ISizeRecommender
    {
        private static List<SizeEntry> sizes;

        public MenTopWearSizeRecommender(string path) {
            sizes = FromJSON(path);
        }

        public string RecommendSize(int chest, int waist, int hip, int sleeveLength)
        {
            throw new System.NotImplementedException();
        }
        public List<SizeEntry> FromJSON(string filePath)
        {
            throw new System.NotImplementedException();
        }
    }
}