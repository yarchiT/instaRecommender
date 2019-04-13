using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Insta.Models
{
    public class Post
    {
        public int ID { get; set; }
        public string PhotoUrl { get; set; }
        public string Caption { get; set; }
        public int LocationId {get;set;}
        public string LocationName {get; set;}
        public string LocationCountry { get; set;}

        public AccountInfo AccountInfo {get;set;}
    }
}
