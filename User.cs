using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot_for_parameter
{
    internal class User
    {
        public string Name { get; set; }
        public string Genre { get; set; }
        public string ID { get; }
        public Parameter Params { get; set; }
        public Config Config { get; set; }
    }
}
