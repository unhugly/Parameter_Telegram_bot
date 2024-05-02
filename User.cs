using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot_for_parameter
{
    enum Genre { Male, Female }
    internal class User
    {
        public string ID { get; }
        public Genre Genre { get; set; }
        public Optional<Parameter> Params { get; set; }
    }
}
