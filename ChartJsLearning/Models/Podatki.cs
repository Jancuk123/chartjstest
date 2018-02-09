using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChartJsLearning.Models
{
    public class Podatki
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public decimal Temperatura { get; set; }
        public decimal Vlaga { get; set; }
    }
}