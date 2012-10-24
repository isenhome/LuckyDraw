using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LuckyDraw.Exceptions
{
    public class ADOException:Exception
    {
        public ADOException()
        { 
            
        }

        public string msg { get; set; }
    }
}
