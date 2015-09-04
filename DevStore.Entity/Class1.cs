using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevStore.Entity
{
    public class Developer
    {

        public string UrlAvatar { get; set; }

        public string User { get; set; }

        public int TotalRepo { get; set; }

        public int TotalFollowers { get; set; }

        public decimal Price { get; set; }
    }
}
