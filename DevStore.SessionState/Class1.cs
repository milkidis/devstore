using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevStore.SessionState
{
    public static class SessionStateManager<T>
    {

        public static string AddItem(T item)
        {
            return "";
        }


        public static T Get(string token)
        {
            throw new NotImplementedException();
        }


        public static void Remove(T item)
        {

        }
    }
}
