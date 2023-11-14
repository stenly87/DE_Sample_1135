using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Столовые_приборы.Static
{
    internal class User
    {
        static Столовые_приборы.DB.User logged = new();

        public static Столовые_приборы.DB.User Logged
        {
            get => logged;
            set
            {
                logged = value;
                LoggedChanged?.Invoke(null, value);
            }
        }

        public static event EventHandler<Столовые_приборы.DB.User> LoggedChanged;
    }
}
