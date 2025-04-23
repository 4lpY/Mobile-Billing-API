using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Models
{
    public class Subscriber
    {
        public int Id { get; set; }
        public int SubscriberId { get; set; }
        public string Fullname { get; set; }

        public List<Usage> Usages { get; set; }
        public List<Bill> Bills { get; set; }
    }
}