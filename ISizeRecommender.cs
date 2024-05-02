using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot_for_parameter
{
    internal interface ISizeRecommender
    {
        List<SizeEntry> FromJSON(string filePath);
        string RecommendSize(int chest, int waist, int hip, int sleeveLength);
    }
}
