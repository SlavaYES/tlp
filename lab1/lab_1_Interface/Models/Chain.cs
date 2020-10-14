using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab_1_Interface.Models
{
    public class Chain : ICloneable
    {
        public string Str { get; set; } = "";
        public string End { get; set; }
        public int Count => Str.Length;

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
