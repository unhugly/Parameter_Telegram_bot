using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot_for_parameter
{
    internal class WomenTopWearSizeRecommender
    {
        private static readonly List<SizeEntry> sizes = FromJSON("../Women_TopWear_SizeChart.json");

        public WomenTopWearSizeRecommender() { }

        public static string RecommendSize(int chest, int waist, int hip)
        {
            SizeEntry closest = null;
            double closestDiff = double.MaxValue;

            foreach (var size in sizes)
            {
                double chestDiff = Math.Abs(size.Chest - chest);
                double waistDiff = Math.Abs(size.Waist - waist);
                double hipDiff = Math.Abs(size.Hip - hip);

                double totalDiff = chestDiff + waistDiff + hipDiff;

                if (totalDiff < closestDiff)
                {
                    closestDiff = totalDiff;
                    closest = size;
                }
            }

            return closest != null ? $"{closest.RussianSize} / {closest.InternationalSize}" : "No suitable size found";
        }

        public static List<SizeEntry> FromJSON(string filePath)
        {
            using (StreamReader file = File.OpenText(filePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                return (List<SizeEntry>)serializer.Deserialize(file, typeof(List<SizeEntry>));
            }
        }
    }
}
