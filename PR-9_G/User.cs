using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace PR_9_G
{
    [Table(Name = "Users")]
    class User
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, Name = "user_id")]
        public int user_id { get; set; }
        [Column(Name = "username")]
        public string user_name { get; set; }
        [Column(Name = "password")]
        public string password { get; set; }
        [Column(Name = "creater")]
        public DateTime creater { get; set; }
        [Column(Name = "phone")]
        public Int64 phone { get; set; }
        [Column(Name = "email")]
        public string email { get; set; }
        [Column(Name = "first_name")]
        public string first_name { get; set; }
        [Column(Name = "last_name")]
        public string last_name { get; set; }
    }
}
