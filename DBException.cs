﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Well_Choosen.Classes
{[Serializable]
   internal class DBException:Exception
    {
        public DBException(string message,Exception ex):base(message,ex)
        {

        }
    }
}
