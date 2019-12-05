using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Truextend.Models
{
    public class User
    {
        public int? id { get; set; }
        public string avatar_url { get; set; }
        public string name { get; set; }
        public string nickName { get; set; }
        public string github_url { get; set; }
    }
}
