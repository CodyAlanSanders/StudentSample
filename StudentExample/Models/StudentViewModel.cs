using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentExample.Models
{
    public class StudentViewModel
    {
        public List<String> States { get; set; }
        public Student Student {get;set;}
    }
}