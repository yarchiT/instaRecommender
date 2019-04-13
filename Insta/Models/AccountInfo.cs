using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Insta.Models
{
    public class AccountInfo
    {
        public int ID { get; set; }
        public string Username {get;set;}
        public string Bio { get; set; }
        public int TotalMediaCount { get; set; }
        public int ParsedPostCount { get; set; }

        public List<Post> Posts {get;set;}
    }
}
