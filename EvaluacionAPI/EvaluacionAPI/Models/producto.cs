using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvaluacionAPI.Models
{
    public class producto
    {
        public int id_product {  get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string category { get; set; }
    }
}