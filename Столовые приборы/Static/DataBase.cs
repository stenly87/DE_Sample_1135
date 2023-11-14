using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Столовые_приборы.DB;

namespace Столовые_приборы.Static
{
    internal class DataBase
    {
        static User21Context db;

        public static User21Context Instance()
        { 
            if (db == null)
                db = new User21Context();
            return db;
        }
    }
}
