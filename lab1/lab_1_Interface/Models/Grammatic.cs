using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab_1_Interface.Models
{
    public class Grammatic
    {
        public List<string> VT { get; set; }
        public List<string> VN { get; set; }
        public string S { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        public List<Regular> Regulation { get; set; }
        public string lamb { get; set; }
    }
}
