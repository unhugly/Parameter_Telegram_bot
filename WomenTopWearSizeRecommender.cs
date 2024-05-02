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
    internal class WomenTopWearSizeRecommender : ISizeRecommender
    {
        private static List<SizeEntry> sizes;

        public WomenTopWearSizeRecommender(string path)
        {
            sizes = FromJSON(path);
        }

        public string RecommendSize(int chest, int waist, int hip, int sleeveLength)
        {
            SizeEntry closest = null;
            double closestDiff = double.MaxValue;

            foreach (var size in sizes)
            {
                double chestDiff = Math.Abs(size.Chest - chest);
                double waistDiff = Math.Abs(size.Waist - waist);
                double hipDiff = Math.Abs(size.Hip - hip);
                double sleeveDiff = CalculateSleeveDifference(size.SleeveLength, sleeveLength);

                double totalDiff = chestDiff + waistDiff + hipDiff + sleeveDiff;

                if (totalDiff < closestDiff)
                {
                    closestDiff = totalDiff;
                    closest = size;
                }
            }

            return closest != null ? $"{closest.RussianSize} / {closest.InternationalSize}" : "No suitable size found";
        }

        private double CalculateSleeveDifference(string sizeSleeveLength, int inputSleeveLength)
        {
            var sizeSleeves = sizeSleeveLength.Split('/');
            double minDiff = double.MaxValue;

            foreach (var sleeve in sizeSleeves)
            {
                double diff = Math.Abs(double.Parse(sleeve) - inputSleeveLength);
                if (diff < minDiff)
                {
                    minDiff = diff;
                }
            }

            return minDiff;
        }

        public List<SizeEntry> FromJSON(string filePath)
        {
            using (StreamReader file = File.OpenText(filePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                return (List<SizeEntry>)serializer.Deserialize(file, typeof(List<SizeEntry>));
            }
        }
    }
}
