using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot_for_parameter
{
    enum Genre { Male, Female }
    internal class ClientSideUser
    {
        public string ID { get; }
        public Genre Genre { get; set; }

        public ClientSideUser (string iD, Genre genre)
        {
            ID = iD;
            Genre = genre;
        }
    }
}
