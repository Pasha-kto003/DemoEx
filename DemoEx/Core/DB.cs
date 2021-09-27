using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEx.Core
{
    public class DB
    {
        public static Some_DbEntities Some_DbEntities;
        public static Some_DbEntities GetDB()
        {
            if(Some_DbEntities == null)
            {
                Some_DbEntities = new Some_DbEntities();
            }
            return Some_DbEntities;

        }
    }
}
